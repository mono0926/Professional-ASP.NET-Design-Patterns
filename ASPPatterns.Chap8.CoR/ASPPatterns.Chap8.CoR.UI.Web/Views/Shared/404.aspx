<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="ASPPatterns.Chap8.CoR.UI.Web.Views.Shared._04" %>
<%@ Import Namespace="ASPPatterns.Chap8.CoR.Controller"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h2>Sorry</h2>
     We couldn't find the page you were after, please navigate back to the <a href="<%=UrlHelper.BuildHomePageLink() %>">home page</a>.
    </div>
    </form>
</body>
</html>
