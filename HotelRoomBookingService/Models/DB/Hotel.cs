using System;
using System.Collections.Generic;

namespace HotelRoomBookingService.Models.DB
{
    public partial class Hotel
    {
        public Hotel()
        {
            Booking = new HashSet<Booking>();
            BookingDetails = new HashSet<BookingDetails>();
            HotelRoom = new HashSet<HotelRoom>();
            Payment = new HashSet<Payment>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string HotelContact { get; set; }
        public string HotelImage { get; set; }

        public ICollection<Booking> Booking { get; set; }
        public ICollection<BookingDetails> BookingDetails { get; set; }
        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
