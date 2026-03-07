using BookShop.Models;

namespace BookShop.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        List<Book> GetBooksByPrice();
        List<Book> SearchBook(string bookname);
    }
}