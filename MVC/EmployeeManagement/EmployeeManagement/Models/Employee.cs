using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        /// <summary>Auto-generated code like EMP-0001</summary>
        public string EmployeeCode { get; set; } = null!;

        // Personal Information
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        [Display(Name = "Aadhaar Number")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhaar number must be 12 digits.")]
        public string AadhaarNumber { get; set; } = null!;

        [Display(Name = "Address")]
        [StringLength(500)]
        public string? Address { get; set; }

        // Employment Details
        [Required]
        public string Department { get; set; } = null!;

        [Required]
        [Display(Name = "Designation")]
        public string Designation { get; set; } = null!;

        [Required]
        [Display(Name = "Employment Type")]
        public string EmploymentType { get; set; } = null!;

        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        // Emergency Contact
        [Required]
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; } = null!;

        [Required]
        [Display(Name = "Emergency Contact Phone")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact phone must be 10 digits.")]
        public string EmergencyContactPhone { get; set; } = null!;

        // Files / Media
        public string? ProfilePhotoPath { get; set; }
        public List<string> DocumentPaths { get; set; } = new();

        // Computed helpers
        /// <summary>Years old calculated from DateOfBirth</summary>
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        /// <summary>Aadhaar with first 8 digits masked: ****-****-3456</summary>
        public string MaskedAadhaar
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AadhaarNumber) || AadhaarNumber.Length < 4)
                    return AadhaarNumber ?? string.Empty;
                var last4 = AadhaarNumber[^4..];
                return $"****-****-{last4}";
            }
        }

        /// <summary>Human-readable tenure, e.g. "3 yrs 5 mos" or "8 months"</summary>
        public string Tenure
        {
            get
            {
                var today = DateTime.Today;
                int years = today.Year - DateOfJoining.Year;
                int months = today.Month - DateOfJoining.Month;
                if (months < 0) { years--; months += 12; }
                if (years > 0 && months > 0) return $"{years} yr{(years > 1 ? "s" : "")} {months} mo{(months > 1 ? "s" : "")}";
                if (years > 0) return $"{years} yr{(years > 1 ? "s" : "")}";
                return $"{months} mo{(months > 1 ? "s" : "")}";
            }
        }

        /// <summary>Returns initials from FullName, e.g. "Arjun Sharma" → "AS"</summary>
        public string AvatarInitials
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FullName)) return "?";
                var parts = FullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return parts.Length >= 2
                    ? $"{parts[0][0]}{parts[^1][0]}".ToUpper()
                    : FullName[0].ToString().ToUpper();
            }
        }
    }
}
