using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASPPatterns.Chap8.CoR.Controller.Request
{
    public class WebRequestFactory : IWebRequestFactory
    {
        public WebRequest CreateFrom(HttpContext context)
        {            
            WebRequest webrequest = new WebRequest();
            webrequest.RequestedURL = context.Request.Url.AbsolutePath;
            webrequest.QueryArguments = context.Request.QueryString;

            return webrequest;
        }
    }
}
