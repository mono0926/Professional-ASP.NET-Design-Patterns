using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.UI.Web.Views.Shared
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        public void SetCategoriesToDisplay(IEnumerable<Category> categories)
        {
            this.rptCategoryList.DataSource = categories;
            this.rptCategoryList.DataBind();
        }
    }
}