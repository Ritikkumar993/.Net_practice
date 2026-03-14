using Microsoft.AspNetCore.Mvc;
using MvcBasics.Data;

namespace MvcBasics.Controllers
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
            var students = _repo.GetAllStudents();
            return View(students);
        }

       

        public IActionResult Student(int m1,int m2,int m3)
        {
            int x = m1 + m2 + m3;
            return View(x);
        }



    }
}
