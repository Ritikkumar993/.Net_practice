namespace BusTicketingSys.Models
{
    public class Seat
    {
        public int SeatId { get; set; }   // ✅ Primary Key
        public int SeatNumber { get; set; }

        public bool IsBooked { get; set; }
    }

}
