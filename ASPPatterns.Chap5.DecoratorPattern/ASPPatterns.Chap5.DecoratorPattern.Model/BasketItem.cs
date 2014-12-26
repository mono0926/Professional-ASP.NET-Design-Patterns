using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DecoratorPattern.Model
{
    public class BasketItem : IBasketItem 
    {        
        public decimal LineTotal
        {
            get  { return Product.Price.Cost * Quantity; }
        }

        public Product Product { get; set; }
        
        public int Quantity { get; set; }
    }
}
