using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.StatePattern.Model;
using ASPPatterns.Chap5.StatePattern.Model.OrderStates;
using NUnit.Framework;

namespace ASPPatterns.Chap5.StatePattern.Tests
{
    [TestFixture]
    public class OrderCanceledStateTests
    {
        [Test]
        public void Canceled_Order_State_Should_Not_Allow_An_Item_To_Be_Shipped()
        {
            OrderCanceledState orderCanceledState = new OrderCanceledState();
            Order order = new Order(orderCanceledState);

            Assert.IsFalse(orderCanceledState.CanShip(order));
        }

        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void Canceled_Order_State_Should_Throw_An_Exception_If_An_Attempt_Is_Made_To_Ship_It_Shipped()
        {
            OrderCanceledState orderCanceledState = new OrderCanceledState();
            Order order = new Order(orderCanceledState);

            orderCanceledState.Ship(order);
        }
    }
}
