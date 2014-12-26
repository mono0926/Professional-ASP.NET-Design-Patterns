using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap3.Layered.Model;   

namespace ASPPatterns.Chap3.Layered.Repository
{
    public class ProductRepository : IProductRepository 
    {        
        public IList<Model.Product> FindAll()
        {
            var products = from p in new ShopDataContext().Products
                           select new Model.Product
                               {
                                   Id = p.ProductId, 
                                   Name = p.ProductName,                                   
                                   Price = new Model.Price(p.RRP, p.SellingPrice)                                                                        
                               };            

            return products.ToList();
        }
     
    }
}
