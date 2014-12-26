using System;
using System.Collections.Generic;

namespace ASPPatterns.Chap5.DependencyInjection.Model
{
    public interface IProductRepository
    {
        IEnumerable<Product> FindAll();
    }
}
