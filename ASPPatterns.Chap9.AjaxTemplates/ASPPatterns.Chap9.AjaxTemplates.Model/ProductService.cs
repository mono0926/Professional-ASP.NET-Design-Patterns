using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap9.AjaxTemplates.Model
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
       
        public IEnumerable<Product> GetAllProductsIn(int categoryId)
        {
            return _productRepository.FindAllBy(categoryId);   
        }

        public IEnumerable<Product> GetAllProductsIn(int categoryId, int brandId)
        {
            return _productRepository.FindAllBy(categoryId).Where(prod => prod.Brand.Id == brandId);
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