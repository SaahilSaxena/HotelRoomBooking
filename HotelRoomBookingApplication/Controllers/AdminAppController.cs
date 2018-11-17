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
using Microsoft.AspNetCore.Http;

namespace HotelRoomBookingApplication.Controllers
{
    public class AdminAppController : Controller
    {
        AdminServiceApp service;
        ILogger<AdminAppController> log;
        public AdminAppController(ILogger<AdminAppController> log)
        {
            service = new AdminServiceApp();
            this.log = log;
        }
        //comment
        //public AdminAppController()
        //{
        //    service = new AdminServiceApp();
        //}
        [ErrorFilter]
        public IActionResult Index()
        {
            return View("Index");
            //Response.Redirect("Homeview");
        }
        public IActionResult LoginView()
        {
            
        
            try
            {
                log.LogInformation("Executing GetProducts Method..");
               
                log.LogInformation("This is a Test Message");

            }
                
            catch (Exception exception)
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
                ModelState.AddModelError("Email", "Invalid Email or Password.");
                return View("LoginView", credentials);
            }
            else {
                HttpContext.Session.SetInt32("CustomerId", result);
                //return View("../SearchApp/HomeView");
                return RedirectToAction("GetCities", "SearchApp");
            }
            
        }

        
        public IActionResult NewCustomer()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult NewCustomer(Customer c1)
        {
            int duplicate = service.AddRecord(c1);
            if (duplicate == 0)
            {

                return RedirectToAction("LoginView");
            }
            else
            {
                ModelState.AddModelError("Email", "Email Already Exists!!");
                return View("NewCustomer",c1);
            }
        }


        public IActionResult HomeView()
        {
            return View();
        }
    }
}