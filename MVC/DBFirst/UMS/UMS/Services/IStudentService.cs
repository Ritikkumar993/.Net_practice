using UMS.DTO;

namespace UMS.Services
{
    public interface IStudentService
    {
        Task CreateStudent(StudentHostelDTO dto);
        Task UpdateRoom(int studentId, int roomNo);
        Task DeleteStudent(int id);
        Task<List<StudentHostelDTO>> GetStudentsInHostel();
        Task<List<StudentDTO>> GetAllStudents();
    }
}
