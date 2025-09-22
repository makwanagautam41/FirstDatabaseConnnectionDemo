<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Details.aspx.cs" Inherits="FirstDatabaseConnnectionDemo.View_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="300" Width="300" ImageUrl='<%# Eval("prod_image") %>' />
                        <br />
                        <br />
                        Product Name:<asp:Label ID="Label1" runat="server" Text='<%# Eval("prod_name") %>'></asp:Label><br />
                        Product Configuration:<asp:Label ID="Label2" runat="server" Text='<%# Eval("prod_config") %>'></asp:Label><br />
                        Product Price:<asp:Label ID="Label3" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
                <div style="margin-top: 10px; text-align: center;">
                    Company Name:<asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label>
                </div>
            </center>
        </div>
    </form>
</body>
</html>
