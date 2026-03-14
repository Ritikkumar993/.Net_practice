using BookHouse.Models;
using BookHouse.Repositories;

namespace BookHouse.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repo;

        public AuthorService(IAuthorRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _repo.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddAuthor(Author author)
        {
            _repo.Add(author);
            _repo.Save();
        }
    }
}
