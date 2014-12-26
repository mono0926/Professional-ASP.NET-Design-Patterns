using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ASPPatterns.Chap9.AjaxTemplates.Model;
using ASPPatterns.Chap9.AjaxTemplates.StubRepository;

namespace ASPPatterns.Chap9.AjaxTemplates.Controllers
{
    public class HomeController : Controller
    {        
        private ProductService _productService;

        public HomeController()
            : this(new ProductService(new CategoryRepository(), new ProductRepository()))
        { }

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {           
            IEnumerable<Category> categories = _productService.GetAllCategories();
            IList<CategoryBrandView> categoryBrandViews = CategoryBrandViewMapper.GetCategoryBrandViews(categories);
                        
            ViewData["categories"] = categoryBrandViews; 
            
            return View();
        }
    }
}
