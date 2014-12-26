<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Views/Shared/CustomerAccount.Master"   
    Inherits="System.Web.Mvc.ViewPage<CustomerDetailView>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.CustomerAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    	Customer Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Your Details</h2>
    
    <% using (Html.BeginForm()) {%>
            <p>
                <label for="FirstName">FirstName:</label><br />
                <%= Html.TextBox("FirstName", Model.Customer.FirstName) %> 
            </p>
            <p>
                <label for="SecondName">SecondName:</label><br />
                <%= Html.TextBox("SecondName", Model.Customer.SecondName)%> 
            </p>
            <p>
                <label for="Email">Email:</label><br />
                <%= Html.TextBox("Email", Model.Customer.Email)%> 
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
    <% } %>    
</asp:Content>
