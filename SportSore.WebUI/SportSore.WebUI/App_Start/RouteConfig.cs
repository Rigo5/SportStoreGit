using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportSore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { Controller = "Product", action = "List", page = 1, category = (string)null }
            );
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { Controller = "Product", action = "List"},
                new { page = @"\d+" }
            );
            routes.MapRoute(null,
                "{category}",
                new { controller = "Product", action = "List", category = (string)null, page = 1 });

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Product", action = "List", category = (string)null, page = 1 },
                new { page = @"\d+" });
           
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
