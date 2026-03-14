using CollageSystem.Models;

namespace CollageSystem.Repositories
{
    public interface IDegreeRepository
    {
        Task<List<Degree>> GetAllAsync();
        Task<Degree?> GetByIdAsync(int id);
    }
}
