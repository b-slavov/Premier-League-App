using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PremierLeagueApp.Web.Startup))]

namespace PremierLeagueApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
