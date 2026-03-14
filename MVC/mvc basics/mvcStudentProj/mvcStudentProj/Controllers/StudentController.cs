using Microsoft.AspNetCore.Mvc;
using mvcStudentProj.Data;
using mvcStudentProj.Models;

namespace mvcStudentProj.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repo;
        public StudentController(StudentRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var students = _repo.GetAllStudents().Select(s => new StudentDetails{ Name=s.Name, AgeSquared = s.Age*s.Age}).ToList();

            return View(students);
        }

        public IActionResult TestError()
        {
            int a = 10;
            int b = 0;
            
            int result = a / b;

            return Content(result.ToString());
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Shared() //Shared Data BW Controller and vie
        {
            ViewBag.StudentName = "Ritik Kumar";
            ViewBag.StudentData = " this student studies in LPU ";
            
            return View();
        }
               
    }
}
