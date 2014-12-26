using System;
namespace ASPPatterns.Chap8.CoR.Controller.Request
{
    public interface IWebRequestFactory
    {
        WebRequest CreateFrom(System.Web.HttpContext context);
    }
}
