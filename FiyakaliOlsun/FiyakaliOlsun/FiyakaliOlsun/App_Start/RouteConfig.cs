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
            
            routes.MapRoute("Home","",new { Controller="Home", Action="Index"});
            routes.MapRoute("Hakkimizda", "hakkimizda", new { Controller = "Home", Action = "Hakkimizda" });
            routes.MapRoute("Canta", "canta", new { Controller = "Home", Action = "Canta" });
            routes.MapRoute("Ayakkabi", "ayakkabi", new { Controller = "Home", Action = "Ayakkabi" });
            routes.MapRoute("Goruntule", "goruntule", new { Controller = "Home", Action = "Goruntule" });
            routes.MapRoute("Iletisim", "iletisim", new { Controller = "Home", Action = "Iletisim" });
            routes.MapRoute("Login", "login", new { Controller = "Login", Action = "Login" });
            routes.MapRoute("UyeOl", "uyeol", new { Controller = "Login", Action = "UyeOl" });

        }
    }
}
