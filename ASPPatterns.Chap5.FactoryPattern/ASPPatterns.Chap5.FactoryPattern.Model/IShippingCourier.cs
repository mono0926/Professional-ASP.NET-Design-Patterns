using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.chap5.FactoryPattern.Model
{
    public interface IShippingCourier
    {
        string GenerateConsignmentLabelFor(Address address);
    }
}
