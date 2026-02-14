using System;

namespace BookStoreApplication
{
    public class Book
    {
        // TODO: Create public properties
        public string Id { get; set; }
        // Id -> string
        public string Title { get; set; }
        // Title -> string
        public string Author { get; set; }
        // Author -> string (Optional)
        public int Price { get; set; }
        // Price -> int
        public int Stock { get; set; }
        // Stock -> int

        // Example:
        // public string Id { get; set; }
    }
}
