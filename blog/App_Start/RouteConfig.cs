using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EdjeBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute
                (
                "PostTag",
                url: "tag/{tag}",
                defaults: new { controller = "Tag", action="Tag"}
                );
            routes.MapRoute
                (
                "PageTag",
                url: "page/tag/{tag}",
                defaults: new { controller = "Page", action = "Tag" }
                );
            routes.MapRoute(
                "PageDetails",
                url: "page/{title}",
                defaults: new { controller = "Page", action = "Details"}
            );
            routes.MapRoute(
                "ArchiveYear",
                url: "archive/{year}",
                defaults: new { controller = "Archive", action = "Index", year = UrlParameter.Optional  }
            );
            routes.MapRoute(
                "ArchiveDetails",
                url: "archive/details/{date}/{title}",
                defaults: new { controller = "Archive", action = "Details", date = UrlParameter.Optional, title = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}