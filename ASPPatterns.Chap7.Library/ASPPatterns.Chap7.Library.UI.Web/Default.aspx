<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPPatterns.Chap7.Library.UI.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <h1>Library System</h1>
        <h2>Members</h2>
        Add new member:<br />
        First Name <asp:TextBox ID="txtFirstName" runat="server" /><br />
        Last Name <asp:TextBox ID="txtLastName" runat="server" /><br />
        <asp:Button ID="btnCreateMember" runat="server" Text="Add Member" onclick="btnCreateMember_Click" />
    
    </div>
    <p>
        All Members
        <asp:Repeater ID="rptMembers" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                    <li><%# Eval("FullName")%> (<a href="MemberDetail.aspx?Id=<%# Eval("MemberId")%>">view details</a>)</li> 
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate> 
        </asp:Repeater>
    </p>
    <h2>Books</h2>
    Add a Book<br />
    Title <asp:DropDownList ID="ddlBookTitles" runat="server" />&nbsp;
    <asp:Button ID="btnAddBook" runat="server" onclick="btnAddBook_Click" Text="Add Book" />
    <p>
        All Books
        <asp:Repeater ID="rptBooks" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                    <li><%# Eval("Title")%></li> 
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate> 
        </asp:Repeater>
    </p>

    <p>
        Add 
        Book Title<br />
        <br />
        ISBN<asp:TextBox ID="txtBookISBN" runat="server" /><br />
        Title<asp:TextBox ID="txtBookTitle" runat="server" />
    <p>
        <asp:Button ID="btnAddTitle" runat="server" onclick="btnAddTitle_Click" Text="Add Title" />
    <p>
        All Book titles<asp:Repeater ID="rptBookTitles" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                    <li><%# Eval("Title")%><br /><small>ISBN: <%# Eval("ISBN")%></small></li> 
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate> 
        </asp:Repeater>
    </p>
    </form>    
</body>
</html>
