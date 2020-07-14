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
                                        <asp:Label ID="lblModalBody" runat="server"></asp:Label>

                                        <form>
                                            <div class="form-group">
                                                <label for="lblnombreInsumo">Nombre:</label>
                                                <asp:TextBox runat="server" type="text" class="form-control" ID="txtnombreInsumo"></asp:TextBox>
                                            </div>

                                            <div class="form-row">
                                                <div class="form-group col-md-6">
                                                    <label for="lblstockMaximo">Stock Máximo:</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtstockMaximo"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label for="lblstockMinimo">Stock Mínimo</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtstockMinimo"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-row">
                                                <div class="form-group col-md-6">
                                                    <label for="lblprecioUnitario">Precio Unitario:</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtprecioUnitario"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label for="lblcantidadTotal">Cantidad Total:</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtcantidadTotal"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-row">
                                                <div class="form-group col-md-6">
                                                    <label for="lblfechaVencimiento">Fecha de Vencimiento:</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtfechaVencimiento"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label for="lblnestadoInsumo">Estado:</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtnestadoInsumo"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-row">
                                                <div class="form-group col-md-6">
                                                    <label for="lblunidadMedida">Unidad de Medida:</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtunidadMedida"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label for="lblcategoriaInsumo">Categoría:</label>
                                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtcategoriaInsumo"></asp:TextBox>
                                                </div>
                                            </div>
                                        </form>                                        
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
