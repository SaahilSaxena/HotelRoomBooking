using HotelRoomBookingService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingService.InvoiceInfo
{
    public class InvoiceData
    {
        public Customer customer { get; set; }
        public int InvoiceNo { get; set; }
    }
}
