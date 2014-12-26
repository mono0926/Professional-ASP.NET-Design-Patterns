using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.FrontController.Controller.ActionCommands;
using ASPPatterns.Chap8.FrontController.Controller.Storage;
using ASPPatterns.Chap8.FrontController.StubRepository;
using ASPPatterns.Chap8.FrontController.Model;
using ASPPatterns.Chap8.FrontController.Controller.WebCommands;
using ASPPatterns.Chap8.FrontController.Controller.Navigation;
using ASPPatterns.Chap8.FrontController.Controller.Routing;
using StructureMap;
using StructureMap.Configuration.DSL;
using ASPPatterns.Chap8.FrontController.Controller.Request;

namespace ASPPatterns.Chap8.FrontController.Controller
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {            
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }

        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {
                ForRequestedType<ICategoryRepository>().TheDefault.Is.OfConcreteType<CategoryRepository>();
                ForRequestedType<IProductRepository>().TheDefault.Is.OfConcreteType<ProductRepository>();
                ForRequestedType<IViewStorage>().TheDefault.Is.OfConcreteType<ViewStorage>();
                ForRequestedType<IPageNavigator>().TheDefault.Is.OfConcreteType<PageNavigator>();
                ForRequestedType<IWebCommandRegistry>().TheDefault.Is.OfConcreteType<WebCommandRegistry>();                
                ForRequestedType<IWebRequestFactory>().TheDefault.Is.OfConcreteType<WebRequestFactory>();                
            }
        }          
    }
}
