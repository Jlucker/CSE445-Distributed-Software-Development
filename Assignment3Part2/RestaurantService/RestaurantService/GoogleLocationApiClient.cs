using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocoding;
using Geocoding.Google;

namespace RestaurantService
{
    public class GoogleLocationApiClient
    {
        /// <summary>
        /// Consumer key used for Google Places API authentication.
        /// </summary>
        private string GOOGLE_API_KEY = "<GOOGLE API KEY GOES HERE>";

        /// <summary>
        /// Sends the request to the Google Places API.
        /// </summary>
        /// <param location="location">The address or zip of the customer.</param>
        /// <returns>The Location object that contains the results of the Google Location API call.</returns>
        public Location GetLocation(string location)
        {
            Location loc = new Location();
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = GOOGLE_API_KEY };
            IEnumerable<Address> addresses = geocoder.Geocode(location);
            loc.address = "Formatted: " + addresses.First().FormattedAddress;
            loc.latitude = addresses.First().Coordinates.Latitude.ToString();
            loc.longitude = addresses.First().Coordinates.Longitude.ToString();
      
            return loc;
        }
    }

    public class Location
    {
        public string latitude = "";
        public string longitude = "";
        public string address = "";
    }
}
