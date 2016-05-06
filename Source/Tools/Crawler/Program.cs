namespace Crawler
{
    using System;
    using AngleSharp;
    using PremierLeagueApp.Data;
    using PremierLeagueApp.Data.Common;
    using PremierLeagueApp.Data.Models;
    using PremierLeagueApp.Services.Data;

    public static class Program
    {
        public static void Main()
        {
            var db = new ApplicationDbContext();
            var repo = new DbRepository<Club>(db);
            var clubService = new ClubService(repo);

            var configuration = Configuration.Default.WithDefaultLoader();
            var browsingContext = BrowsingContext.New(configuration);

            for (int i = 1; i <= 10000; i++)
            {
                var url = $"http://vicove.com/vic-{i}";
                var document = browsingContext.OpenAsync(url).Result;
                var newsContent = document.QuerySelector("#content_box .post-content").TextContent.Trim();
                if (!string.IsNullOrWhiteSpace(newsContent))
                {
                    var clubName = document.QuerySelector("#content_box .thecategory a").TextContent.Trim();
                    var club = clubService.EnsureClub(clubName);
                    var news = new News { Club = club, Content = newsContent };
                    db.News.Add(news);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
            }
        }
    }
}
