using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASPPatterns.Chap8.CoR.Controller.Navigation
{
    public class PageNavigator : ASPPatterns.Chap8.CoR.Controller.Navigation.IPageNavigator
    {
        public void NavigateTo(PageDirectory page)
        {
            switch (page)
            {
                case PageDirectory.Home:
                    HttpContext.Current.Server.Transfer("~/views/Home/Index.aspx");
                    break;
                case PageDirectory.ProductDetail:
                    HttpContext.Current.Server.Transfer("~/views/Product/ProductDetail.aspx");
                    break;
                case PageDirectory.CategoryProducts:
                    HttpContext.Current.Server.Transfer("~/views/Product/CategoryProducts.aspx");
                    break;
                case PageDirectory.MissingPage:
                    HttpContext.Current.Server.Transfer("~/views/Shared/404.aspx");
                    break;
            }
        }
    }
}
