using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ASPPatterns.Chap8.ASPNETMVC.AppService;
using ASPPatterns.Chap8.ASPNETMVC.AppService.Views;

namespace ASPPatterns.Chap8.ASPNETMVC.Controllers
{   
    public class HomeController : Controller 
    {
        private ShopService _shopService;
      
        public HomeController(ShopService shopService)
        {
            _shopService = shopService;
        }

        public ActionResult Index()
        {
            HomeView viewModel = _shopService.GetHomePageView();
            ViewData["categories"] = viewModel.Categories;

            return View(viewModel);
        }        
    }
}
