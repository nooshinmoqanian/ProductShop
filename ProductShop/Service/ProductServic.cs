using ProductShop.DBContext;
using ProductShop.Dto;
using ProductShop.Enums;
using ProductShop.Interface;
using ProductShop.Models;

namespace ProductShop.Service
{
    public class ProductServic : IProduct
    {
        private readonly ProductContext _productContext;

        private readonly IConfiguration _configuration;

        public ProductServic(ProductContext productContext, IConfiguration Configuration)
        {
            _productContext = productContext;

            _configuration = Configuration;

          
        }

        #region Product
        
        public bool createProduct(ProductDto product,IFormFile file)
        {
           ///Insert Dto
            ProductDto productDto = new ProductDto()
            {
                name = product.name,
                price = product.price,
                typePrice = product.typePrice,
                discountAmount = product.discountAmount,
                discount_expire_at = product.discount_expire_at,
                additive = product.additive,
                feature = product.feature,
                count = product.count,
                count_all = product.count_all - product.count
            };

            if (product.count <= 0)
            {
                return false;
            }

           // getting file original name
            string FileName = file.FileName;

            // combining GUID to create unique name before saving in wwwroot
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;

            // getting full path inside wwwroot/images
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "images/", FileName);

            // copying file
            file.CopyTo(new FileStream(imagePath, FileMode.Create));


            ///insert product
            Product Product = new Product()
            {
                name = productDto.name,
                image = FileName,
                price = productDto.price,
                typePrice = productDto.typePrice,
                discountAmount = productDto.discountAmount,
                discount_expire_at = productDto.discount_expire_at,
                count = productDto.count_all
            };
            _productContext.product.Add(Product);
            _productContext.SaveChanges();


            ///insert feature
            foreach (var itemfeature in product.feature)
            {
                Feature feature = new Feature()
                {
                    IdProduct = Product.Id,
                    Name = itemfeature.Name,
                    Price = itemfeature.Price
                };
                _productContext.features.Add(feature);
            }

            ///insert additive
            foreach (var itemadditive in product.additive)
            {
                Additive additive = new Additive()
                {
                    Name = itemadditive.Name,
                    Price = itemadditive.Price,
                };
                _productContext.additives.Add(additive);
            }
           var resultSave = _productContext.SaveChanges();

            if(resultSave == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            }
        #endregion

        #region TypePrice

        public float discountAmount(float finallPrice, DateTime dateExpire, float dicsount)
        {
            if (dicsount != 0 && DateTime.Now >= dateExpire)
            {
                return finallPrice -= (float)dicsount;
                
            }
            return 0;
        }

        public float typePrice(float? priceStatic, float dollar, float priceFeature, float priceAdditive, TypePrice typeprice)
        {
            if (typeprice == TypePrice.CONSTANT)
            {
                float finallyPrice = (float)(priceStatic + priceAdditive + priceFeature);
                return finallyPrice;
            }
            else
            {
                float finallyPrice = (float.Parse("1.5") * dollar) + priceFeature + priceAdditive;
                return finallyPrice;
            }

            return 0;
        }
        #endregion
    }
}
