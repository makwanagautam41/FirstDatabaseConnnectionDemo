<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FirstDatabaseConnnectionDemo.Cart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <asp:Button ID="back_btn" runat="server" Text="Back To Display Product Page" OnClick="back_btn_Click" />
                <asp:GridView ID="gvCart" runat="server" DataKeyNames="Cart_prod_id" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Cart_prod_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="100" Width="100" ImageUrl='<%# Eval("Cart_prod_image") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Cart_prod_price") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Cart_prod_quantity") %>' Width="50"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Remove">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="RemoveItem" CommandArgument='<%# Eval("Cart_id") %>' ForeColor="Red">Remove</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <br />
                <asp:Label ID="lblFinnalTotal" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                <br /><br />
                <asp:Button ID="update_cart_btn" runat="server" Text="Update Cart" OnClick="update_cart_btn_Click" />
            </center>
        </div>
    </form>
</body>
</html>
