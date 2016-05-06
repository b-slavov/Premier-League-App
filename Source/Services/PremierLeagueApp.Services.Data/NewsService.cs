namespace PremierLeagueApp.Services.Data
{
    using System.Linq;

    using PremierLeagueApp.Data.Common;
    using PremierLeagueApp.Data.Models;
    using PremierLeagueApp.Services.Web;

    public class NewsService : INewsService
    {
        private readonly IDbRepository<News> news;
        private readonly IIdentifierProvider identifierProvider;

        public NewsService(IDbRepository<News> news, IIdentifierProvider identifierProvider)
        {
            this.news = news;
            this.identifierProvider = identifierProvider;
        }

        public News GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var news = this.news.GetById(intId);
            return news;
        }

        public IQueryable<News> GetNews(int count)
        {
            return this.news.All().OrderBy(x => x.CreatedOn).Take(count);
        }
    }
}
