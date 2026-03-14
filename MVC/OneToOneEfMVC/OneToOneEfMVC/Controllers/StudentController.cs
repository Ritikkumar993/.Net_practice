using Microsoft.AspNetCore.Mvc;
using OneToOneEfMVC.Models;
using OneToOneEfMVC.Services;

namespace OneToOneEfMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentServices _service;

        public StudentController(StudentServices service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAllStudents());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, string roomNumber)
        {
            student.AssignedRoom = new HostelRoom
            {
                RoomNumber = roomNumber
            };

            _service.AddStudent(student);

            return RedirectToAction("Index");
        }
        
    }
}
