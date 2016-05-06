namespace PremierLeagueApp.Services.Data
{
    using System.Linq;

    using PremierLeagueApp.Data.Models;

    public interface INewsService
    {
        IQueryable<News> GetNews(int count);

        News GetById(string id);
    }
}
