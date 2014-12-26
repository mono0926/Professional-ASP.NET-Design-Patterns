<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductList.ascx.cs" Inherits="ASPPatterns.Chap8.CoR.UI.Web.Views.Shared.ProductList" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Model"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Controller"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Controller.Storage"%>

    
    <% foreach (Product prod in (IEnumerable<Product>)ViewStorageFactory.GetStorage().Get(ViewStorageKeys.Products))
    {%>
      <%=prod.Name%> only <%=String.Format("{0:C}", prod.Price)%><br /> 
      <a href="<%=UrlHelper.BuildProductDetailLinkFor(prod) %>">more information</a>                  
      <hr />
    <%} %>   