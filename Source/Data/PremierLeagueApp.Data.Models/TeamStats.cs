﻿namespace PremierLeagueApp.Data.Models
{
    public class TeamStats
    {
        public int Position { get; set; }

        public string TeamName { get; set; }

        public int PlayedGames { get; set; }

        public int Points { get; set; }

        public int Goals { get; set; }

        public int GoalsAgainst { get; set; }

        public int GoalDifference { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }
    }
}