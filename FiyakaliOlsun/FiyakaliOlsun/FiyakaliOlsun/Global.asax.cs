﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FiyakaliOlsun
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Database.Configure();
        }

        protected void Application_BeginRequest()
        {
            Database.OpenSession();
        }

        protected void Application_EndRequest()
        {
            Database.CloseSession();
        }

    }
}
