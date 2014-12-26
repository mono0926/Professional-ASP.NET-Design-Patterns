using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ASPPatterns.Chap8.CoR.Model;
using ASPPatterns.Chap8.CoR.Controller.Storage;
using ASPPatterns.Chap8.CoR.Controller.Routing;
using ASPPatterns.Chap8.CoR.Controller.Navigation;
using ASPPatterns.Chap8.CoR.Controller.Request;

namespace ASPPatterns.Chap8.CoR.Controller.Handlers
{
    public class HomePageHandler : RequestHandler 
    {
        private Route _route;
        private ProductService _productService;
        private IViewStorage _viewStorage;
        private IPageNavigator _pageNavigator;

        public HomePageHandler(Route route, ProductService productService, IViewStorage viewStorage, IPageNavigator pageNavigator)
        {
            _route = route;
            _productService = productService;
            _viewStorage = viewStorage;
            _pageNavigator = pageNavigator;
        }

        public override void Handle(WebRequest request)
        {
            if (_route.Matches(request))
            {
                IEnumerable<Category> categories = _productService.GetAllCategories();
                _viewStorage.Add(ViewStorageKeys.Categories, categories);

                IEnumerable<Product> products = _productService.GetBestSellingProducts();
                _viewStorage.Add(ViewStorageKeys.Products, products);

                _pageNavigator.NavigateTo(PageDirectory.Home); 
            }
            else
                base._nextHandler.Handle(request);
        }       
    }
}
