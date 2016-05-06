namespace PremierLeagueApp.Web.ViewModels.Home
{
    using System;

    using AutoMapper;

    using PremierLeagueApp.Data.Models;
    using PremierLeagueApp.Services.Web;
    using PremierLeagueApp.Web.Infrastructure.Mapping;

    public class NewsViewModel : IMapFrom<News>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Club { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/News/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<News, NewsViewModel>()
                .ForMember(x => x.Club, opt => opt.MapFrom(x => x.Club.Name));
        }
    }
}
