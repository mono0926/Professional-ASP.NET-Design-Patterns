<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Shop.Master" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="ASPPatterns.Chap8.MVP.UI.Web.Views.Basket.Basket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Your Basket</h2>
<ul>
<asp:Repeater ID="rptBasket" runat="server">
    <ItemTemplate>
        <li>1 x <a href="/Views/Product/ProductDetail.aspx?ProductId=<%# Eval("Id") %>"><%# Eval("Name") %></a> for <%#Eval("Price", "{0:C}")%></li>             
    </ItemTemplate>        
</asp:Repeater> 
</ul>
</asp:Content>
