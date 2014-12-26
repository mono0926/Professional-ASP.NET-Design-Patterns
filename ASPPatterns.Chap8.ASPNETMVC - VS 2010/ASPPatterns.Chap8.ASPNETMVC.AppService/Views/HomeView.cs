using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.ASPNETMVC.AppService.Views
{
    public class HomeView : BaseView 
    {
        public IEnumerable<ProductView> BestSellingProducts { get; set; }
    }
}
