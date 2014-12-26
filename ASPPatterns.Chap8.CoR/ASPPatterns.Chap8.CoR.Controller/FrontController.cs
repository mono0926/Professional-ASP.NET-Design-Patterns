using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.CoR.Controller.Handlers;
using ASPPatterns.Chap8.CoR.Controller.Request;

namespace ASPPatterns.Chap8.CoR.Controller
{
    public class FrontController
    {
        RequestHandler _requestHandler;

        public FrontController(IHandlerFactory handlerFactory)
        {
            _requestHandler = handlerFactory.GetHandlers();
        }

        public void handle(WebRequest request)
        {
            _requestHandler.Handle(request);
        }       
    }
}
