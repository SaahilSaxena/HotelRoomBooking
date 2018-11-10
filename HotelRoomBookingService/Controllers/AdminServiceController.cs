using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoomBookingLibrary;
using HotelRoomBookingService.Controllers.Models;
using HotelRoomBookingService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomBookingService.Controllers
{
   // [Route("api/[controller]")]
   [Route("Admin")]
    [ApiController]
    public class AdminServiceController : ControllerBase
    {
        HotelRoomBookingDBContext context;
        AdminService service;

        //public AdminServiceController()
        //{
        //}

        public AdminServiceController(HotelRoomBookingDBContext context)
        {
            this.context = context;
             service = new AdminService(this.context);
          // this.service = new AdminService();
        }
       
        //comment
        [Route("Authenticate")]
        [HttpPost]
        public IActionResult Authenticate(Credentials credentials)
        {
            int result = service.Authenticate(credentials);
            if (result == 0)
                return NotFound();
            else
                return Ok(result);
        }
        //comment
        [Route("NewCustomer")]
        [HttpPost]
        public IActionResult NewCustomer(Customer c1)
        {
            service.AddRecord(c1);
            return Ok();
        }
       
       
    }
}