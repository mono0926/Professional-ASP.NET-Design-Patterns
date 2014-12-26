using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.FrontController.Controller.Request;

namespace ASPPatterns.Chap8.FrontController.Controller.WebCommands
{
    public interface IWebCommand
    {
        Boolean CanHandle(WebRequest webRequest);
        void Process(WebRequest webRequest);
    }
}
