using System;
using System.Collections.Generic;
using ASPPatterns.Chap9.AjaxTemplates.Model;

namespace ASPPatterns.Chap9.AjaxTemplates.StubRepository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> FindAll()
        {
            return new DataContext().Products;
        }
        
        public IEnumerable<Product> FindAllBy(int categoryId)
        {
            return new DataContext().Products.FindAll(prod => prod.Category.Id == categoryId);
        }
    }
}
