namespace PremierLeagueApp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using PremierLeagueApp.Common;
    using PremierLeagueApp.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
