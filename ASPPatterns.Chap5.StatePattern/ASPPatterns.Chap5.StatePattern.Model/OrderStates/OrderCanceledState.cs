using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StatePattern.Model.OrderStates
{
    public class OrderCanceledState : IOrderState 
    {        
        public bool CanShip(Order Order)
        {
            return false;
        }

        public void Ship(Order Order)
        {
            throw new NotImplementedException("You can't ship a cancelled order!");
        }

        public OrderStatus Status
        {
            get { return OrderStatus.Canceled; }
        }        

        public bool CanCancel(Order Order)
        {
            return false;
        }

        public void Cancel(Order order)
        {
            throw new NotImplementedException("You can't ship a cancelled order!");
        }
    }
}
