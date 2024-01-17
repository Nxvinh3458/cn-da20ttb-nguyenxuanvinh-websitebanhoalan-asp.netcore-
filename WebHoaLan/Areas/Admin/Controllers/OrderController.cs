using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebHoaLan.Data;
using WebHoaLan.Models;

namespace WebHoaLan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }

        private int GetTotalOrdersForDate(DateTime selectedDate)
        {
            // Thực hiện truy vấn cơ sở dữ liệu để lấy số lượng đơn hàng cho ngày đã chọn
            var totalOrders = _db.Orders.Count(o => o.OrderDate.Date == selectedDate.Date);
            return totalOrders;
        }

        [HttpGet]
        public IActionResult GetOrdersByDate(string selectedDate)
        {
            if (DateTime.TryParse(selectedDate, out var date))
            {
                int totalOrders = GetTotalOrdersForDate(date);
                return PartialView("_OrderStatisticsPartial", totalOrders);
            }

            return BadRequest("Invalid date format.");
        }
        [HttpPost]
        public IActionResult GetOrderStatistics(DateTime startDate, DateTime endDate)
        {
            var orders = _db.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .ToList();

            var statistics = orders.GroupBy(o => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(o.OrderDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                .Select(g => new
                {
                    WeekNumber = g.Key,
                    NumberOfOrders = g.Count()
                })
                .OrderBy(g => g.WeekNumber)
                .ToList();

            return Json(statistics);
        }
        public IActionResult OrderByMonth()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetOrderStatisticsByMonth(DateTime startDate, DateTime endDate)
        {
            var orders = _db.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .ToList();

            var statistics = orders.GroupBy(o => new { Year = o.OrderDate.Year, Month = o.OrderDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    NumberOfOrders = g.Count()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();

            return Json(statistics);
        }
        public IActionResult OrderByYear()
        {
            var distinctYears = _db.Orders
                .Select(o => o.OrderDate.Year)
                .Distinct()
                .OrderByDescending(year => year)
                .ToList();

            ViewBag.Years = new SelectList(distinctYears);

            return View();
        }
        [HttpPost]
        public IActionResult GetOrderStatisticsByYear(int selectedYear)
        {
            var orders = _db.Orders
                .Where(o => o.OrderDate.Year == selectedYear)
                .ToList();

            var statistics = orders.GroupBy(o => new { Year = o.OrderDate.Year, Month = o.OrderDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    NumberOfOrders = g.Count()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();

            return Json(statistics);
        }
    }
}
