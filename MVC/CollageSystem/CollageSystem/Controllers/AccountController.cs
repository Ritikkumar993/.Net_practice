using CollageSystem.Models.ViewModels;
using CollageSystem.Repositories;
using CollageSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollageSystem.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDegreeRepository _degreeRepo;

        public AccountController(IStudentService studentService, IDegreeRepository degreeRepo)
        {
            _studentService = studentService;
            _degreeRepo = degreeRepo;
        }

        // GET: /account/register
        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            var degrees = await _degreeRepo.GetAllAsync();
            var model = new RegisterViewModel
            {
                Degrees = degrees.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.Name} ({d.Code})"
                }).ToList()
            };
            return View(model);
        }

        // POST: /account/register
        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var degrees = await _degreeRepo.GetAllAsync();
                model.Degrees = degrees.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.Name} ({d.Code})"
                }).ToList();
                return View(model);
            }

            var result = await _studentService.RegisterAsync(model);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                var degrees = await _degreeRepo.GetAllAsync();
                model.Degrees = degrees.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.Name} ({d.Code})"
                }).ToList();
                return View(model);
            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction("RegistrationSuccess");
        }

        // GET: /account/registration-success
        [HttpGet("registration-success")]
        public IActionResult RegistrationSuccess()
        {
            return View();
        }

        // GET: /account/login
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: /account/login
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var student = await _studentService.LoginAsync(model);

            if (student == null)
            {
                ModelState.AddModelError("", "Invalid registration number or password.");
                return View(model);
            }

            // Store student session
            HttpContext.Session.SetInt32("StudentId", student.Id);
            HttpContext.Session.SetString("StudentName", $"{student.FirstName} {student.LastName}");
            HttpContext.Session.SetString("RegistrationNumber", student.RegistrationNumber!);
            HttpContext.Session.SetString("UserRole", "Student");

            return RedirectToAction("Dashboard", "Student");
        }

        // GET: /account/logout
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
