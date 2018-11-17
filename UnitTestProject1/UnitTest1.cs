using HotelRoomBookingLibrary;
using HotelRoomBookingService.Controllers;
using HotelRoomBookingService.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomServiceTests
{
    [TestClass]
    public class SearchTests
    {
        static int PaymentInvoiceNo=0, CustomerId=0;
        AdminServiceController controller1;
        static HotelRoomBookingDBContext context;
        SearchServiceController controller;
        PaymentServiceController controller2;
        public SearchTests()
        {

            context = new HotelRoomBookingDBContext();
            controller = new SearchServiceController();
            controller1 = new AdminServiceController(context);
            controller2 = new PaymentServiceController();
        }






        //------------Test for Login--------------------------------------------------------



        //null reference exception for email and password should be done seperately.



        //  [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestForLoginNullRefError()
        {
            Credentials obj = new Credentials()
            {
                Email = "ankita@ankita.com",
                Password = "ankita@123"
            };
            var result = controller1.Authenticate(obj);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            obj.Email = "ankita@ankita.com";
            obj.Password = "ankita@123456";

             result = controller1.Authenticate(obj);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }



        




        //--------------Test for SignUp-------------------------------------------------------


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestForSUNullRefError()
        {
            var result = controller1.NewCustomer(null);
            //Assert.IsInstanceOfType(result, typeof(Customer));
            //          Assert.IsNotNull(result);

        }




        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void TestForSignUpException()
        {
            Customer c1 = new Customer();
            controller1.NewCustomer(c1);
        }



        [TestMethod]
        public void TestForCustomerList()
        {

            Customer c1 = new Customer()
            {
                CustomerName = "Ankita Sharma",
                CustomerContact = "8630964990",
                City = "Meerut",
                Password = "ankita@123",
                Email = "ankita@ankita.com",

            };
            var result = controller1.NewCustomer(c1);

            Assert.IsInstanceOfType(result, typeof(OkResult));

        }


        //~~~~~~~~~~~~~~~~Test for Searching ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [TestMethod]
        public void TestForGetCitiesNullRefError()
        {
            var result = controller.GetCities();
            Assert.IsInstanceOfType(result, typeof(List<string>));
            Assert.IsNotNull(result);
        }





        //--------------Test for Selection of Rooms-----------------------------------






        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void TestForHotelDetailsException()
        {
            HotelSearchDetails details = new HotelSearchDetails();
            controller.GetRooms(details);
        }



        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestForHotelDetailsNullRefError()
        {
            var result = controller.GetRooms(null);
            Assert.IsInstanceOfType(result, typeof(List<SelectedRooms>));
        }




        [TestMethod]
        public void TestForHotelDetailsList()
        {
            HotelSearchDetails details = new HotelSearchDetails()
            {
                HotelId = 500,
                CheckIn = DateTime.Parse("11/2/2018"),
                CheckOut = DateTime.Parse("11/12/2018"),
                Ac = true,
                Wifi = true
            };
            var result = controller.GetRooms(details);
            Assert.IsInstanceOfType(result, typeof(List<SelectedRooms>));


        }


        //~~~~~~~~~~~~~~~~~~~~~Test for Payment Service~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        [TestMethod]

        public void TestForMakeBooking()
        {
            HotelSearchDetails obj = new HotelSearchDetails();

            obj.CheckIn = DateTime.Parse("2018-11-17");
            obj.CheckOut = DateTime.Parse("2018-11-19");
            obj.Ac = false;
            obj.Wifi = false;
            obj.HotelId = 510;

            SelectedRoomsViewModel list = new SelectedRoomsViewModel();
            
                list.RoomPrice = 3500;
                list.HotelContact = "9876234546";
                list.HotelName = "Hotel Wow";
                list.RoomId = 219;
                list.City = "Indore";
            
           

            AllData data = new AllData();
            
                data.CustomerId = 104;
                data.payMode = "DC";
                data.SelectedRooms = new List<SelectedRoomsViewModel>() { list };
                data.userinfo = obj;
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            var result = (OkObjectResult)controller2.BookingDetails(data);
            PaymentInvoiceNo = (int)result.Value;
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));




        }

        [ClassCleanup]
        public static void CleanUp()
        {
            if (CustomerId != 0)
            {
                var customer = context.Customer.SingleOrDefault(c => c.CustomerId == CustomerId);
                // var details = context.SelectedRooms.SingleOrDefault(s => s.HotelId == HotelId);
             
                context.Customer.Remove(customer);
                // context.SelectedRooms.Remove(details);
                context.SaveChanges();
            }
            if(PaymentInvoiceNo!=0)
            {
                var bookingid=context.Payment.Where(c => c.PaymentInvoiceNo == PaymentInvoiceNo).Select(c => c.BookingId).FirstOrDefault();
                var booking = context.Booking.SingleOrDefault(b => b.BookingId == bookingid);
                var bookingdetails = context.BookingDetails.Where(d => d.BookingId == bookingid).ToArray();
                context.BookingDetails.RemoveRange(bookingdetails);
                var payment = context.Payment.SingleOrDefault(p => p.PaymentInvoiceNo == PaymentInvoiceNo);
                context.Payment.Remove(payment);
                context.Booking.Remove(booking);
              
                
                context.SaveChanges();
            }
       

        }

    }
}


