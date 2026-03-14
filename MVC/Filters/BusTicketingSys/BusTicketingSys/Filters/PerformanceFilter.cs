using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace BusTicketingSys.Filters
{
    public class PerformanceFilter : IResourceFilter
    {
        Stopwatch watch;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            watch = Stopwatch.StartNew();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            watch.Stop();

            Console.WriteLine($"Booking Request Time: {watch.ElapsedMilliseconds}ms");
        }
    }

}
