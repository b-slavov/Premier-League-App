namespace PremierLeagueApp.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Crawler;

    using PremierLeagueApp.Data.Common;
    using PremierLeagueApp.Data.Models;

    public class TeamsController : Controller
    {
        private readonly IDbRepository<Club> teams;

        public TeamsController(IDbRepository<Club> teams)
        {
            this.teams = teams;
        }

        public ActionResult Index()
        {
            return this.View(this.teams.All());
        }

        public ActionResult TrackTeams()
        {
            var dbTeams = this.teams.All().ToList();
            var trackedTeams = TeamsInfo.GetPremierLeagueTeams();

            foreach (var team in trackedTeams)
            {
                if (!dbTeams.Any(x => x.Name == team.Name))
                {
                    var newTeam = new Club { CreatedOn = DateTime.Now, Name = team.Name };
                    this.teams.Add(newTeam);
                }
            }

            this.teams.Save();

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
