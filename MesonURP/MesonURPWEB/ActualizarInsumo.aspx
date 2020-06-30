<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarInsumo.aspx.cs" Inherits="MesonURPWEB.ActualizarInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Insumo</h2>
            </div>
        </div>
     <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlInsumo" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlInsumo" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlCategoria" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlCategoria" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Cantidad Total</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCantidadT" placeholder="Ingrese la cantidad total" runat="server" CssClass="form-control1" onkeypress="return SoloNumeroIntDouble(event);" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCantidadT" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Unidad de Medida</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtUnidadMedida" runat="server" CssClass="form-control1" onkeypress="return lettersOnly(event);" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUnidadMedida" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Estado</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="ddlEstado" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlEstado" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <hr />
                    <p class="center-button">
                        <asp:Button ID="btnActualizarInsumo" CssClass="btn btn-primary" runat="server" ValidationGroup="actualizarInsumo" Text="Actualizar Insumo" />
                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarInsumo';" class="btn btn-primary" />
                        <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
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
