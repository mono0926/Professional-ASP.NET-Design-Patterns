using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASPPatterns.Chap8.MVP.Presentation.Navigation
{
    public class PageNavigator : IPageNavigator 
    {        
        public void NaviagteTo(PageDirectory page)
        {
            switch (page)
            {
                case PageDirectory.Basket:
                    HttpContext.Current.Response.Redirect("/Views/Basket/Basket.aspx");
                    break;
                default:
                    throw new ApplicationException("Cannot navigate to " + page.ToString() );                    
            }  
        }        
    }
}
