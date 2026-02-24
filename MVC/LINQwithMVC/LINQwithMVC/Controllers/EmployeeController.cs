using LINQwithMVC.Data;
using LINQwithMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LINQwithMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepo _repo;

        public EmployeeController(EmployeeRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            Dictionary<string , List<Employee>> employees = _repo.GetFilteredEmployees().Where(x => x.Salary>50000).GroupBy(e => e.Department).ToDictionary(g => g.Key, g=> g.ToList());
            return View(employees);
        }
    }
}
