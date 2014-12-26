<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Shop.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ASPPatterns.Chap8.CoR.UI.Web.Views.Home.Index" %>
<%@ Register src="../Shared/ProductList.ascx" tagname="ProductList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Todays Top Products</h2>
<uc1:ProductList ID="ProductList1" runat="server" />
</asp:Content>
