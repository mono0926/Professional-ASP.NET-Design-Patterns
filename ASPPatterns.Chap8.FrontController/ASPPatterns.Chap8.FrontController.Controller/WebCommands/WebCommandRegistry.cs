using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.FrontController.Model;
using ASPPatterns.Chap8.FrontController.Controller.Request;
using ASPPatterns.Chap8.FrontController.Controller.Navigation;
using ASPPatterns.Chap8.FrontController.Controller.ActionCommands;
using StructureMap;
using ASPPatterns.Chap8.FrontController.Controller.Routing;

namespace ASPPatterns.Chap8.FrontController.Controller.WebCommands
{
    public class WebCommandRegistry : IWebCommandRegistry
    {
        private IList<IWebCommand> _webCommands = new List<IWebCommand>(); 

        public WebCommandRegistry()
        {            
            _webCommands.Add(CreateGetCategoryProductsCommand());
            _webCommands.Add(CreateGetHomePageCommand());
            _webCommands.Add(CreateGetProductDetailCommand());
        }
        
        public IWebCommand GetCommandFor(WebRequest webRequest)
        {
            return _webCommands.FirstOrDefault(wc => wc.CanHandle(webRequest)) ?? new Display404PageCommand(ObjectFactory.GetInstance<IPageNavigator>());
        }
        
        public IWebCommand CreateGetCategoryProductsCommand()
        {
            List<IActionCommand> _categoryProductsActionCommands = new List<IActionCommand>();
            _categoryProductsActionCommands.Add(ObjectFactory.GetInstance<GetCategoryListCommand>());
            _categoryProductsActionCommands.Add(ObjectFactory.GetInstance<GetCategoryProductsCommand>());
            _categoryProductsActionCommands.Add(ObjectFactory.GetInstance<GetCategoryCommand>());

            return new WebCommand(
                        ObjectFactory.GetInstance<IPageNavigator>(),
                        _categoryProductsActionCommands,
                        Routes.CategoryProducts,
                        PageDirectory.CategoryProducts);
        }

        public IWebCommand CreateGetHomePageCommand()
        {
            List<IActionCommand> _homePageActionCommands = new List<IActionCommand>();
            _homePageActionCommands.Add(ObjectFactory.GetInstance<GetCategoryListCommand>());
            _homePageActionCommands.Add(ObjectFactory.GetInstance<GetTopSellingProductsCommand>());

            return new WebCommand(
                    ObjectFactory.GetInstance<IPageNavigator>(),
                    _homePageActionCommands,
                    Routes.Home,
                    PageDirectory.Home);
        }

        public IWebCommand CreateGetProductDetailCommand()
        {
            List<IActionCommand> _productDetailActionCommands = new List<IActionCommand>();
            _productDetailActionCommands.Add(ObjectFactory.GetInstance<GetCategoryListCommand>());
            _productDetailActionCommands.Add(ObjectFactory.GetInstance<GetProductDetailCommand>());

            return new WebCommand(
                    ObjectFactory.GetInstance<IPageNavigator>(),
                    _productDetailActionCommands,
                    Routes.ProductDetail,
                    PageDirectory.ProductDetail);
        }
    }
}
