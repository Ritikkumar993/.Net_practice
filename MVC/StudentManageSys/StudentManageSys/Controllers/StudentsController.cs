using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManageSys.Models;
using StudentManageSys.Services;

namespace StudentManageSys.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        // GET: /Students?q=...
        //public async Task<IActionResult> Index(string q = null)
        //{
        //    var items = await _service.SearchAsync(q);
        //    ViewBag.Query = q ?? "";
        //    return View(items);
        //    //return View("Index",items);

        //}

        // GET: /Students/Create
        public IActionResult Create()
        {
            return View(new Student { Status = "Active" });
        }

        // POST: /Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            var (ok, msg) = await _service.CreateAsync(student);
            if (!ok)
            {
                ModelState.AddModelError("", msg);
                return View(student);
            }

            TempData["Toast"] = msg;
            return RedirectToAction(nameof(Index));
        }

        // GET: /Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _service.GetAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: /Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentId) return BadRequest();

            if (!ModelState.IsValid)
                return View(student);

            var (ok, msg) = await _service.UpdateAsync(student);
            if (!ok)
            {
                ModelState.AddModelError("", msg);
                return View(student);
            }

            TempData["Toast"] = msg;
            return RedirectToAction(nameof(Index));
        }

        // GET: /Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: /Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            TempData["Toast"] = "Student deleted.";
            return RedirectToAction(nameof(Index));
        }

        // AJAX: /Students/Search?q=ash
        // Returns small JSON list for live search
        [HttpGet]
        public async Task<IActionResult> Search(string q)
        {
            var items = await _service.SearchAsync(q);

            var mini = items
                .Take(10)
                .Select(s => new { s.StudentId, s.FullName, s.Email, s.Status });

            return Json(mini);
        }

        public async Task<IActionResult> Index(string q = null, int page = 1)
        {
            int pageSize = 10;

            var items = await _service.SearchPagedAsync(q, page, pageSize);

            ViewBag.Query = q ?? "";
            ViewBag.Page = page;

            return View(items);
        }
    }
}
