using BookHouse.Models;

namespace BookHouse.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
    }
}
