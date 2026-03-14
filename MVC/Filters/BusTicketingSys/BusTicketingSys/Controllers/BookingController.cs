using BusTicketingSys.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketingSys.Controllers
{
    [ServiceFilter(typeof(BookingLogFilter))]
    public class BookingController : Controller
    {
        static List<int> bookedSeats = new();

        public IActionResult BookSeat(int seatNo)
        {
            if (bookedSeats.Contains(seatNo))
            {
                throw new Exception("Seat already booked");
            }

            bookedSeats.Add(seatNo);

            return Ok($"Seat {seatNo} booked successfully");
        }
    }

}
