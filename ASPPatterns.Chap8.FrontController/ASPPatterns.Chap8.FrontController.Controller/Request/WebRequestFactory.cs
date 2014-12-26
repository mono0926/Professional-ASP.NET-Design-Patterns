using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASPPatterns.Chap8.FrontController.Controller.Request
{
    public class WebRequestFactory : IWebRequestFactory
    {
        public WebRequest CreateFrom(HttpContext context)
        {
            WebRequest webrequest = new WebRequest();
            webrequest.RequestedURL = context.Request.Url.ToString();
            webrequest.QueryArguments = context.Request.QueryString;

            return webrequest;
        }
    }
}
