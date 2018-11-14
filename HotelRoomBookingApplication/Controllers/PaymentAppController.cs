using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HotelRoomBookingApplication.Models;
using HotelRoomBookingLibrary;

namespace HotelRoomBookingApplication.Controllers
{
    public class PaymentAppController : Controller
    {
        PaymentServiceApp service;
        public HttpContext context;
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
            // service.FinalBooking(payMode);
            
           
            int InvoiceNumber = service.FinalBooking(payMode);
            ViewData["InvoiceNumber"] = InvoiceNumber;
            List<SelectedRoomsViewModel> rooms= service.GetSelectedRooms(HttpContext);
            HotelSearchDetails userinfo = service.GetUserInfo(HttpContext);
            //int CustomerId = context.Session.GetInt32("CustomerId").Value;
            ViewData["userSearchInfo"] = userinfo;
            ViewData["selectedRooms"] = rooms;
            return View();
        }
    }
}