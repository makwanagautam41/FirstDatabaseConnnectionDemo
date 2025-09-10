<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginStudent.aspx.cs" Inherits="FirstDatabaseConnnectionDemo.LoginStudent" %>

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
                        <td>Email</td>
                        <td>
                            <asp:TextBox ID="txtem" runat="server"></asp:TextBox></td>
                    </tr
                    <tr>
                        <td>Password</td>
                        <td><asp:TextBox ID="txtpw" runat="server"></asp:TextBox></td>
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
