<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Shop.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="ASPPatterns.Chap8.CoR.UI.Web.Views.Product.ProductDetail" %>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Model"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Controller"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Controller.Storage"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<% Product product = (Product)ViewStorageFactory.GetStorage().Get(ViewStorageKeys.Product); %>

<h2><%=product.Name %></h2>
<p>
    pay: <%=String.Format("{0:C}", product.Price)%>
</p>
<p>
    <%=product.Description %>
</p>
</asp:Content>
