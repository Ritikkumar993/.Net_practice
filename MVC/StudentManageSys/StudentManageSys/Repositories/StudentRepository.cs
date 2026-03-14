using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentManageSys.Models;

namespace StudentManageSys.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _db;

        public StudentRepository(StudentPortalDbContext db)
        {
            _db = db;
        }

        public async Task<List<Student>> GetAllAsync(string q = null)
        {
            var query = _db.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                q = q.Trim().ToLower();
                query = query.Where(s => s.FullName.ToLower().Contains(q) || s.Email.ToLower().Contains(q));
                //query = query.Where(s => s.FullName.ToLower().Contains(q) );
            }

            // Read-only list -> AsNoTracking improves performance
            return await query.AsNoTracking().OrderByDescending(s => s.CreatedAt).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task AddAsync(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var s = await _db.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (s == null) return;

            _db.Students.Remove(s);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email, int? ignoreStudentId = null)
        {
            var q = _db.Students.AsQueryable();
            if (ignoreStudentId.HasValue)
                q = q.Where(s => s.StudentId != ignoreStudentId.Value);

            return await q.AnyAsync(s => s.Email == email);
        }

        public async Task<List<Student>> GetStudentsPaged(int pageNumber, int pageSize)
        {
            var students = await _db.Students
                .FromSqlRaw("EXEC sp_GetStudentsPaged @PageNumber,@PageSize",
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@PageSize", pageSize))
                .ToListAsync();

            return students;
        }

        public async Task<List<Student>> SearchPagedAsync(string q, int page, int pageSize)
        {
            var students = await _db.Students
                .FromSqlRaw("EXEC sp_SearchStudentsPaged @Query,@PageNumber,@PageSize",
                    new SqlParameter("@Query", (object?)q ?? DBNull.Value),
                    new SqlParameter("@PageNumber", page),
                    new SqlParameter("@PageSize", pageSize))
                .ToListAsync();

            return students;
        }

    }
}
