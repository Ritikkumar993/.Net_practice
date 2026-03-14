using Microsoft.AspNetCore.Components.Web;
using StudentManageSys.Models;

namespace StudentManageSys.Services
{
    public interface IStudentService
    {
        Task<List<Student>> SearchAsync(string q = null);
        Task<Student?> GetAsync(int id);
        Task<(bool ok, string message)> CreateAsync(Student student);
        Task<(bool ok, string message)> UpdateAsync(Student student);
        Task DeleteAsync(int id);

        Task<List<Student>> GetStudentsPaged(int pageNumber, int pageSize);
        Task<List<Student>> SearchPagedAsync(string q, int page, int pageSize);
    }
}
