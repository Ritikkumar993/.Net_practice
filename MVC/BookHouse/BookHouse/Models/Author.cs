using System.ComponentModel.DataAnnotations;

namespace BookHouse.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
