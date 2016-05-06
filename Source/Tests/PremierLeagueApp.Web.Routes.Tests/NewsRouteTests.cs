namespace PremierLeagueApp.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using NUnit.Framework;

    using PremierLeagueApp.Web.Controllers;

    [TestFixture]
    public class NewsRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/News/Mjc2NS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<NewsController>(c => c.ById("Mjc2NS4xMjMxMjMxMzEyMw=="));
        }
    }
}
