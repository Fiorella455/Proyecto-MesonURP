<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarCategoria.aspx.cs" Inherits="MesonURPWEB.GestionarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Categorías</h2>
            </div>
             <div class="form-group">
                <label for="focusedinput" class="col-sm-1 control-label">Categoría</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtCategoria" runat="server" placeholder="Ingrese un nombre de categoría" CssClass="form-control1" />
                    <asp:RegularExpressionValidator ID="revNombreC" runat="server" ErrorMessage="Por favor ingrese solo letras" ControlToValidate="txtCategoria" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z ]*$" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>                   
                </div>
                  <div class="stock-options">
                    <div class="width-auto margin-5">
                            <asp:Button type="btnAgregarCategoria" class="btn btn-primary" runat="server" text="Agregar Nueva Categoría" onclick="btnAgregarCategoria_Click" />
                    </div>
                  </div>
             </div>
            <div class="search-buttons">
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Categorías</h4>
                             </div>
                        <div class="table-wrapper-scroll-y">
                            <asp:GridView ID="gvCategoria" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="C_idCategoria,C_NombreCategoria" 
                                OnPageIndexChanging="gvCategoria_PageIndexChanging" OnRowCommand="gvCategoria_RowCommand" Style="text-align: center" CellPadding="4" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="C_idCategoria" HeaderText="ID"/>
                                    <asp:BoundField DataField="C_NombreCategoria" HeaderText="Nombre de Categoría" />
                                  
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

     <div class="modal fade bd-example-modal-lg" tabindex="-1" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                      <div class="modal-dialog modal-lg">
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

                                        <div class="table-wrapper-scroll-y">
                            <asp:GridView ID="GridView1" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_NombreInsumo,I_CantidadTotal,M_NombreMedida,C_NombreCategoria" 
                                 Style="text-align: center" CellPadding="4" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="I_idInsumo" HeaderText="ID"/>
                                    <asp:BoundField DataField="I_NombreInsumo" HeaderText="Nombre de Insumo" />
                                    <asp:BoundField DataField="I_CantidadTotal" HeaderText="Cantidad Total"/>
                                    <asp:BoundField DataField="M_NombreMedida" HeaderText="Unidad de Medida" />
                                    <asp:BoundField DataField="C_NombreCategoria" HeaderText="Nombre de Categoría"/>
                                </Columns>
                            </asp:GridView>
                                      </div>
                                    <div class="modal-footer">
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">OK</button>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

    <script src="js/sweetalert.js"></script>
    <script>
        function myalert() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ya existe una categoría con el nombre.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function prueba() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No se puede eliminar la categoría, existe insumos.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function prueba1() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'La categoría fue eliminado correctamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
        //function prueba1() {
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
        //                    'La categoría fue eliminado correctamente',
        //                    'success'
        //                )
        //            }
        //        }
        //        Response.Redirect("GestionarCategoria.aspx");
        //    })
        
        function myalertCorrecto() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'La categoría fue registrado correctamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
    </script>
</asp:Content>
