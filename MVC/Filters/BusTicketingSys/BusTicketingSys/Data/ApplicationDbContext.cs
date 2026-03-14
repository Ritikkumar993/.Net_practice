using BusTicketingSys.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingSys.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => new { t.TripId, t.SeatId })
                .IsUnique();
        }
    }
}
