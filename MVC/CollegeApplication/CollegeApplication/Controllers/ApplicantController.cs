using CollegeApplication.Data;
using CollegeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CollegeApplication.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly ApplicantRepository _repo;

        public ApplicantController(IConfiguration config)
        {
            string connString = config.GetConnectionString("DefaultConnection");
            _repo = new ApplicantRepository(connString);
        }

        public IActionResult Index()
        {
            var applicants = _repo.GetAllApplicants();
            return View(applicants);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            if (_repo.isEmailExists(applicant.Email, applicant.RegistrationNo))
            {
                ModelState.AddModelError("Email", "Email already exists.");
            }
            // 🔥 Image Validation
            if (applicant.PhotoFile != null)
            {
                // Size limit 2MB
                if (applicant.PhotoFile.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("PhotoFile", "File must be less than 2MB.");
                }

                // Allowed extensions
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(applicant.PhotoFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("PhotoFile", "Only JPG and PNG allowed.");
                }

                // MIME type check
                var allowedMime = new[] { "image/jpeg", "image/png" };
                if (!allowedMime.Contains(applicant.PhotoFile.ContentType))
                {
                    ModelState.AddModelError("PhotoFile", "Invalid image format.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int newRegNo = _repo.AddApplicant(applicant);
                    TempData["SuccessMessage"] =
                        $"Application submitted successfully! Your Registration Number is: {newRegNo}";
                    return RedirectToAction("Index");
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    ModelState.AddModelError("Email", "Email already exists.");
                }
            }
            return View(applicant);
        }

        public IActionResult Edit(int id) // 'id' matches standard MVC routing, but maps to RegNo
        {
            var applicant = _repo.GetApplicantById(id);
            if (applicant.RegistrationNo == 0) return NotFound();
            return View(applicant);
        }

        [HttpPost]
        public IActionResult Edit(Applicant applicant)
        {
            if (_repo.isEmailExists(applicant.Email, applicant.RegistrationNo))
            {
                ModelState.AddModelError("Email", "Email already exists.");
            }

            if (ModelState.IsValid)
            {
                _repo.UpdateApplicant(applicant);
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        public IActionResult Delete(int id)
        {
            var applicant = _repo.GetApplicantById(id);
            if (applicant.RegistrationNo == 0) return NotFound();
            return View(applicant);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteApplicant(id);
            return RedirectToAction("Index");
        }
    }
}
