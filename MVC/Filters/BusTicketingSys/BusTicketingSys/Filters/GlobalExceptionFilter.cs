using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BusTicketingSys.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = "Seat already booked or booking failed",
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }

}
