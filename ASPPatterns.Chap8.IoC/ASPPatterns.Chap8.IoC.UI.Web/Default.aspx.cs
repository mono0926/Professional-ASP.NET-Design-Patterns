using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap8.IoC.Model;
using ASPPatterns.Chap8.IoC.Model.Payment;
using ASPPatterns.Chap8.IoC.Model.Despatch;
using StructureMap;


namespace ASPPatterns.Chap8.IoC.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderService orderService;

            //orderService = new OrderService(new PaymentGateway(new StreamLinePaymentMerchant()),
            //                                new DespatchService(new FedExCourier()));

            orderService = ObjectFactory.GetInstance<OrderService>();

            Response.Write(orderService.ToString()); 
        }
    }
}
