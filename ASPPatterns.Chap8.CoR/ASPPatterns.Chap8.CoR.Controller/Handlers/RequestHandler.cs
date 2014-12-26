using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.CoR.Controller.Request;

namespace ASPPatterns.Chap8.CoR.Controller.Handlers
{
    public abstract class RequestHandler
    {
        protected RequestHandler _nextHandler;

        public RequestHandler SetNextHandler(RequestHandler requestHandler)
		{
            _nextHandler = requestHandler;
            return _nextHandler;
        }

        public abstract void Handle(WebRequest request);       
    }
}
