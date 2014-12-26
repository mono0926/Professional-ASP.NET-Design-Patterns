using System;
using System.Web;

namespace ASPPatterns.Chap8.FrontController.Controller.Request
{
    public interface IWebRequestFactory
    {
        WebRequest CreateFrom(HttpContext context);
    }
}
