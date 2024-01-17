using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHoaLan.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Order")]
        public int OrderId { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Products Product { get; set; }

    }
}
