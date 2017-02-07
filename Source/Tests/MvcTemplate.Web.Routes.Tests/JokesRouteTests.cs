namespace MvcTemplate.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using MvcTemplate.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class JokesRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Home/Index";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index());
        }
    }
}
