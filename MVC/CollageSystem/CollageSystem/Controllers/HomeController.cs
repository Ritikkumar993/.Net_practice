using Microsoft.AspNetCore.Mvc;

namespace CollageSystem.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        [HttpGet("home")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
