using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PostIt.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                null,
                "View/{action}",
                new { controller = "View", action = "Index"}
            );

            routes.MapRoute(
                null,
                "",
                new { controller = "Note", action = "List", category = (string)null, page = 1 }
            );

            routes.MapRoute(
                null,
                "Page{page}",
                new { controller = "Note", action = "List", category = (string)null },
                new { page = @"\d+" }
            );

            routes.MapRoute(
                null,
                "Login/",
                new { controller = "LogIn", Action = "LogIn" }
                );

            routes.MapRoute(
                null,
                "Admin/",
                new { controller = "Admin", Action = "Index" }
                );

            routes.MapRoute(
                null,
                "{category}",
                new { controller = "Note", action = "List", page = 1 }
            );

            routes.MapRoute(
                null,
                "{category}/Page{page}",
                new { controller = "Note", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}