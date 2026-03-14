namespace BusTicketingSys.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int TicketId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public Ticket Ticket { get; set; }
    }
}
