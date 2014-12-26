using System.Web.Mvc;
using Agathas.Storefront.Controllers.ViewModels.ProductCatalog;
using Agathas.Storefront.Infrastructure.CookieStorage;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;

namespace Agathas.Storefront.Controllers.Controllers
{
    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productCatalogService;

        public HomeController(IProductCatalogService productCatalogService,
                               ICookieStorageService cookieStorageService)
            : base(cookieStorageService, productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }


        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();
            homePageView.BasketSummary = base.GetBasketSummaryView();

            GetFeaturedProductsResponse response =
                           _productCatalogService.GetFeaturedProducts();
            homePageView.Products = response.Products;

            return View(homePageView);
        }
    }
}
