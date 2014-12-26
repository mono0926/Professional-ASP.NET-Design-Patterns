<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="ASPPatterns.Chap8.FrontController.UI.Web.Views.Shared.CategoryList" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="ASPPatterns.Chap8.FrontController.Model"%>
<%@ Import Namespace="ASPPatterns.Chap8.FrontController.Controller"%>
<%@ Import Namespace="ASPPatterns.Chap8.FrontController.Controller.Storage"%>

     <ul>
    <% foreach (Category cat in (IEnumerable<Category>)ViewStorageFactory.GetStorage().Get(ViewStorageKeys.Categories))
    {%>
         <li><a href="<%=UrlHelper.BuildProductCategoryLinkFor(cat)%>"><%=cat.Name%></a></li>
    <%} %>
    </ul>