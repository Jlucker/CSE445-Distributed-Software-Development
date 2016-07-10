using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Assignment3Part1
{
    public class Restaurants
    {

        [JsonProperty("restaurants")]
        public Restaurant[] restaurants { get; set; }
    }

    public class Restaurant
    {

        [JsonProperty("ContainsBoth")]
        public string ContainsBoth { get; set; }

        [JsonProperty("restaurantAddress")]
        public string RestaurantAddress { get; set; }

        [JsonProperty("restaurantCity")]
        public string RestaurantCity { get; set; }

        [JsonProperty("restaurantImageUrl")]
        public string RestaurantImageUrl { get; set; }

        [JsonProperty("restaurantName")]
        public string RestaurantName { get; set; }

        [JsonProperty("restaurantPrice")]
        public string RestaurantPrice { get; set; }

        [JsonProperty("yelpRating")]
        public string YelpRating { get; set; }

        [JsonProperty("yelpRatingImageUrl")]
        public string YelpRatingImageUrl { get; set; }

        [JsonProperty("yelpUrl")]
        public string YelpUrl { get; set; }

        [JsonProperty("zomatoRating")]
        public string ZomatoRating { get; set; }

        [JsonProperty("zomatoUrl")]
        public string ZomatoUrl { get; set; }
    }
}