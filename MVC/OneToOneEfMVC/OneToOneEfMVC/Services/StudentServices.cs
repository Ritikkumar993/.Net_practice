using Microsoft.EntityFrameworkCore;
using OneToOneEfMVC.Data;
using OneToOneEfMVC.Models;

namespace OneToOneEfMVC.Services
{
    public class StudentServices
    {
        private readonly StudentManagementContext _context;

        public StudentServices(StudentManagementContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students
                           .Include(s => s.AssignedRoom)
                           .ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
