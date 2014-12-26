using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DecoratorPattern.Model
{
    public static class ProductCollectionExtensionMethods
    {
        public static void ApplyCurrencyMultiplier(this IEnumerable<Product> products)
        {
            foreach (Product p in products)            
                p.Price = new CurrencyPriceDecorator(p.Price, 0.78m);            
        }

        public static void ApplyTradeDiscount(this IEnumerable<Product> products)
        {
            foreach (Product p in products)            
                p.Price = new TradeDiscountPriceDecorator(p.Price);            
        }
    }
}
