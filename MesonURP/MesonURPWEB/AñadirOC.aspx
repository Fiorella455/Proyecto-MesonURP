<%@ Page Title="Gestionar OC | Agregar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AñadirOC.aspx.cs" Inherits="MesonURPWEB.AñadirOC" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Agregar Nueva Orden de Compra</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="input-info">
                        <h3>Detalles de Compra</h3>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">N° Orden</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumeroOrden" runat="server" placeholder="Ingrese el número de orden" CssClass="form-control1" ValidationGroup="añadirOC" onkeypress="return SoloNumeroInt(event);" />
                            <asp:RequiredFieldValidator ID="validationNumeroOrden" runat="server" ControlToValidate="txtNumeroOrden" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Emisión</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled ID="txtFechaEmision" runat="server" TextMode="Date" CssClass="form-control1" ValidationGroup="añadirOC" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Entrega</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFechaEntrega" runat="server" TextMode="Date" CssClass="form-control1" ValidationGroup="añadirOC" />
                            <asp:RequiredFieldValidator ID="validationFechaEntrega" runat="server" ControlToValidate="txtFechaEntrega" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Estado</label>
                        <div class="col-sm-8">
                            <asp:DropDownList disabled ID="selectEstadoAñadirOC" runat="server" CssClass="form-control1" ValidationGroup="añadirOC"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="selectProveedorOC" runat="server" CssClass="form-control1" AutoPostBack="true" OnSelectedIndexChanged="selectProveedorOC_SelectedIndexChanged" ValidationGroup="añadirOC">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationProveedorOC" runat="server" ControlToValidate="selectProveedorOC" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Forma de Pago</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="selectFormaPagoOC" runat="server" CssClass="form-control1" AutoPostBack="true" ValidationGroup="añadirOC"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationFormaPagoOC" runat="server" ControlToValidate="selectFormaPagoOC" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="input-info">
                        <h3>Detalles de Compra</h3>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="selectCategoriaOC" disabled runat="server" CssClass="form-control1" ValidationGroup="añadirOC"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationCategoriaOC" runat="server" ControlToValidate="selectCategoriaOC" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="selectInsumoOC" disabled runat="server" CssClass="form-control1" ValidationGroup="añadirOC"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationInsumoOC" runat="server" ControlToValidate="selectInsumoOC" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCantidadOC" runat="server" CssClass="form-control1" onkeypress="return SoloNumeroInt(event);" ValidationGroup="añadirOC" />
                            <asp:RequiredFieldValidator ID="validationCantidadOC" runat="server" ControlToValidate="txtCantidadOC" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Precio Unitario</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPrecioUnitarioOC" runat="server" CssClass="form-control1" onkeypress="return BlockChars(event);" ValidationGroup="añadirOC" />
                            <asp:RequiredFieldValidator ID="validationPrecioUnitario" runat="server" ControlToValidate="txtPrecioUnitarioOC" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Unidades de Medida</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="selectUnidadesOC" runat="server" CssClass="form-control1" ValidationGroup="añadirOC"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationUnidadesMedidaOC" runat="server" ControlToValidate="selectUnidadesOC" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <p class="center-button">
                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ValidationGroup="añadirOC" />
                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Quitar" />
                    </p>

                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Órdenes de Compra</h4>
                            </div>
                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="GridViewAñadirOC" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible."
                                    CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">

                                    <Columns>
                                        <asp:BoundField HeaderText="Descripción del Insumo" />
                                        <asp:BoundField HeaderText="Cantidad" />
                                        <asp:BoundField HeaderText="Unidad" />
                                        <asp:BoundField HeaderText="Costo Unitario" />
                                        <asp:BoundField HeaderText="Total" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <hr />
                        <p class="center-button">
                            <asp:Button ID="btnAñadirOC" CssClass="btn btn-primary" runat="server" OnClick="btnAñadirOC_Click" Text="Agregar" />
                            <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarOC';" class="btn btn-primary" />
                            <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                        </p>
                    </div>
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
    </script>
</asp:Content>
