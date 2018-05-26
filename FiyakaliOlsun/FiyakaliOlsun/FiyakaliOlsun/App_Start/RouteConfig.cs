using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FiyakaliOlsun
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var namespaces = new[] { typeof(PostController).Namespace };
            routes.MapRoute("Home","",new { Controller="Home", Action="Index"});
            routes.MapRoute("Hakkimizda", "hakkimizda", new { Controller = "Home", Action = "Hakkimizda" });
            routes.MapRoute("Iletisim", "iletisim", new { Controller = "Home", Action = "Iletisim" });
            routes.MapRoute("Login", "login", new { Controller = "Login", Action = "Login" });
        }
    }
}
