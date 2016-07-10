using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace RestaurantService
{
    class ZomatoApiClient
    {
        /// <summary>
        /// Consumer key used for authentication.
        /// </summary>
        private const string ZOMATO_API_KEY = "<ZOMATO API KEY GOES HERE>";

        /// <summary>
        /// Host of the API.
        /// </summary>
        private const string API_HOST = "https://developers.zomato.com";

        /// <summary>
        /// Relative path for the Search API.
        /// </summary>
        private const string SEARCH_PATH = "/api/v2.1/search?";

        /// <summary>
        /// Radius that the API should search in.
        /// </summary>
        private const string RADIUS = "&radius=5000";

        /// <summary>
        /// Number of results to return
        /// </summary>
        private const string COUNT = "count=10";

        /// <summary>
        /// Order the results by rating.
        /// </summary>
        private const string RATING = "&sort=rating";

        /// <summary>
        /// Prepares OAuth authentication and sends the request to the API.
        /// </summary>
        /// <param name="latitude">The latitiude value for the search</param>
        /// <param name="longitude">The longitude value for the search.</param>
        /// <returns>The JSON response from the API mapped to a ZomatoPlaces object.</returns>
        private ZomatoPlaces PerformRequest(string latitude, string longitude)
        {
            HttpWebRequest webRequest = WebRequest.Create(API_HOST + SEARCH_PATH + COUNT + "&lat=" + latitude + "&lon=" + longitude + RADIUS + RATING)as HttpWebRequest;
            HttpWebResponse webResponse = null;
            //webRequest.Headers.Add("Accept:", "application/json");
            webRequest.Headers.Add("user-key", ZOMATO_API_KEY);
            webRequest.Method = "GET";
            webResponse = (HttpWebResponse)webRequest.GetResponse();
            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                var jsonStr = responseReader.ReadToEnd();
                ZomatoPlaces zpr = (ZomatoPlaces)JsonConvert.DeserializeObject<ZomatoPlaces>(jsonStr);
                return zpr;
            }
            else
            {
                ZomatoPlaces zpr = new ZomatoPlaces();
                zpr.ResultsFound = 0;
                return zpr;
            }
        }

        public ZomatoPlaces Search(Location location)
        {
            return PerformRequest(location.latitude, location.longitude);
        }
    }
}
