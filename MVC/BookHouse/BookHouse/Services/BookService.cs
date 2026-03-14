using BookHouse.Models;
using BookHouse.Repositories;

namespace BookHouse.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _repo.GetAll();
        }

        public void AddBook(Book book)
        {
            _repo.Add(book);
            _repo.Save();
        }
    }
}
