using Microsoft.AspNetCore.Mvc.Filters;

namespace BusTicketingSys.Filters
{
    public class BookingLogFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Booking process started");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Booking process completed");
        }
    }

}
