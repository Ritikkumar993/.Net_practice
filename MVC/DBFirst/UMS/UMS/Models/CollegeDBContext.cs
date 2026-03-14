using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UMS.Models;

public partial class CollegeDBContext : DbContext
{
    public CollegeDBContext()
    {
    }

    public CollegeDBContext(DbContextOptions<CollegeDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=RITIKPC\\SQLEXPRESS;Initial Catalog=CollegeDB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelId).HasName("PK__Hostels__677EEB28FA8549F7");

            entity.HasIndex(e => e.StudentId, "UQ__Hostels__32C52B9845508312").IsUnique();

            entity.HasOne(d => d.Student).WithOne(p => p.Hostel)
                .HasForeignKey<Hostel>(d => d.StudentId)
                .HasConstraintName("FK__Hostels__Student__4D94879B");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B996A81B31B");

            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
