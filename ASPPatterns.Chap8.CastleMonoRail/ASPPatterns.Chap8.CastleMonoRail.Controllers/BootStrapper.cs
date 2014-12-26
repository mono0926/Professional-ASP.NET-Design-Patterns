using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using StructureMap;
using ASPPatterns.Chap8.CastleMonoRail.Model;
using ASPPatterns.Chap8.CastleMonoRail.StubRepository;

namespace ASPPatterns.Chap8.CastleMonoRail.Controllers
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
