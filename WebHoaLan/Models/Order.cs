using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebHoaLan.Models
{
    public class Order
    {

        public Order()
        {
            OrderDetails=new List<OrderDetails>();
        }
        public int OrderId { get; set; }
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderDay => OrderDate.Day;
        public int OrderWeek => (int)OrderDate.DayOfWeek;
        public int OrderMonth => OrderDate.Month; // Lấy thông tin tháng
        public int OrderYear => OrderDate.Year; // Lấy thông tin năm
        public virtual List<OrderDetails> OrderDetails { get; set; }
        public int TotalOrders { get; set; }
    }

}
