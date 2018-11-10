using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingService.Models
{
    public class PaymentService
    {
        HotelRoomBookingDBContext context;

        public PaymentService()
        {
            //this.context = context;
            this.context = new HotelRoomBookingDBContext();
        }


        
        public int MakeBooking(AllData allData)
        {
            Booking booking = new Booking();
            booking.CustomerId = allData.CustomerId;
            booking.Checkin = allData.userinfo.CheckIn;
            booking.Checkout = allData.userinfo.CheckOut;
            booking.HotelId = allData.userinfo.HotelId;
            int days = (allData.userinfo.CheckOut - allData.userinfo.CheckIn).Days+1;
            int sum = 0;
           
            for (int i=0; i<allData.SelectedRooms.Count; i++)
            {
                
                sum += (int)allData.SelectedRooms[i].RoomPrice * days;
            }
            booking.TotalAmount = sum;
            context.Booking.Add(booking);
            context.SaveChanges();


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~




            int Roomcount = allData.SelectedRooms.Count;
            BookingDetails[] bookingDetails = new BookingDetails[Roomcount];
            BookingDetails temp; 

            for( int i=0; i<Roomcount; i++)
            {
                temp = new BookingDetails();
                temp.BookingId = booking.BookingId;
                temp.HotelId = booking.HotelId;
                temp.RoomId = allData.SelectedRooms[i].RoomId;
                temp.Days = days;
                temp.RoomPrice = allData.SelectedRooms[i].RoomPrice;
                bookingDetails[i] = temp;
              //  context.BookingDetails.Add(bookingDetails[i]);
               
            }
            context.BookingDetails.AddRange(bookingDetails);



//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~





            Payment payment = new Payment();
            payment.BookingId = booking.BookingId;
            payment.CustomerId = booking.CustomerId.Value;
            payment.HotelId = booking.HotelId.Value;
            payment.PaymentType = allData.payMode;
            payment.TotalAmount = sum;
            payment.Date = DateTime.Now;


            context.Payment.Add(payment);



//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



            context.SaveChanges();
            return payment.PaymentInvoiceNo;

        }
    }
}
