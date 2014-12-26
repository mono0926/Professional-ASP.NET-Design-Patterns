using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ASPPatterns.Chap5.DecoratorPattern.Model;

namespace ASPPatterns.Chap5.DecoratorPattern.Tests
{
    [TestFixture]
    public class BasketItemTests
    {
        [Test]
        public void The_Basket_Item_Should_Caclulate_The_Line_Cost_By_Multipling_The_Product_Price_By_The_Quantity()
        {
            decimal productPrice = 100;
            decimal expectedLineTotal = productPrice * 2;
            IPrice basePrice = new BasePrice { Cost = productPrice };
            Product product = new Product { Price = basePrice };
            IBasketItem baseBasketItem = new BasketItem { Product = product, Quantity = 2 };

            Assert.AreEqual(expectedLineTotal, baseBasketItem.LineTotal); 
        }

        [Test]
        public void The_BOGOFF_Basket_Item_Decorator_Should_Charge_For_One_Item_If_There_Are_Two()
        {
            decimal productPrice = 100;
            decimal expectedLineTotal = productPrice * 1;
            IPrice basePrice = new BasePrice { Cost = productPrice };
            Product product = new Product { Price = basePrice };
            IBasketItem baseBasketItem = new BasketItem { Product = product, Quantity = 2 };

            baseBasketItem = new BogOffBasktemItemDecorator(baseBasketItem);

            Assert.AreEqual(expectedLineTotal, baseBasketItem.LineTotal);  
        }

        [Test]
        public void The_BOGOFF_Basket_Item_Decorator_Should_Charge_For_Two_Items_If_There_Are_Three()
        {
            decimal productPrice = 100;
            decimal expectedLineTotal = productPrice * 2;
            IPrice basePrice = new BasePrice { Cost = productPrice };
            Product product = new Product { Price = basePrice };
            IBasketItem baseBasketItem = new BasketItem { Product = product, Quantity = 3 };

            baseBasketItem = new BogOffBasktemItemDecorator(baseBasketItem);

            Assert.AreEqual(expectedLineTotal, baseBasketItem.LineTotal);
        }

        [Test]
        public void If_Basket_Item_Quantity_Is_Zero_The_Line_Total_Should_Be_Zero()
        {
            decimal productPrice = 100;
            decimal expectedLineTotal = 0;
            IPrice basePrice = new BasePrice { Cost = productPrice };
            Product product = new Product { Price = basePrice };
            IBasketItem baseBasketItem = new BasketItem { Product = product, Quantity = 0 };
            
            Assert.AreEqual(expectedLineTotal, baseBasketItem.LineTotal);
        }

        [Test]
        public void When_Applying_The_BogOffBasktemItemDecorator_If_Basket_Item_Quantity_Is_Zero_The_Line_Total_Should_Be_Zero()
        {
            decimal productPrice = 100;
            decimal expectedLineTotal = 0;
            IPrice basePrice = new BasePrice { Cost = productPrice };
            Product product = new Product { Price = basePrice };
            IBasketItem baseBasketItem = new BasketItem { Product = product, Quantity = 0 };

            baseBasketItem = new BogOffBasktemItemDecorator(baseBasketItem);

            Assert.AreEqual(expectedLineTotal, baseBasketItem.LineTotal);
        }        
    }
}
