namespace BusTicketingSys.Models
{
    public class Bus
    {
        public int BusId { get; set; }

        public string BusName { get; set; }

        public int TotalSeats { get; set; } = 40;

        public List<Seat> Seats { get; set; }
    }

}
