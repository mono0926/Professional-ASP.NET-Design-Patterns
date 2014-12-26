using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.FrontController.Controller.WebCommands;
using ASPPatterns.Chap8.FrontController.Controller.Request;

namespace ASPPatterns.Chap8.FrontController.Controller
{
    public class FrontController
    {
        IWebCommandRegistry _webCommandRegistry;

        public FrontController(IWebCommandRegistry webCommandRegistry)
        {
            _webCommandRegistry = webCommandRegistry;
        }

        public void handle(WebRequest request)
        {
            _webCommandRegistry.GetCommandFor(request).Process(request);
        }
    }
}
