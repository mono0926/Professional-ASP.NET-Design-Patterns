<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Shop.Master" AutoEventWireup="true" CodeBehind="CategoryProducts.aspx.cs" Inherits="ASPPatterns.Chap8.CoR.UI.Web.Views.Product.CategoryProducts" %>
<%@ Register src="../Shared/ProductList.ascx" tagname="ProductList" tagprefix="uc1" %>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Controller.Storage"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Model"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All <%=((Category)ViewStorageFactory.GetStorage().Get(ViewStorageKeys.Category)).Name %></h2>
    <uc1:ProductList ID="ProductList1" runat="server" />
</asp:Content>
