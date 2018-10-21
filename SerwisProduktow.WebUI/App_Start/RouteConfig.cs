using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SerwisProduktow.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "Register/{login}/{password}", new { controller = "User", action="Register" });
            routes.MapRoute(null, "AddService/{userID}/{descryption}/{categoryID}", new { controller = "Service", action="AddService" });
            routes.MapRoute(null, "AddComment/{userID}/{content}/{serviceID}", new { controller = "Service", action="AddComment" });
            routes.MapRoute(null, "Vote/{userID}/{rate}/{serviceID}", new { controller = "Service", action="Vote" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
