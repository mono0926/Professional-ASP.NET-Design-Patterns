using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap2.Service; 

namespace ASPPatterns.Chap2.Tests.Stubs
{
    public class StubProductRepository : IProductRepository 
    {        
        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products = new List<Product>();            

            return products;
        }
    }
}
