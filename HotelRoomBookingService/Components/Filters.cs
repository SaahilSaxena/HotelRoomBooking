using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingService.Components
{
    public class ServiceErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
          

            context.Result = new ContentResult() {  Content=context.Exception.Message };

        }
    }
}
