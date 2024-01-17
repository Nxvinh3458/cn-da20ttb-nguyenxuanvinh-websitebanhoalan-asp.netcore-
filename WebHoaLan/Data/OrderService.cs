using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebHoaLan.Models;

namespace WebHoaLan.Data
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalOrders()
        {
            return await _context.Orders.CountAsync();
        }
    }


}
