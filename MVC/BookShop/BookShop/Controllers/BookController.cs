using BookShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _repo;

        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        //public IActionResult 
        public IActionResult Index()
        {
           return View();
        }
        public IActionResult ListAllBook()
        {
            var books = _repo.GetAllBooks();
            return View(books);
        }

        public IActionResult ListByPrice()
        {
            var books = _repo.GetBooksByPrice();
            return View(books);
        }

        public IActionResult BookByName(string name)
        {
            var books = _repo.SearchBook(name);
            return View(books);
        }
    }
}
