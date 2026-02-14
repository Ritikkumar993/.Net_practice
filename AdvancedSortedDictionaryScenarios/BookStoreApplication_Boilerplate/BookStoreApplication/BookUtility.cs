using System;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
            // TODO: Assign book object
            _book = book;
        }

        public void GetBookDetails()
        {
            // TODO:
            Console.WriteLine($"Details: {_book.Id} {_book.Title} {_book.Stock}");
            // Print format:
            // Details: <BookId> <Title> <Price> <Stock>
        }

        public void UpdateBookPrice(int newPrice)
        {
            // TODO:
            if (newPrice > 0)
            {
                _book.Price = newPrice;
                Console.WriteLine($"Updated Price: {_book.Price}");
                return;

            }
            // Validate new price
            Console.WriteLine("Invalid new Price");
            // Update price
            // Print: Updated Price: <newPrice>
        }

        public void UpdateBookStock(int newStock)
        {
            // TODO:
            // Validate new stock
            if (newStock > 0)
            {
                _book.Stock = newStock;
                Console.WriteLine($"Updated Stock: {_book.Stock}");
                return;
            }
            Console.WriteLine("Invalid new Stock");
            // Update stock
            // Print: Updated Stock: <newStock>
        }
    }
}
