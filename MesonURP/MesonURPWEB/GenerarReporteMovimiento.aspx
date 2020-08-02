<%@ Page Title="Generar Reporte Movimiento" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GenerarReporteMovimiento.aspx.cs" Inherits="MesonURPWEB.GenerarReporteMovimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!--start content-->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Generar Reporte Movimientos</h2>
                <div class="stock-options">
                    <div class="width-auto margin-5">
                        <input type="button" class="btn btn-primary" onclick="DescargarPDF('Reporte', 'Reporte Movimiento Mensual')" value="Descargar Reporte" />
                    </div>
                </div>
            </div>
            <div class="search-buttons">
                <div class="panel panel-widget forms-panel">
                    <div class="text-center">
                     <asp:DropDownList ID="ddlMes" CssClass="form-control1" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="true" text-align="center" Width="126px">
                           <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                            <asp:ListItem Text="Enero" Value=1>Enero</asp:ListItem>
                                            <asp:ListItem Text="Febrero" Value=2>Febrero</asp:ListItem>
                                            <asp:ListItem Text="Marzo" Value=3>Marzo</asp:ListItem>
                                            <asp:ListItem Text="Abril" Value=4>Abril</asp:ListItem>
                                            <asp:ListItem Text="Mayo" Value=5>Mayo</asp:ListItem>
                                            <asp:ListItem Text="Junio" Value=6>Junio</asp:ListItem>
                                            <asp:ListItem Text="Julio" Value=7>Julio</asp:ListItem>
                                            <asp:ListItem Text="Agosto" Value=8>Agosto</asp:ListItem>
                                            <asp:ListItem Text="Septiembre" Value=9>Septiembre</asp:ListItem>
                                            <asp:ListItem Text="Octubre" Value=10>Octubre</asp:ListItem>
                                            <asp:ListItem Text="Noviembre" Value=11>Noviembre</asp:ListItem>
                                            <asp:ListItem Text="Diciembre" Value=12>Diciembre</asp:ListItem>

                         </asp:DropDownList>
            </div>
                    <div class="form-grids widget-shadow" data-example-id="basic-forms" id="Reporte">
                         
                                    <div class="clearfix">
                                        

                                    </div>
                        <div class="form-title color-white">
                            <h4>Ingresos y Egresos del Mes</h4>
                        </div>
                       
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                           <asp:GridView ID="gvMovimientos" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="fechamov,M_TipoMovimiento,I_NombreInsumo,nomcategoria,MxI_Cantidad,M_NombreMedida,usuariomov" OnSelectedIndexChanged="gvMovimientos_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="fechamov" HeaderText="Fecha" />
                                                <asp:BoundField DataField="M_TipoMovimiento" HeaderText="Tipo" />
                                                <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                                <asp:BoundField DataField="nomcategoria" HeaderText="Categoria" />
                                                <asp:BoundField DataField="MxI_Cantidad" HeaderText="Cantidad" />
                                                <asp:BoundField DataField="M_NombreMedida" HeaderText="Medida" />
                                                <asp:BoundField DataField="usuariomov" HeaderText="Usuario" /> 
                                              </Columns>
                           </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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