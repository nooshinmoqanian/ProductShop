using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductShop.DBContext;
using ProductShop.Dto;
using ProductShop.Enums;
using ProductShop.Models;
using Microsoft.Extensions.Configuration;
using ProductShop.Service;
using System.Collections;
using System.Linq;
using ProductShop.Interface;

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        
        private readonly ProductContext _productContext;

        private readonly IProduct productServic;

        public ProductController(ProductContext productContext, IConfiguration Configuration, IProduct productServic)
        {
           _productContext = productContext;

           _configuration = Configuration;

            this.productServic = productServic;
        }

        [HttpGet]
        public IActionResult GetAllProduct(TypePrice? type, DateTime? expire_date)
        {
            var allProduct = _productContext.product.ToList();

            if (type != null && expire_date != null)
            {
                var sortTypeAndExpire = _productContext.product.Where(x => x.discount_expire_at == expire_date && x.typePrice == type);
                return Ok(sortTypeAndExpire);
            } 

            if (type != null)
            {
                var sortType = _productContext.product.Where(x=> x.typePrice == type);
                return Ok(sortType);
            }

            if (expire_date != null)
            {
                var sortExpire = _productContext.product.Where(x=> x.discount_expire_at == expire_date);
                return Ok(sortExpire);
            }

               return Ok(allProduct);
           
        }


        [HttpGet("feature")]
        public IActionResult GetAllfeatcher()
        {
            var feature = _productContext.features.ToList();
            return Ok(feature);

        }

        
        [HttpPost("/{productDto}")]
        public  IActionResult create([FromForm]ProductDto productDto, IFormFile file)
        {

            var created = productServic.createProduct(productDto, file);

            float priceAdditive = 0;
            float priceFeature = 0;
            float dollar = float.Parse( _configuration["Price:DOLLAR"]);
            foreach (var itemAdditive in productDto.additive)

            {
                priceAdditive = itemAdditive.Price;

            }
            foreach (var itemFeature in productDto.additive)

            {
                priceAdditive = itemFeature.Price;

            }
            if (productDto.typePrice == TypePrice.CONSTANT)
            {
                var typePrice = productServic.typePrice(productDto.price, dollar, priceFeature, priceAdditive, productDto.typePrice);

            }
            if (productDto.typePrice == TypePrice.FORMULA)
            {
                var typePrice = productServic.typePrice(productDto.price, dollar, priceFeature, priceAdditive, productDto.typePrice);

            }

            return Ok();
            
        }


    }
}