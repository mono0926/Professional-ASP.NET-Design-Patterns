using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap7.QueryObject.Model;
using ASPPatterns.Chap7.QueryObject.Repository;
using System.Configuration;

namespace ASPPatterns.Chap7.QueryObject.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IOrderRepository orderRepository = new OrderRepository(ConfigurationManager.ConnectionStrings["ShopConnectionString"].ConnectionString);
            OrderService orderService = new OrderService(orderRepository);

            IEnumerable<Order> orders;
            Guid customerId = new Guid("be948490-dbdc-4d55-b4a1-0ad52ec72b39");

            orders = orderService.FindAllCustomersOrdersBy(customerId);

            foreach (Order order in orders)
            {
                Response.Write(order.OrderDate + "<br/>");   
            }

            Response.Write("<br/><br/>");

            orders = orderService.FindAllCustomersOrdersWithInOrderDateBy(customerId, DateTime.Parse("06/03/2010 23:59:59"));

            foreach (Order order in orders)
            {
                Response.Write(order.OrderDate + "<br/>");
            }

            Response.Write("<br/><br/>");

            orders = orderService.FindAllCustomersOrdersUsingAComplexQueryWith(customerId);

            foreach (Order order in orders)
            {
                Response.Write(order.OrderDate + "<br/>");
            }
        }
    }
}
