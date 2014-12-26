using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;

namespace Agathas.Storefront.Services.Interfaces
{
    public interface IProductCatalogService
    {
        GetFeaturedProductsResponse GetFeaturedProducts();
        GetProductsByCategoryResponse GetProductsByCategory(
                                         GetProductsByCategoryRequest request);
        GetProductResponse GetProduct(GetProductRequest request);

        GetAllCategoriesResponse GetAllCategories();
    }

}
