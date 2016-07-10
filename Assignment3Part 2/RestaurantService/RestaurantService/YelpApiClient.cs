// Code provided by Yelp via Github: https://github.com/Yelp/yelp-api/blob/master/v2/csharp/YelpAPI/Program.cs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SimpleOAuth;
using System.Web;
using Newtonsoft.Json;

namespace RestaurantService
{
    class YelpApiClient
    {
        /// <summary>
        /// Consumer key used for OAuth authentication.
        /// </summary>
        private const string CONSUMER_KEY = "<CONSUMER KEY GOES HERE>";

        /// <summary>
        /// Consumer secret used for OAuth authentication.
        /// </summary>
        private const string CONSUMER_SECRET = "<CONSUMER SECRET GOES HERE>";

        /// <summary>
        /// Token used for OAuth authentication.
        /// </summary>
        private const string TOKEN = "<TOKEN GOES HERE>";

        /// <summary>
        /// Token secret used for OAuth authentication.
        /// </summary>
        private const string TOKEN_SECRET = "<TOKEN SECRET GOES HERE>";

        /// <summary>
        /// Host of the API.
        /// </summary>
        private const string API_HOST = "https://api.yelp.com";

        /// <summary>
        /// Relative path for the Search API.
        /// </summary>
        private const string SEARCH_PATH = "/v2/search/";

        /// <summary>
        /// Relative path for the Business API.
        /// </summary>
        private const string BUSINESS_PATH = "/v2/business/";

        /// <summary>
        /// Search limit that dictates the number of businesses returned.
        /// </summary>
        private const string SEARCH_LIMIT = "20";

        /// <summary>
        /// Yelp API search term
        /// </summary>
        private string YELP_PLACE_TYPE = "restaurant";

        /// <summary>
        /// Prepares OAuth authentication and sends the request to the API.
        /// </summary>
        /// <param name="baseURL">The base URL of the API.</param>
        /// <param name="queryParams">The set of query parameters.</param>
        /// <returns>The JSON response from the API mapped to a Yelp places object.</returns>
        /// <exception>Throws WebException if there is an error from the HTTP request.</exception>
        private YelpPlaces PerformRequest(string baseURL, Dictionary<string, string> queryParams = null)
        {
            var query = System.Web.HttpUtility.ParseQueryString(String.Empty);

            if (queryParams == null)
            {
                queryParams = new Dictionary<string, string>();
            }

            foreach (var queryParam in queryParams)
            {
                query[queryParam.Key] = queryParam.Value;
            }

            var uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Query = query.ToString();

            var request = WebRequest.Create(uriBuilder.ToString());
            request.Method = "GET";

            request.SignRequest(
                new Tokens
                {
                    ConsumerKey = CONSUMER_KEY,
                    ConsumerSecret = CONSUMER_SECRET,
                    AccessToken = TOKEN,
                    AccessTokenSecret = TOKEN_SECRET
                }
            ).WithEncryption(EncryptionMethod.HMACSHA1).InHeader();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            YelpPlaces ypr = (YelpPlaces)JsonConvert.DeserializeObject<YelpPlaces>(stream.ReadToEnd());
            return ypr;
        }

        /// <summary>
        /// Query the Search API by a search term and location.
        /// </summary>
        /// <param name="location">The search location passed to the API.</param>
        /// <returns>The JSON response from the API.</returns>
        public YelpPlaces Search(Location location)
        {
            string baseURL = API_HOST + SEARCH_PATH;
            var queryParams = new Dictionary<string, string>()
            {
                { "term" , YELP_PLACE_TYPE },
                {"ll", location.latitude + "," + location.longitude }
            };
            return PerformRequest(baseURL, queryParams);
        }

        /// <summary>
        /// Query the Business API with the business' name.
        /// </summary>
        /// <param name="baseURL">The search location passed to the API.</param>
        /// <returns>The JSON response from the API mapped to a Yelp Business object</returns>
        private YelpBusiness SearchBusiness(string baseURL)
        {
            var query = System.Web.HttpUtility.ParseQueryString(String.Empty);

            var uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Query = query.ToString();

            var request = WebRequest.Create(uriBuilder.ToString());
            request.Method = "GET";

            request.SignRequest(
                new Tokens
                {
                    ConsumerKey = CONSUMER_KEY,
                    ConsumerSecret = CONSUMER_SECRET,
                    AccessToken = TOKEN,
                    AccessTokenSecret = TOKEN_SECRET
                }
            ).WithEncryption(EncryptionMethod.HMACSHA1).InHeader();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            YelpBusiness ypr = (YelpBusiness)JsonConvert.DeserializeObject<YelpBusiness>(stream.ReadToEnd());
            return ypr;
        }

        /// <summary>
        /// Query the Business API by a business ID.
        /// </summary>
        /// <param name="business_id">The ID of the business to query.</param>
        /// <returns>The JSON response from the API.</returns>
        public YelpBusiness GetBusiness(string business_id)
        {
            string baseURL = API_HOST + BUSINESS_PATH + business_id;
            return SearchBusiness(baseURL);
        }


        private YelpPlaces GetYelpInfo(string baseURL, Dictionary<string, string> queryParams = null)
        {
            var query = System.Web.HttpUtility.ParseQueryString(String.Empty);

            if (queryParams == null)
            {
                queryParams = new Dictionary<string, string>();
            }

            foreach (var queryParam in queryParams)
            {
                query[queryParam.Key] = queryParam.Value;
            }

            var uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Query = query.ToString();

            var request = WebRequest.Create(uriBuilder.ToString());
            request.Method = "GET";

            request.SignRequest(
                new Tokens
                {
                    ConsumerKey = CONSUMER_KEY,
                    ConsumerSecret = CONSUMER_SECRET,
                    AccessToken = TOKEN,
                    AccessTokenSecret = TOKEN_SECRET
                }
            ).WithEncryption(EncryptionMethod.HMACSHA1).InHeader();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            YelpPlaces ypr = (YelpPlaces)JsonConvert.DeserializeObject<YelpPlaces>(stream.ReadToEnd());
            return ypr;
        }

        /// <summary>
        /// Query the Search API by a search term and location.
        /// </summary>
        /// <param name="term">The search location passed to the API.</param>
        /// <param name="city">The search location passed to the API.</param>
        /// <returns>The JSON response from the API.</returns>
        public YelpPlaces SearchYelpInfo(string term, string city)
        {
            string baseURL = API_HOST + SEARCH_PATH;
            var queryParams = new Dictionary<string, string>()
            {
                { "term" , term },
                { "location", city },
                { "limit", "1" }
            };
            return GetYelpInfo(baseURL, queryParams);
        }
    }
}
