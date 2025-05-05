using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "Admin",
            "admin",
            new { controller = "Account", action = "Admin" }
        );

            routes.MapRoute(
            "Art",
            "art",
            new { controller = "ImagePosts", action = "Index" }
        );

            routes.MapRoute(
            "Programming",
            "programming",
            new { controller = "Home", action = "Programming" }
        );

            routes.MapRoute(
            "Resume",
            "resume",
            new { controller = "Home", action = "Contact" }
        );

            routes.MapRoute(
           "Website",
           "programming/website",
           new { controller = "Home", action = "About" }
       );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
