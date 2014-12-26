<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPPatterns.Chap4.AnemicModel.UI.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
     <fieldset>
        <legend>Create New Account</legend>    
     <p>        
        Customer Ref:
        <asp:TextBox ID="txtCustomerRef" runat="server"></asp:TextBox>
                
        <asp:Button ID="btCreateAccount" runat="server" Text="Create Account" 
            onclick="btCreateAccount_Click" />
    </p>
    </fieldset>
    
    <fieldset>
        <legend>Account Detail</legend> 
        <p>
        <asp:DropDownList AutoPostBack="true" ID="ddlBankAccounts" runat="server" 
                onselectedindexchanged="ddlBankAccounts_SelectedIndexChanged"></asp:DropDownList>
        </p>        
        <p>
            Account No:
            <asp:Label ID="lblAccountNo" runat="server" />
        </p>
        <p>
            Customer Ref:
            <asp:Label ID="lblCustomerRef" runat="server" />
        </p>
        <p>
            Balance:
            <asp:Label ID="lblBalance" runat="server" />
        </p>
        <p>
            Amount
        £<asp:TextBox ID="txtAmount" runat="server" Width="60px"></asp:TextBox>
                
        &nbsp;<asp:Button ID="btnWithdrawal" runat="server" Text="Withdrawal" 
                onclick="btnWithdrawal_Click" />
        &nbsp;<asp:Button ID="btnDeposit" runat="server" Text="Deposit" 
                onclick="btnDeposit_Click" />
        </p>
        <p>
            Transfer
        £<asp:TextBox ID="txtAmountToTransfer" runat="server" Width="60px"></asp:TextBox>
                
        &nbsp;to
        <asp:DropDownList AutoPostBack="true" ID="ddlBankAccountsToTransferTo" runat="server"></asp:DropDownList>
        &nbsp;<asp:Button ID="btnTransfer" runat="server" Text="Commit" 
                onclick="btnTransfer_Click" />
        </p>
        <p>
            Transactions</p>
            <asp:Repeater ID="rptTransactions" runat="server">        
                <HeaderTemplate>
                    <table>
                    <tr>
                        <td>deposit</td>
                        <td>withdrawal</td>
                        <td>reference</td>
                    </tr>
                </HeaderTemplate> 
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Deposit")  %></td>
                        <td><%# Eval("Withdrawal")  %></td>
                        <td><%# Eval("Reference")  %></td>                
                        <td><%# Eval("Date")  %></td>
                    </tr>
                </ItemTemplate> 
                <FooterTemplate>
                    </table>
                </FooterTemplate>   
            </asp:Repeater>
    </fieldset>    
    </div> 
    </form>
</body>
</html>
