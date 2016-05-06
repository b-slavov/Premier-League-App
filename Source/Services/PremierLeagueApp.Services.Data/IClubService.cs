namespace PremierLeagueApp.Services.Data
{
    using System.Linq;

    using PremierLeagueApp.Data.Models;

    public interface IClubService
    {
        IQueryable<Club> GetAll();

        Club EnsureClub(string name);
    }
}
