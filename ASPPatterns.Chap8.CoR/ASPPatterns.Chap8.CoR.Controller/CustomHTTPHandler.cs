using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ASPPatterns.Chap8.CoR.Controller.Request;
using StructureMap;

namespace ASPPatterns.Chap8.CoR.Controller
{
    public class CustomHTTPHandler : IHttpHandler 
    {
        public void ProcessRequest(HttpContext context)
        {
            ObjectFactory.GetInstance<FrontController>()
                .handle(ObjectFactory.GetInstance<IWebRequestFactory>().CreateFrom(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }          
    }
}
