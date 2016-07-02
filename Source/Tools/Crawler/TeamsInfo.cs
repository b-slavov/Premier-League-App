namespace Crawler
{
    using System.Collections.Generic;
    using System.Net;

    using Newtonsoft.Json;

    using PremierLeagueApp.Data.Models;

    public static class TeamsInfo
    {
        public static IList<Club> GetPremierLeagueTeams()
        {
            var client = new WebClient();
            string content = client.DownloadString("http://api.football-data.org/v1/soccerseasons/398/teams");
            IList<Club> clubs = JsonConvert.DeserializeObject<FootballData>(content).Teams;
            return clubs;
        }

        public static IList<TeamStats> GetTableInfo()
        {
            var client = new WebClient();
            string content = client.DownloadString("http://api.football-data.org/v1/soccerseasons/398/leagueTable");
            var standing = JsonConvert.DeserializeObject<FootballData>(content);
            return standing.Standing;
        }
    }
}
