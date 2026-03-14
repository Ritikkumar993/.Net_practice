using BookHouse.Models;

namespace BookHouse.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        void Add(Book book);
        void Save();
    }
}
