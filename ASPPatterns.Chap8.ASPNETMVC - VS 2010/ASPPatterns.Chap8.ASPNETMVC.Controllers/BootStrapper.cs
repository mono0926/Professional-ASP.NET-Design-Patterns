using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.ASPNETMVC.Model;
using ASPPatterns.Chap8.ASPNETMVC.StubRepository;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace ASPPatterns.Chap8.ASPNETMVC.Controllers
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
            }
        }
    }
}
