using ProductShop.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class Product
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string image { get; set; }

        [Required]
        public float price { get; set; }

        public int count { get; set; }

        public TypePrice typePrice { get; set; }

        public int? discountAmount { get; set; }

        public DateTime? discount_expire_at { get; set; }
             
        public List<Feature>? feature { get;  set; }
           
        public List<Additive>? additive { get; set; }

        



    }
}
