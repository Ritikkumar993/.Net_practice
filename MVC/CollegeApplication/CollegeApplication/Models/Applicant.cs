using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace CollegeApplication.Models
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dob = (DateTime)value;
                DateTime today = DateTime.Today;
                if (dob > today)
                {
                    return new ValidationResult("Date of Birth cannot be a future date.");
                }
                int age = today.Year - dob.Year;

                if (today < dob.AddYears(age))
                    age--;

                if (age < 14)
                    return new ValidationResult("Age must be greater than or equal to 14 years.");

            }
            return ValidationResult.Success;
        }
    }

    public class Applicant
    {
        [Display(Name = "Registration Number")]
        public int RegistrationNo { get; set; }
        public string? ProfilePhoto { get; set; }

        public IFormFile? PhotoFile { get; set; }

        [Required(ErrorMessage ="Full name is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Date of Birth is required")]
        [DataType(DataType.Date)]
        [PastDate]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="Course is required")]
        public string Course { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[6-9][0-9]{9}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please select a gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(500)]
        public string Address { get; set; }
    }
}
