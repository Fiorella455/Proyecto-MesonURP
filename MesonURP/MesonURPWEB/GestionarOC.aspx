<%@ Page Title="Mesón URP | Gestionar OC" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarOC.aspx.cs" Inherits="MesonURPWEB.GestionarOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Gestionar Orden de Compra</h2>
                            <div class="stock-options">
                                <div class="width-auto margin-5">
        <input type="button" class="btn btn-primary" value="Agregar Nueva Orden de Compra" onclick="window.location.href = 'AñadirOC';">
    </div>
                            </div>
                        </div>
                        <div class="search-buttons">
                              <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Órdenes de Compra</h4>
                                    </div>
                                <%-- <asp:UpdatePanel ID="panelOC" runat="server">
                                    <ContentTemplate>--%>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                         <asp:GridView ID="GridViewOC" Allowpaging="True" runat="server" emptydatatext="No hay información disponible."  OnRowCommand="GridViewOC_RowCommand" OnRowDataBound="GridViewOC_OnRowDataBound" OnPageIndexChanging="GridViewOC_PageIndexChanging"
                                             DataKeyNames="OC_idOrdenCompra,EOC_NombreEstadoOC,OC_TipoComprobante,OC_NumeroComprobante,OC_FormaPago,OC_TotalCompra,OC_FechaEmision,P_idProveedor"   AutoGenerateColumns="False"
                                             CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                             <Columns>
                                                 
                                                <asp:BoundField HeaderText="ID Compra" DataField="OC_idOrdenCompra" />
                                                 <asp:BoundField HeaderText="Estado" DataField="EOC_NombreEstadoOC"/>
                                                <asp:BoundField HeaderText="Tipo de Comprobante" DataField="OC_TipoComprobante" />
                                                <asp:BoundField HeaderText="Número de comprobante" DataField="OC_NumeroComprobante"/>
                                               <asp:BoundField HeaderText="Forma de Pago" DataField="OC_FormaPago"/>
                                                <asp:BoundField HeaderText="Total de Compra" DataField="OC_TotalCompra"/>
                                                <asp:BoundField  HeaderText="Fecha de Emisión"  DataField="OC_FechaEmision"/>    
                                                <asp:BoundField  HeaderText="ID Proveedor" DataField="P_idProveedor" Visible="false" />
                                                   <asp:TemplateField  HeaderText="Enviar">
                                                       <ItemTemplate>
                                                           <%--<asp:Button ID="btnEnviarEmailOC" class="btn btn-primary" runat="server" CommandName="EnviarEmailOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Enviar" OnClick="btnEnviarEmailOC_Click" />--%>
                                                       <asp:ImageButton ID="btnEnviarEmailOC" CssClass="colorBEmail" ImageUrl="img/email.png" runat="server" CommandName="EnviarEmailOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/> 
                                                       </ItemTemplate>                                                     
                                                   </asp:TemplateField>  
                                                   <asp:TemplateField  HeaderText="Editar">
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btnEditarOC" class="colorBEd" ImageUrl="img/lapiz.png" runat="server" CommandName ="ActualizarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                          <%-- opción para el hover--%> <%--<asp:ImageButton ID="ImageButton1" ImageUrl="img/lapiz.png" onmouseover="this.src='img/editar-w.png'"  onmouseout="this.src='img/lapiz.png'" runat="server" CommandName ="ActualizarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>
                                                       </ItemTemplate> 
                                                   </asp:TemplateField>
                                                   <asp:TemplateField  HeaderText="Ver Detalles">
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btnVerDetallesOC" class="colorBV" ImageUrl="img/ver.png" runat="server" CommandName="ConsultarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                       </ItemTemplate>                                                     
                                                   </asp:TemplateField>                                                    
                                                   <asp:TemplateField HeaderText="Eliminar">
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btnEliminar" class="colorBE" ImageUrl="img/delete.png" runat="server" CommandName="EliminarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                 <asp:TemplateField>
                                                     <ItemTemplate>
                                                         <div style="text-align: center"> 
                                                         <asp:ImageButton ID="btnAceptado" class="colorBCheck" ImageUrl="img/check.png" runat="server"  CommandName="AceptarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" TabIndex="1" />
                                                         
                                                         <asp:ImageButton ID="btnRechazado" class="colorBR" ImageUrl="img/eliminar.png" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="RechazarOC" TabIndex="2" />
                                                         </div>
                                                         <asp:ImageButton ID="btnRecibido" class="colorBRecib" runat="server" ImageUrl="img/recibido-b.png" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="RecibirOC" TabIndex="3" />
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                                </div>
                            </div>
                        </div>
     
                                <div class="clearfix"></div>
                            </div>

      </div>
    <script>
        function lettersOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122)) {
                alert("Por favor, ingrese solo letras.");
                return false;
            }
            return true;
        }
    </script>
        <script>
            function alertaAceptado() {
                Swal.fire({
                    title: 'Aceptado',
                    text: 'La Orden de Compra ha cambiado de estado satisfactoriamente',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaRechazado() {
                Swal.fire({
                    title: 'Rechazado',
                    text: 'La Orden de Compra ha cambiado de estado satisfactoriamente',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaRecibido() {
                Swal.fire({
                    title: 'Recibido',
                    text: 'Los insumos ya se encuentran en stock',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaEliminar() {
                Swal.fire({
                    title: 'Eliminado',
                    text: 'La Orden de Compra ha sido eliminada',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaCorreo() {
                Swal.fire({
                    title: 'Enhorabuena!',
                    text: 'Se ha enviado el correo correctamente',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.value) {
                        window.location.href = 'GestionarOC.aspx';
                    }
                })

            }
        </script>
</asp:Content>
