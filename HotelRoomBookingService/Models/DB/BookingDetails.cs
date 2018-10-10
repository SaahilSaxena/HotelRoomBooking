using System;
using System.Collections.Generic;

namespace HotelRoomBookingService.Models.DB
{
    public partial class BookingDetails
    {
        public int BookingId { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int Days { get; set; }
        public decimal? RoomPrice { get; set; }

        public Booking Booking { get; set; }
        public Hotel Hotel { get; set; }
        public HotelRoom Room { get; set; }
    }
}
