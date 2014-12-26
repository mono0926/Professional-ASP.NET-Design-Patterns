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

namespace ASPPatterns.Chap8.MVP.UI.Web.Views.Product
{
    public partial class CategoryProducts : System.Web.UI.Page, ICategoryProductsView
    {
        private ICategoryProductsPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new CategoryProductsPresenter(this, ObjectFactory.GetInstance<ProductService>()); 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Display();
        }
        
        public int CategoryId
        {            
            get { return int.Parse(Request.QueryString["CategoryId"]); }
        }

        public Category Category
        {
            set { litCategoryName.Text = value.Name; }
        }

        public IEnumerable<Model.Product> CategoryProductList
        {
            set { this.plCategoryProducts.SetProductsToDisplay(value); }
        }

        public IEnumerable<Category> CategoryList
        {
            set
            {
                Shop shopMasterPage = (Shop)Page.Master;
                shopMasterPage.CategoryListControl.SetCategoriesToDisplay(value);
            }
        }
       
    }
}
