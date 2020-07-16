<%@ Page Title="Mesón URP| Generar Reporte OC" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PruebaReporte.aspx.cs" Inherits="MesonURPWEB.PruebaReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="grids">
             <div class="progressbar-heading grids-heading title-flex">
                  <h2 class="tittle-margin5">Generar Reporte Compras</h2>
                      <div class="stock-options">
                        <div class="width-auto margin-5">
                            <input type="button" class="btn btn-primary" onclick="DescargarPDF('Reporte', 'Reporte Mensual')" value="Descargar Reporte" />
                        </div>
                       </div>
              </div>
         <div class="search-buttons">
               <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                         <div class="form-title color-white">
                              <h4>Órdenes de Compra e Insumos</h4>
                         </div>
                             <div class="table-wrapper-scroll-y my-custom-scrollbar" id="Reporte">
                                  <asp:GridView ID="GridViewOC" Allowpaging="True" runat="server" emptydatatext="No hay información disponible."
                                   AutoGenerateColumns="False" CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                             <Columns>
                                             <asp:BoundField HeaderText="ID Compra" DataField="OC_idOrdenCompra" />
                                             <asp:BoundField HeaderText="Estado" DataField="EOC_NombreEstadoOC"/>
                                             <asp:BoundField HeaderText="Tipo de Comprobante" DataField="OC_TipoComprobante" />
                                             <asp:BoundField HeaderText="Total de Compra" DataField="OC_TotalCompra"/>
                                             <asp:BoundField  HeaderText="Fecha de Emisión"  DataField="OC_FechaEmision"/>     
                                              <asp:BoundField  HeaderText="Proveedor" DataField="P_idProveedor"/> 
                                             </Columns>
                                        </asp:GridView>                            
                             <br />                        
                                  <asp:GridView ID="GridViewInsumoxOC" Allowpaging="True" runat="server" emptydatatext="No hay información disponible." 
                                   AutoGenerateColumns="False" CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                             <Columns>                  
                                             <asp:BoundField HeaderText="N°Orden Compra" DataField="OC_idOrdenCompra" />
                                             <asp:BoundField HeaderText="Insumo" DataField="I_NombreInsumo"/>
                                             <asp:BoundField HeaderText="Cantidad" DataField="OCxI_Cantidad" />
                                             <asp:BoundField HeaderText="Total" DataField="OCxI_PrecioTotal" />
                                              </Columns>
                                   </asp:GridView>
                             </div>                     
                       </div>
                 </div>
            </div>    
           <div class="clearfix"></div>
      </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
 </div>
    <script src="js/jspdf.debug.js"></script>
    <script src="js1/jquery-1.7.2.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
     <script>
         function DescargarPDF(ContenidoID, nombre) {
             var pdf = new jsPDF('p', 'pt', 'letter');
             html = $('#' + ContenidoID).html();
             specialElementHandlers = {};
             margins = { top: 10, bottom: 20, left: 20, width: 522 };
             pdf.fromHTML(html, margins.left, margins.top, { 'width': margins.width }, function (dispose) { pdf.save(nombre + '.pdf'); }, margins);
         }

     </script>
</asp:Content>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>

