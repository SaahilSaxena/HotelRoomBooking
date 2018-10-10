using System;
using System.Collections.Generic;

namespace HotelRoomBookingService.Models.DB
{
    public partial class Payment
    {
        public int? BookingId { get; set; }
        public int? CustomerId { get; set; }
        public string PaymentType { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int PaymentInvoiceNo { get; set; }

        public Booking Booking { get; set; }
        public Customer Customer { get; set; }
    }
}
