using System;
using System.Collections.Generic;

namespace HotelRoomBookingService.Models.DB
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetails>();
            Payment = new HashSet<Payment>();
        }

        public int BookingId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int? HotelId { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
        public Hotel Hotel { get; set; }
        public ICollection<BookingDetails> BookingDetails { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
