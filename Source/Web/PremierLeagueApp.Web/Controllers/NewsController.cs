namespace PremierLeagueApp.Web.Controllers
{
    using System.Web.Mvc;

    using PremierLeagueApp.Services.Data;
    using PremierLeagueApp.Web.ViewModels.Home;

    public class NewsController : BaseController
    {
        private readonly INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        public ActionResult ById(string id)
        {
            var news = this.news.GetById(id);
            var viewModel = this.Mapper.Map<NewsViewModel>(news);
            return this.View(viewModel);
        }
    }
}
