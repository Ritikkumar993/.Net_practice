using BookHouse.Data;
using BookHouse.Models;

namespace BookHouse.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
