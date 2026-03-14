using BookHouse.Models;
using BookHouse.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookHouse.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;

        public BookController(IBookRepository bookRepo, IAuthorRepository authorRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }

        public IActionResult Index()
        {
            var books = _bookRepo.GetAll();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_authorRepo.GetAll(), "AuthorId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookRepo.Add(book);
            _bookRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
