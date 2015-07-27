using System.Web.Mvc;
using System.Web.Routing;

namespace Soweb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*allappleicon}", new { allappleicon = @"apple-touch-icon-.*\.png(/.*)?" });
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("{page}.html");

            routes.MapRoute(
                "illos",
                "illos",
                new { controller = "Portfolio", action = "Illos" });

            routes.MapRoute(
                "piccies",
                "piccies",
                new { controller = "Portfolio", action = "Piccies" });

            routes.MapRoute(
                "detail",
                "detail/{name}",
                new { controller = "Portfolio", action = "Detail", name = UrlParameter.Optional });

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{name}",
                new { controller = "Portfolio", action = "Index", name = UrlParameter.Optional });
        }
    }
}