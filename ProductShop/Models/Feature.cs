using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class Feature
    {
        
       
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

         public string Name { get; set; }
         
         public int IdProduct { get; set; }

         public float Price { get; set; }

    }
}
