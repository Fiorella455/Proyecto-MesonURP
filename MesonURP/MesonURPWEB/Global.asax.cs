using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace MesonURPWEB
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            //ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            //      new ScriptResourceDefinition                 {
            //            Path = "C:\Users\Milagros\source\repos\Fiorella455\Proyecto-MesonURP\MesonURP\MesonURPWEB\js1\jquery-1.7.2.min.js",
            //            DebugPath = "~/scripts/jquery-1.8.3.js",
            //            CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.2.min.js",
            //            CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.2.js"
            //     });
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

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Home", "Home", "~/paginas/Home.aspx", true);
        }
    }
}