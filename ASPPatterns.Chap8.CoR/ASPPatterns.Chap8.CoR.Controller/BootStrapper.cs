using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.CoR.Controller.Handlers;
using ASPPatterns.Chap8.CoR.Model;
using ASPPatterns.Chap8.CoR.StubRepository;
using ASPPatterns.Chap8.CoR.Controller.Storage;
using ASPPatterns.Chap8.CoR.Controller.Routing;
using ASPPatterns.Chap8.CoR.Controller.Navigation;
using StructureMap;
using StructureMap.Configuration.DSL;
using ASPPatterns.Chap8.CoR.Controller.Request;

namespace ASPPatterns.Chap8.CoR.Controller
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            // Initialize the registry
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
                ForRequestedType<IWebRequestFactory>().TheDefault.Is.OfConcreteType<WebRequestFactory>();
                ForRequestedType<IHandlerFactory>().TheDefault.Is.OfConcreteType<HandlerFactory>();                
            }
        }                           
    }
}
