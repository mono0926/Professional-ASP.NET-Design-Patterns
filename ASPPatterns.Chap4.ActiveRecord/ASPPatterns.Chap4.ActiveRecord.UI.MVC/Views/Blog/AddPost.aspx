<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BlogMaster.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
     <% using (Html.BeginForm())
        {%>    
        <p>
        Subject<br />
        <%= Html.TextBox("Subject")%> </p>
    
        <p>
        Content<br />
        <%= Html.TextArea("Content")%></p>
    
        <p>
        <input type="submit" value="Create" />
        </p>    
    <%} %>
    
 </asp:Content>
