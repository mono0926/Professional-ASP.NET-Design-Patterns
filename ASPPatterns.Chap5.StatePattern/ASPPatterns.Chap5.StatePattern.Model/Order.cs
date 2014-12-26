using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.StatePattern.Model.OrderStates;

namespace ASPPatterns.Chap5.StatePattern.Model
{
    public class Order
    {
        private IOrderState _orderState;       

        public Order(IOrderState baseState)
        {
            _orderState = baseState; 
        }

        public int Id { get; set; }

        public string Customer { get; set; }

        public DateTime OrderedDate { get; set; }
        
        public OrderStatus Status()
        {
            return _orderState.Status;  
        }

        public bool CanCancel()
        {
            return _orderState.CanCancel(this);  
        }

        public void Cancel()
        {
            if (CanCancel())
                _orderState.Cancel(this);
        }

        public bool CanShip()
        {
            return _orderState.CanShip(this);
        }

        public void Ship()
        { 
            if (CanShip())
                _orderState.Ship(this);
        }

        internal void Change(IOrderState OrderState)
        {
            _orderState = OrderState;
        }
    }
}
