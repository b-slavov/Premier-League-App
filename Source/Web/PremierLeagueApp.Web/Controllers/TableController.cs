namespace PremierLeagueApp.Web.Controllers
{
    using System.Web.Mvc;

    public class TableController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
