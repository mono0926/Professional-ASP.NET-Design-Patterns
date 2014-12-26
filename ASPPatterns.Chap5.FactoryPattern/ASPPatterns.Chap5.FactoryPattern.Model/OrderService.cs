using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.chap5.FactoryPattern.Model
{
    public class OrderService
    {
        public void Dispatch(Order order)
        {
            IShippingCourier shippingCourier = UKShippingCourierFactory.CreateShippingCourier(order);

            order.CourierTrackingId = shippingCourier.GenerateConsignmentLabelFor(order.DispatchAddress);    
        }
    }
}
