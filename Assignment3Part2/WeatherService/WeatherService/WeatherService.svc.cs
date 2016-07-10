using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace WeatherService
{
    public class Service1 : IWeatherService
    {
        private string apiKey1 = "";
        private string apiKey2 = "";
        private string zip = "";

        public Weather GetWeather(string zipCode)
        {
            zip = "q=" + zipCode;
            Weather weather = new Weather();
            var key = GetLocationKey(zipCode);
            weather = GetAccuWeather(key);
            return weather;
        }

        // Gets the Accuweather location key for the specified zip code
        private string GetLocationKey(string zipCode)
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString("http://dataservice.accuweather.com/locations/v1/search?" + apiKey1 + zip);
                Trace.WriteLine(json);
                try
                {
                    // Converts the json to a list of Location objects using JSON.NET
                    var location = JsonConvert.DeserializeObject<List<Location>>(json);
                    var locationKey = location.ElementAt(0).Key;
                    return locationKey;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
            }
            return String.Empty;
        }

        private Weather GetAccuWeather(string key)
        {
            Weather weather = new Weather();

            using (var client = new WebClient())
            {
                var json = client.DownloadString("http://dataservice.accuweather.com/forecasts/v1/daily/5day/" + key + apiKey2 );
                Trace.WriteLine(json);
                try
                {
                    // Converts the json to a Weather objects using JSON.NET
                    weather = JsonConvert.DeserializeObject<Weather>(json);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
            }
            return weather;
        }
    }
}
