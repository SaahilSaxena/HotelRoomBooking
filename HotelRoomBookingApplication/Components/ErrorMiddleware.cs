using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingApplication.Components
{
    public class ExceptionHandlingAppMiddleware
    {
        public RequestDelegate Next;
        
        public ExceptionHandlingAppMiddleware(RequestDelegate Next)
        {
            this.Next = Next;
            
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception e)
            {
                context.Response.ContentType = "text/html";
                string Html = $"<div><a href='/AdminApp/LoginView'>Go to Home Page</a></div><div>{e.Message}</div>";
                await context.Response.WriteAsync(Html);
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
