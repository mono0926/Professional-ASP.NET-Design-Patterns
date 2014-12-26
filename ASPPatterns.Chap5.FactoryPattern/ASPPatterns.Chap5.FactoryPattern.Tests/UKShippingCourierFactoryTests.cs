using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.chap5.FactoryPattern.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace ASPPatterns.Chap5.FactoryPattern.Tests
{
    [TestFixture]
    public class UKShippingCourierFactoryTests
    {
        [Test]
        public void UKShippingCourierFactory_Should_Create_DHL_Shipping_Courier_For_An_Order_With_A_TotalCost_Of_Over_100()
        {
            Order order = new Order() { TotalCost = 101};

            IShippingCourier courier = UKShippingCourierFactory.CreateShippingCourier(order);

            Assert.That(courier, Is.TypeOf(typeof(DHL)));
        }

        [Test]
        public void UKShippingCourierFactory_Should_Create_DHL_Shipping_Courier_For_An_Order_With_A_Weight_In_KG_Over_5()
        {
            Order order = new Order() { WeightInKG = 6 };

            IShippingCourier courier = UKShippingCourierFactory.CreateShippingCourier(order);

            Assert.That(courier, Is.TypeOf(typeof(DHL)));
        }

        [Test]
        public void UKShippingCourierFactory_Should_Create_RoyalMail_Shipping_Courier_For_An_Order_With_A_Weight_In_KG_5_And_Under()
        {
            Order order = new Order() { WeightInKG = 5 };

            IShippingCourier courier = UKShippingCourierFactory.CreateShippingCourier(order);

            Assert.That(courier, Is.TypeOf(typeof(RoyalMail)));
        }

        [Test]
        public void UKShippingCourierFactory_Should_Create_DHL_Shipping_Courier_For_An_Order_With_A_TotalCost_Of_100_And_Under()
        {
            Order order = new Order() { TotalCost = 100 };

            IShippingCourier courier = UKShippingCourierFactory.CreateShippingCourier(order);

            Assert.That(courier, Is.TypeOf(typeof(RoyalMail)));
        }
    }
}
