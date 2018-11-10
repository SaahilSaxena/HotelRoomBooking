using HotelRoomBookingLibrary;
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

        public int FinalBooking(string payMode) {

            int InvoiceNumber;

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
            InvoiceNumber = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);
            return InvoiceNumber;

            //-----------------------------------------------------------------




            //HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");





        }
    }
}
