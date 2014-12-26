<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Shop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ASPPatterns.Chap9.AjaxTemplates.Model.Product>>" %>
<%@ Import Namespace="ASPPatterns.Chap9.AjaxTemplates.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">

    $(document).ready(function() {
        initialiseStateFromURL();
    });

    function initialiseStateFromURL() {
                        
        figuresRE = /#([0-9])/;
        figuresSpec = window.location.hash;
        if (!figuresRE.test(figuresSpec)) {        
            return; // ignore url if invalid
        }        
                
        var brandId = figuresSpec.replace(figuresRE, "$1");
        var categoryId = $("#categoryId").val();

        filterProductsBy(brandId, categoryId);
                
    }

    function filterProductsBy(brandId, categoryId) {

        showOverlay();

        window.location.hash = brandId;

        $.getJSON('/Product/GetProductsIn?brandId=' + brandId + '&categoryId=' + categoryId,
                        function(data) {

                            var mydata = {
                                items: data
                            };

                            $("#items").setTemplate($("#productItemTemplate").html());
                            $("#items").processTemplate(mydata);

                            hideOverlay();
                        }
                        );

    }

    function hideOverlay() {

        $("#overlay").animate({ opacity: "hide" }, "slow");
    }

    function showOverlay() {
            
      //get the position of the placeholder element 
      var pos = $("#products").offset();
      var width = $("#products").width();
      var height = $("#products").height();
      //show the waiting overlay directly over the products
      $("#overlay").css({ "width": width + "px", "left": pos.left + "px", "top": pos.top + "px", "height": height + "px" });      
      $("#overlay").show();
      
      $("#overlay").animate
              (
      		    { opacity: 0.7 },
      	        1,
      		    function() { }
      	       );
    }	    
       
    </script>
    
    <script type="text/html" id="productItemTemplate">               
			{#foreach $T.items as record}			
			  {$T.record.Brand.Name} {$T.record.Name} only {$T.record.Price}<br /> 
              <a href="#">more information</a>
              <hr />								
			{#/for}		   
	</script>        
	    
	               
    <h2>Category Products</h2>

    
    <div id="products">                        
        <div id="overlay" class="overlay"></div>
        <div id="items">    
        <% foreach (Product product in Model)
           {%>                                   			
			     <%=product.Brand.Name %> <%=product.Name %> only <%=product.Price %><br /> 
                  <a href="#">more information</a>
                  <hr />											                  
        <%} %>
        </div>        
    </div>    
    
    <input type="hidden" id="categoryId" name="categoryId" value="<%=Request.QueryString["categoryId"] %>" /> 
    
</asp:Content>
