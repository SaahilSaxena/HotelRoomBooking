using System;
using System.Collections.Generic;

namespace HotelRoomBookingService.Models.DB
{
    public partial class HotelRoom
    {
        public HotelRoom()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        public int RoomId { get; set; }
        public int? HotelId { get; set; }
        public string AirConditioner { get; set; }
        public string WiFi { get; set; }
        public decimal? RoomPrice { get; set; }

        public Hotel Hotel { get; set; }
        public ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
