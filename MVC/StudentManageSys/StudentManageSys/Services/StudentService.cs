using StudentManageSys.Models;
using StudentManageSys.Repositories;

namespace StudentManageSys.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Student>> SearchAsync(string q = null) => _repo.GetAllAsync(q);

        public Task<Student?> GetAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<(bool ok, string message)> CreateAsync(Student student)
        {
            // Business validation example
            if (string.IsNullOrWhiteSpace(student.FullName))
                return (false, "Full Name is required.");

            if (string.IsNullOrWhiteSpace(student.Email))
                return (false, "Email is required.");

            var exists = await _repo.EmailExistsAsync(student.Email);
            if (exists)
                return (false, "Email already exists.");

            student.Status ??= "Active";
            if (student.JoinDate == default)
                student.JoinDate = DateOnly.FromDateTime(DateTime.Today);

            student.CreatedAt = DateTime.UtcNow;

            await _repo.AddAsync(student);
            return (true, "Student created successfully.");
        }

        public async Task<(bool ok, string message)> UpdateAsync(Student student)
        {
            if (student.StudentId <= 0)
                return (false, "Invalid StudentId.");

            var exists = await _repo.EmailExistsAsync(student.Email, student.StudentId);
            if (exists)
                return (false, "Email already exists.");

            await _repo.UpdateAsync(student);
            return (true, "Student updated successfully.");
        }

        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

        public async Task<List<Student>> GetStudentsPaged(int pageNumber, int pageSize)
        {
            return await _repo.GetStudentsPaged(pageNumber, pageSize);
        }

        public async Task<List<Student>> SearchPagedAsync(string q, int page, int pageSize)
        {
            return await _repo.SearchPagedAsync(q, page, pageSize);
        }


    }
}
