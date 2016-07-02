namespace PremierLeagueApp.Web.Controllers
{
    using System.Web.Mvc;

    using Crawler;

    public class TableController : BaseController
    {
        [OutputCache(Duration = 60 * 5)]
        public ActionResult Index()
        {
            var standing = TeamsInfo.GetTableInfo();
            return this.View(standing);
        }
    }
}
