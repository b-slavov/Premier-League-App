namespace PremierLeagueApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using PagedList;

    using PremierLeagueApp.Services.Data;
    using PremierLeagueApp.Web.Infrastructure.Mapping;
    using PremierLeagueApp.Web.ViewModels.Home;
    using Crawler;
    public class HomeController : BaseController
    {
        private const int PageSize = 12;

        private readonly INewsService news;

        public HomeController(INewsService news, IClubService clubs)
        {
            this.news = news;
        }

        public ActionResult Index(int page = 1)
        {
            var news = this.news.GetNews().To<NewsViewModel>().ToList().ToPagedList(page, PageSize);
            return this.View(news);
        }

        public ActionResult Search(string query, int page = 1)
        {
            var news = this.news
                    .GetNews()
                    .To<NewsViewModel>()
                    .AsQueryable()
                    .Where(n => n.Title.ToLower().Contains(query.ToLower()))
                    .ToList()
                    .ToPagedList(page, PageSize);

            return this.PartialView("_NewsResult", news);
        }
    }
}
