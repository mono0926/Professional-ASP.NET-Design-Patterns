using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.Presentation
{
    public class CategoryProductsPresenter : ICategoryProductsPresenter
    {
        private ICategoryProductsView _view;
        private ProductService _productService;

        public CategoryProductsPresenter(ICategoryProductsView view, ProductService productService)
        {
            _productService = productService;
            _view = view;
        }

        public void Display()
        {
           _view.CategoryProductList = _productService.GetAllProductsIn(_view.CategoryId);
           _view.Category = _productService.GetCategoryBy(_view.CategoryId);
           _view.CategoryList = _productService.GetAllCategories(); 
        }    
    }
}
