using ProductShop.Enums;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Dto
{
    public class ProductDto
    {

        [Required]
        public string name { get; set; }
        
        [Required]
        public float price { get; set; }

        public int count_all { get; set; }

        public int count { get; set; }
        

        [Required]
        public TypePrice typePrice { get; set; }

        public List<FeaureDto> feature { get; set; }
      
        public List<AdditiveDto> additive { get; set; }

        public int? discountAmount { get; set; }

        public DateTime? discount_expire_at { get; set; }

       

    }
}
