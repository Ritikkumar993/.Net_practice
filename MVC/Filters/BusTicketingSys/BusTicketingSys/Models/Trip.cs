namespace BusTicketingSys.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        public int BusId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal Fare { get; set; }

        public Bus Bus { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
