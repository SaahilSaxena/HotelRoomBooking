using System;
using System.Collections.Generic;

namespace HotelRoomBookingService.Models.DB
{
    public partial class Customer
    {
        public Customer()
        {
            Booking = new HashSet<Booking>();
            Payment = new HashSet<Payment>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Password { get; set; }

        public ICollection<Booking> Booking { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
