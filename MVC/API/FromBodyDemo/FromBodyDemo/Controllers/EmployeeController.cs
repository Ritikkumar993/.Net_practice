using FromBodyDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FromBodyDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase    
    {
        private static List<Employee> _employees = new();

        [HttpPost("addemp")]
        public IActionResult AddEmployee([FromBody] List<Employee> employees)
        {
            _employees.AddRange(employees);
            return Ok("Employees added successfully");
        }

        [HttpGet("Employees")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employees);
        }

        [HttpGet("TotalSalary")]
        public IActionResult GetTotalSalaryofAll()
        {
            int res = _employees.Sum(e => e.Salary);
            return Ok($"Total Salary is {res}");
        }
    }
}
