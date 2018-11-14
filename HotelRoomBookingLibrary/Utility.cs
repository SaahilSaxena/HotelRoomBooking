using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomBookingLibrary
{
    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class SelectedRooms
    {
        public int HotelId { get; set; }
        [Key]
        public int RoomId { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string HotelContact { get; set; }
        public decimal RoomPrice { get; set; }
        public string HotelImage { get; set; }
        //public DateTime CheckIn { get; set; }
        //public DateTime CheckOut { get; set; }
    }

    public class HotelSearchDetails
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }  //not using
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool Wifi { get; set; }
        public bool Ac { get; set; }
        public string HotelImage { get; set; }
    }
    public class SelectedRoomsViewModel
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string HotelContact { get; set; }
        public decimal RoomPrice { get; set; }
        public bool Selected { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string HotelImage { get; set; }
       
    }

    public class AllData
    {
        public int CustomerId { get; set; }
        public List<SelectedRoomsViewModel> SelectedRooms { get; set; }
        public HotelSearchDetails userinfo { get; set; }
        public string payMode { get; set; }
       
    }
}
