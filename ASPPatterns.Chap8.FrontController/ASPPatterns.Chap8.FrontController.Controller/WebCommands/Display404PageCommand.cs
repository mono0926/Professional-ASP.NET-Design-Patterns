using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.FrontController.Controller.Navigation;
using ASPPatterns.Chap8.FrontController.Controller.Request;

namespace ASPPatterns.Chap8.FrontController.Controller.WebCommands
{
    public class Display404PageCommand : IWebCommand 
    {
        private IPageNavigator _navigator;

        public Display404PageCommand(IPageNavigator navigator)
        {
            _navigator = navigator;         
        }

        public bool CanHandle(WebRequest webRequest)
        {
             return true;
        }

        public void Process(WebRequest webRequest)
        {
            _navigator.NavigateTo(PageDirectory.MissingPage);  
        }        
    }
}
