using Classwork_19._01._24_cookiesUsage_.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace Classwork_19._01._24_cookiesUsage_.Repositories
{
    public class NewsRepository
    {
        private readonly List<News> news;

        public NewsRepository() {
            news = new List<News>()
            {
                new News() {Id = 1, Name = "Creatures in nature", Content = "Want to see more, let it be..."},
                new News() {Id = 2, Name = "Politics today", Content = "How world has changed after the conflict..."},
                new News(){Id = 3, Name = "Science nowadays", Content="How science had changed us..."},
            };
        }
        public List<News> GetAllNews()
        {
            return news;
        }
        
        public News GetNewsById(int id)
        {
            return news.FirstOrDefault(e => e.Name.Equals(id));
        }
    }
}
