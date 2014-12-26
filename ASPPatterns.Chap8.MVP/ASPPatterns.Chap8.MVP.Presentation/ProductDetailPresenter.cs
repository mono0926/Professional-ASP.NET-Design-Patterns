using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;
using ASPPatterns.Chap8.MVP.Presentation.Basket;
using ASPPatterns.Chap8.MVP.Presentation.Navigation;

namespace ASPPatterns.Chap8.MVP.Presentation
{
    public class ProductDetailPresenter : IProductDetailPresenter
    {
        private IProductDetailView _view;
        private ProductService _productService;
        private IBasket _basket;
        private IPageNavigator _pageNavigator;

        public ProductDetailPresenter(IProductDetailView view, ProductService productService, 
                                      IBasket basket, IPageNavigator pageNavigator)
        {
            _productService = productService;
            _view = view;
            _basket = basket;
            _pageNavigator = pageNavigator;
        }

        public void Display()
        {
            Product product = _productService.GetProductBy(_view.ProductId);
            _view.Name = product.Name;
            _view.Description = product.Description;
            _view.Price = product.Price;
           _view.CategoryList = _productService.GetAllCategories(); 
        }

        public void AddProductToBasketAndShowBasketPage()
        {
            Product product = _productService.GetProductBy(_view.ProductId);

            _basket.Add(product);

            _pageNavigator.NaviagteTo(PageDirectory.Basket);   
        }
    }
}
