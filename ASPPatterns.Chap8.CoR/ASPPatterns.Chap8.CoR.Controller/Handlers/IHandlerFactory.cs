using System;
namespace ASPPatterns.Chap8.CoR.Controller.Handlers
{
    public interface IHandlerFactory
    {
        RequestHandler GetHandlers();
    }
}
