using CollageSystem.Models;

namespace CollageSystem.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<List<Student>> GetByStatusAsync(StudentStatus status);
        Task<Student?> GetByRegistrationNumberAsync(string registrationNumber);
        Task<Student?> GetByEmailAsync(string email);
        Task<int> GetApprovedCountAsync();
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
    }
}
