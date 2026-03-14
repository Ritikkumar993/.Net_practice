using Microsoft.AspNetCore.Mvc;
using SimpleEFServices.Services;

namespace SimpleEFServices.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculator;
        public CalculatorController(CalculatorService calculator)
        {
            _calculator = calculator;
        }

        public IActionResult Add()
        {
            int result = _calculator.Add(5, 3);
            return Content("Result = "+result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
