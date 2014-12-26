using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ASPPatterns.Chap8.CoR.Model;
using ASPPatterns.Chap8.CoR.Controller.Storage;
using ASPPatterns.Chap8.CoR.Controller.Navigation;
using ASPPatterns.Chap8.CoR.Controller.Request;

namespace ASPPatterns.Chap8.CoR.Controller.Handlers
{
    public class PageNotFoundHandler : RequestHandler 
    {
        private ProductService _productService;
        private IViewStorage _viewStorage;
        private IPageNavigator _pageNavigator;

        public PageNotFoundHandler(ProductService productService, IViewStorage viewStorage, IPageNavigator pageNavigator)
        {
            _productService = productService;
            _viewStorage = viewStorage;
            _pageNavigator = pageNavigator;
        }        

        public override void Handle(WebRequest request)
        {
            _pageNavigator.NavigateTo(PageDirectory.MissingPage);          
        }
    }
}
