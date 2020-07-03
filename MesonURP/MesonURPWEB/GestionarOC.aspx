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
                                    <div class="table-wrapper-scroll-y  my-custom-scrollbar">
                                         <asp:GridView ID="GridViewOC" allowpaging="True" runat="server" emptydatatext="No hay información disponible."  OnRowCommand="GridViewOC_RowCommand"
                                                   DataKeyNames="OC_idOrdenCompra, OC_TipoComprobante,OC_NumeroComprobante,OC_FormaPago, OC_TotalCompra, OC_FechaEmision, P_idProveedor"   AutoGenerateColumns="false"
                                             CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                             <Columns>
                                                <asp:BoundField HeaderText="ID Compra" DataField="OC_idOrdenCompra" />
                                                <asp:BoundField HeaderText="Tipo de Comprobante" DataField="OC_TipoComprobante" />
                                                <asp:BoundField HeaderText="Número de comprobante" DataField="OC_NumeroComprobante"/>
                                                <asp:BoundField HeaderText="Forma de Pago" DataField="OC_FormaPago"/>
                                                <asp:BoundField HeaderText="Total de Compra" DataField="OC_TotalCompra"/>
                                                <asp:BoundField  HeaderText="Fecha de Emisión"  DataField="OC_FechaEmision"/>    
                                                <asp:BoundField  HeaderText="ID Proveedor" DataField="P_idProveedor" Visible="false" />
                                                   <asp:TemplateField  HeaderText="Enviar">
                                                       <ItemTemplate>
                                                           <%--<asp:Button ID="btnEnviarEmailOC" class="btn btn-primary" runat="server" CommandName="EnviarEmailOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Enviar" OnClick="btnEnviarEmailOC_Click" />--%>
                                                       <asp:Button ID="btnEnviarEmailOC" class="btn btn-primary" runat="server" CommandName="EnviarEmailOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Enviar" />
                                                       </ItemTemplate>                                                     
                                                   </asp:TemplateField>  
                                                   <asp:TemplateField  HeaderText="Editar">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnEditarOC" class="btn btn-primary" runat="server" CommandName ="ActualizarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Actualizar" />
                                                       </ItemTemplate> 
                                                   </asp:TemplateField>
                                                   <asp:TemplateField  HeaderText="Ver Detalles">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnVerDetallesOC" class="btn btn-primary" runat="server" CommandName="ConsultarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Consultar" />
                                                       </ItemTemplate>                                                     
                                                   </asp:TemplateField>                                                    
                                                   <asp:TemplateField HeaderText="Eliminar">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnEliminar" class="btn btn-primary" runat="server" CommandName="EliminarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  Text="Eliminar" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
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
</asp:Content>
