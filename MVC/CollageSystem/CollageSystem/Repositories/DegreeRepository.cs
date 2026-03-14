using CollageSystem.Data;
using CollageSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollageSystem.Repositories
{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly AppDbContext _context;

        public DegreeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Degree>> GetAllAsync()
        {
            return await _context.Degrees
                .OrderBy(d => d.Name)
                .ToListAsync();
        }

        public async Task<Degree?> GetByIdAsync(int id)
        {
            return await _context.Degrees.FindAsync(id);
        }
    }
}
