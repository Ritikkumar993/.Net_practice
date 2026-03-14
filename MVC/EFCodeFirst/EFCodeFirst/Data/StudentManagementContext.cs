using Microsoft.EntityFrameworkCore;


using EFCodeFirst.Models;

namespace EFCodeFirst.Data
{
    public class StudentManagementContext:DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
