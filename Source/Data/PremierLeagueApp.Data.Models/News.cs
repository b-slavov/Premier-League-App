namespace PremierLeagueApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using PremierLeagueApp.Data.Common.Models;

    public class News : BaseModel<int>
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(90)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}