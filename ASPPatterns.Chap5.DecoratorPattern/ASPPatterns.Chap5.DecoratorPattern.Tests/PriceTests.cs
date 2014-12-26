using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ASPPatterns.Chap5.DecoratorPattern.Model;

namespace ASPPatterns.Chap5.DecoratorPattern.Tests
{
    [TestFixture]
    public class PriceTests
    {
        [Test]
        public void The_Trade_Discount_Decorator_Will_Apply_5_Percent_Discount_To_A_Price()
        {
            IPrice basePrice = new BasePrice {  Cost  = 100 };
            decimal priceAfterDiscountShouldEqual = basePrice.Cost * 0.95m;

            basePrice = new TradeDiscountPriceDecorator(basePrice);

            Assert.AreEqual(priceAfterDiscountShouldEqual, basePrice.Cost);  
        }

        [Test]
        public void The_Currency_Multiplier_Decorator_Will_Apply_A_Given_Currency_To_A_Price()
        {
            IPrice basePrice = new BasePrice { Cost = 100 };
            decimal priceAfterDiscountShouldEqual = basePrice.Cost * 0.95m;

            basePrice = new TradeDiscountPriceDecorator(basePrice);

            Assert.AreEqual(priceAfterDiscountShouldEqual, basePrice.Cost);
        }
    }
}
