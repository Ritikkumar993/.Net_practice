using System.ComponentModel.DataAnnotations;
namespace CRUDwithMVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(14, 60, ErrorMessage = "Age must be between 14 and 60")]
        public int Age { get; set; }
        [Required]
        public string City { get; set; }
    }
}
