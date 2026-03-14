using Microsoft.AspNetCore.Mvc;

namespace APIVersionDemo.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class ConsoleController : Controller
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<string>
            {
            "Ritik" ,
            "Raman",
            "Aryan"
            };
            return Ok(students);
        }
    }
}
