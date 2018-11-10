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


        //[Route("BookingDetails")]
        //[HttpPost]
        //public IActionResult BookingDetails(HotelSearchDetails h1)
        //{
        //    service.BookingDetails(h1);
        //    return Ok();
        //}


        //[Route("BookingDetails")]
        //[HttpPost]
        //public IActionResult BookingDetails(HotelSearchDetails bd1)
        //{
        //    service.AddBookingDetails(bd1);
        //    return Ok();
        //}

        [Route("MakeBooking")]
        [HttpPost]
        public IActionResult BookingDetails(AllData allData)
        {
            int InvoiceNumber = service.MakeBooking(allData);
            
            return Ok(InvoiceNumber);
        }

    }


}
