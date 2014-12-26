using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ASPPatterns.Chap8.FrontController.Controller;

namespace ASPPatterns.Chap8.FrontController.UI.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BootStrapper.ConfigureDependencies();
        }        
    }
}