using BookHouse.Models;

namespace BookHouse.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Add(Author author);
        void Save();
    }
}
