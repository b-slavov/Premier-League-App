namespace PremierLeagueApp.Web.ViewModels.Home
{
    using System;
    using System.Web.Mvc;

    using PremierLeagueApp.Data.Models;
    using PremierLeagueApp.Services.Web;
    using PremierLeagueApp.Web.Infrastructure.Mapping;

    public class NewsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public int ClubId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/News/{identifier.EncodeId(this.Id)}";
            }
        }
    }
}
