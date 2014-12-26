using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPPatterns.Chap8.MVP.UI.Web.Views.Shared
{
    public partial class Shop : System.Web.UI.MasterPage
    {
        public CategoryList CategoryListControl
        {
            get { return this.CategoryList1; }
        }
    }
}
