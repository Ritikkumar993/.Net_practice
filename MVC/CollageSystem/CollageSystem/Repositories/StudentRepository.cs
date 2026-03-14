using CollageSystem.Data;
using CollageSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollageSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.Degree)
                .OrderByDescending(s => s.AppliedOn)
                .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Degree)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Student>> GetByStatusAsync(StudentStatus status)
        {
            return await _context.Students
                .Include(s => s.Degree)
                .Where(s => s.Status == status)
                .OrderByDescending(s => s.AppliedOn)
                .ToListAsync();
        }

        public async Task<Student?> GetByRegistrationNumberAsync(string registrationNumber)
        {
            return await _context.Students
                .Include(s => s.Degree)
                .FirstOrDefaultAsync(s => s.RegistrationNumber == registrationNumber);
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<int> GetApprovedCountAsync()
        {
            return await _context.Students
                .CountAsync(s => s.Status == StudentStatus.Approved);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
