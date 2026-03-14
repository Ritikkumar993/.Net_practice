using BookHouse.Models;
using BookHouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookHouse.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var authors = _service.GetAllAuthors();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _service.AddAuthor(author);
            return RedirectToAction("Index");
        }
    }
}
