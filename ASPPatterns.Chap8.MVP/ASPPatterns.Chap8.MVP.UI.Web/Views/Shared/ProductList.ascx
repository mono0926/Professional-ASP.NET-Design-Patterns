<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductList.ascx.cs" Inherits="ASPPatterns.Chap8.MVP.UI.Web.Views.Shared.ProductList" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="ASPPatterns.Chap8.MVP.Model"%>
   
<asp:Repeater ID="rptProducts" runat="server">
    <ItemTemplate>
        <%# Eval("Name") %> only <%#Eval("Price", "{0:C}")%><br /> 
      <a href="/Views/Product/ProductDetail.aspx?ProductId=<%# Eval("Id") %>">more information</a>                  
      <hr />
    </ItemTemplate>        
</asp:Repeater>  