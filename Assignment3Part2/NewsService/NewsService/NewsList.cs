using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsService
{
    public class NewsList
    {
        public List<NewsItem> newsList = new List<NewsItem>();

        public void AddNews(NewsItem news)
        {
            newsList.Add(news);
        }
    }
}
