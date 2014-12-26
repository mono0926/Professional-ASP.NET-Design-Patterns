using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StrategyPattern.Model
{
    public class Basket
    {
        private IBasketDiscountStrategy _basketDiscount;

        public Basket(DiscountType discountType)
        {
            _basketDiscount = BasketDiscountFactory.GetDiscount(discountType);
        }

        public decimal TotalCost { get; set; }        

        public decimal GetTotalCostAfterDiscount()
        {
            return _basketDiscount.GetTotalCostAfterApplyingDiscountTo(this); 
        }
    }
}
