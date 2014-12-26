<%@ Page Language="C#" 
         MasterPageFile="~/Views/Shared/Site.Master" 
         Inherits="System.Web.Mvc.ViewPage<AccountView>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.Account" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" 
             runat="server">
   <% if (Model.HasIssue) { %>
   <p>
   <div style="color: #D63301; background-color: #FFCCBA; 
               padding:15px 10px 15px 50px;" >
        <%=Html.Encode(Model.Message)%>
   </div>
   </p>
   <% } %>

    <h2>Associate an existing acount with us</h2>
    <% Html.RenderPartial("~/Views/Shared/JanrainLogin.ascx", 
                          Model.CallBackSettings); %>

    <h2>Don't have an internet account? Create an account with us</h2>

    <% using (Html.BeginForm()) { %>
        <div>
                <p>
                    <label for="email">Email:</label><br />
                    <%= Html.TextBox("email") %>
                </p>
                <p>
                    <label for="password">Password:</label><br />
                    <%= Html.Password("password") %>
                </p>
                <p>
                    <label for="confirmPassword">Confirm password:</label><br />
                    <%= Html.Password("confirmPassword") %>
                </p>
                <p>
                    <label for="email">First Name:</label><br />
                    <%= Html.TextBox("FirstName")%>
                </p>
                <p>
                    <label for="email">Second Name:</label><br />
                    <%= Html.TextBox("SecondName")%>
                </p>
                <p>
                    <input type="submit" value="Register" />
                </p>
        </div>
    <% } %>
</asp:Content>
