<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ASPPatterns.Chap8.ASPNETMVC.AppService.Views.CategoryProductsPageView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All <%=Model.Category.Name %></h2>
    <% Html.RenderPartial("~/Views/Shared/Products.ascx", Model.Products); %>
</asp:Content>
