using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingService.Components
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate Next;
        ILogger<ExceptionHandlingMiddleware> log;
        public ExceptionHandlingMiddleware(RequestDelegate Next, ILogger<ExceptionHandlingMiddleware> log)
        {
            this.Next = Next;
            this.log = log;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception exception)
            {
               log.LogError(exception.Message);
                context.Response.ContentType = "application/json";
                log.LogCritical(exception.Message);
               
                
                 await context.Response.WriteAsync(exception.Message);
                await context.Response.WriteAsync(exception.Message);
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}
