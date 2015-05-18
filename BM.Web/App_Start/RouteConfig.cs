using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BM.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "DB",
                url: "CreateDB/DBVersion",
                defaults: new { controller = "CreateDB", action = "DBVersion" }
                );
            routes.MapRoute(
                name: "Error",
                url: "Error/ErrorPage",
                defaults: new { controller = "CreateDB", action = "DBVersion" }
                );
            routes.MapRoute(
                name: "Demo",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
