using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StatePattern.Model.OrderStates
{
    public class OrderShippedState : IOrderState 
    {        
        public bool CanShip(Order order)
        {
            return false;
        }

        public void Ship(Order order)
        {            
            throw new NotImplementedException("You can't ship a shipped order!");
        }
        
        public OrderStatus Status
        {
            get { return OrderStatus.Shipped; }
        }
        
        public bool CanCancel(Order Order)
        {
            return false;
        }

        public void Cancel(Order order)
        {
            throw new NotImplementedException("You can't ship a shipped order!");
        }

    }
}
