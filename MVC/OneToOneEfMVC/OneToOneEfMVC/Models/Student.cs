namespace OneToOneEfMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public HostelRoom AssignedRoom { get; set; }
    }
}
