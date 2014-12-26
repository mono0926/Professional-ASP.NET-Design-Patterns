using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.CustomerAccount
{
    public class CustomerDetailView : BaseCustomerAccountView
    {
        public CustomerView Customer { get; set; }
    }

}
