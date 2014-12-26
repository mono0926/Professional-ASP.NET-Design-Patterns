using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StatePattern.Model.OrderStates
{
    public interface IOrderState
    {        
        bool CanShip(Order Order);
        void Ship(Order Order);

        bool CanCancel(Order Order);
        void Cancel(Order order);

        OrderStatus Status { get; }
    }
}
