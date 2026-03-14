using CollageSystem.Data;
using CollageSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollageSystem.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Admin?> GetByCredentialsAsync(string username, string password)
        {
            return await _context.Admins
                .FirstOrDefaultAsync(a => a.Username == username && a.Password == password);
        }
    }
}
