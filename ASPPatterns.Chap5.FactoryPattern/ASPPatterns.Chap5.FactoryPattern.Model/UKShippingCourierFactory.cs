using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.chap5.FactoryPattern.Model
{
    public static class UKShippingCourierFactory 
    {
        public static IShippingCourier CreateShippingCourier(Order order)
        { 
            if ((order.TotalCost > 100) || (order.WeightInKG > 5))
                return new DHL();            
            else            
                return new RoyalMail();            
        }
    }
}
