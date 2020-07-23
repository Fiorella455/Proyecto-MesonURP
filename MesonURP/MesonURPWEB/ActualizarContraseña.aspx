<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarContraseña.aspx.cs" Inherits="MesonURPWEB.ActualizarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Contraseña Actual:"></asp:Label>
            <asp:TextBox ID="txtContraseñaAct" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Contraseña Nueva:"></asp:Label>
            <asp:TextBox ID="txtContraseñaAct0" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Confirmar Contraseña:"></asp:Label>
            <asp:TextBox ID="txtContraseñaAct1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnCambiarCont" runat="server" Text="Cambiar Contraseña" />
        </div>
    </form>
</body>
</html>
