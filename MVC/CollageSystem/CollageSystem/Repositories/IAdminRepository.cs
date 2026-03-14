using CollageSystem.Models;

namespace CollageSystem.Repositories
{
    public interface IAdminRepository
    {
        Task<Admin?> GetByCredentialsAsync(string username, string password);
    }
}
