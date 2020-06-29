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
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Entrega</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFechaEntrega" runat="server" textmode="Date" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Estado</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlEstado"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlEstado" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="DdlProveedor" runat="server" CssClass="form-control1" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationProveedorOC" runat="server" ControlToValidate="DdlProveedor" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="form-group">
                               <label for="selector1" class="col-sm-2 control-label">Forma de pago</label>
                               <div class="col-sm-8">
                               <asp:DropDownList runat="server" CssClass="form-control1" ID="DListFormaP"  AutoPostBack="true">
                                <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                <asp:ListItem Text="Efectivo" Value="Efectivo">Efectivo</asp:ListItem>
                                <asp:ListItem Text="Crédito" Value="Crédito">Crédito</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                       
                           <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Numero de Comprobante</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumeroComprobante" runat="server" placeholder="Ingrese el número de comprobante" CssClass="form-control1" onkeypress="return SoloNumeroInt(event);"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumeroComprobante" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                           <div class="form-group">
                               <label for="selector1" class="col-sm-2 control-label">Tipo de Comprobante</label>
                               <div class="col-sm-8">
                               <asp:DropDownList runat="server" CssClass="form-control1" ID="DListTipoC"  AutoPostBack="true">
                                <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                <asp:ListItem Text="Boleta" Value="Boleta">Boleta</asp:ListItem>
                                <asp:ListItem Text="Factura" Value="Factura">Factura</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                      <div class="input-info">
						<h3>Detalles de Compra</h3>
					</div>
                   
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlInsumo"  AutoPostBack="true" OnSelectedIndexChanged="DdlInsumo_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DdlInsumo" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" placeholder="Ingrese una cantidad" CssClass="form-control1" ID="txtCantidad" onkeypress="return SoloNumeroIntDouble(event);" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Precio Unitario</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" CssClass="form-control1" ID="txtPrecioU" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPrecioU" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Unidades de Medida</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtMedida" runat="server" CssClass="form-control1"  onkeypress="return lettersOnly(event);" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMedida" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                     <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirInsumo" OnClick="btnAñadirInsumo_Click" ValidationGroup="añadirOC"/>
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Quitar" OnClick="Unnamed1_Click" />
                        </p>
                   </div>

                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Órdenes de Compra</h4>
                            </div>
                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="GridViewAñadirOC" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
                                   DataKeyNames="OC_idOrdenCompra,I_NombreInsumo,OCxI_Cantidad,I_PrecioUnitario,OCxI_PrecioTotal" CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                    <Columns>
                                        <asp:BoundField HeaderText="Orden de Compra" DataField="OC_idOrdenCompra" />
                                        <asp:BoundField HeaderText="Insumo" DataField="I_NombreInsumo" />
                                        <asp:BoundField HeaderText="Cantidad" Datafield="OCxI_Cantidad"/>
                                        <asp:BoundField HeaderText="Precio unitario" DataField="I_PrecioUnitario" />
                                        <asp:BoundField HeaderText="Precio Total" Datafield="OCxI_PrecioTotal"/>
                                        
                                    </Columns>   
                                </asp:GridView>
                            </div>
                             <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Total</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTotal" runat="server" align="left" CssClass="special" Width="102px" />
                        </div>
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
