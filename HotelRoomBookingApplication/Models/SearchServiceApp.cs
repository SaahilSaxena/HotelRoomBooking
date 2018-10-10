using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                        Selected=false
            }).ToList();
            return result;

        }
    }
}
