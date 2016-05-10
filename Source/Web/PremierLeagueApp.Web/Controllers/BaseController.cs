namespace PremierLeagueApp.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Infrastructure.Mapping;

    using PremierLeagueApp.Services.Web;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
