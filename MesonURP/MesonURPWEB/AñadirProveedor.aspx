<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AñadirProveedor.aspx.cs" Inherits="MesonURPWEB.AñadirProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Agregar Nuevo Proveedor</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">                    
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Razón Social</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtRazonSocial" runat="server" placeholder="Ingrese la razón social" CssClass="form-control1" ValidationGroup="añadirProveedor" onkeypress="return BlockChars(event);" MaxLength="50" />
                            <%--<asp:RegularExpressionValidator ID="revMaxLen" runat="server" ErrorMessage="Mucho texto" ControlToValidate="txtRazonSocial" ForeColor="#CC0000" ValidationExpression="(.{1,50}){1}" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                            --%><asp:RequiredFieldValidator ID="validationRazon" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirProveedor" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
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
                            <asp:TextBox ID="txtNumeroDoc" placeholder="Ingrese el número de documento" runat="server" CssClass="form-control1" MaxLength="20"/>
                            <asp:RegularExpressionValidator ID="revNumDoc" runat="server" ErrorMessage="DNI Inválido" ControlToValidate="txtNumeroDoc" ForeColor="#CC0000" SetFocusOnError="True" Display="Dynamic" ValidationGroup="añadirProveedor" ValidationExpression="\d{8,9}"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="validationNumeroDoc" runat="server" ControlToValidate="txtNumeroDoc" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirProveedor" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Dirección</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDireccion" placeholder="Ingrese la dirección" runat="server" CssClass="form-control1" onkeypress="return BlockChars(event);" MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="validationDir" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirProveedor" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                      <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Nombre del Contacto</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNombre" placeholder="Ingrese el nombre del contacto" runat="server" CssClass="form-control1" onkeypress="return lettersOnly(event);" MaxLength="50"/>
                            <asp:RequiredFieldValidator ID="validationProveedorOC" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirProveedor" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="form-group">
                          <label for="selector1" class="col-sm-2 control-label">Teléfono del Contacto</label>
                          <div class="col-sm-8">
                             <asp:TextBox ID="txtTelefono" placeholder="Ingrese el teléfono" runat="server" CssClass="form-control1" onkeypress="return SoloNumeroInt(event);" MaxLength="20"/>
                              <asp:RegularExpressionValidator ID="revTelefono" runat="server" ErrorMessage="Teléfono Inválido" ControlToValidate="txtTelefono" ForeColor="#CC0000" ValidationExpression="\d{6,11}" SetFocusOnError="True" Display="Dynamic" ValidationGroup="añadirProveedor"></asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="validacionTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirProveedor" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                          </div>
                    </div>
                       
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Correo electrónico</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCorreo" runat="server" placeholder="Ingrese su correo electrónico" CssClass="form-control1" MaxLength="50"/>     
                            <asp:RegularExpressionValidator ID="revCorreo" runat="server" ErrorMessage="Correo Inválido" ControlToValidate="txtCorreo" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" Display="Dynamic" ValidationGroup="añadirProveedor"></asp:RegularExpressionValidator>                           
                            <asp:RequiredFieldValidator ID="validationCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirProveedor" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>                        
                    <hr />
                    <asp:UpdatePanel ID="panelAñadirProv" runat="server">
                        <ContentTemplate>
                            <p class="center-button">
                                <asp:Button ID="btnAñadirProveedor" CssClass="btn btn-primary" runat="server" ValidationGroup="añadirProveedor" Text="Agregar Proveedor" OnClick="btnAñadirProveedor_Click"/>
                                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarProveedor';" class="btn btn-primary" />
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
        function lettersOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }
    </script>
        <script>
            function alertaError() {
                Swal.fire({
                    title: 'Oh, no!',
                    text: 'No se ha logrado añadir correctamente',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaExiste() {
                Swal.fire({
                    title: 'Oh, no!',
                    text: 'Este proveedor ya existe',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaExito() {
                Swal.fire({
                    title: 'Enhorabuena!',
                    text: 'Se ha logrado añadir correctamente',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.value) {
                        window.location.href = "GestionarProveedor";
                    }
                })
            }
        </script>
</asp:Content>
