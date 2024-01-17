using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebHoaLan.Data;

namespace WebHoaLan.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }
        [HttpPost]
        public IActionResult Search(string productName)
        {
            var searchResults = _db.Products
                .Where(p => p.ProductsName.Contains(productName))
                .ToList();

            return View("SearchResults", searchResults);
        }
    }
}
