using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models;
using HotelRoomBookingService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomBookingService.Controllers
{
    [Route("Payment")]
    [ApiController]
    public class PaymentServiceController : ControllerBase
    {
        PaymentService service;
        public PaymentServiceController()
        {
            this.service = new PaymentService();
        }


       
        [Route("MakeBooking")]
        [HttpPost]
        public IActionResult BookingDetails(AllData allData)
        {
            int InvoiceNumber = service.MakeBooking(allData);
            
            return Ok(InvoiceNumber);
        }

    }


}
