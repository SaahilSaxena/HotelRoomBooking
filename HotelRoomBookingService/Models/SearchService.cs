using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingService.Models
{
    public class SearchService
    {
        HotelRoomBookingDBContext context;
        public SearchService()
        {
            context = new HotelRoomBookingDBContext();
        }
        public List<string> getCities()
        {
            var cities = (from c in context.Hotel select c.City).Distinct().ToList();
            return cities;
        }

        public List<Hotel> getHotels(string city)
        {
            var hotels = (from h in context.Hotel where h.City == city select h).ToList();
            return hotels;
        }



        //public List<SelectedRooms> GetRooms(HotelSearchDetails details)
        //{
        //    throw new NotImplementedException();
        //}

        public List<SelectedRooms> GetRooms(HotelSearchDetails details)
        {
            string wifi = details.Wifi == true ? "Y" : "N";
            string ac = details.Ac == true ? "Y" : "N";
            var result = context.SelectedRooms.FromSql($"exec GetAvailableRooms {details.CheckIn},{details.CheckOut},{details.HotelId},{ac},{wifi} ").ToList();
            return result;
        }
        public void AddBooking(Booking b1)
        {
            context.Booking.Add(b1);
            context.SaveChanges();
        }
    }
}