<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuario.aspx.cs" Inherits="MesonURPWEB.ConsultarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Consultar Usuario</h2>
            </div>
        </div>
         <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">                    

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Nombre</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNombre" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Apellido Paterno</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAPaterno" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Apellido Materno</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAMaterno" disabled="true" runat="server" CssClass="form-control1"/>
                         </div>
                    </div>

                     <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Celular</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCelular" disabled="true" runat="server" CssClass="form-control1"/>
                         </div>
                    </div>

                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Correo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCorreo" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Dirección</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDireccion" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                    <div class="form-group">
                          <label for="selector1" class="col-sm-2 control-label">Fecha de Nacimiento</label>
                          <div class="col-sm-8">
                             <asp:TextBox ID="txtFecha" disabled="true" runat="server" CssClass="form-control1"/>
                          </div>
                    </div>
                       
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Sexo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSexo" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Contraseña</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContra" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Tipo de Documento</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTipoDocumento" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Número de Documento</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDni" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Tipo de Usuario</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTipoUsuario" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Estado del Usuario</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtEstadoUsuario" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>

                        <hr />
                        <p class="center-button">
                            <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarUsuario';" class="btn btn-primary" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
