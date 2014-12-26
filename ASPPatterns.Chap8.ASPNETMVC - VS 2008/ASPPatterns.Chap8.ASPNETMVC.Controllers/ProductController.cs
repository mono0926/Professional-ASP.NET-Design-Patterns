using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ASPPatterns.Chap8.ASPNETMVC.AppService;
using ASPPatterns.Chap8.ASPNETMVC.AppService.Views;

namespace ASPPatterns.Chap8.ASPNETMVC.Controllers
{
    public class ProductController : Controller 
    {
        private ShopService _shopService;
       
        public ProductController(ShopService shopService)
        {
            _shopService = shopService;
        }

        public ActionResult CategoryProducts(int categoryId)
        {
            CategoryProductsPageView viewModel = _shopService.GetCategoryProductPageViewFor(categoryId); 

            ViewData["categories"] = viewModel.Categories;

            return View(viewModel);
        }

        public ActionResult Detail(string Id)
        {
            ProductDetailPageView viewModel = _shopService.GetProductDetailPageViewFor(int.Parse(Id));

            ViewData["categories"] = viewModel.Categories;

            return View("ProductDetail", viewModel);
        }
    }    
}
