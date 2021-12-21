using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tshop.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Size")]
        public string ProductSize { get; set; }
    }
}
