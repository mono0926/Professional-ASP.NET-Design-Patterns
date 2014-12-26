using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DecoratorPattern.Model
{
    public interface IProductRepository
    {
        IEnumerable<Product> FindAll(); 
    }
}
