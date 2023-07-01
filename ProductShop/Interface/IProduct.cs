using ProductShop.Dto;
using ProductShop.Enums;

namespace ProductShop.Interface
{
    public interface IProduct
    {
        public bool createProduct(ProductDto product, IFormFile file);

        public float typePrice(float? priceStatic, float dollar, float priceFeature, float priceAdditive, TypePrice typeprice);

        public float discountAmount(float finallPrice, DateTime dateExpaier, float dicsount);
    }
}
