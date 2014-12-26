using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap8.MVP.Presentation;
using ASPPatterns.Chap8.MVP.StubRepository;
using ASPPatterns.Chap8.MVP.Model;
using ASPPatterns.Chap8.MVP.Presentation.Basket;
using ASPPatterns.Chap8.MVP.UI.Web.Views.Shared;
using StructureMap;

namespace ASPPatterns.Chap8.MVP.UI.Web.Views.Basket
{
    public partial class Basket : System.Web.UI.Page, IBasketView
    {
        private IBasketPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new BasketPresenter(this, ObjectFactory.GetInstance<ProductService>(), ObjectFactory.GetInstance<IBasket>()); 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Display();
        }
        
        public IEnumerable<Category> CategoryList
        {
            set
            {
                Shop shopMasterPage = (Shop)Page.Master;
                shopMasterPage.CategoryListControl.SetCategoriesToDisplay(value);
            }
        }

        public IEnumerable<Model.Product> BasketItems
        {
            set {
                rptBasket.DataSource = value;
                rptBasket.DataBind(); 
            }
        }        
    }
}
