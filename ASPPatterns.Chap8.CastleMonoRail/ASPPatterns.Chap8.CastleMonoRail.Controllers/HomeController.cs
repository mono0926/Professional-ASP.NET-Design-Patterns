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
    public class HomeController : SmartDispatcherController
    {
        private ProductService _productService;

        public HomeController()
        {
            _productService = ObjectFactory.GetInstance<ProductService>();
        }

        public void Index()
        {
            PropertyBag["products"] = _productService.GetBestSellingProducts();
            PropertyBag["categories"] = _productService.GetAllCategories();            
        }
    }
}
