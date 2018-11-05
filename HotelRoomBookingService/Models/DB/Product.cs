﻿using System;
using System.Collections.Generic;

namespace HotelRoomBookingService.Models.DB
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Price { get; set; }
        public string ProductImage { get; set; }
        public string SupplierName { get; set; }
    }
}