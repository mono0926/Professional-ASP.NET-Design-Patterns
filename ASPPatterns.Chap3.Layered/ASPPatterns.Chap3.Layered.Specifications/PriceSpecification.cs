using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using ASPPatterns.Chap3.Layered.Model; 

namespace ASPPatterns.Chap3.Layered.Specifications
{
    public abstract class with_rrp_of_10_and_sellingprice_of_9_99
    {
        protected static Price price;

        Establish context = () =>
        {
            price = new Price(10M, 9.99M);
        };

    }

    [Subject("Applying a Trade Discount")]
    public class when_a_trade_discount_is_applied_to_a_price : with_rrp_of_10_and_sellingprice_of_9_99
    {
        Because of = () =>
        {
            price.SetDiscountStrategyTo(new TradeDiscountStrategy()); 
        };

        It rrp_should_remain_the_same = () =>
        {
            price.RRP.ShouldEqual(10M);
        };

        It selling_price_should_be_5pc_less = () =>
        {
            price.RRP.ShouldEqual(10M);
        };
    }
}
