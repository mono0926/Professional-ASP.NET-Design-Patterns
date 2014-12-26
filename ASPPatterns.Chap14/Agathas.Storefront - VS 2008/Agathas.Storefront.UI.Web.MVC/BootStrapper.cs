using Agathas.Storefront.Controllers.ActionArguments;
using Agathas.Storefront.Infrastructure.Authentication;
using Agathas.Storefront.Infrastructure.CookieStorage;
using Agathas.Storefront.Infrastructure.Domain.Events;
using Agathas.Storefront.Infrastructure.Logging;
using Agathas.Storefront.Infrastructure.Payments;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Infrastructure.Configuration;
using Agathas.Storefront.Model.Basket;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Customers;
using Agathas.Storefront.Model.Orders;
using Agathas.Storefront.Model.Orders.Events;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Model.Shipping;
using Agathas.Storefront.Services.DomainEventHandlers;
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
                ForRequestedType<IOrderRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.OrderRepository>();
                ForRequestedType<ICustomerRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.CustomerRepository>();
                ForRequestedType<IBasketRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.BasketRepository>();
                ForRequestedType<IDeliveryOptionRepository>().TheDefault.Is.OfConcreteType
                          <Repository.NHibernate.Repositories.DeliveryOptionRepository>();
               
                ForRequestedType<ICategoryRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.CategoryRepository>();
                ForRequestedType<IProductTitleRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.ProductTitleRepository>();
                ForRequestedType<IProductRepository>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.Repositories.ProductRepository>();
                ForRequestedType<IUnitOfWork>().TheDefault.Is.OfConcreteType
                         <Repository.NHibernate.NHUnitOfWork>();

                // Order Service
                ForRequestedType<IOrderService>().TheDefault.Is.OfConcreteType
                        <OrderService>();

                // Payment
                ForRequestedType<IPaymentService>().TheDefault.Is.OfConcreteType
                        <PayPalPaymentService>();

                // Handlers for Domain Events
                ForRequestedType<IDomainEventHandlerFactory>().TheDefault
                       .Is.OfConcreteType<StructureMapDomainEventHandlerFactory>();
                ForRequestedType<IDomainEventHandler<OrderSubmittedEvent>>()
                       .AddConcreteType<OrderSubmittedHandler>();


                // Product Catalogue                                         
                ForRequestedType<IProductCatalogService>().TheDefault.Is.OfConcreteType
                         <ProductCatalogService>();


                // Product Catalogue & Category Service with Caching Layer Registration
                this.InstanceOf<IProductCatalogService>().Is.OfConcreteType<ProductCatalogService>()
                    .WithName("RealProductCatalogueService");

                // Uncomment the line below to use the product service caching layer
                //ForRequestedType<IProductCatalogueService>().TheDefault.Is.OfConcreteType<CachedProductCatalogueService>()
                //    .CtorDependency<IProductCatalogueService>().Is(x => x.TheInstanceNamed("RealProductCatalogueService"));

                ForRequestedType<IBasketService>().TheDefault.Is.OfConcreteType
                         <BasketService>();
                ForRequestedType<ICookieStorageService>().TheDefault.Is.OfConcreteType
                          <CookieStorageService>();


                // Application Settings                 
                ForRequestedType<IApplicationSettings>().TheDefault.Is.OfConcreteType
                         <WebConfigApplicationSettings>();

                // Logger
                ForRequestedType<ILogger>().TheDefault.Is.OfConcreteType
                          <Log4NetAdapter>();

                // Email Service                 
                ForRequestedType<IEmailService>().TheDefault.Is.OfConcreteType
                        <TextLoggingEmailService>();

                ForRequestedType<ICustomerService>().TheDefault.Is.OfConcreteType
                        <CustomerService>();

                // Authentication
                ForRequestedType<IExternalAuthenticationService>().TheDefault.Is
                         .OfConcreteType<JanrainAuthenticationService>();
                ForRequestedType<IFormsAuthentication>().TheDefault.Is
                         .OfConcreteType<AspFormsAuthentication>();
                ForRequestedType<ILocalAuthenticationService>().TheDefault.Is
                         .OfConcreteType<AspMembershipAuthentication>();

                // Controller Helpers
                ForRequestedType<IActionArguments>().TheDefault.Is.OfConcreteType
                     <HttpRequestActionArguments>();

            }
        }
    }
}
