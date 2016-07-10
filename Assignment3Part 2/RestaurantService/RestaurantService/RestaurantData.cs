using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantService
{
    public class RestaurantPlace
    {
        public string restaurantName = string.Empty;
        public string restaurantAddress = string.Empty;
        public string restaurantPrice = string.Empty;
        public string restaurantCity = string.Empty;
        public string yelpRating = string.Empty;
        public string yelpRatingImageUrl = string.Empty;
        public string yelpUrl = string.Empty;
        public string zomatoRating = string.Empty;
        public string zomatoUrl = string.Empty;
        public string restaurantImageUrl = string.Empty;
        public string ContainsBoth = string.Empty;
    }
    public class RestaurantData
    {
        public List<RestaurantPlace> restaurants = new List<RestaurantPlace>(); 
    }
}