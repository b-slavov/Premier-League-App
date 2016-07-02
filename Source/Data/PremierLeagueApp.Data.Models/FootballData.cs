﻿namespace PremierLeagueApp.Data.Models
{
    using System.Collections.Generic;

    public class FootballData
    {
        public IList<Club> Teams { get; set; }

        public IList<TeamStats> Standing { get; set; }
    }
}
