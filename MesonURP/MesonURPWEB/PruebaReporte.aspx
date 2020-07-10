<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaReporte.aspx.cs" Inherits="MesonURPWEB.PruebaReporte" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="GridViewInsumoxOC" runat="server" >
                <Columns>
                   
               <%-- <asp:BoundField HeaderText="N°Orden Compra" DataField="OC_idOrdenCompra" />
                <asp:BoundField HeaderText="Insumo" DataField="I_NombreInsumo"/>
                <asp:BoundField HeaderText="Cantidad" DataField="OCxI_Cantidad" />
                <asp:BoundField HeaderText="Total" DataField="OCxI_PrecioTotal" />--%>
                </Columns>
               
            </asp:GridView>

        </div>
        
         
    </form>
</body>
</html>
