using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.StrategyPattern.Model;
using NUnit.Framework;

namespace ASPPatterns.Chap5.StrategyPattern.Tests
{
    [TestFixture]
    public class BasketTest
    {
        [Test]
        public void Basket_With_DiscountType_Of_PercentageOff_Should_Take_15pc_Off_A_Baskets_Total_If_Over_100()
        {
            int totalAfterDiscount = 85;
            Basket basket = new Basket(DiscountType.PercentageOff) {TotalCost = 100};
            Assert.AreEqual(totalAfterDiscount, basket.GetTotalCostAfterDiscount());
        }

        [Test]
        public void Basket_With_DiscountType_Of_MoneyOff_Should_Take_10_Off_A_Baskets_Total_If_Over_100()
        {
            int totalAfterDiscount = 91;
            Basket basket = new Basket(DiscountType.MoneyOff) { TotalCost = 101 };
            Assert.AreEqual(totalAfterDiscount, basket.GetTotalCostAfterDiscount());
        }
    }
}
