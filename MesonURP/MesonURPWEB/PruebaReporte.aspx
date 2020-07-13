<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaReporte.aspx.cs" Inherits="MesonURPWEB.PruebaReporte" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jspdf.debug.js"></script>
    <script src="js1/jquery-1.7.2.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1" id="Reporte">

            <asp:GridView ID="GridViewOC" runat="server" AutoGenerateColumns="false">
                  <Columns>
                                                 
                  <asp:BoundField HeaderText="ID Compra" DataField="OC_idOrdenCompra" />
                  <asp:BoundField HeaderText="Estado" DataField="EOC_NombreEstadoOC"/>
                  <asp:BoundField HeaderText="Tipo de Comprobante" DataField="OC_TipoComprobante" />
                  <asp:BoundField HeaderText="Total de Compra" DataField="OC_TotalCompra"/>
                  <asp:BoundField  HeaderText="Fecha de Emisión"  DataField="OC_FechaEmision"/>     
                  <%-- <asp:BoundField  HeaderText="ID Proveedor" DataField="P_idProveedor" Visible="false" />--%>                                                                                    
              </Columns>                           
            </asp:GridView>
            <br />

            <asp:GridView ID="GridViewInsumoxOC" runat="server" AutoGenerateColumns="false" >
                <Columns>
                   
                <asp:BoundField HeaderText="N°Orden Compra" DataField="OC_idOrdenCompra" />
                <asp:BoundField HeaderText="Insumo" DataField="I_NombreInsumo"/>
                <asp:BoundField HeaderText="Cantidad" DataField="OCxI_Cantidad" />
                <asp:BoundField HeaderText="Total" DataField="OCxI_PrecioTotal" />
                </Columns>
               
            </asp:GridView>

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
&nbsp;&nbsp;&nbsp;
           
        </div>    
        <input type="button" onclick="DescargarPDF('Reporte', 'ReporteASP')" value="Descargar Reporte" />
        <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
    </form>
    <script>
        function DescargarPDF(ContenidoID, nombre) {
            var pdf = new jsPDF('p', 'pt', 'letter');
            html = $('#' + ContenidoID).html();
            specialElementHandlers = {};
            margins = { top: 10, bottom: 20, left: 20, width: 522 };
            pdf.fromHTML(html, margins.left, margins.top, { 'width': margins.width }, function (dispose) { pdf.save(nombre + '.pdf'); }, margins);
        }

    </script>
</body>
</html>
