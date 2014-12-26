using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap8.MVP.Presentation;
using ASPPatterns.Chap8.MVP.Model;
using ASPPatterns.Chap8.MVP.StubRepository;
using ASPPatterns.Chap8.MVP.UI.Web.Views.Shared;
using StructureMap;

namespace ASPPatterns.Chap8.MVP.UI.Web.Views.Home
{
    public partial class Index : System.Web.UI.Page, IHomeView
    {
        private IHomePagePresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new HomePagePresenter(this, ObjectFactory.GetInstance<ProductService>());
        }
 
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Display(); 
        }

        public IEnumerable<Model.Product> TopSellingProduct
        {
            set { plBestSellingProducts.SetProductsToDisplay(value); }
        }

        public IEnumerable<Category> CategoryList
        {
            set {
                Shop shopMasterPage = (Shop)Page.Master;
                shopMasterPage.CategoryListControl.SetCategoriesToDisplay(value);  
            }
        }        
    }
}
