using CollageSystem.Models.ViewModels;
using CollageSystem.Repositories;
using CollageSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollageSystem.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IAdminRepository _adminRepo;

        public AdminController(IStudentService studentService, IAdminRepository adminRepo)
        {
            _studentService = studentService;
            _adminRepo = adminRepo;
        }

        // GET: /admin/login
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View(new AdminLoginViewModel());
        }

        // POST: /admin/login
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var admin = await _adminRepo.GetByCredentialsAsync(model.Username, model.Password);

            if (admin == null)
            {
                ModelState.AddModelError("", "Invalid admin credentials.");
                return View(model);
            }

            HttpContext.Session.SetString("AdminUsername", admin.Username);
            HttpContext.Session.SetString("UserRole", "Admin");

            return RedirectToAction("Dashboard");
        }

        // GET: /admin/dashboard
        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login");
            }

            var pendingStudents = await _studentService.GetPendingStudentsAsync();
            var allStudents = await _studentService.GetAllStudentsAsync();

            ViewBag.AllStudents = allStudents;
            return View(pendingStudents);
        }

        // POST: /admin/approve/{id}
        [HttpPost("approve/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login");
            }

            var result = await _studentService.ApproveAsync(id);
            TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;

            return RedirectToAction("Dashboard");
        }

        // POST: /admin/reject/{id}
        [HttpPost("reject/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login");
            }

            var result = await _studentService.RejectAsync(id);
            TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;

            return RedirectToAction("Dashboard");
        }

        // GET: /admin/logout
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
