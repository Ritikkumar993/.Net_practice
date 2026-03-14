using CollageSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollageSystem.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: /student/dashboard
        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            if (HttpContext.Session.GetString("UserRole") != "Student")
            {
                return RedirectToAction("Login", "Account");
            }

            int? studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var student = await _studentService.GetStudentByIdAsync(studentId.Value);
            if (student == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(student);
        }
    }
}
