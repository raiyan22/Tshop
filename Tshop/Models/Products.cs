using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tshop.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
        [Display(Name ="Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name ="Available")]
        public bool IsAvailable { get; set; }
        
        
        [Required]
        [Display(Name ="Product Type")]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductTypes productTypes { get; set; }



    } 
}
