using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.ProxyPattern.Model;

namespace ASPPatterns.Chap7.ProxyPattern.Repository
{
    public class CustomerProxy : Customer
    {
        private bool _haveLoadedOrders = false;
        private IEnumerable<Order> _orders;

        public IOrderRepository OrderRepository { get; set; }

        public bool HaveLoadedOrders()
        {
            return _haveLoadedOrders;
        }

        public override IEnumerable<Order> Orders
        {
            get
            {
                if (!HaveLoadedOrders())
                {
                    RetrieveOrders();
                    _haveLoadedOrders = true;
                }

                return _orders;
            }
            set
            {
                base.Orders = value;
            }
        }

        private void RetrieveOrders()
        {
            _orders = OrderRepository.FindAllBy(base.Id);  
        }
    }
}
