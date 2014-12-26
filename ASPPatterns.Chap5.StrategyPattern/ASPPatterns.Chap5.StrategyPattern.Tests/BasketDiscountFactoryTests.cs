using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.StrategyPattern.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace ASPPatterns.Chap5.StrategyPattern.Tests
{
    [TestFixture]
    public class BasketDiscountFactoryTests
    {
        [Test]
        public void BasketDiscountFactory_Should_Return_BasketDiscountMoneyOff_When_Passed_DiscountType_Of_MoneyOff()
        {
            IBasketDiscountStrategy basketDiscountStrategy = BasketDiscountFactory.GetDiscount(DiscountType.MoneyOff);

            Assert.That(basketDiscountStrategy, Is.TypeOf(typeof(BasketDiscountMoneyOff)));
        }

        [Test]
        public void BasketDiscountFactory_Should_Return_BasketDiscountPercentageOff_When_Passed_DiscountType_Of_PercentageOff()
        {
            IBasketDiscountStrategy basketDiscountStrategy = BasketDiscountFactory.GetDiscount(DiscountType.PercentageOff);

            Assert.That(basketDiscountStrategy, Is.TypeOf(typeof(BasketDiscountPercentageOff)));
        }
    }
}
