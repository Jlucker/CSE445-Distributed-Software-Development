using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace NewsService
{
    public class Service1 : INewsService
    {
        private string apiKey = "866265ad-1eeb-4cd4-bb99-9b7225c00d77";
        private string url = "http://content.guardianapis.com/search?order-by=newest&q=";

        public NewsList GetNews(string topic)
        {
            NewsList newsList = new NewsList();

            var topics = ProcessTopic(topic);

            for (int i = 0; i < topics.Length; i++)
            {
                NewsItem news = new NewsItem();
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(url + topic + "&api-key=" + apiKey);
                    Trace.WriteLine(json);
                    try
                    {
                        news = JsonConvert.DeserializeObject<NewsItem>(json);
                        newsList.AddNews(news);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e);
                    }
                }
            }
            Trace.WriteLine(newsList.newsList.Count);
            return newsList;
        }

        private string[] ProcessTopic(string topic)
        {
            char delimiterChar = ' ';
            string[] parts = topic.Split(delimiterChar);
            return parts;
        }
    }
}

