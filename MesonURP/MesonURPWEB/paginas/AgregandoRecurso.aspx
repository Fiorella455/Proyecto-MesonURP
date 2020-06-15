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
            <asp:TextBox ID="txt_idOC" runat="server" />
             <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Enviar" />
        </div>
         <div>
            <asp:Label ID="categoria" Text="categoria" runat="server"></asp:Label>
             <asp:DropDownList ID="ddlcategoria" runat="server">
             </asp:DropDownList>
        </div>
         <div>
            <asp:Label ID="lblNombre" Text="Nombre Recurso" runat="server"></asp:Label>
             <asp:DropDownList ID="ddlInsumo" runat="server">
             </asp:DropDownList>
        </div>
         <div>
            <asp:Label ID="lblStockMax" Text="ID" runat="server"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" />
        </div>
         <div>
            <asp:Label ID="lblStockMin" Text="Tipo Comprobante" runat="server"></asp:Label>
            <asp:TextBox ID="txtTipoComp" runat="server" />
        </div>
         <div>
            <asp:Label ID="lblPUnitario" Text="Numero Comprobante" runat="server"></asp:Label>
            <asp:TextBox ID="txtNumeroComp" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblCEntrada" Text="Total" runat="server"></asp:Label>
            <asp:TextBox ID="txtTotal" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblCSalida" Text="Fecha Emision" runat="server"></asp:Label>
            <asp:TextBox ID="txtFechaEmi" runat="server" />
        </div>
        <div id="lblMsj">
            <asp:Label ID="lblTotal" Text="Proveedor" runat="server"></asp:Label>
            <asp:TextBox ID="txtProveedor" runat="server" />
        &nbsp;&nbsp;
            <asp:TextBox ID="txtMsj" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnRegistro" CssClass="button btn btn-success btn-large" runat="server" Text="Agregar" OnClick="btnRegistro_Click" style="height: 26px" />
            <asp:Button ID="btnEliminar" CssClass="button btn btn-success btn-large" runat="server" Text="Eliminar" OnClick="btnRegistro_Click" style="height: 26px" />
        </div>
    </form>
</body>
</html>
