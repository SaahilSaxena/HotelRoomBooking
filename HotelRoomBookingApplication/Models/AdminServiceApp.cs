using HotelRoomBookingLibrary;
using HotelRoomBookingService.Models.DB;
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
    public class AdminServiceApp
    {
        HttpClient client;
        public AdminServiceApp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61606/");
        }
        //comment 2
      //comment 3

        public int Login(Credentials credentials)
        {
            string customerId;
            string json = JsonConvert.SerializeObject(credentials);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Admin/Authenticate", content).Result;
            if (response.IsSuccessStatusCode == true)
            {
                customerId = response.Content.ReadAsStringAsync().Result;
                return 1;
            }
            else
            
                return 0;
            }

            public int AddRecord(Customer customer)
            {
              
                string json = JsonConvert.SerializeObject(customer);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("Admin/NewCustomer", content).Result;
                if (response.IsSuccessStatusCode == true)
                {
                  string  CustomerId = response.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                
                
                    return 0;
                
            }
        }
    }
