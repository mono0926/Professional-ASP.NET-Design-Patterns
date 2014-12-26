using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DecoratorPattern.Model
{
    public interface IBasketItem
    {
        Product Product { get; set; }
        int Quantity { get; set; }
        decimal LineTotal { get; }
    }
}
