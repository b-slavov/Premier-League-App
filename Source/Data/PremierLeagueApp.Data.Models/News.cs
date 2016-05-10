namespace PremierLeagueApp.Data.Models
{
    using System.Web.Mvc;

    using PremierLeagueApp.Data.Common.Models;

    public class News : BaseModel<int>
    {
        public string ImageUrl { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
    }
}
