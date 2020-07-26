<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarUsuario.aspx.cs" Inherits="MesonURPWEB.GestionarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Usuario</h2>
                <div class="stock-options">
                    <div class="width-auto margin-5">
                        <input type="button" class="btn btn-primary" value="Agregar Nuevo Usuario" onclick="window.location.href = 'AñadirUsuario.aspx';">
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
                                CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" DataKeyNames="U_idUsuario" OnRowCommand="GridViewUsuario_RowCommand" OnRowDataBound="GridViewUsuario_RowDataBound">
                                <Columns>
                                    <%--<asp:BoundField HeaderText="ID Proveedor"/>--%>
                                    <asp:TemplateField Visible="false">
                                          <ItemTemplate>
                                              <asp:Label ID="U_idUsuario" runat="server" Text="Label"></asp:Label>
                                          </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:BoundField DataField="U_Nombre" HeaderText="Nombre" />
                                     <asp:BoundField DataField="U_APaterno" HeaderText="Apellido Paterno" />
                                     <asp:BoundField DataField="U_AMaterno" HeaderText="Apellido Materno" />
                                     <asp:BoundField DataField="U_Celular" HeaderText="Celular" />
                                     <asp:BoundField DataField="U_Correo" HeaderText="Correo" />
                                     <asp:BoundField DataField="U_Direccion" HeaderText="Dirección" />
                                     <asp:BoundField DataField="U_FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                                     <asp:BoundField DataField="U_Sexo" HeaderText="Sexo" />
                                     <asp:BoundField DataField="U_Contraseña" HeaderText="Contraseña" />
                                     <asp:BoundField DataField="TD_NombreTipoDocumento" HeaderText="Tipo de Documento" />
                                     <asp:BoundField DataField="U_Dni" HeaderText="Número documento" />
                                     <asp:BoundField DataField="EU_NombreEstadoUsuario" HeaderText="Estado del Usuario" />
                                     <asp:BoundField DataField="TU_NombreTipoUsuario" HeaderText="Tipo de Usuario" />


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
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEliminarUsuario" ImageUrl="img/delete.png" onmouseover="this.src='img/basura-b.png'" onmouseout="this.src='img/delete.png'" runat="server" CommandName="EliminarUsuario" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Eliminar" />
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
</asp:Content>
