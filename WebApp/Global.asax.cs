using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.Web.Http;
using System.Web.Routing;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //api/mobile/1
            RouteTable.Routes.MapHttpRoute(
            name: "MobileLecturer",
            routeTemplate: "api/{controller}/{lecturer}",
            defaults: new { lecturer = RouteParameter.Optional }
            );

            //api/mobile/a@a/123
            RouteTable.Routes.MapHttpRoute(
            name: "MobileLogin",
            routeTemplate: "api/{controller}/{email}/{password}",
            defaults: new { email = RouteParameter.Optional, password = RouteParameter.Optional }
            );

            //nfc/nfc/1
            RouteTable.Routes.MapHttpRoute(
            name: "NfcModules",
            routeTemplate: "nfc/{controller}/{module}",
            defaults: new { module = RouteParameter.Optional }
            );

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}