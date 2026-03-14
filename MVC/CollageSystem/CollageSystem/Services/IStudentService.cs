using CollageSystem.Models;
using CollageSystem.Models.ViewModels;

namespace CollageSystem.Services
{
    public interface IStudentService
    {
        Task<(bool Success, string Message)> RegisterAsync(RegisterViewModel model);
        Task<(bool Success, string Message)> ApproveAsync(int studentId);
        Task<(bool Success, string Message)> RejectAsync(int studentId);
        Task<Student?> LoginAsync(LoginViewModel model);
        Task<List<Student>> GetPendingStudentsAsync();
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
    }
}
