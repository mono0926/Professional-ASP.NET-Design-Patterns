using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap2.Service; 

namespace ASPPatterns.Chap2.Tests.Mocks
{
    public class MockProductRepository : IProductRepository 
    {
        private int _numberOfTimesCalled = 0;

        public int NumberOfTimesCalled()
        {
            return _numberOfTimesCalled;
        }

        public IList<Product> GetAllProductsIn(int categoryId)
        {
            _numberOfTimesCalled++;

            IList<Product> products = new List<Product>();

            return products;
        }        
    }
}
