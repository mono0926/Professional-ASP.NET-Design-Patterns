using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.ASPNETMVC.Model;
using ASPPatterns.Chap8.ASPNETMVC.AppService.Views;
using ASPPatterns.Chap8.ASPNETMVC.AppService.Mapping;

namespace ASPPatterns.Chap8.ASPNETMVC.AppService
{
    public class ShopService
    {
        private ProductService _productService;

        public ShopService(ProductService productService)
        {
            _productService = productService;
        }

        public HomeView GetHomePageView()
        {
            IEnumerable<ProductView> products = _productService.GetBestSellingProducts().ConvertToProductViewList();
            IEnumerable<CategoryView> categories = _productService.GetAllCategories().ConvertToCategoryViewList();

            HomeView productViewModel = new HomeView { BestSellingProducts = products, Categories = categories };

            return productViewModel;
        }

        public ProductDetailPageView GetProductDetailPageViewFor(int ProductId)
        {
            ProductDetailView product = _productService.GetProductBy(ProductId).ConvertToProductDetailView(); 
            IEnumerable<CategoryView> categories = _productService.GetAllCategories().ConvertToCategoryViewList();

            ProductDetailPageView productDetailPageViewModel = new ProductDetailPageView { Product = product, Categories = categories};

            return productDetailPageViewModel;
        }

        public CategoryProductsPageView GetCategoryProductPageViewFor(int categoryId)
        {
            IEnumerable<ProductView> products = _productService.GetAllProductsIn(categoryId).ConvertToProductViewList();
            CategoryView category = _productService.GetCategoryBy(categoryId).ConvertToCategoryView();
            IEnumerable<CategoryView> categories = _productService.GetAllCategories().ConvertToCategoryViewList();

            CategoryProductsPageView categoryProductsPageView = new CategoryProductsPageView { Category = category,  Products = products, Categories = categories };

            return categoryProductsPageView;
        }
    }
}
