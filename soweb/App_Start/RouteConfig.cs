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
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Portfolio", action = "Index", id = UrlParameter.Optional });
        }
    }
}