using System.Runtime.CompilerServices;

namespace OneToOneEfMVC.Models
{
    public class HostelRoom
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int StudentId { get; set; }
        public Student ResidentStudent { get; set; }

    }
}
