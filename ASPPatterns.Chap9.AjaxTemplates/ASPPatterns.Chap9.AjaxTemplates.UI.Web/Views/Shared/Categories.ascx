<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="ASPPatterns.Chap9.AjaxTemplates.Model" %>
<%@ Import Namespace="ASPPatterns.Chap9.AjaxTemplates.Controllers" %>
<ul>
<% foreach (CategoryBrandView categoryBrandView in (IEnumerable<CategoryBrandView>)ViewData["categories"])
   {%>        
        <li><%= Html.ActionLink(categoryBrandView.Name, 
                             "CategoryProducts",
                             "Product", new { CategoryId = categoryBrandView.CategoryId }, null)%>
            <% if (categoryBrandView.Brands.Count() > 0) {%>
            <p>
            refine by brand:
            <br />
            <% foreach (Brand brand in categoryBrandView.Brands)
               { %>                                            
            <a href="JavaScript:filterProductsBy(<%=brand.Id %>, 
                                                 <%=categoryBrandView.CategoryId %>);">
                                                 <%=brand.Name%></a><br /> 
            <% } %>                                  
            </p>
            <% } %>                      
        </li>          
<%} %>    
</ul>


