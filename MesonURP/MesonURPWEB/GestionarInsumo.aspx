<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarInsumo.aspx.cs" Inherits="MesonURPWEB.GestionarInsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Insumos</h2>
                <div class="stock-options">
                    <div class="width-auto margin-5">
                        <input type="button" class="btn btn-primary" value="Agregar Nuevo Insumo" onclick="window.location.href = 'AñadirInsumo.aspx';">
                    </div>
                </div>
            </div>
            <div class="search-buttons">
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Insumos</h4>
<%--                            holi--%>
                        </div>
                        <div class="table-wrapper-scroll-y">
                            <asp:GridView ID="gvInsumos" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_NombreInsumo,C_NombreCategoria,I_CantidadTotal, M_NombreMedida,EI_NombreEstadoInsumo"
                                OnPageIndexChanging="gvInsumos_PageIndexChanging" OnRowCommand="gvInsumos_RowCommand" Style="text-align: center" CellPadding="4" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="I_idInsumo" HeaderText="I_idInsumo" Visible="false" />
                                    <asp:BoundField DataField="I_NombreInsumo" HeaderText="Nombre" />
                                    <asp:BoundField DataField="C_NombreCategoria" HeaderText="Categoría" />
                                    <asp:BoundField DataField="I_CantidadTotal" HeaderText="Cantidad Total" />
                                    <asp:BoundField DataField="M_NombreMedida" HeaderText="Unidad de Medida" />
                                    <asp:BoundField DataField="EI_NombreEstadoInsumo" HeaderText="Estado" />
                                  
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelectItem" class="btn btn-primary" runat="server" CommandName="selectItem" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ver Detalles">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelectItem1" class="btn btn-primary" runat="server" CommandName="selectItem1" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Consultar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelectItem2" class="btn btn-primary" runat="server" CommandName="selectItem2" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Eliminar" />
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
    <!-- Bootstrap Modal Dialog -->
                <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>


                                        <label for="lblnombreInsumo" class="control-label">Nombre:</label>
                                        <asp:TextBox id="txtnombreInsumo" runat="server" class="form-control1" type="text" placeholder="Nombre del insumo"></asp:TextBox>
                                        
                                        <label for="lblstockMaximo" class="control-label">Stock Máximo:</label>
                                        <asp:TextBox id="txtstockMaximo" runat="server" class="form-control1" type="text" placeholder="Stock Máximo"></asp:TextBox>

                                        <label for="lblstockMinimo" class="control-label">Stock Mínimo:</label>
                                        <asp:TextBox id="txtstockMinimo" runat="server" class="form-control1" type="text" placeholder="Stock Mínimo"></asp:TextBox>

                                        <label for="lblprecioUnitario" class="control-label">Precio Unitario:</label>
                                        <asp:TextBox id="txtprecioUnitario" runat="server" class="form-control1" type="text" placeholder="Precio Unitario"></asp:TextBox>

                                        <label for="lblcantidadTotal" class="control-label">Cantidad Total:</label>
                                        <asp:TextBox id="txtcantidadTotal" runat="server" class="form-control1" type="text" placeholder="Cantidad Total"></asp:TextBox>

                                        <label for="lblfechaVencimiento" class="control-label">Fecha de Vencimiento:</label>
                                        <asp:TextBox id="txtfechaVencimiento" runat="server" class="form-control1" type="text" placeholder="Fecha de Vencimiento"></asp:TextBox>

                                        <label for="lblestadoInsumo" class="control-label">Estado del Insumo:</label>
                                        <asp:TextBox id="txtestadoInsumo" runat="server" class="form-control1" type="text" placeholder="Estado del Insumo"></asp:TextBox>

                                        <label for="lblnestadoInsumo" class="control-label">Nombre del Estado:</label>
                                        <asp:TextBox id="txtnestadoInsumo" runat="server" class="form-control1" type="text" placeholder="Estado del Insumo"></asp:TextBox>

                                        <label for="lblunidadMedida" class="control-label">Unidad de Medida:</label>
                                        <asp:TextBox id="txtunidadMedida" runat="server" class="form-control1" type="text" placeholder="Unidad de Medida"></asp:TextBox>

                                        <label for="lblcategoriaInsumo" class="control-label">Categoría del Insumo:</label>
                                        <asp:TextBox id="txtcategoriaInsumo" runat="server" class="form-control1" type="text" placeholder="Categoría del Insumo"></asp:TextBox>

                                    </div>
                                    <div class="modal-footer">
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">OK</button>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
    <script src="js/sweetalert.js"></script>
    <script>
        function myalertixoc() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'El insumo se encuentra usado en una Orden de Compra',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function myalertixm() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'El insumo se encuentra usado en Movimientos',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function myalertixmxoc() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'El insumo existe en una Orden de Compra y Movimiento',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function myalertEliminar() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'El insumo fue eliminado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
        //function myalertEliminar() {
        //    Swal.fire({
        //        title: 'Estás seguro?',
        //        text: 'No podrás revertir esto!',
        //        icon: 'warning',
        //        showCancelButton: true,
        //        confirmButtonColor: '#3085d6',
        //        cancelButtonColor: '#d33',
        //        confirmButtonText: 'Si, elimina!'
        //    }).then((result) => {
        //        if (result.value) {
        //            if (result.value) {
        //                Swal.fire(
        //                    'Eliminado!',
        //                    'El insumo fue eliminado correctamente',
        //                    'success'
        //                )
        //            }
        //        }
        //    })
        //}
    </script>
</asp:Content>
