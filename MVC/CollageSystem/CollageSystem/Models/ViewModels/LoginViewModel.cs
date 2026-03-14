using System.ComponentModel.DataAnnotations;

namespace CollageSystem.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Registration number is required")]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
