using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoomBookingApplication.Models;
using HotelRoomBookingLibrary;
using Microsoft.AspNetCore.Mvc;
using HotelRoomBookingService.Models.DB;
using HotelRoomBookingApplication.Components;
using Microsoft.Extensions.Logging;

namespace HotelRoomBookingApplication.Controllers
{
    public class AdminAppController : Controller
    {
        AdminServiceApp service;
        ILogger<AdminAppController> log;
        public AdminAppController(ILogger<AdminAppController> log)
        {
            this.log = log;
        }

        public AdminAppController()
        {
            service = new AdminServiceApp();
        }
        [ErrorFilter]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginView()
        {
            
        
            try
            {
                log.LogInformation("Executing GetProducts Method..");
                log.LogInformation("This is a Test Message");
                
            }
            catch(Exception exception)
            {
                log.LogCritical("error message ,e.g, DO NOT DIVIDE BY ZERO......................"); // In catch block
                log.LogInformation("Executed GetProducts Method..");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Credentials credentials)
        {
            int result = service.Login(credentials);
            if (result == 0)
            {
                ModelState.AddModelError("Email", "Login Failed..");
                return View("LoginView", credentials);
            }

            //return View("../SearchApp/HomeView");
            return RedirectToAction("GetCities", "SearchApp");
        }

        
        public IActionResult NewCustomer()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult NewCustomer(Customer c1)
        {
            service.AddRecord(c1);

            return RedirectToAction("LoginView");
        }


        public IActionResult HomeView()
        {
            return View();
        }
    }
}