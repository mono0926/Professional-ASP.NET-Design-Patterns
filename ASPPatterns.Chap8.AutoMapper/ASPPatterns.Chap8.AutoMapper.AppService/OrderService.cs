using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ASPPatterns.Chap8.AutoMapper.Model;
using ASPPatterns.Chap8.AutoMapper.StubRepository;
using ASPPatterns.Chap8.AutoMapper.AppService.Views;

namespace ASPPatterns.Chap8.AutoMapper.AppService
{
    public class OrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService()
            : this(new OrderRepository())
        { }

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderView GetOrder(int orderId)
        {
            OrderView orderView;
            Order order = _orderRepository.FindBy(orderId);

            orderView = order.ConvertToOrderView();

            return orderView; 
        }
    }
}
