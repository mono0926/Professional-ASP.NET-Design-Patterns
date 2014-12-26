using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.ASPNETMVC.AppService.Views
{
    public abstract class BaseView
    {
        public IEnumerable<CategoryView> Categories { get; set; }           
    }
}
