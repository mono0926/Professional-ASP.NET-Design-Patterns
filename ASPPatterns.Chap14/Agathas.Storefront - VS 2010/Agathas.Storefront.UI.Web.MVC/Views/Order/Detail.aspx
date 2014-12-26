<%@ Page Title="" Language="C#" 
         MasterPageFile="~/Views/Shared/CustomerAccount.Master" 
         Inherits="System.Web.Mvc.ViewPage<CustomerOrderView>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.CustomerAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   	Your Order Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        
    <h2>Order #<%= Html.Encode(Model.Order.Id)%> placed on <%=Html.Encode(Model.Order.Created.ToLongDateString()) %> at <%=Html.Encode(Model.Order.Created.ToShortTimeString())%></h2>
    
    <% if (Model.Order.OrderHasBeenPaidFor == false) {%>
        <p>This order has not been paid. 
          <%=Html.ActionLink("Pay", "CreatePaymentFor", "Payment", 
                             new { orderId = Model.Order.Id }, null)%>  </p>
    <% }
       else
       {
     %>
        <p>Paid on <%=Html.Encode(Model.Order.PaymentDatePaid)%>. 
           Payment ref <%=Html.Encode(Model.Order.PaymentTransactionId)%></p>
     <%     
       }%>


    <ul>
    <% foreach (OrderItemView item in Model.Order.Items)
       {%>
        <li><%=Html.Encode(item.Qty) %> of <%=Html.Encode(item.ProductName) %>
           (<%=Html.Encode(item.ProductSizeName)%>) at 
            <%=Html.Encode(String.Format("{0:F}", item.Price))%></li>
    <% }%>
    </ul>
    
    <p>Shipping Charge: <%= Html.Encode(String.Format("{0:F}",
                                    Model.Order.ShippingCharge))%></p>
    <p>Shipping Via: <%=Html.Encode(Model.Order.ShippingServiceCourierName)%> -
                     <%=Html.Encode(Model.Order.ShippingServiceDescription)%></p>
    <p>Total: <%= Html.Encode(String.Format("{0:F}", Model.Order.Total))%></p>
    
    <p>Delivery Address</p>
    
    <%=Html.Encode(Model.Order.DeliveryAddress.AddressLine1)%><br />
    <%=Html.Encode(Model.Order.DeliveryAddress.AddressLine2)%><br />
    <%=Html.Encode(Model.Order.DeliveryAddress.City)%><br />
    <%=Html.Encode(Model.Order.DeliveryAddress.State)%><br />
    <%=Html.Encode(Model.Order.DeliveryAddress.ZipCode)%><br />
    <%=Html.Encode(Model.Order.DeliveryAddress.Country)%><br />

</asp:Content>
