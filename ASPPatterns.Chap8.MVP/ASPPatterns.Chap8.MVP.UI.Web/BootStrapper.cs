using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;
using ASPPatterns.Chap8.MVP.Model;
using ASPPatterns.Chap8.MVP.Presentation.Navigation;
using ASPPatterns.Chap8.MVP.StubRepository;
using ASPPatterns.Chap8.MVP.Presentation;
using ASPPatterns.Chap8.MVP.Presentation.Basket;

namespace ASPPatterns.Chap8.MVP.UI.Web
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
                ForRequestedType<IPageNavigator>().TheDefault.Is.OfConcreteType<PageNavigator>();      
                ForRequestedType<IBasket>().TheDefault.Is.OfConcreteType<WebBasket>();                                                                          
            }
        }   
    }
}
