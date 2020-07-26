<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AñadirUsuario.aspx.cs" Inherits="MesonURPWEB.AñadirUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Añadir Usuario</h2>
            </div>
        </div>
         <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">                    

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Nombre</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Apellido Paterno</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAPaterno" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Apellido Materno</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAMaterno" runat="server" CssClass="form-control1"/>
                         </div>
                    </div>

                     <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Celular</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control1"/>
                         </div>
                    </div>

                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Correo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Dirección</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                    <div class="form-group">
                          <label for="selector1" class="col-sm-2 control-label">Fecha de Nacimiento</label>
                          <div class="col-sm-8">
                             <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control1"/>
                          </div>
                    </div>
                       
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Sexo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSexo" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Contraseña</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContra" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Tipo de Documento</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlTipoDocumento" OnSelectedIndexChanged="DdlTipoDocumento_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Número de Documento</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Tipo de Usuario</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlTipoUsuario" OnSelectedIndexChanged="DdlTipoUsuario_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <hr />
                    <asp:UpdatePanel ID="panelAñadirUser" runat="server">
                        <ContentTemplate>
                            <p class="center-button">
                                <asp:Button ID="btnAñadirUsuario" CssClass="btn btn-primary" runat="server" ValidationGroup="añadirUsuario" Text="Agregar Usuario" OnClick="btnAñadirUsuario_Click"/>
                                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarUsuario;" class="btn btn-primary" />
                                <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                            </p>
                        </ContentTemplate>
                     </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
