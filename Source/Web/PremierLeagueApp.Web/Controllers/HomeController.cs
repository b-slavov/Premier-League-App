namespace PremierLeagueApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly INewsService news;
        private readonly IClubService clubs;

        public HomeController(INewsService news, IClubService clubs)
        {
            this.news = news;
            this.clubs = clubs;
        }

        public ActionResult Index()
        {
            var news = this.news.GetNews(12).To<NewsViewModel>().ToList();
            var clubs =
                this.Cache.Get(
                    "clubs",
                    () => this.clubs.GetAll().To<ClubViewModel>().ToList(),
                    30 * 60);
            var viewModel = new IndexViewModel
            {
                News = news,
                Clubs = clubs
            };

            return this.View(viewModel);
        }
    }
}
