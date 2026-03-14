using FromBodyDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace FromBodyDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private List<Student> _students = new();
     
        [HttpPost("add")]
        public IActionResult AddStudent([FromBody] Student student)
        {

            _students.Add(student);
            string message = $"Student {student.Name} with Marks {student.Marks} added.";

            return Ok(message);
        }
    }
}
