namespace PremierLeagueApp.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using PremierLeagueApp.Common;
    using PremierLeagueApp.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
