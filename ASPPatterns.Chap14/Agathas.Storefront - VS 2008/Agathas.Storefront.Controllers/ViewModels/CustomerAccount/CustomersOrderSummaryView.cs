using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.CustomerAccount
{
    public class CustomersOrderSummaryView : BaseCustomerAccountView
    {
        public IEnumerable<OrderSummaryView> Orders { get; set; }
    }

}
