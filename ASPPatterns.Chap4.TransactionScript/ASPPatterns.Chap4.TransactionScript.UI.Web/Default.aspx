<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPPatterns.Chap4.TransactionScript.UI.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <fieldset>
            <legend>Create Employee</legend>                 
            <p>        
            Name
            <br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </p>
            <p>
            Holiday entitlement
            <br />
            <asp:TextBox ID="txtEntitlement" runat="server"></asp:TextBox>                               
            </p>
            <p>
            <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" onclick="btnAddEmployee_Click" />
            </p>
        </fieldset>
        
        <fieldset>
            <legend>Employees</legend>          
                <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlEmployees_SelectedIndexChanged">                                               
                </asp:DropDownList>
                <br />
            <br />
            Holidays Booked<br />
            <asp:Repeater ID="rptHolidaysBooked" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <td>From </td>
                            <td>To</td>
                            <td>Day(s) taken</td>
                        </tr>
                </HeaderTemplate> 
                <ItemTemplate>
                        <tr>
                            <td><%# Eval("From", "{0:d}") %></td>
                            <td><%# Eval("To", "{0:d}")%></td>
                            <td><%# Eval("DaysTaken") %></td>
                        </tr>
                </ItemTemplate> 
                <FooterTemplate>
                    </table>
                </FooterTemplate> 
            </asp:Repeater>
                <p>
                Book Holiday
                </p>
                <p>
                <table>
                    <tr>
                        <td>From</td>
                        <td>To</td>
                    </tr>
                    <tr>
                        <td><asp:Calendar ID="calFrom" runat="server"></asp:Calendar></td>
                        <td><asp:Calendar ID="calTo" runat="server"></asp:Calendar></td>
                    </tr>
                </table>     
                <asp:Button ID="btnBookHoliday" runat="server" Text="Book Holiday" 
                        onclick="btnBookHoliday_Click" />                                 
                </p>
                <p>
                    <strong><asp:Label ID="lblBookingResult" runat="server"></asp:Label></strong>
                </p>
        </fieldset>        
    
    </div>    
    </form>
</body>
</html>
