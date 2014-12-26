using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StrategyPattern.Model
{
    public class BasketDiscountMoneyOff : IBasketDiscountStrategy 
    {
        public decimal GetTotalCostAfterApplyingDiscountTo(Basket basket)
        {            
            if (basket.TotalCost > 100)
                return basket.TotalCost - 10m;
            if (basket.TotalCost > 50)
                return basket.TotalCost - 5m;
            else
                return basket.TotalCost;
        }     
    }
}
