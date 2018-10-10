using HotelRoomBookingLibrary;
using HotelRoomBookingService.Controllers;
using HotelRoomBookingService.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HotelRoomServiceTests
{
    [TestClass]
    public class SearchTests
    {
        AdminServiceController controller1;
        HotelRoomBookingDBContext context;
        SearchServiceController controller;
        public SearchTests()
        {
           
            context = new HotelRoomBookingDBContext();
            controller = new SearchServiceController();
            controller1 = new AdminServiceController(context);
        }


//--------------Test for Searching-----------------------------------






        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void TestForHotelException()
        {
            HotelSearchDetails details = new HotelSearchDetails();
            controller.GetRooms(details);
        }



        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestForHotelNullRefError()
        {
            var result = controller.GetRooms(null);
            Assert.IsInstanceOfType(result, typeof(List<SelectedRooms>));
        }




        [TestMethod]
        public void TestForHotelList()
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




//------------Test for Login--------------------------------------------------------




        


        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestForLoginNullRefError()
        {
            var result = controller1.Authenticate(null);
            // Assert.IsInstanceOfType(result, typeof(Credentials));
            Assert.IsNotNull(result);
        }





//--------------Test for SignUp-------------------------------------------------------


        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestForSUNullRefError()
        {
            var result = controller1.NewCustomer(null);
            Assert.IsInstanceOfType(result, typeof(Customer));
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
                Password = "ankita@6",
                 Email="xyz@xyz.com",
                  
            };
            var result = controller1.NewCustomer(c1);
           
            Assert.IsInstanceOfType(result, typeof(OkResult));

        }
    }


}


