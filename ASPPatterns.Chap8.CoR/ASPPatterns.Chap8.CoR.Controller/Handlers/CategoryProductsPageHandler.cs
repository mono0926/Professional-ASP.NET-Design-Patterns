using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.CoR.Model;
using ASPPatterns.Chap8.CoR.Controller.Storage;
using ASPPatterns.Chap8.CoR.Controller.Routing;
using ASPPatterns.Chap8.CoR.Controller.Navigation;
using ASPPatterns.Chap8.CoR.Controller.Request;

namespace ASPPatterns.Chap8.CoR.Controller.Handlers
{
    public class CategoryProductsPageHandler : RequestHandler 
    {
        private Route _route;
        private ProductService _productService;
        private IViewStorage _viewStorage;
        private IPageNavigator _pageNavigator;

        public CategoryProductsPageHandler(Route route, ProductService productService, IViewStorage viewStorage, IPageNavigator pageNavigator)
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
                int categoryId = ActionArguments.CategoryId.ExtractFrom(request.QueryArguments);

                IEnumerable<Category> categories = _productService.GetAllCategories();
                _viewStorage.Add(ViewStorageKeys.Categories, categories);

                Category category = _productService.GetCategoryBy(categoryId);
                _viewStorage.Add(ViewStorageKeys.Category, category);

                IEnumerable<Product> products = _productService.GetAllProductsIn(categoryId);
                _viewStorage.Add(ViewStorageKeys.Products, products);

                _pageNavigator.NavigateTo(PageDirectory.CategoryProducts);  
            }
            else
                base._nextHandler.Handle(request);
        }       
    }
}
