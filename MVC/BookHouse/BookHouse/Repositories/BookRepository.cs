using BookHouse.Data;
using BookHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace BookHouse.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Include(b => b.Author).ToList();
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
