using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public static class EmployeeRepo
    {
        private static readonly List<Employee> _employees = new()
        {
            new Employee
            {
                Id = 1,
                EmployeeCode = "EMP-0001",
                FullName = "Arjun Sharma",
                Email = "arjun.sharma@company.com",
                PhoneNumber = "9876543210",
                DateOfBirth = new DateTime(1992, 5, 15),
                Gender = "Male",
                AadhaarNumber = "123456789012",
                Address = "12, MG Road, Bengaluru, Karnataka",
                Department = "Engineering",
                Designation = "Senior Engineer",
                EmploymentType = "Full-Time",
                DateOfJoining = new DateTime(2020, 3, 1),
                Salary = 95000,
                IsActive = true,
                EmergencyContactName = "Priya Sharma",
                EmergencyContactPhone = "9871234560"
            },
            new Employee
            {
                Id = 2,
                EmployeeCode = "EMP-0002",
                FullName = "Divya Menon",
                Email = "divya.menon@company.com",
                PhoneNumber = "9123456780",
                DateOfBirth = new DateTime(1995, 9, 22),
                Gender = "Female",
                AadhaarNumber = "234567890123",
                Department = "HR",
                Designation = "HR Manager",
                EmploymentType = "Full-Time",
                DateOfJoining = new DateTime(2019, 7, 15),
                Salary = 72000,
                IsActive = true,
                EmergencyContactName = "Rahul Menon",
                EmergencyContactPhone = "9812345670"
            },
            new Employee
            {
                Id = 3,
                EmployeeCode = "EMP-0003",
                FullName = "Rohan Verma",
                Email = "rohan.verma@company.com",
                PhoneNumber = "8765432109",
                DateOfBirth = new DateTime(1998, 2, 10),
                Gender = "Male",
                AadhaarNumber = "345678901234",
                Department = "Finance",
                Designation = "Financial Analyst",
                EmploymentType = "Contract",
                DateOfJoining = new DateTime(2023, 1, 10),
                Salary = 55000,
                IsActive = true,
                EmergencyContactName = "Sunita Verma",
                EmergencyContactPhone = "9876501234"
            }
        };

        private static int _nextId = 4;

        public static List<Employee> GetAll() => _employees.ToList();

        public static Employee? GetById(int id) =>
            _employees.FirstOrDefault(e => e.Id == id);

        public static List<Employee> Search(
            string? q,
            string? department,
            string? employmentType,
            int? joiningYear)
        {
            var query = _employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                var ql = q.ToLower();
                query = query.Where(e =>
                    e.FullName.ToLower().Contains(ql) ||
                    e.Email.ToLower().Contains(ql) ||
                    e.EmployeeCode.ToLower().Contains(ql) ||
                    e.Designation.ToLower().Contains(ql));
            }

            if (!string.IsNullOrWhiteSpace(department))
                query = query.Where(e => e.Department == department);

            if (!string.IsNullOrWhiteSpace(employmentType))
                query = query.Where(e => e.EmploymentType == employmentType);

            if (joiningYear.HasValue)
                query = query.Where(e => e.DateOfJoining.Year == joiningYear.Value);

            return query.ToList();
        }

        public static List<string> GetDepartments() =>
            _employees.Select(e => e.Department).Distinct().Order().ToList();

        public static int GetNewThisMonth()
        {
            var now = DateTime.Today;
            return _employees.Count(e => e.DateOfJoining.Year == now.Year && e.DateOfJoining.Month == now.Month);
        }

        public static Dictionary<string, int> GetDepartmentCounts() =>
            _employees.GroupBy(e => e.Department)
                      .ToDictionary(g => g.Key, g => g.Count());

        public static Dictionary<string, int> GetEmploymentTypeCounts() =>
            _employees.GroupBy(e => e.EmploymentType)
                      .ToDictionary(g => g.Key, g => g.Count());

        public static void Add(Employee emp)
        {
            emp.Id = _nextId++;
            emp.EmployeeCode = $"EMP-{emp.Id:D4}";
            _employees.Add(emp);
        }

        public static void Update(Employee emp)
        {
            var idx = _employees.FindIndex(e => e.Id == emp.Id);
            if (idx >= 0)
                _employees[idx] = emp;
        }

        public static void Delete(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp != null) _employees.Remove(emp);
        }
    }
}
