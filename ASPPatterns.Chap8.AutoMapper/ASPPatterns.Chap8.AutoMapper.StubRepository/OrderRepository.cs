using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.AutoMapper.Model;

namespace ASPPatterns.Chap8.AutoMapper.StubRepository
{
    public class OrderRepository : IOrderRepository
    {        
        public Order FindBy(int Id)
        {
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.Customer = new Customer { Name = "Scott Millett" };
            order.Items = new List<Item>();
            order.Items.Add(new Item { Qty = 1, Product = new Product { Name = "Hat" } });

            return order;            
        }     
    }
}
