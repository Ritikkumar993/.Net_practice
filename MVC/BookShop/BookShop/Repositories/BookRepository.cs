using BookShop.Data;
using BookShop.Models;

namespace BookShop.Repositories
{
    public class BookRepository : IBookRepository
    {
        

        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

       public List<Book> GetAllBooks()
       {
            return _context.Books.ToList();   
       }
        public List<Book> GetBooksByPrice()
       {
            return _context.Books.Where(b => b.Price >= 500).ToList();

       }
       public List<Book> SearchBook(string bookname)
       {
            return _context.Books.Where(b => b.BookName.Contains(bookname)).ToList();
       }
    }
}
