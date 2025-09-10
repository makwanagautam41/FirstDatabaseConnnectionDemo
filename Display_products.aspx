<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display_products.aspx.cs" Inherits="FirstDatabaseConnnectionDemo.Display_products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h1>Display Products</h1>
                <asp:DataList ID="DataList1" runat="server" CellPadding="10" CellSpacing="10" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100" Width="100" ImageUrl='<%# Eval("prod_image") %>' />
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("prod_name") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("prod_config") %>'></asp:Label>
                        <div style="display:flex margin:2px">
                            <asp:LinkButton ID="LinkButton1" runat="server">View Details</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server">Add To Cart</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </center>
        </div>
        <div style="display:flex;justify-content:space-between;">
            <asp:LinkButton ID="lnk_prev" runat="server" OnClick="lnk_prev_Click">Previous</asp:LinkButton>
            <asp:LinkButton ID="lnk_nxt" runat="server" OnClick="lnk_nxt_Click">Next</asp:LinkButton>
        </div>
    </form>
</body>
</html>
