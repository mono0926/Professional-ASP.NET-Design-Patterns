using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.UI.Web.Views.Shared
{
    public partial class ProductList : System.Web.UI.UserControl
    {
        public void SetProductsToDisplay(IEnumerable<Model.Product> products)
        {
            this.rptProducts.DataSource = products;
            this.rptProducts.DataBind(); 
        }
    }
}