<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ASPPatterns.Chap8.ASPNETMVC.AppService.Views.ProductDetailPageView>" %>
<%@ Import Namespace="ASPPatterns.Chap8.ASPNETMVC.AppService.Views"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <% ProductDetailView productModel = Model.Product;  %>
       
    <h2><%=productModel.Name%></h2>
    <p>
        pay: <%=productModel.Price%>
    </p>
    <p>
        <%=productModel.Description%>
    </p>

</asp:Content>
