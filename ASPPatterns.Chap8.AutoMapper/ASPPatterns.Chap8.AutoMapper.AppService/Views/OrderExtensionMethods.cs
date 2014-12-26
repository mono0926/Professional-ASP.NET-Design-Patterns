using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.AutoMapper.Model;
using AutoMapper;

namespace ASPPatterns.Chap8.AutoMapper.AppService.Views
{
    public static class OrderExtensionMethods
    {
        public static OrderView ConvertToOrderView(this Order order)
        {
            return Mapper.Map<Order, OrderView>(order);
        }
    }
}
