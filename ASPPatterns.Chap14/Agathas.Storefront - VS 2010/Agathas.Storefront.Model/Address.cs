using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model
{
    public class Address : EntityBase<int>
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        protected override void Validate()
        {
            if (String.IsNullOrEmpty(AddressLine1))
                base.AddBrokenRule(AddressBusinessRules.AddressLine1Required);

            if (String.IsNullOrEmpty(City))
                base.AddBrokenRule(AddressBusinessRules.CityRequired);

            if (String.IsNullOrEmpty(State))
                base.AddBrokenRule(AddressBusinessRules.StateRequired);

            if (String.IsNullOrEmpty(Country))
                base.AddBrokenRule(AddressBusinessRules.CountryRequired);

            if (String.IsNullOrEmpty(ZipCode))
                base.AddBrokenRule(AddressBusinessRules.ZipCodeRequired);
        }
    }

}
