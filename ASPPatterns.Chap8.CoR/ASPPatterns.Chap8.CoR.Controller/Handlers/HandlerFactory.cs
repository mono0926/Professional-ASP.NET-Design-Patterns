using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using ASPPatterns.Chap8.CoR.Controller.Routing;
using ASPPatterns.Chap8.CoR.Model;
using ASPPatterns.Chap8.CoR.Controller.Storage;
using ASPPatterns.Chap8.CoR.Controller.Navigation;

namespace ASPPatterns.Chap8.CoR.Controller.Handlers
{
    public class HandlerFactory : IHandlerFactory
    {
        public  RequestHandler GetHandlers()
        {
            RequestHandler handler = GetHomePageHandler();

            handler
                .SetNextHandler(GetCategoryProductsPageHandler())
                .SetNextHandler(GetProductDetailPageHandler()) 
                .SetNextHandler(GetPageNotFoundHandler());

            return handler;
        }

        private RequestHandler GetPageNotFoundHandler()
        {
            return new PageNotFoundHandler(
                          ObjectFactory.GetInstance<ProductService>(),
                          ObjectFactory.GetInstance<IViewStorage>(),
                          ObjectFactory.GetInstance<IPageNavigator>());
        }

        private RequestHandler GetProductDetailPageHandler()
        {
            return new ProductDetailPageHandler(
                          Routes.ProductDetail,
                          ObjectFactory.GetInstance<ProductService>(),
                          ObjectFactory.GetInstance<IViewStorage>(),
                          ObjectFactory.GetInstance<IPageNavigator>());
        }

        private RequestHandler GetCategoryProductsPageHandler()
        {
            return new CategoryProductsPageHandler(
                           Routes.CategoryProducts,
                           ObjectFactory.GetInstance<ProductService>(),
                           ObjectFactory.GetInstance<IViewStorage>(),
                           ObjectFactory.GetInstance<IPageNavigator>());
        }

        private RequestHandler GetHomePageHandler()
        {
 	        return new HomePageHandler(
                            Routes.Home,
                            ObjectFactory.GetInstance<ProductService>(),
                            ObjectFactory.GetInstance<IViewStorage>(),
                            ObjectFactory.GetInstance<IPageNavigator>());
        }
    }
    
}
