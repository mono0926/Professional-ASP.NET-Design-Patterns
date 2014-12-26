using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DependencyInjection.Model
{
    public class LinqProductRepository : IProductRepository
    {
        public IEnumerable<Product> FindAll()
        {            
            return new List<Product>();
        }     
    }
}
