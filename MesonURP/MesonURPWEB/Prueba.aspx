<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="MesonURPWEB.Prueba"  EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewConsultar" runat="server" AutoGenerateColumns="False"  emptydatatext="No hay información disponible." OnRowCommand="GridViewOC_RowCommand" OnSelectedIndexChanged="GridViewConsultar_SelectedIndexChanged" 
            DataKeyNames="OC_idOrdenCompra,EOC_NombreEstadoOC,OC_TipoComprobante,OC_TotalCompra,OC_FechaEmision">
             <Columns>
                                                 
              <asp:BoundField HeaderText="ID Compra" DataField="OC_idOrdenCompra" />
              <asp:BoundField HeaderText="Estado" DataField="EOC_NombreEstadoOC"/>
              <asp:BoundField HeaderText="Tipo de Comprobante" DataField="OC_TipoComprobante" />             
              <%-- <asp:BoundField HeaderText="Forma de Pago" DataField="OC_FormaPago"/>--%>
              <asp:BoundField HeaderText="Total de Compra" DataField="OC_TotalCompra"/>
              <asp:BoundField  HeaderText="Fecha de Emisión"  DataField="OC_FechaEmision"/>    
              <%-- <asp:BoundField  HeaderText="ID Proveedor" DataField="P_idProveedor" Visible="false" />--%>
              <asp:TemplateField HeaderText="Ver Detalles">
                   <ItemTemplate>
                   <asp:Button ID="btnConsultar" runat="server" CommandName="ConsultarOC_R" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  Text="Consultar" OnClick="btnConsultar_Click"  />
                   </ItemTemplate>
              </asp:TemplateField>
              </Columns>                                     
        </asp:GridView>
    <div class="auto-style1">

        <asp:DropDownList ID="ddlMes" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="true"  >
        </asp:DropDownList>
        <asp:Button ID="btnReporte" runat="server" Text="Generar Reporte" OnClick="btnReporte_Click" />

    &nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="583px"></asp:TextBox>

    </div>
    </form>
    </body>
</html>
