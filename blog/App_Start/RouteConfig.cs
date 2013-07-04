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
            //routes.MapRoute
            //    (
            //        "PostCategory",
            //        url: "category/{category}",
            //        defaults: new { controller = "Home", action = "Category" }
            //    );
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
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}