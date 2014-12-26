using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MonoRail.Framework;
using ASPPatterns.Chap8.CastleMonoRail.Model;
using ASPPatterns.Chap8.CastleMonoRail.StubRepository;
using StructureMap;

namespace ASPPatterns.Chap8.CastleMonoRail.UI.Web.Controllers
{
    [Layout("default")]
    public class ProductController : SmartDispatcherController
    {
        private ProductService _productService;

        public ProductController()
        {
            _productService = ObjectFactory.GetInstance<ProductService>();
        }

        public void ProductDetail()
        {            
            int productId;
            int.TryParse(Request.QueryString["ProductId"], out productId);

            Product product = _productService.GetProductBy(productId);

            if (product != null)
            {
                PropertyBag["product"] = _productService.GetProductBy(productId);
                PropertyBag["categories"] = _productService.GetAllCategories();                
            }
            else
                RenderView("productnotfound");
        }

        public void CategoryProducts()
        {
            int categoryId = int.Parse(Request.QueryString["CategoryId"]);

            PropertyBag["products"] = _productService.GetAllProductsIn(categoryId);
            PropertyBag["categories"] = _productService.GetAllCategories();
            PropertyBag["category"] = _productService.GetCategoryBy(categoryId);
            
        }
    }
}