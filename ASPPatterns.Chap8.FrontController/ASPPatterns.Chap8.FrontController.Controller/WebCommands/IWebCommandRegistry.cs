using System;
using ASPPatterns.Chap8.FrontController.Controller.Request;

namespace ASPPatterns.Chap8.FrontController.Controller.WebCommands
{
    public interface IWebCommandRegistry
    {
        IWebCommand GetCommandFor(WebRequest webRequest);
    }
}
