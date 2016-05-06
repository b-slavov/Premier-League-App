namespace PremierLeagueApp.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }

        public IEnumerable<ClubViewModel> Clubs { get; set; }
    }
}
