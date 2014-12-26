using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Controllers.ViewModels;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers
{
    public static class BasketMapper
    {
        public static BasketSummaryView ConvertToSummary(this BasketView basket)
        {
            return new BasketSummaryView()
            {
                BasketTotal = basket.BasketTotal,
                NumberOfItems = basket.NumberOfItems
            };
        }
    }

}
