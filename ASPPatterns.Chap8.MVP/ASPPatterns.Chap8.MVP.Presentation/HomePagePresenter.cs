using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.Presentation
{
    public class HomePagePresenter : IHomePagePresenter
    {
        private IHomeView _view;
        private ProductService _productService;

        public HomePagePresenter(IHomeView view, ProductService productService)
        {
            _productService = productService;
            _view = view;
        }

        public void Display()
        {
            _view.TopSellingProduct = _productService.GetBestSellingProducts();
            _view.CategoryList = _productService.GetAllCategories(); 
        }       
    }
}
