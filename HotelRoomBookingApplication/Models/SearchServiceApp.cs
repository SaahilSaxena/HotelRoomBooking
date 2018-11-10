using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRoomBookingApplication.Models
{

    public class SearchServiceApp
    {
        HttpClient client;
       
        public SearchServiceApp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61606");
        }

        public List<string> GetCities()
        {

            HttpResponseMessage response = client.GetAsync("Admin/Cities").Result;
            //HttpResponseMessage response = client.GetAsync("Search/getCities").Result;
            string json = response.Content.ReadAsStringAsync().Result;
            List<string> cities = JsonConvert.DeserializeObject<List<string>>(json);
            return cities;

        }

        public List<Hotel> GetHotels()
        {

            HttpResponseMessage response = client.GetAsync("Admin/Hotels").Result;
            string json = response.Content.ReadAsStringAsync().Result;
            List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
            return hotels;

        }
        public List<SelectedRoomsViewModel> GetRooms(HotelSearchDetails details)
        {
            string json = JsonConvert.SerializeObject(details);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Admin/SelectedRooms", content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            List<SelectedRooms> rooms = JsonConvert.DeserializeObject<List<SelectedRooms>>(json);
            var result = (from r in rooms select new SelectedRoomsViewModel() {
                 City=r.City,
                  HotelContact=r.HotelContact,
                    HotelId=r.HotelId,
                     HotelName=r.HotelName,
                      RoomId=r.RoomId,
                       RoomPrice=r.RoomPrice,
                        //CheckIn = r.CheckIn,
                         //CheckOut = r.CheckOut,
                          HotelImage=r.HotelImage,
                        Selected=false
            }).ToList();
            return result;

        }
       public void storeSelectedRoomsToSession(HttpContext context, List<SelectedRoomsViewModel> rooms )
        {
            
            string sel_obj = JsonConvert.SerializeObject(rooms);
            context.Session.SetString("selectedRoomList", sel_obj);
        }

        public void UserSearchInfo(HttpContext context, HotelSearchDetails details)
        {

            string avail_obj = JsonConvert.SerializeObject(details);
            context.Session.SetString("userSearchData", avail_obj);
        }

        public HotelSearchDetails GetUserInfo(HttpContext context)
        {
            //HttpResponseMessage response = client.GetAsync("Admin/SelectedRooms").Result;
            //string json = response.Content.ReadAsStringAsync().Result;

            string roomstring = context.Session.GetString("userSearchData");

            HotelSearchDetails UserInfo = JsonConvert.DeserializeObject<HotelSearchDetails>(roomstring);
            return UserInfo;
        }
    }
}
