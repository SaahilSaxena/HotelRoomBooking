using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingService.Controllers.Models
{
    public class AdminService
    {
        HotelRoomBookingDBContext context;

        public AdminService(HotelRoomBookingDBContext context)
        {
            this.context = context;
            //this.context = new HotelRoomBookingDBContext();
        }
      
        public int Authenticate(Credentials credentials)
        {
            var result = (from c in context.Customer
                          where c.Password == credentials.Password && c.Email == credentials.Email

                          select c.CustomerId).FirstOrDefault();
            return result;

        }
        public void AddRecord(Customer c1)
        {
            context.Customer.Add(c1);
            context.SaveChanges();
        }
    
       

       
    }
}
