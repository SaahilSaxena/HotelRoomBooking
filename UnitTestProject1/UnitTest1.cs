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
        static int PaymentInvoiceNo;
        AdminServiceController controller1;
        HotelRoomBookingDBContext context;
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



        //[TestMethod]

        //public void AuthenticateTestMethod()
        //{
        //    //Arrange
        //    string email;
        //    Credentials obj = new Credentials()
        //    {
        //        Email = "testmail@gmail.com",
        //        Password = "123"
        //    };
        //    //Act
        //    email = controller.Authenticate(obj);
        //    //Assert
        //    Assert.IsNotNull(email);
        //}





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
           
            SelectedRoomsViewModel list = new SelectedRoomsViewModel();
            
                list.RoomPrice = 7800;
                list.HotelContact = "8877887787";
                list.HotelName = "Hyatt Regency";
                list.RoomId = 214;
                list.City = "Delhi";
            
            HotelSearchDetails obj = new HotelSearchDetails();
            
                obj.CheckIn = DateTime.Parse("2018-11-15");
                obj.CheckOut = DateTime.Parse("2018-11-17");
                obj.Ac = false;
                obj.Wifi = false;
                obj.HotelId = 503;


            AllData data = new AllData();
            
                data.CustomerId = 104;
                data.payMode = "DC";
                data.SelectedRooms = new List<SelectedRoomsViewModel>() { list };
                data.userinfo = obj;
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            var result = controller2.BookingDetails(data);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));




        }
        
        //[ClassCleanup]
        //public static void CleanUp()
        //{

        //}

    }
}


