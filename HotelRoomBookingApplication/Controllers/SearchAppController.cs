using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoomBookingApplication.Models;
using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace HotelRoomBookingApplication.Controllers
{
    public class SearchAppController : Controller
    {
        SearchServiceApp service;
        public SearchAppController()
        {
            this.service = new SearchServiceApp();
        }
        public IActionResult GetCities()
        {

            var list = service.GetCities();
            SelectList citylist = new SelectList(list);
            ViewData["cities"] = citylist;
            return View("HomeView");

        }
        //comment
        public IActionResult GetHotels()
        {
            var list1 = service.GetHotels();
            SelectList Hotellist = new SelectList(list1);
            ViewData["hotels"] = Hotellist;
            return View("HomeView");

        }


        public IActionResult AvailableRooms(HotelSearchDetails details)
        {
            List<SelectedRoomsViewModel> list;
            try
            {
                service.UserSearchInfo(HttpContext, details);
                list = service.GetRooms(details);
                //if (list.Count == 0)
                //{
                    ModelState.AddModelError("", "No Rooms Available..");
                    return View("HomeView", details);

                //}
               //return View(list);
            }
            catch(Exception e)
            {
                ErrorViewModel model = new ErrorViewModel() {
                     RequestId=e.Message
                };
                return View("Error", model);
            }
        }

       //comment push
         public IActionResult SelectedRooms(List<SelectedRoomsViewModel> rooms)
        {
            //List<SelectedRoomsViewModel> model = SelectedRoomsViewModel.rooms

            //ViewData["rooms"] = rooms;
            HotelSearchDetails userinfo = service.GetUserInfo(HttpContext);

            int date = (userinfo.CheckOut - userinfo.CheckIn).Days+1;
            rooms = rooms.Where(r => r.Selected == true).ToList();
            decimal total = rooms.Sum(c => c.RoomPrice);
            total = date * total;
            ViewData["total"] = total;
            service.storeSelectedRoomsToSession(HttpContext, rooms);


            //rooms.SingleOrDefault(r => r.RoomId == 209);

            //rooms.Select(c => { c.CheckIn = userinfo.CheckIn; c.CheckOut = userinfo.CheckOut; } );

            foreach (SelectedRoomsViewModel room in rooms)
            {
                room.CheckIn = userinfo.CheckIn;
                room.CheckOut = userinfo.CheckOut;
            }
            
          //  rooms.SingleOrDefault(userinfo.CheckIn)
          

            ViewData["userSearchInfo"]= userinfo;
            ViewData["selectedRooms"] = rooms;
            return View();

           
        }
      
        public IActionResult HomeView()
        {
            return View();
        }
    }
}


