using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.chap5.FactoryPattern.Model
{
    public class RoyalMail : IShippingCourier 
    {                
        public string GenerateConsignmentLabelFor(Address address)
        {
            return "RMXXXX-XXXX-XXXX";
        }        
    }
}
