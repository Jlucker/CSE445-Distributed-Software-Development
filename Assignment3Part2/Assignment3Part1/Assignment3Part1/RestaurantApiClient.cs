using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace Assignment3Part1
{
    public class RestaurantApiClient
    {
        /// <summary>
        /// Restaurant service URL
        /// </summary>
        private string BASE_URL = "http://localhost:3394/RestaurantService.svc/restaurants/";

        private Restaurants GetRestaurants(string postalCode)
        {
            using (WebResponse response = WebRequest.Create(BASE_URL + postalCode).GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    Restaurants restaurants = (Restaurants)JsonConvert.DeserializeObject<Restaurants>(reader.ReadToEnd());
                    return restaurants;
                }
            }
        }

        public Restaurants Search(string postalCode)
        {
            return GetRestaurants(postalCode);
        }
    }
}