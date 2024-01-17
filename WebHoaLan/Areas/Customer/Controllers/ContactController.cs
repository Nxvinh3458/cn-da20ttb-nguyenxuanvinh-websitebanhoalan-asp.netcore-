using Microsoft.AspNetCore.Mvc;
using WebHoaLan.Models;

namespace WebHoaLan.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
