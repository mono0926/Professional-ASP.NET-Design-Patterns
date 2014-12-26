using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using ASPPatterns.Chap5.DecoratorPattern.Model;   

namespace ASPPatterns.Chap5.DecoratorPattern.Specifications
{
    public class BasketItemSpecs
    {
        public abstract class with_basketitem_that_contains_2_of_a_product_with_a_price_of_100
        {
            protected static IBasketItem basketItem;
            public static decimal productPrice = 100;

            Establish context = () =>
            {
                IPrice basePrice = new BasePrice { Cost = productPrice };
                Product product = new Product { Price = basePrice };
                basketItem = new BasketItem { Product = product, Quantity = 2 };
                
            };

        }

        [Subject("Basket Item that contains 2 of a product with a price of 100")]
        public class when_no_offer_is_applied : with_basketitem_that_contains_2_of_a_product_with_a_price_of_100
        {
            Because of = () =>
            {
               //
            };

            It line_total_should_be_200 = () =>
            {
                basketItem.LineTotal.ShouldEqual(200M);  
            };          
        }

        [Subject("Basket Item that contains 2 of a product with a price of 100")]
        public class when_BogOffBasktemItemDecorator_is_applied : with_basketitem_that_contains_2_of_a_product_with_a_price_of_100
        {
            Because of = () =>
            {
                basketItem = new BogOffBasktemItemDecorator(basketItem); 
            };

            It line_total_should_be_100 = () =>
            {
                basketItem.LineTotal.ShouldEqual(100M);
            };
        }
    }
}
