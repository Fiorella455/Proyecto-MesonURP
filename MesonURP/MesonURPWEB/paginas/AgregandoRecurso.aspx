<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregandoRecurso.aspx.cs" Inherits="MesonURPWEB.paginas.AgregandoRecurso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <asp:Label ID="lblNombre" Text="Nombre Recurso" runat="server"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" />
        </div>
         <div>
            <asp:Label ID="categoria" Text="categoria" runat="server"></asp:Label>
             <asp:DropDownList ID="ddlcategoria" runat="server">
             </asp:DropDownList>
        </div>
         <div>
            <asp:Label ID="lblFechaSal" Text="Fecha Salida" runat="server"></asp:Label>
            <asp:TextBox ID="txtFechaSal" runat="server" />
        </div>
         <div>
            <asp:Label ID="lblStockMax" Text="Stock Maximo" runat="server"></asp:Label>
            <asp:TextBox ID="txtStockMax" runat="server" />
        </div>
         <div>
            <asp:Label ID="lblStockMin" Text="Stock Minimo" runat="server"></asp:Label>
            <asp:TextBox ID="txtStockMin" runat="server" />
        </div>
         <div>
            <asp:Label ID="lblPUnitario" Text="Precio Unitario" runat="server"></asp:Label>
            <asp:TextBox ID="txtPUnitario" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblCEntrada" Text="Cantidad Entrada" runat="server"></asp:Label>
            <asp:TextBox ID="txtCEntrada" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblCSalida" Text="Cantidad Salida" runat="server"></asp:Label>
            <asp:TextBox ID="txtCSalida" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblTotal" Text="Cantidad Total" runat="server"></asp:Label>
            <asp:TextBox ID="txtCTotal" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnRegistro" CssClass="button btn btn-success btn-large" runat="server" Text="Agregar" OnClick="btnRegistro_Click" style="height: 26px" />
        </div>
    </form>
</body>
</html>
