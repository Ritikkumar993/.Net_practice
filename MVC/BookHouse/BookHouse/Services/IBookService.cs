using BookHouse.Models;

namespace BookHouse.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book book);
    }
}
