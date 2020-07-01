<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="MesonURPWEB.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewConsultar" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewConsultar_SelectedIndexChanged" >
             <Columns>
                                                 
                                                <asp:BoundField HeaderText="ID Compra" DataField="OC_idOrdenCompra" />
                                                 <asp:BoundField HeaderText="Estado" DataField="EOC_NombreEstadoOC"/>
                                                <asp:BoundField HeaderText="Tipo de Comprobante" DataField="OC_TipoComprobante" />
                                                <asp:BoundField HeaderText="Número de comprobante" DataField="OC_NumeroComprobante"/>
                                               <asp:BoundField HeaderText="Forma de Pago" DataField="OC_FormaPago"/>
                                                <asp:BoundField HeaderText="Total de Compra" DataField="OC_TotalCompra"/>
                                                <asp:BoundField  HeaderText="Fecha de Emisión"  DataField="OC_FechaEmision"/>    
                                                <asp:BoundField  HeaderText="ID Proveedor" DataField="P_idProveedor" Visible="false" />
                                                <asp:TemplateField HeaderText="Ver Detalles">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnConsultar" runat="server" CommandName="ConsultarOC_R" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  Text="Consultar" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
              </Columns>                                     
        </asp:GridView>
    </form>
</body>
</html>
