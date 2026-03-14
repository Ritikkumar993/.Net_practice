using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TotalEmployees = EmployeeRepo.GetAll().Count;
            ViewBag.NewThisMonth = EmployeeRepo.GetNewThisMonth();
            ViewBag.DepartmentCounts = EmployeeRepo.GetDepartmentCounts();
            ViewBag.EmploymentTypeCounts = EmployeeRepo.GetEmploymentTypeCounts();
            ViewBag.RecentJoiners = EmployeeRepo.GetAll()
                .OrderByDescending(e => e.DateOfJoining).Take(5).ToList();
            ViewBag.ActiveCount = EmployeeRepo.GetAll().Count(e => e.IsActive);
            var all = EmployeeRepo.GetAll();
            ViewBag.FullTimeCount = all.Count(e => e.EmploymentType == "Full-Time");
            ViewBag.ContractCount = all.Count(e => e.EmploymentType == "Contract");
            ViewBag.InternCount = all.Count(e => e.EmploymentType == "Intern");
            ViewBag.PartTimeCount = all.Count(e => e.EmploymentType == "Part-Time");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}
