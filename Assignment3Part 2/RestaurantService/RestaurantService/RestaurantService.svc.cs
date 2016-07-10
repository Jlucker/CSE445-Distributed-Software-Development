using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        //[WebGet(UriTemplate = "restaurants/{postalCode}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public RestaurantData GetRestaurants(string postalCode)
        {
            RestaurantData rData = new RestaurantData();

            // Get the location data from Googles location services
            Location location = new Location();
            location.address = postalCode;
            location = GetLocation(location);

            // Get the Zomato results from the Zomato API
            ZomatoPlaces zPlaces = GetZomatoResutls(location);

            // Combine the Zomato data with yelp data
            rData = CombineRestaurants(zPlaces);

            return rData;
        }

        private Location GetLocation(Location location)
        {
            GoogleLocationApiClient client = new GoogleLocationApiClient();
            return client.GetLocation(location.address);
        }

        private ZomatoPlaces GetZomatoResutls(Location location)
        {
            ZomatoApiClient client = new ZomatoApiClient();
            ZomatoPlaces response = client.Search(location);
            return response;
        }

        private RestaurantData CombineRestaurants(ZomatoPlaces zPlaces)
        {
            RestaurantData rData = new RestaurantData();

            foreach (var place in zPlaces.Restaurants)
            {
                RestaurantPlace rPlace = new RestaurantPlace();

                // Set the Restaurant object data to the Zomato data
                rPlace.restaurantName = place.RestaurantInfo.Name;
                rPlace.restaurantAddress = place.RestaurantInfo.Location.Address;
                rPlace.restaurantCity = place.RestaurantInfo.Location.City;
                rPlace.zomatoRating = place.RestaurantInfo.UserRating.AggregateRating;
                rPlace.zomatoUrl = place.RestaurantInfo.Url;
                rPlace.restaurantPrice = place.RestaurantInfo.PriceRange.ToString();

                // If Zomato has a picture, get its URL
                if (!string.IsNullOrEmpty(place.RestaurantInfo.FeaturedImage))
                {
                    rPlace.restaurantImageUrl = place.RestaurantInfo.FeaturedImage;
                }

                rPlace = GetYelpData(rPlace);
                rData.restaurants.Add(rPlace);
            }
            return rData;
        }

        // Takes the results from Zomato and adds information from Yelp
        private RestaurantPlace GetYelpData (RestaurantPlace rPlace)
        {
            YelpApiClient client = new YelpApiClient();
            var yelpResult = client.SearchYelpInfo(rPlace.restaurantName, rPlace.restaurantCity);

            if (yelpResult.Businesses.Length > 0)
            {
                var yr = yelpResult.Businesses[0];
                rPlace.yelpRating = yr.Rating;
                rPlace.yelpUrl = yr.Url;
                rPlace.yelpRatingImageUrl = yr.RatingImgUrl;

                // If Zomato didn't have a picture then it checks yelp for one
                if (string.IsNullOrEmpty(rPlace.restaurantImageUrl))
                {
                    if (!string.IsNullOrEmpty(yr.ImageUrl))
                    {
                        rPlace.restaurantImageUrl = yr.ImageUrl;
                    }
                }

                rPlace.ContainsBoth = "true";
                return rPlace;
            }
            else
            {
                rPlace.ContainsBoth = "false";
                return rPlace;
            }
        }
    }
}
