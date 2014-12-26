using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StatePattern.Model.OrderStates
{
    public class OrderNewState : IOrderState 
    {        
        public bool CanShip(Order Order)
        {
            return true;
        }

        public void Ship(Order Order)
        {
            Order.Change(new OrderShippedState());
        }

        public OrderStatus Status
        {
            get { return OrderStatus.New; }
        }
       
        public bool CanCancel(Order Order)
        {
            return true;
        }

        public void Cancel(Order order)
        {
            order.Change(new OrderCanceledState());
        }

    }
}
