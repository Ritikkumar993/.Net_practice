using Microsoft.AspNetCore.Mvc;
using MvcBasics.Models;
using System.Diagnostics;

namespace MvcBasics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Student()
        {
            var s = new { Name = "Ritik", Marks = 90 };
            return Json(s);
        }

        public IActionResult Square(int? number)
        {
            if (number == null)
                return Content("Please provide number");
            return View(number.Value);
        }

       

        public IActionResult Time()
        {
            return Content(DateTime.Now.ToString());
        }

        public IActionResult Welcome()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
