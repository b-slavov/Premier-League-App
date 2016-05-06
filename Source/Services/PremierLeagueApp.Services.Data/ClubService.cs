namespace PremierLeagueApp.Services.Data
{
    using System.Linq;

    using PremierLeagueApp.Data.Common;
    using PremierLeagueApp.Data.Models;

    public class ClubService : IClubService
    {
        private readonly IDbRepository<Club> clubs;

        public ClubService(IDbRepository<Club> clubs)
        {
            this.clubs = clubs;
        }

        public Club EnsureClub(string name)
        {
            var club = this.clubs.All().FirstOrDefault(x => x.Name == name);
            if (club != null)
            {
                return club;
            }

            club = new Club { Name = name };
            this.clubs.Add(club);
            this.clubs.Save();
            return club;
        }

        public IQueryable<Club> GetAll()
        {
            return this.clubs.All().OrderBy(x => x.Name);
        }
    }
}
