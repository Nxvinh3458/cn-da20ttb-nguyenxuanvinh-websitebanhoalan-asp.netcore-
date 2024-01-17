using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoaLan.Models
{
    public class ProductTypes
    {
        public int ProductTypesId { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public string ProductType { get; set; }

    }
}
