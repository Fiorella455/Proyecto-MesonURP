<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarProveedor.aspx.cs" Inherits="MesonURPWEB.ConsultarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Consultar Proveedor</h2>
            </div>
        </div>
         <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">                    
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Razón Social</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtRazonSocial" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Número de Documento</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumeroDoc" disabled="true" runat="server" CssClass="form-control1"/>
                         </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Dirección</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDireccion" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Nombre del Contacto</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNombre" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                    <div class="form-group">
                          <label for="selector1" class="col-sm-2 control-label">Teléfono del Contacto</label>
                          <div class="col-sm-8">
                             <asp:TextBox ID="txtTelefono" disabled="true" runat="server" CssClass="form-control1"/>
                          </div>
                    </div>
                       
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Correo electrónico</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCorreo" disabled="true" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                        
                        <hr />
                        <p class="center-button">
                            <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarProveedor';" class="btn btn-primary" />
                        </p>
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
</asp:Content>
