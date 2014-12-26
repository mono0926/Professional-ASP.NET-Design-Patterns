<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPPatterns.Chap3.SmartUI.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Savings
        <asp:DropDownList ID="ddlDiscountType" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlDiscountType_SelectedIndexChanged">
            <asp:ListItem Value="0">No Discount</asp:ListItem>
            <asp:ListItem Value="1">Trade Discount</asp:ListItem>
        </asp:DropDownList>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
             DataSourceID="SqlDataSource1"
             DataKeyNames="ProductId"  
            EmptyDataText="There are no data records to display." 
            OnRowDataBound="GridView1_RowDataBound">
            <Columns>           
                <asp:BoundField DataField="ProductId" HeaderText="ProductId" 
                                ReadOnly="True" SortExpression="ProductId" />     
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="RRP" HeaderText="RRP" SortExpression="RRP" 
                    DataFormatString="{0:C}" />               
                <asp:TemplateField HeaderText="SellingPrice" SortExpression="SellingPrice">
                    <ItemTemplate>
                        <asp:Label ID="lblSellingPrice" runat="server" Text='<%# Bind("SellingPrice") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discount">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDiscount"></asp:Label>
                    </ItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Savings">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblSavings"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
    
    </div>   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShopConnectionString1 %>" 
        ProviderName="<%$ ConnectionStrings:ShopConnectionString1.ProviderName %>" 
        SelectCommand="SELECT [ProductId], [ProductName], [RRP], [SellingPrice] FROM [Products]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
