using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ASPPatterns.Chap4.ActiveRecord.Model;
using Castle.ActiveRecord.Framework;

namespace ASPPatterns.Chap4.ActiveRecord.UI.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Blog", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            IConfigurationSource source = ConfigurationManager.GetSection("activeRecord") as IConfigurationSource;
            Castle.ActiveRecord.ActiveRecordStarter.Initialize(source, typeof(Post), typeof(Comment));
        }
    }
}