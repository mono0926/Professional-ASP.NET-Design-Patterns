<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="ASPPatterns.Chap8.CoR.UI.Web.Views.Shared.CategoryList" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Model"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Controller"%>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Controller.Storage"%>

    <ul>
    <% foreach (Category cat in (IEnumerable<Category>)ViewStorageFactory.GetStorage().Get(ViewStorageKeys.Categories))
    {%>
         <li><a href="<%=UrlHelper.BuildProductCategoryLinkFor(cat)%>"><%=cat.Name%></a></li>
    <%} %>
    </ul> 