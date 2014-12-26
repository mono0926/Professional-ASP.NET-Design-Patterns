using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using ASPPatterns.Chap3.Layered.Repository;
using ASPPatterns.Chap3.Layered.Model;

namespace ASPPatterns.Chap3.Layered.WebUI
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {            
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ProductRegistry>();

            });
        }   
    }

    public class ProductRegistry : Registry
    {
        public ProductRegistry()
        {
            ForRequestedType<IProductRepository>().TheDefaultIsConcreteType<ProductRepository>();            
        }

    }

}
