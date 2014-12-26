using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.Presentation.Basket
{
    public interface IBasket
    {
        IEnumerable<Product> Items { get; }
        void Add(Product product);
    }
}
