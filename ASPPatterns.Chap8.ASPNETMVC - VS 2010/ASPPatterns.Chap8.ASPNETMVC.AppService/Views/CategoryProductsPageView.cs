using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.ASPNETMVC.AppService.Views
{
    public class CategoryProductsPageView : BaseView 
    {
        public IEnumerable<ProductView> Products { get; set; }
        public CategoryView Category { get; set; }
    }
}
