using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using ASPPatterns.Chap8.IoC.Model.Payment;
using ASPPatterns.Chap8.IoC.Model.Despatch;

namespace ASPPatterns.Chap8.IoC.UI.Web
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            // Initialize the registry
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ModelRegistry>();

            });
        }

        public class ModelRegistry : Registry
        {
            public ModelRegistry()
            {
                ForRequestedType<IPaymentGateway>().TheDefault.Is.OfConcreteType<PaymentGateway>();
                ForRequestedType<IPaymentMerchant>().TheDefault.Is.OfConcreteType<StreamLinePaymentMerchant>();
                ForRequestedType<IDespatchService>().TheDefault.Is.OfConcreteType<DespatchService>();
                ForRequestedType<ICourier>().TheDefault.Is.OfConcreteType<FedExCourier>();
            }

        }

    }
}
