using CollageSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollageSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Degree> Degrees => Set<Degree>();
        public DbSet<Admin> Admins => Set<Admin>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── Student Configuration ──
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(s => s.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(s => s.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(s => s.Email)
                    .IsUnique();

                entity.Property(s => s.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(s => s.RegistrationNumber)
                    .HasMaxLength(20);

                entity.HasIndex(s => s.RegistrationNumber)
                    .IsUnique()
                    .HasFilter("[RegistrationNumber] IS NOT NULL");

                entity.Property(s => s.Password)
                    .HasMaxLength(100);

                entity.Property(s => s.Status)
                    .HasConversion<int>()
                    .HasDefaultValue(StudentStatus.Pending);

                entity.Property(s => s.AppliedOn)
                    .HasDefaultValueSql("GETDATE()");

                // Relationship: Student → Degree
                entity.HasOne(s => s.Degree)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DegreeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ── Degree Configuration ──
            modelBuilder.Entity<Degree>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(d => d.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasIndex(d => d.Code)
                    .IsUnique();
            });

            // ── Admin Configuration ──
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(a => a.Username)
                    .IsUnique();

                entity.Property(a => a.Password)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // ── Seed Data ──
            modelBuilder.Entity<Degree>().HasData(
                new Degree { Id = 1, Name = "Bachelor of Technology", Code = "B.Tech" },
                new Degree { Id = 2, Name = "Bachelor of Science", Code = "B.Sc" },
                new Degree { Id = 3, Name = "Bachelor of Arts", Code = "B.A" },
                new Degree { Id = 4, Name = "Bachelor of Commerce", Code = "B.Com" },
                new Degree { Id = 5, Name = "Master of Technology", Code = "M.Tech" },
                new Degree { Id = 6, Name = "Master of Science", Code = "M.Sc" },
                new Degree { Id = 7, Name = "Master of Business Administration", Code = "MBA" },
                new Degree { Id = 8, Name = "Bachelor of Computer Applications", Code = "BCA" },
                new Degree { Id = 9, Name = "Master of Computer Applications", Code = "MCA" }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, Username = "admin", Password = "admin123" }
            );
        }
    }
}
