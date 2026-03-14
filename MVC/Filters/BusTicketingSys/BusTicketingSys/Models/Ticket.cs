namespace BusTicketingSys.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int PassengerId { get; set; }

        public int TripId { get; set; }   // ✅ MUST EXIST

        public int SeatId { get; set; }   // ✅ MUST EXIST

        public DateTime BookingTime { get; set; }

        public Passenger Passenger { get; set; }

        public Trip Trip { get; set; }

        public Seat Seat { get; set; }

        public Payment Payment { get; set; }
    }

}
