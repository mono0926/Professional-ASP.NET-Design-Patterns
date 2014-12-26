<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Shop.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ASPPatterns.Chap8.MVP.UI.Web.Views.Home.Index" %>
<%@ Register src="~/Views/Shared/ProductList.ascx" tagname="ProductList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Todays Top Products</h2>
    <uc1:ProductList ID="plBestSellingProducts" runat="server" />
</asp:Content>
