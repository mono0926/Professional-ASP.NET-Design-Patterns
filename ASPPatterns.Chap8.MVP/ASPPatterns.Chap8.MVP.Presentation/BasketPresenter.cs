using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;
using ASPPatterns.Chap8.MVP.Presentation.Basket;

namespace ASPPatterns.Chap8.MVP.Presentation
{
    public class BasketPresenter : IBasketPresenter
    {
        private IBasketView _view;
        private ProductService _productService;
        private IBasket _basket;

        public BasketPresenter(IBasketView view, ProductService productService, 
                               IBasket basket)
        {
            _productService = productService;
            _view = view;
            _basket = basket;
        }

        public void Display()
        {
           _view.BasketItems = _basket.Items; 
           _view.CategoryList = _productService.GetAllCategories(); 
        }
    }
}
