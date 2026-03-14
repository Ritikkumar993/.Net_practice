namespace CollageSystem.Models
{
    public class Degree
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        // Navigation
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
