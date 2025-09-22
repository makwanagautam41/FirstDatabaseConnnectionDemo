<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="FirstDatabaseConnnectionDemo.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <table border="1">
                    <tr>
                        <td>Select Company</td>
                        <td>
                            <asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Product name</td>
                        <td>
                            <asp:TextBox ID="txtpnm" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Product Configuration</td>
                        <td>
                            <asp:TextBox ID="txtconfig" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Product Price</td>
                        <td>
                            <asp:TextBox ID="txtprice" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Product Image</td>
                        <td>
                            <asp:FileUpload ID="FileUpload" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></td>
                    </tr>
                </table>
            </center>
        </div>
    </form>
</body>
</html>
