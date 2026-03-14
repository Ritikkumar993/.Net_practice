using Microsoft.EntityFrameworkCore;
using BookHouse.Models;

namespace BookHouse.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)        // Book has one Author
                .WithMany(a => a.Books)       // Author has many Books
                .HasForeignKey(b => b.AuthorId); // Foreign Key
        }
    }

}
