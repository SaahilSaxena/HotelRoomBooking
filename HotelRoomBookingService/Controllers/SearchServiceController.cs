using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoomBookingLibrary;
using HotelRoomBookingService.Components;
using HotelRoomBookingService.Models;
using HotelRoomBookingService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomBookingService.Controllers
{
    [Route("Admin")]
    [ApiController]
    public class SearchServiceController : ControllerBase
    {
        SearchService service;
        public SearchServiceController()
        {
            this.service = new SearchService();
        }

        [Route("Cities")]
        [HttpGet]
        public List<string> GetCities()
        {
            return service.getCities();
        }
        [Route("Hotels")]
        [HttpGet]
        public List<Hotel> GetHotels(string id)
        {
            return service.getHotels(id);
        }
        //------------------------------------------------------------------------------
        [ServiceErrorFilter]
        [Route("SelectedRooms")]
        [HttpPost]
        public List<SelectedRooms> GetRooms(HotelSearchDetails details)
        {
            return service.GetRooms(details);
        }

        [Route("Booking")]
        [HttpPost]
        public IActionResult Booking(Booking b1)
        {
            service.AddBooking(b1);
            return Ok();
        }
    }
}