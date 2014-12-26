<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BlogMaster.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="ASPPatterns.Chap4.ActiveRecord.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewPage1
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">            
        <div id="content"><h2><%= Html.Encode(((Post)ViewData["LatestPost"]).Subject) %></h2> 
        <%= ((Post)ViewData["LatestPost"]).Text.Replace("\n", "<br/>") %>        
        <br /><i>posted on <%= Html.Encode(((Post)ViewData["LatestPost"]).DateAdded.ToLongDateString()) %></i>
        <hr />
        Comments<br />
         <% foreach (var item in ((Post)ViewData["LatestPost"]).Comments)
           { %> 
                <p><i><%= Html.Encode(item.Author) %> said on <%= Html.Encode(item.DateAdded.ToLongDateString()) %> at <%= Html.Encode(item.DateAdded.ToShortTimeString()) %>...</i><br />
                 <%= Html.Encode(item.Text) %>                 
                 </p>
        <% } %>
        
        <p>Add a comment</p>
        <% using (Html.BeginForm("CreateComment", "Blog", new { Id = ((Post)ViewData["LatestPost"]).Id }, FormMethod.Post))
        {%>    
        <p>
        Your name<br />
        <%= Html.TextBox("Author")%> </p>
    
        <p>
        Your comment<br />
        <%= Html.TextArea("Comment")%></p>
    
        <p>
        <input type="submit" value="Add Comment" />
        
        </p>    
    <%} %>
        </div>
        <div id="rightNav"><h2>All Posts</h2>
        <ul>
        <% foreach (var item in (Post[])ViewData["AllPosts"])
           { %>  
                <li>
                <%= Html.ActionLink(item.Subject, "Detail", new { Id=item.Id  })%>
                <br />
                <%= Html.Encode(item.ShortText) %>                        
                </li>
        <% } %>
        </ul>
        </div>        
</asp:Content>


