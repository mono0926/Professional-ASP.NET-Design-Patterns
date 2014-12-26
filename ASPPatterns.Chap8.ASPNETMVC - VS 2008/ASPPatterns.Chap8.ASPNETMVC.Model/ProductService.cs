using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.ASPNETMVC.Model
{
    public class ProductService
    {
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        public ProductService(ICategoryRepository categoryRepository,
                              IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public Product GetProductBy(int id)
        {
            return _productRepository.FindBy(id);  
        }

        public IEnumerable<Product> GetAllProductsIn(int catetgoryId)
        {
            return _productRepository.FindAll().Where(cat => cat.Category.Id == catetgoryId);          
        }

        public Category GetCategoryBy(int id)
        {
            return _categoryRepository.FindBy(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.FindAll(); 
        }

        public IEnumerable<Product> GetBestSellingProducts()
        {
            return _productRepository.FindAll().Take(4);
        }
   }
}