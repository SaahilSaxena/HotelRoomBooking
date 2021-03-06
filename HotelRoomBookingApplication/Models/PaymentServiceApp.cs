﻿using HotelRoomBookingLibrary;
using HotelRoomBookingService.InvoiceInfo;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomBookingApplication.Models
{
    public class PaymentServiceApp
    {
        HttpClient client;
        public HttpContext context;
        public PaymentServiceApp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61606");
        }

        public InvoiceData FinalBooking(string payMode)
        {

           

            int CustomerId = context.Session.GetInt32("CustomerId").Value;//it is nullable type

            string sessionRooms = context.Session.GetString("selectedRoomList");
            List<SelectedRoomsViewModel> FinalRooms = JsonConvert.DeserializeObject<List<SelectedRoomsViewModel>>(sessionRooms);


            string sessionUserInfo = context.Session.GetString("userSearchData");
            HotelSearchDetails FinalUserInfo = JsonConvert.DeserializeObject<HotelSearchDetails>(sessionUserInfo);

            AllData allData = new AllData();
            allData.CustomerId = CustomerId;
            allData.SelectedRooms = FinalRooms;
            allData.userinfo = FinalUserInfo;
            allData.payMode = payMode;

            string json = JsonConvert.SerializeObject(allData);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Payment/MakeBooking", content).Result;
            string data = response.Content.ReadAsStringAsync().Result;
            InvoiceData InvoiceInfo = (InvoiceData)JsonConvert.DeserializeObject<InvoiceData>(data);
            
            return InvoiceInfo;

           

            //-----------------------------------------------------------------

        }

       
        public void storeSelectedRoomsToSession(HttpContext context, List<SelectedRoomsViewModel> rooms)
        {

            string sel_obj = JsonConvert.SerializeObject(rooms);
            context.Session.SetString("selectedRoomList", sel_obj);
        }
        public List<SelectedRoomsViewModel> GetSelectedRooms(HttpContext context)
        {
            string selectedroomstring = context.Session.GetString("selectedRoomList");

            List<SelectedRoomsViewModel> rooms = JsonConvert.DeserializeObject<List<SelectedRoomsViewModel>>(selectedroomstring);
            return rooms;
        }



        public void UserSearchInfo(HttpContext context, HotelSearchDetails details)
        {

            string avail_obj = JsonConvert.SerializeObject(details);
            context.Session.SetString("userSearchData", avail_obj);
        }

        public HotelSearchDetails GetUserInfo(HttpContext context)
        {
            string roomstring = context.Session.GetString("userSearchData");

            HotelSearchDetails UserInfo = JsonConvert.DeserializeObject<HotelSearchDetails>(roomstring);
            return UserInfo;
        }

        






    }
}
