<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ASPPatterns.Chap8.ASPNETMVC.AppService.Views.HomeView>" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Todays Top Products</h2>
    <% Html.RenderPartial("~/Views/Shared/Products.ascx", Model.BestSellingProducts); %>
</asp:Content>