using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DependencyInjection.Model
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;            
        }

        public IEnumerable<Product> GetProductsAndApplyDiscount(IProductDiscountStrategy discount)
        {
            IEnumerable<Product> products = _productRepository.FindAll();

            foreach (Product p in products)
                p.AdjustPriceWith(discount);

            return products;
        }
    }
}
