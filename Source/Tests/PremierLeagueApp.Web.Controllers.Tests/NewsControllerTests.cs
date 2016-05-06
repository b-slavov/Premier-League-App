namespace PremierLeagueApp.Web.Controllers.Tests
{
    using Moq;

    using NUnit.Framework;

    using PremierLeagueApp.Data.Models;
    using PremierLeagueApp.Services.Data;
    using PremierLeagueApp.Web.Infrastructure.Mapping;
    using PremierLeagueApp.Web.ViewModels.Home;

    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class NewsControllerTests
    {
        [Test]
        public void ByIdShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(NewsController).Assembly);
            const string NewsContent = "SomeContent";
            var newsServiceMock = new Mock<INewsService>();
            newsServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new News { Content = NewsContent, Club = new Club { Name = "Football Club" } });
            var controller = new NewsController(newsServiceMock.Object);
            controller.WithCallTo(x => x.ById("asdasasd"))
                .ShouldRenderView("ById")
                .WithModel<NewsViewModel>(
                    viewModel =>
                        {
                            Assert.AreEqual(NewsContent, viewModel.Content);
                        }).AndNoModelErrors();
        }
    }
}
