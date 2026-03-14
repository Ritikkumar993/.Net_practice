using CollageSystem.Models;
using CollageSystem.Models.ViewModels;
using CollageSystem.Repositories;

namespace CollageSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IDegreeRepository _degreeRepo;

        public StudentService(IStudentRepository studentRepo, IDegreeRepository degreeRepo)
        {
            _studentRepo = studentRepo;
            _degreeRepo = degreeRepo;
        }

        public async Task<(bool Success, string Message)> RegisterAsync(RegisterViewModel model)
        {
            // Check if email already exists
            var existing = await _studentRepo.GetByEmailAsync(model.Email);
            if (existing != null)
            {
                return (false, "A student with this email address already exists.");
            }

            // Verify selected degree exists
            var degree = await _degreeRepo.GetByIdAsync(model.DegreeId);
            if (degree == null)
            {
                return (false, "Selected degree program does not exist.");
            }

            var student = new Student
            {
                FirstName = model.FirstName.Trim(),
                LastName = model.LastName.Trim(),
                Email = model.Email.Trim().ToLower(),
                PhoneNumber = model.PhoneNumber.Trim(),
                DegreeId = model.DegreeId,
                Status = StudentStatus.Pending,
                AppliedOn = DateTime.Now
            };

            await _studentRepo.AddAsync(student);
            return (true, "Your application has been submitted successfully! Please wait for admin approval.");
        }

        public async Task<(bool Success, string Message)> ApproveAsync(int studentId)
        {
            var student = await _studentRepo.GetByIdAsync(studentId);
            if (student == null)
            {
                return (false, "Student not found.");
            }

            if (student.Status != StudentStatus.Pending)
            {
                return (false, "This student has already been processed.");
            }

            // Generate registration number
            student.RegistrationNumber = await GenerateRegistrationNumber();

            // Generate default password: [Last 4 digits of Phone]@[FirstName]
            student.Password = GenerateDefaultPassword(student.PhoneNumber, student.FirstName);

            // Update status
            student.Status = StudentStatus.Approved;

            await _studentRepo.UpdateAsync(student);

            return (true, $"Student approved. Registration: {student.RegistrationNumber}, Password: {student.Password}");
        }

        public async Task<(bool Success, string Message)> RejectAsync(int studentId)
        {
            var student = await _studentRepo.GetByIdAsync(studentId);
            if (student == null)
            {
                return (false, "Student not found.");
            }

            if (student.Status != StudentStatus.Pending)
            {
                return (false, "This student has already been processed.");
            }

            student.Status = StudentStatus.Rejected;
            await _studentRepo.UpdateAsync(student);

            return (true, "Student application has been rejected.");
        }

        public async Task<Student?> LoginAsync(LoginViewModel model)
        {
            var student = await _studentRepo.GetByRegistrationNumberAsync(model.RegistrationNumber.Trim());

            if (student == null || student.Status != StudentStatus.Approved)
            {
                return null;
            }

            if (student.Password != model.Password)
            {
                return null;
            }

            return student;
        }

        public async Task<List<Student>> GetPendingStudentsAsync()
        {
            return await _studentRepo.GetByStatusAsync(StudentStatus.Pending);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepo.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRepo.GetByIdAsync(id);
        }

        // ── Private Business Logic Methods ──

        private async Task<string> GenerateRegistrationNumber()
        {
            int count = await _studentRepo.GetApprovedCountAsync();
            int nextNumber = count + 1;
            string year = DateTime.Now.Year.ToString();
            return $"STU-{year}-{nextNumber:D4}";
        }

        private static string GenerateDefaultPassword(string phoneNumber, string firstName)
        {
            // Business rule: [Last 4 digits of Phone No]@[First Name]
            string last4Digits = phoneNumber.Length >= 4
                ? phoneNumber[^4..]
                : phoneNumber;

            return $"{last4Digits}@{firstName}";
        }
    }
}
