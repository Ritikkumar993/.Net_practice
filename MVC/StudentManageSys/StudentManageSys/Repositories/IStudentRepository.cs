using StudentManageSys.Models;

namespace StudentManageSys.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(string q = null);
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? ignoreStudentId = null);

        Task<List<Student>> GetStudentsPaged(int pageNumber, int pageSize);
        Task<List<Student>> SearchPagedAsync(string q, int page, int pageSize);
    }
}
