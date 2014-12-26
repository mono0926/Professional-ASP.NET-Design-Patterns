using System.Collections.Generic;
using System.Web.Mvc;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.Controllers
{
    public class ProductCatalogBaseController : Controller
    {
        private readonly IProductCatalogService _productCatalogService;

        public ProductCatalogBaseController(
                          IProductCatalogService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        public IEnumerable<CategoryView> GetCategories()
        {
            GetAllCategoriesResponse response =
                                _productCatalogService.GetAllCategories();

            return response.Categories;
        }
    }

}
