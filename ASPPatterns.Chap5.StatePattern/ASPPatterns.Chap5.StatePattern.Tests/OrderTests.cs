using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.StatePattern.Model;
using ASPPatterns.Chap5.StatePattern.Model.OrderStates;
using Moq;
using NUnit.Framework;

namespace ASPPatterns.Chap5.StatePattern.Tests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void An_Order_Should_Delegate_To_Its_Current_State_When_Determining_If_Can_Be_Canceled()
        {            
            var orderStateMocker = new Mock<IOrderState>();           
            Order order = new Order(orderStateMocker.Object);

            orderStateMocker.Setup(os => os.CanCancel(order));            

            order.Cancel();

            orderStateMocker.VerifyAll();
        }

        [Test]
        public void An_Order_Should_Delegate_To_Its_Current_State_When_Determining_If_Can_Be_Shipped()
        {
            var orderStateMocker = new Mock<IOrderState>();
            Order order = new Order(orderStateMocker.Object);

            orderStateMocker.Setup(os => os.CanShip(order));

            order.Ship();

            orderStateMocker.VerifyAll();
        }
    }
}
