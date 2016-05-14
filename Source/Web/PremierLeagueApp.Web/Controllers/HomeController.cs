namespace PremierLeagueApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using PagedList;

    using PremierLeagueApp.Services.Data;
    using PremierLeagueApp.Web.Infrastructure.Mapping;
    using PremierLeagueApp.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly INewsService news;
        private readonly IClubService clubs;

        public HomeController(INewsService news, IClubService clubs)
        {
            this.news = news;
            this.clubs = clubs;
        }

        public ActionResult Index(int page = 1)
        {
            const int pageSize = 12;

            var news = this.news.GetNews().To<NewsViewModel>().ToList().ToPagedList(page, pageSize);

            return this.View(news);
        }
    }
}
