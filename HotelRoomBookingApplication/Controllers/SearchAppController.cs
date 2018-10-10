using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoomBookingApplication.Models;
using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                list= service.GetRooms(details);
                return View(list);
            }
            catch(Exception e)
            {
                ErrorViewModel model = new ErrorViewModel() {
                     RequestId=e.Message
                };
                return View("Error", model);
            }
        }

       
         public IActionResult SelectedRooms(List<SelectedRoomsViewModel> rooms)
        {
            //List<SelectedRoomsViewModel> model = SelectedRoomsViewModel.rooms
             decimal total=rooms.Sum(c => c.RoomPrice);
            ViewData["total"] = total;
            ViewData["rooms"] = rooms;
            return View("FinalView");
        }
    }
}
