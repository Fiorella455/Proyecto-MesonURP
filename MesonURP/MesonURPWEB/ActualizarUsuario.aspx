<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarUsuario.aspx.cs" Inherits="MesonURPWEB.ActualizarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Usuario</h2>
            </div>
        </div>
         <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">                    

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Nombre</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control1"  placeholder="Ingrese el nombre" ValidationGroup="actualizarUsuario" onkeypress="return soloLetras(event);" MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="validation1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Apellido Paterno</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAPaterno" runat="server" placeholder="Ingrese el apellido paterno" ValidationGroup="actualizarUsuario" onkeypress="return soloLetras(event);" CssClass="form-control1" MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAPaterno" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Apellido Materno</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAMaterno" runat="server"  placeholder="Ingrese el apellido materno" ValidationGroup="actualizarUsuario" onkeypress="return soloLetras(event);" CssClass="form-control1" MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAMaterno" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Celular</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCelular" runat="server" placeholder="Ingrese el número de celular" ValidationGroup="actualizarUsuario" onkeypress="return SoloNumeroInt(event);" CssClass="form-control1" MaxLength="20"/>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Celular Inválido" ControlToValidate="txtCelular" ForeColor="#CC0000" SetFocusOnError="True" Display="Dynamic" ValidationGroup="actualizarUsuario" ValidationExpression="\d{6,11}"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCelular" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Correo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control1" placeholder="Ingrese el correo electrónico" ValidationGroup="actualizarUsuario" MaxLength="50"/>
                            <asp:RegularExpressionValidator ID="revCorreo" runat="server" ErrorMessage="Correo Inválido" ControlToValidate="txtCorreo" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" Display="Dynamic" ValidationGroup="actualizarUsuario"></asp:RegularExpressionValidator> 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>                  
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Dirección</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control1" placeholder="Ingrese la dirección" ValidationGroup="actualizarUsuario"  onkeypress="return BlockChars(event);" MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>                  
                        </div>
                    </div>
                    <div class="form-group">
                          <label for="selector1" class="col-sm-2 control-label">Fecha de Nacimiento</label>
                          <div class="col-sm-8">
                             <asp:TextBox ID="txtFecha" TextMode="Date" runat="server" CssClass="form-control1" ValidationGroup="actualizarUsuario"/>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>                  
                          </div>
                    </div>      
                       
                     <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Sexo</label>
                        <div class="col-sm-8">
<%--                            <asp:TextBox ID="txtSexo" runat="server" CssClass="form-control1"/>--%>
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="ddlSexo">
                                 <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                 <asp:ListItem Text="Femenino" Value="Femenino">Femenino</asp:ListItem>
                                 <asp:ListItem Text="Masculino" Value="Masculino">Masculino</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>                  
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Contraseña</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContra" runat="server" CssClass="form-control1" placeholder="Ingrese la contraseña" ValidationGroup="actualizarUsuario" onkeypress="return BlockChars(event);" MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtContra" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>                  
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Tipo de Documento</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlTipoDocumento" OnSelectedIndexChanged="DdlTipoDocumento_SelectedIndexChanged1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DdlTipoDocumento" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Número de Documento</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control1" placeholder="Ingrese el número de documento" ValidationGroup="actualizarUsuario"  MaxLength="20"/>
                            <asp:RegularExpressionValidator ID="revNumDoc" runat="server" ErrorMessage="DNI Inválido" ControlToValidate="txtDni" ForeColor="#CC0000" SetFocusOnError="True" Display="Dynamic" ValidationGroup="actualizarUsuario" ValidationExpression="\d{8}"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDni" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarUsuario" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>                  
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Tipo de Usuario</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlTipoUsuario">
                            </asp:DropDownList>
                        </div>
                    </div>
                     
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Estado del Usuario</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlEstadoUsuario" >
                            </asp:DropDownList>
                            
                        </div>
                    </div>

                    <hr />
                    <asp:UpdatePanel ID="panelActualizarUser" runat="server">
                        <ContentTemplate>
                            <p class="center-button">
                                <asp:Button ID="btnActualizarUsuario" CssClass="btn btn-primary" runat="server" ValidationGroup="actualizarUsuario" Text="Actualizar Usuario" OnClick="btnActualizarUsuario_Click"/>
                                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarUsuario.aspx';" class="btn btn-primary" />
                                <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                            </p>
                        </ContentTemplate>
                     </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
           <script>
               function BlockChars(ev) {
                   var tecla = (document.all) ? ev.keyCode : ev.which;
                   if (tecla == 8 || tecla == 13 || tecla == 0) return true;
                   if (tecla >= 8226 && tecla <= 10175) { return false; } //BlockAltCtrl
                   var regEx = /[\~`!#$%^&§¥£│øƒ×®️¿¬¡©️¢┐└┴┬├─┼ãÃ╚╔╩╦╠═╬¤ðÐÊËÈıÍÎÏ┘┌█▬¦▬▀­­­±­¶@_*\+\=\\[\]\\\´'\{}|\":<>?()]/;
                   return !regEx.test(String.fromCharCode(tecla));
               }
               function SoloNumeroInt(ev) {
                   var tecla = (document.all) ? ev.keyCode : ev.which;
                   if (tecla == 8 || tecla == 13 || tecla == 0) return true;
                   if (tecla >= 8226 && tecla <= 10175) { return false; }
                   var regEx = /^[0-9]+$/i;
                   return regEx.test(String.fromCharCode(tecla));
               }
               function SoloNumeroIntDouble(ev) {
                   var tecla = (document.all) ? ev.keyCode : ev.which;
                   if (tecla == 8 || tecla == 13 || tecla == 0) return true;
                   if (tecla >= 8226 && tecla <= 10175) { return false; }
                   var regEx = /^[0-9\.]+$/i;
                   return regEx.test(String.fromCharCode(tecla));
               }
               function soloLetras(e) {
                   key = e.keyCode || e.which;
                   tecla = String.fromCharCode(key).toLowerCase();
                   letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
                   especiales = [8, 37, 39, 46];

                   tecla_especial = false
                   for (var i in especiales) {
                       if (key == especiales[i]) {
                           tecla_especial = true;
                           break;
                       }
                   }

                   if (letras.indexOf(tecla) == -1 && !tecla_especial)
                       return false;
               }
           </script>
        <script>
            function alertaError() {
                Swal.fire({
                    title: 'Oh, no!',
                    text: 'No se ha logrado Actualizar correctamente',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaExiste() {
                Swal.fire({
                    title: 'Oh, no!',
                    text: 'Este usuario ya existe',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaExito() {
                Swal.fire({
                    title: 'Enhorabuena!',
                    text: 'Se ha logrado Actualizar correctamente',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.value) {
                        window.location.href = "GestionarUsuario";
                    }
                })
            }
        </script>
</asp:Content>
