namespace PremierLeagueApp.Web.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using PremierLeagueApp.Data.Models;
    using PremierLeagueApp.Services.Web;
    using PremierLeagueApp.Web.Infrastructure.Mapping;

    public class NewsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image url")]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(90)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Club")]
        public int ClubId { get; set; }

        public DateTime CreatedOn { get; set; }

        public ApplicationUser Creator { get; set; }


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
