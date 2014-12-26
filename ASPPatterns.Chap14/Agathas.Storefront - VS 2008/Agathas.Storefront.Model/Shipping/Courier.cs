using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Shipping
{
    public class Courier : EntityBase<int>
    {
        private readonly string _name;
        private readonly IEnumerable<ShippingService> _services;

        public Courier()
        {
        }

        public Courier(string name, IEnumerable<ShippingService> services)
        {
            _name = name;
            _services = services;
        }
                
        public string Name
        {
            get { return _name; }
        }

        public IEnumerable<ShippingService> Services
        {
            get { return _services; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }

}
