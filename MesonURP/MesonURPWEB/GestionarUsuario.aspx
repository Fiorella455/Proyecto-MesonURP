<%@ Page Title="MesónURP | Gestionar Usuario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarUsuario.aspx.cs" Inherits="MesonURPWEB.GestionarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Usuario</h2>
                <div class="stock-options">
                    <%--<div class="width-auto margin-5">
                        <input type="button" class="btn btn-primary" value="Agregar Nuevo Usuario" onclick="window.location.href = 'AñadirUsuario';">
                    </div>--%>
                    <div class="width-auto margin-5">
                        <button type="button" class="btn btn-primary btn-flex" runat="server" onserverclick="btnRegistrarUsuario_Click">     
                            <span class="material-icons margin-5">add_circle_outline</span>
                            <h> Agregar Usuario</h>
                        </button>
                    </div>
                </div>
            </div>
            <div class="search-buttons">
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Usuario</h4>
                        </div>
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                            <asp:GridView ID="GridViewUsuario" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
                                CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" DataKeyNames="U_idUsuario,Usuario,U_Celular,U_Correo, U_Direccion,TU_NombreTipoUsuario,EU_NombreEstadoUsuario" OnRowCommand="GridViewUsuario_RowCommand">
                                <Columns>
                                    <%--<asp:BoundField HeaderText="ID Proveedor"/>--%>
                                    <asp:TemplateField Visible="false">
                                          <ItemTemplate>
                                              <asp:Label ID="U_idUsuario" runat="server" Text="Label"></asp:Label>
                                          </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="U_idUsuario" HeaderText="U_idUsuario" Visible="false" />
                                    <asp:BoundField DataField="Usuario" HeaderText="Nombres y Apellidos" />
                                    <asp:BoundField DataField="U_Celular" HeaderText="Celular" />
                                    <asp:BoundField DataField="U_Correo" HeaderText="Correo electrónico" />
                                    <asp:BoundField DataField="U_Direccion" HeaderText="Dirección" />
                                    <asp:BoundField DataField="TU_NombreTipoUsuario" HeaderText="Rol" />
                                    <asp:BoundField DataField="EU_NombreEstadoUsuario" HeaderText="Estado" />

                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEditarUsuario" ImageUrl="img/editar.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar.png'" runat="server" CommandName="ActualizarUsuario" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ver Detalles">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnConsultarUsuario" ImageUrl="img/ojo.png" onmouseover="this.src='img/ojo-b.png'" onmouseout="this.src='img/ojo.png'" runat="server" CommandName="ConsultarUsuario" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Consultar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 <%--   <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEliminarUsuario" ImageUrl="img/delete.png" onmouseover="this.src='img/basura-b.png'" onmouseout="this.src='img/delete.png'" runat="server" CommandName="EliminarUsuario" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Eliminar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
            function alertaEli() {
                Swal.fire({
                    title: 'Enhorabuena!',
                    text: 'El usuario fue eliminado correctamente',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                })
            }
        </script>
</asp:Content>
