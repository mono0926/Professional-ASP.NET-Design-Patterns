<%@ Control Language="C#" 
            Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CategoryView>>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>

<h2>Categories</h2>
<ul class="refine-attributes">						
<% foreach (CategoryView categoryView in Model) 
   { %> 
    <li><%= Html.ActionLink(categoryView.Name, "GetProductsByCategory", "Product", 
                                       new { categoryId = categoryView.Id }, null)%></li>                                        
<% }  %>				
</ul>

