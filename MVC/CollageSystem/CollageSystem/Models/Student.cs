namespace CollageSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Foreign Key
        public int DegreeId { get; set; }

        // Status tracking
        public StudentStatus Status { get; set; } = StudentStatus.Pending;

        // Generated on approval
        public string? RegistrationNumber { get; set; }
        public string? Password { get; set; }

        public DateTime AppliedOn { get; set; } = DateTime.Now;

        // Navigation
        public Degree Degree { get; set; } = null!;
    }
}
