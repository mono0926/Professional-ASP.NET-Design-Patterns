using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap8.AutoMapper.AppService;
using ASPPatterns.Chap8.AutoMapper.AppService.Views;

namespace ASPPatterns.Chap8.AutoMapper.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderView order = new OrderService().GetOrder(1);  

            Response.Write(String.Format("CustomerName: {0}<br/>", order.CustomerName));
            Response.Write(String.Format("OrderDate: {0}<br/>", order.OrderDate));

            foreach (ItemView item in order.Items)
            {
                Response.Write(String.Format("Qty: {0}, Product: {1}<br/>", item.Qty, item.ProductName ));
            }
        }
    }
}
