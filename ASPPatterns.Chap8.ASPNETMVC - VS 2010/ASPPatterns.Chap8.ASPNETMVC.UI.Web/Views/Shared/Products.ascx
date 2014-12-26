<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<ASPPatterns.Chap8.ASPNETMVC.AppService.Views.ProductView>>" %>

 <% foreach (var item in Model) { %> 
  <%=item.Name%> only <%=String.Format("{0:C}", item.Price)%><br /> 
      <%= Html.ActionLink("More Information", "Detail", "Product", new { Id = item.Id }, null)%>                  
      <hr />                         
<% } %>