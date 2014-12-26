using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ASPPatterns.Chap9.AjaxTemplates.Model;
using ASPPatterns.Chap9.AjaxTemplates.StubRepository;

namespace ASPPatterns.Chap9.AjaxTemplates.Controllers
{
    public class ProductController : Controller
    {
        private ProductService _productService;

        public ProductController()
            : this(new ProductService(new CategoryRepository(), new ProductRepository()))
        { }

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public ActionResult CategoryProducts(int categoryId)
        {            
            IEnumerable<Category> categories = _productService.GetAllCategories();
            IEnumerable<Product> products = _productService.GetAllProductsIn(categoryId);
            List<CategoryBrandView> categoryBrandViews = CategoryBrandViewMapper.GetCategoryBrandViews(categoryId, categories, products);

            ViewData["categories"] = categoryBrandViews;            

            return View(products);
        }
        

        public JsonResult GetProductsIn(string categoryId, string brandId)
        {                                    
            IEnumerable<Product> products = _productService.GetAllProductsIn(int.Parse(categoryId), int.Parse(brandId));

            System.Threading.Thread.Sleep(1000);

            return Json(products);
        }
    }
}
