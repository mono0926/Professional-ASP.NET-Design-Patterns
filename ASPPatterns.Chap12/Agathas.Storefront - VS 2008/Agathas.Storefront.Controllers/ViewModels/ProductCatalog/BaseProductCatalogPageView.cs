using System.Collections.Generic;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.ProductCatalog
{
    public abstract class BaseProductCatalogPageView : BasePageView 
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }

}
