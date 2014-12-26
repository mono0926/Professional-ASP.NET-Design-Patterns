<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ASPPatterns.Chap6.EventTickets.WebShop.Checkout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Checkout</h2>  
        
        In your basket you have:
        <p>
        <asp:Label ID="lblBasketContents" runat="server" Text=""></asp:Label>
        </p>
                            
        <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" 
            onclick="btnPlaceOrder_Click"  />
        <br />
        <small>Click the &#39;Place Order&#39; button again and the Ticket Id will 
        always return the same due to the use of the Idempotent Pattern.</small><br />
        <br />
        <asp:Label ID="lblThankYou" runat="server" Text=""></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
