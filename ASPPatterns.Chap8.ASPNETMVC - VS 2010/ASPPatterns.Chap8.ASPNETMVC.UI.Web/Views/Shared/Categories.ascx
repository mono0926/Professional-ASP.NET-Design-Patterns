<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<ASPPatterns.Chap8.ASPNETMVC.AppService.Views.CategoryView>>" %>

<ul>
 <% foreach (var item in Model) { %>                      
     <li><%= Html.ActionLink(item.Name, 
                             "CategoryProducts", 
                             "Product", new { CategoryId = item.Id }, null)%></li>         
<% } %>
</ul>