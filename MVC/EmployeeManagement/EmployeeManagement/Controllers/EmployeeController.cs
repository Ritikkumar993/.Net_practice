using ClosedXML.Excel;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // GET: /Employee/Index
        public IActionResult Index(string? q, string? department, string? employmentType, int? joiningYear)
        {
            var employees = EmployeeRepo.Search(q, department, employmentType, joiningYear);
            ViewBag.Query = q;
            ViewBag.Department = department;
            ViewBag.EmploymentType = employmentType;
            ViewBag.JoiningYear = joiningYear;
            ViewBag.Departments = EmployeeRepo.GetDepartments();
            ViewBag.TotalCount = EmployeeRepo.GetAll().Count;
            return View(employees);
        }

        // GET: /Employee/Details/5
        public IActionResult Details(int id)
        {
            var emp = EmployeeRepo.GetById(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // GET: /Employee/Create
        public IActionResult Create()
        {
            ViewBag.Departments = EmployeeRepo.GetDepartments();
            return View();
        }

        // POST: /Employee/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee emp, IFormFile? profilePhoto, List<IFormFile>? documents)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = EmployeeRepo.GetDepartments();
                return View(emp);
            }

            var dob = emp.DateOfBirth;
            var today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (today < dob.AddYears(age)) age--;
            if (age < 18)
            {
                ModelState.AddModelError("DateOfBirth", "Employee must be at least 18 years old.");
                ViewBag.Departments = EmployeeRepo.GetDepartments();
                return View(emp);
            }

            emp.ProfilePhotoPath = await SaveFile(profilePhoto, "photos");
            emp.DocumentPaths = new List<string>();
            if (documents != null)
                foreach (var doc in documents)
                {
                    var path = await SaveFile(doc, "documents");
                    if (path != null) emp.DocumentPaths.Add(path);
                }

            EmployeeRepo.Add(emp);
            TempData["Success"] = $"Employee {emp.FullName} added successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var emp = EmployeeRepo.GetById(id);
            if (emp == null) return NotFound();
            ViewBag.Departments = EmployeeRepo.GetDepartments();
            return View(emp);
        }

        // POST: /Employee/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee emp, IFormFile? profilePhoto, List<IFormFile>? documents, string? removeDocument)
        {
            if (id != emp.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = EmployeeRepo.GetDepartments();
                return View(emp);
            }

            var existing = EmployeeRepo.GetById(id);
            if (existing == null) return NotFound();

            // Keep existing files unless replaced
            if (profilePhoto != null && profilePhoto.Length > 0)
                emp.ProfilePhotoPath = await SaveFile(profilePhoto, "photos");
            else
                emp.ProfilePhotoPath = existing.ProfilePhotoPath;

            emp.DocumentPaths = existing.DocumentPaths.ToList();
            if (!string.IsNullOrEmpty(removeDocument))
                emp.DocumentPaths.Remove(removeDocument);
            if (documents != null)
                foreach (var doc in documents)
                {
                    var path = await SaveFile(doc, "documents");
                    if (path != null) emp.DocumentPaths.Add(path);
                }

            EmployeeRepo.Update(emp);
            TempData["Success"] = $"Employee {emp.FullName} updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Employee/Delete/5
        public IActionResult Delete(int id)
        {
            var emp = EmployeeRepo.GetById(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = EmployeeRepo.GetById(id);
            if (emp == null) return NotFound();
            var name = emp.FullName;
            EmployeeRepo.Delete(id);
            TempData["Success"] = $"Employee {name} has been deleted.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Employee/ExportCsv
        public IActionResult ExportCsv(string? q, string? department, string? employmentType, int? joiningYear)
        {
            var employees = string.IsNullOrEmpty(q) && string.IsNullOrEmpty(department) &&
                            string.IsNullOrEmpty(employmentType) && !joiningYear.HasValue
                ? EmployeeRepo.GetAll()
                : EmployeeRepo.Search(q, department, employmentType, joiningYear);

            var sb = new StringBuilder();
            sb.AppendLine("Emp ID,Full Name,Email,Phone,Department,Designation,Employment Type,Date of Joining,Salary,Status");
            foreach (var e in employees)
                sb.AppendLine($"\"{e.EmployeeCode}\",\"{e.FullName}\",\"{e.Email}\",\"{e.PhoneNumber}\",\"{e.Department}\",\"{e.Designation}\",\"{e.EmploymentType}\",\"{e.DateOfJoining:yyyy-MM-dd}\",{e.Salary},\"{(e.IsActive ? "Active" : "Inactive")}\"");

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/csv", $"employees_{DateTime.Now:yyyyMMdd}.csv");
        }

        // GET: /Employee/ExportExcel
        public IActionResult ExportExcel(string? q, string? department, string? employmentType, int? joiningYear)
        {
            var employees = string.IsNullOrEmpty(q) && string.IsNullOrEmpty(department) &&
                            string.IsNullOrEmpty(employmentType) && !joiningYear.HasValue
                ? EmployeeRepo.GetAll()
                : EmployeeRepo.Search(q, department, employmentType, joiningYear);

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Employees");

            // Header row
            var headers = new[] { "Emp ID", "Full Name", "Email", "Phone", "Department", "Designation", "Employment Type", "Date of Joining", "Date of Birth", "Salary", "Gender", "Address", "Status" };
            for (int i = 0; i < headers.Length; i++)
            {
                ws.Cell(1, i + 1).Value = headers[i];
                ws.Cell(1, i + 1).Style.Font.Bold = true;
                ws.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#1B3A6B");
                ws.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
            }

            int row = 2;
            foreach (var e in employees)
            {
                ws.Cell(row, 1).Value = e.EmployeeCode;
                ws.Cell(row, 2).Value = e.FullName;
                ws.Cell(row, 3).Value = e.Email;
                ws.Cell(row, 4).Value = e.PhoneNumber;
                ws.Cell(row, 5).Value = e.Department;
                ws.Cell(row, 6).Value = e.Designation;
                ws.Cell(row, 7).Value = e.EmploymentType;
                ws.Cell(row, 8).Value = e.DateOfJoining.ToString("yyyy-MM-dd");
                ws.Cell(row, 9).Value = e.DateOfBirth.ToString("yyyy-MM-dd");
                ws.Cell(row, 10).Value = (double)e.Salary;
                ws.Cell(row, 11).Value = e.Gender;
                ws.Cell(row, 12).Value = e.Address;
                ws.Cell(row, 13).Value = e.IsActive ? "Active" : "Inactive";
                if (row % 2 == 0)
                    ws.Row(row).Style.Fill.BackgroundColor = XLColor.FromHtml("#EFF1F8");
                row++;
            }
            ws.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            wb.SaveAs(ms);
            return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"employees_{DateTime.Now:yyyyMMdd}.xlsx");
        }

        // GET: /Employee/DownloadPdf/5 — simple print-styled HTML
        public IActionResult DownloadPdf(int id)
        {
            var emp = EmployeeRepo.GetById(id);
            if (emp == null) return NotFound();
            return View("PdfView", emp);
        }

        // --- Helpers ---
        private async Task<string?> SaveFile(IFormFile? file, string folder)
        {
            if (file == null || file.Length == 0) return null;
            var uploadsDir = Path.Combine(_env.WebRootPath, "uploads", folder);
            Directory.CreateDirectory(uploadsDir);
            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var fullPath = Path.Combine(uploadsDir, fileName);
            await using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);
            return $"/uploads/{folder}/{fileName}";
        }
    }
}
