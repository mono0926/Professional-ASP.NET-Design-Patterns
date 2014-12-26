using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.ProxyPattern.Model;
using ASPPatterns.Chap7.ProxyPattern.Repository;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace ASPPatterns.Chap7.ProxyPattern.Test
{
    [TestFixture]
    public class CustomerProxyTests
    {
        [Test]
        public void CustomerProxy_Should_Delegate_The_Retrieval_Of_Orders_To_The_OrderRepository()
        {
            Guid customerId = Guid.NewGuid();
            
            var mockery = new Mock<IOrderRepository>();
            mockery.Setup(or => or.FindAllBy(customerId));

            Customer customer = new CustomerProxy() {OrderRepository = mockery.Object, Id = customerId};

            IEnumerable<Order> orders = customer.Orders;

            mockery.VerifyAll();

        }
    }
}
