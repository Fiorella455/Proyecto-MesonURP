<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaAnñadirOC.aspx.cs" Inherits="MesonURPWEB.PruebaAnñadirOC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Cantidad"></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server" ></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
