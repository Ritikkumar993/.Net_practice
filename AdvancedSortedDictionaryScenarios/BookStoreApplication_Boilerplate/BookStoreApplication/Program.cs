using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            Console.WriteLine("Details: <BookId> <Title> <Price> <Stock>");
            // Format: BookID Title Price Stock
            string str = Console.ReadLine();
            string[] arr = str.Split();

            Book book = new Book();
            book.Id = arr[0];
            book.Title = arr[1];
            book.Price = Convert.ToInt32(arr[2]);
            book.Stock = Convert.ToInt32(arr[3]);

            BookUtility utility = new BookUtility(book);

            while (true)
            {
                // TODO:
                // Display menu:
                // 1 -> Display book details
                // 2 -> Update book price
                // 3 -> Update book stock
                // 4 -> Exit
                Console.WriteLine("1.Display book details");
                Console.WriteLine("2.Update book price");
                Console.WriteLine("3.Update book stock");
                Console.WriteLine("4.Exit");

                string[] starr = Console.ReadLine().Split();

                int choice = Convert.ToInt32(starr[0]);
                    // TODO: Read user choice

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        // Call UpdateBookPrice()
                        utility.UpdateBookPrice(Convert.ToInt32(starr[1]));
                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        // Call UpdateBookStock()
                        utility.UpdateBookStock(Convert.ToInt32(starr[1]));
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
