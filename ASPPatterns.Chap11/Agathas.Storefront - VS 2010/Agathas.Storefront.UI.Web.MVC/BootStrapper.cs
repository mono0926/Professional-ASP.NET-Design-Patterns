using Agathas.Storefront.Infrastructure.Logging;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Infrastructure.Configuration;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Implementations;
using Agathas.Storefront.Services.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;
using Agathas.Storefront.Infrastructure.Email;

namespace Agathas.Storefront.UI.Web.MVC
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
                // Repositories                                
                ForRequestedType<ICategoryRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.CategoryRepository>();
                ForRequestedType<IProductTitleRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.ProductTitleRepository>();
                ForRequestedType<IProductRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.ProductRepository>();
                ForRequestedType<IUnitOfWork>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.NHUnitOfWork>();

                // Product Catalogue                                         
                ForRequestedType<IProductCatalogService>().TheDefault.Is.OfConcreteType
                         <ProductCatalogService>();

                // Application Settings                 
                ForRequestedType<IApplicationSettings>().TheDefault.Is.OfConcreteType
                         <WebConfigApplicationSettings>();

                // Logger
                ForRequestedType<ILogger>().TheDefault.Is.OfConcreteType
                          <Log4NetAdapter>();

                // Email Service                 
                ForRequestedType<IEmailService>().TheDefault.Is.OfConcreteType
                        <TextLoggingEmailService>();
            }
        }
    }
}
