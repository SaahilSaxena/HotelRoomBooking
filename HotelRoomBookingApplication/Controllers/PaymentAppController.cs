using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HotelRoomBookingApplication.Models;
using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
using HotelRoomBookingService.InvoiceInfo;

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
        public IActionResult Invoice(string payMode)
        {
            service.context = HttpContext;
            // service.FinalBooking(payMode);


            InvoiceData InvoiceInfo = service.FinalBooking(payMode);
            ViewData["InvoiceInfo"] = InvoiceInfo;
            List<SelectedRoomsViewModel> rooms= service.GetSelectedRooms(HttpContext);
            HotelSearchDetails userinfo = service.GetUserInfo(HttpContext);

            int days = (userinfo.CheckOut - userinfo.CheckIn).Days + 1;

            ViewData["userSearchInfo"] = userinfo;
            ViewData["selectedRooms"] = rooms;
            ViewData["payMode"] = payMode;
            ViewData["days"] = days;

            HttpContext.Session.Clear();
            return View();
        }
    }
}