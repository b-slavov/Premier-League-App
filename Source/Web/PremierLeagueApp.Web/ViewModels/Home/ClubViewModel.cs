namespace PremierLeagueApp.Web.ViewModels.Home
{
    using PremierLeagueApp.Data.Models;
    using PremierLeagueApp.Web.Infrastructure.Mapping;

    public class ClubViewModel : IMapFrom<Club>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
