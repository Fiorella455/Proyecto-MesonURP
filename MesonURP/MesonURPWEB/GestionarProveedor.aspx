<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarProveedor.aspx.cs" Inherits="MesonURPWEB.GestionarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Gestionar Proveedor</h2>
                            <div class="stock-options">
                                <div class="width-auto margin-5">
                                     <input type="button" class="btn btn-primary" value="Agregar Nuevo Proveedor" onclick="window.location.href = 'AñadirProveedor';"> 
                                </div>
                            </div>
                        </div>
                        <div class="search-buttons">
                              <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Proveedor</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                         <asp:GridView ID="GridViewProveedor" allowpaging="True" runat="server" emptydatatext="No hay información disponible." AutoGenerateColumns="false"
                                             CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" DataKeyNames="P_idProveedor"   OnRowCommand="GridViewProveedor_RowCommand" OnRowDataBound="GridViewProveedor_RowDataBound">
                                             <Columns>
                                                <%--<asp:BoundField HeaderText="ID Proveedor"/>--%>
                                                 <asp:TemplateField Visible="false">
                                                     <ItemTemplate>
                                                           <asp:Label ID="P_idProveedor" runat="server" Text="Label"></asp:Label>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="P_RazonSocial" HeaderText="Razón Social"/>
                                                <asp:BoundField DataField="TD_NombreTipoDocumento" HeaderText="Tipo de Documento"/>
                                                <asp:BoundField DataField="P_NumeroDocumento" HeaderText="Número de Documento"/>
                                                <asp:BoundField DataField="P_Direccion" HeaderText="Dirección"/>
                                                <asp:BoundField DataField="P_NombreContacto" HeaderText="Nombre Contacto"/>
                                                <asp:BoundField DataField="P_TelefonoContacto" HeaderText="Teléfono" />    
                                                <asp:BoundField DataField="P_CorreoContacto" HeaderText="Correo Electrónico"/>
                                                <asp:BoundField DataField="EP_NombreEstadoProveedor" HeaderText="Estado del Proveedor" />
                                                   <asp:TemplateField  HeaderText="Editar">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnEditarProveedor" class="btn btn-primary" runat="server" CommandName ="ActualizarProveedor" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                                                       </ItemTemplate> 
                                                   </asp:TemplateField>
                                                   <asp:TemplateField  HeaderText="Ver Detalles">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnConsultarProveedor" class="btn btn-primary" runat="server" CommandName="ConsultarProveedor" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Consultar" />
                                                       </ItemTemplate>                                                     
                                                   </asp:TemplateField>                                                    
                                                   <asp:TemplateField HeaderText="Eliminar">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnEliminarProveedor" class="btn btn-primary" runat="server" CommandName="EliminarProveedor" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  Text="Eliminar" />
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
    <script>
        function deleteProv() {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: false
            })

            swalWithBootstrapButtons.fire({
                title: '¿Estás seguro?',
                text: "Después de eliminarlo no podrás volver atrás",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sí, eliminar',
                cancelButtonText: 'No, cancelar',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    swalWithBootstrapButtons.fire(
                        '¡Enhorabuena!',
                        'El proveedor ha sido eliminado',
                        'success'
                    )
                } else if (
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'Cancelado',
                        'El proveedor no fue eliminado',
                        'error'
                    )
                }
            })
        }
    </script>
</asp:Content>
