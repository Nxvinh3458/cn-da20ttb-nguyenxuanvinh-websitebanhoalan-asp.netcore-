using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHoaLan.Models
{
    public class Products
    {
        public int ProductsId { get; set; }
        [Required]
        public string ProductsName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        public string Image { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Product Type")]
        [Required]
        public int ProductTypesId { get; set; }
        [ForeignKey("ProductTypesId")]
        public virtual ProductTypes ProductTypes { get; set; }
        [Display(Name = "Special Tag")]
        [Required]
        public int SpecialTagId { get; set; }
        [ForeignKey("SpecialTagId")]
        public virtual SpecialTag SpecialTag { get; set; }
    }
}
