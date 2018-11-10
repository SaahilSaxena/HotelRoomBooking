using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HotelRoomBookingApplication.Models;

namespace HotelRoomBookingApplication.Controllers
{
    public class PaymentAppController : Controller
    {
        PaymentServiceApp service;
       // ILogger<PaymentAppController> log;
        public PaymentAppController()//ILogger<PaymentAppController> log)
        {
            service = new PaymentServiceApp();
            //this.log = log;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult PlaceOrder(string payMode)
        {
            service.context = HttpContext;
            service.FinalBooking(payMode);

            return View();
        }
    }
}