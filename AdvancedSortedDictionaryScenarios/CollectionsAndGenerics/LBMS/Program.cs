using System;
public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
}

// Generic catalog class
public class Catalog<T> where T : Book
{
    private List<T> _items = new List<T>();
    private HashSet<string> _isbnSet = new HashSet<string>();
    private SortedDictionary<string, List<T>> _genreIndex = new SortedDictionary<string, List<T>>();
    
    // Add item with genre indexing
    public bool AddItem(T item)
    {
        // TODO: Check ISBN uniqueness, add to list and genre index
        if (!_isbnSet.Contains(item.ISBN))
        {
            _isbnSet.Add(item.ISBN);
            _items.Add(item);
            if (!_genreIndex.ContainsKey(item.Genre))
            {
                _genreIndex.Add(item.Genre,_items.Where(x => x.Genre==item.Genre).ToList());
            }
            else
            {
                _genreIndex[item.Genre]=_items.Where(x => x.Genre==item.Genre).ToList();
            }
            return true;
        }
        return false;

    }
    
    // Get books by genre using indexer
    public List<T> this[string genre]
    {
        get
        {
            // TODO: Return books by genre or empty list
            if (_genreIndex.ContainsKey(genre))
            {
                return _genreIndex[genre];
            }
            return new List<T>();
        }
    }
    
    // Find books using LINQ and lambda expressions
    public IEnumerable<T> FindBooks(Func<T, bool> predicate)
    {
        // TODO: Use LINQ Where with predicate
        var res = _items.Where(x => predicate(x)).Select(r => r);
        return res;
    }
}


class Program
{
    static void Main()
    {
        Catalog<Book> library = new Catalog<Book>();

        Book book1 = new Book 
        { 

            ISBN = "978-3-16-148410-0", 
            Title = "C# Programming", 
            Author = "John Sharp", 
            Genre = "Programming" 
        };

        library.AddItem(book1);

        var programmingBooks = library["Programming"];
        Console.WriteLine(programmingBooks.Count); // Should output: 1

        var johnsBooks = library.FindBooks(b => b.Author.Contains("John"));
        Console.WriteLine(johnsBooks.Count()); // Should output: 1

    }
}