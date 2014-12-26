<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPPatterns.Chap9.PredictiveFetch.UI.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>    
    <script type="text/javascript" src="/Scripts/jquery-1.3.2.js"></script> 
    <script type="text/javascript" src="/Scripts/jquery-jtemplates.js"></script>
    <link href="/Content/Site.css" type="text/css" rel="stylesheet" /> 
    <script type="text/javascript">

        var showCommentsAfterLoad = false;
        var timerToShowComments;
        var blogComments;

        $.ajaxSetup({
            type: "post",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })

        $(document).ready(function() {

             timerToShowComments = setTimeout(function() {
                    getComments()
                }, 5000);                                            
        });
        
        function storeComments(comments)
        {
            blogComments = comments;
            if (showCommentsAfterLoad == true)
                showComments(blogComments);
        }
        
        function showComments(comments) {           
            $("#comments").setTemplate($("#productItemTemplate").html());
            $("#comments").processTemplate(comments);
            $("#Loading").hide();
        }
        
        function getComments()
        {
            var dto = { postId: 100 };
            $.ajax(
            {
                url: "/BlogService.svc/GetCommentsFor",
                data: JSON.stringify(dto),
                success: storeComments
             });
        }

        function displayComments() {

            if (blogComments != null) 
            {   showComments(blogComments);}
            else 
            {
                showCommentsAfterLoad = true;
                clearTimeout(timerToShowComments);
                getComments();
                $("#Loading").show();
            }
        }
     
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    
    <script type="text/html" id="productItemTemplate">               
			{#foreach $T.d as record}			
			  {$T.record.Text}<br />               
              <hr />								
			{#/for}		   
	    </script>  
    
    <div>        
    <h1>
        Post Title
    </h1>
    <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec justo nisl, 
        posuere sit amet dignissim et, luctus eu diam. Donec eget orci ligula, ut 
        posuere turpis. Nam scelerisque mi in ligula pharetra pharetra. Nulla vulputate 
        felis accumsan arcu aliquam mattis. Morbi vitae augue id mi auctor dignissim. 
        Vivamus vulputate, augue quis sagittis porttitor, augue libero vestibulum mi, 
        vitae ullamcorper massa erat placerat enim. Proin urna ipsum, fermentum sit amet 
        ultricies vel, cursus sit amet felis. Morbi sit amet diam ac metus placerat 
        vehicula. Nulla facilisi. Aliquam facilisis leo consequat velit facilisis vel 
        iaculis diam convallis. Maecenas et nunc arcu. Sed id nunc non purus luctus 
        faucibus. Pellentesque non dui massa. Fusce felis lorem, consectetur id congue 
        varius, ultrices eget libero. Nulla lobortis, sem at ultricies aliquam, dui leo 
        ullamcorper dui, at fermentum diam ipsum et nibh.
    </p>   
    <p>
        <i>Posted by Scott Millett on 17 March 2010.</i></p>
    <p>
        <a href="JavaScript:displayComments();">Read comments on this post</a>.</p>
        <div id="comments"></div>
        <div id="Loading">Updating... <img src='Content/ajax-loader.gif' /></div>
        </div>
    </form>
</body>
</html>
