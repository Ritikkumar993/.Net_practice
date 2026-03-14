using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BusTicketingSys.Filters
{
    public class ResponseWrapperFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult obj)
            {
                obj.Value = new
                {
                    success = true,
                    data = obj.Value,
                    time = DateTime.Now
                };
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }

}
