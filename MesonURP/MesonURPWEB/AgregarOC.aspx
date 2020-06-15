<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarOC.aspx.cs" Inherits="MesonURPWEB.paginas.AgregarOC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="categoria"></asp:Label>
            <asp:DropDownList ID="ddlcategoria" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label2" runat="server" Text="insumo"></asp:Label>
            <asp:DropDownList ID="ddlinsumo" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="cantidad"></asp:Label>
            <asp:TextBox ID="txtcantidad" runat="server"></asp:TextBox>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
            <asp:Button ID="btnQuitar" runat="server" Text="Quitar" />
        </div>
    </form>
</body>
</html>
