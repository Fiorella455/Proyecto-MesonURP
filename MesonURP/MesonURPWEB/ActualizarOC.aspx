<%@ Page Title="Gestionar OC | Actualizar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarOC.aspx.cs" Inherits="MesonURPWEB.ActualizarOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Orden de Compra</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="input-info">
						<h3>Detalles de Producto</h3>
					</div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">N° Orden</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" placeholder="Ingrese el número de orden" CssClass="form-control1" ID="txtNumeroOrdenOC" onkeypress="return SoloNumeroInt(event);"/>
                            <asp:RequiredFieldValidator ID="validationNumeroOrden" runat="server" ControlToValidate="txtNumeroOrdenOC" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Emisión</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" TextMode="Date" CssClass="form-control1" ID="txtFechaEmision"/>
                            <asp:RequiredFieldValidator ID="validationFechaEmision" runat="server" ControlToValidate="txtFechaEmision" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Entrega</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" TextMode="Date" CssClass="form-control1" ID="txtFechaEntrega"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaEntrega" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlProveedor">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlProveedor" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Forma de Pago</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlFormaPago"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlFormaPago" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>                      
                      <div class="input-info">
						<h3>Detalles de Insumo</h3>
					</div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-sm-8">
                            <asp:DropDownList disabled runat="server" CssClass="form-control1" ID="DdlCategoria"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DdlCategoria" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                      <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlInsumo"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DdlInsumo" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" CssClass="form-control1" ID="txtCantidad" onkeypress="return SoloNumeroIntDouble(event);"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Precio Unitario</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" CssClass="form-control1" ID="txtPrecioU" onkeypress="return SoloNumeroIntDouble(event);"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPrecioU" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                      <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Unidades de Medida</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlUnidades" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DdlUnidades" ErrorMessage="Campo Obligatorio" ValidationGroup="actOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                     <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ValidationGroup="actOC"/>
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
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Actualizar" />
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
         function SoloNumeroIntDouble(ev) {
             var tecla = (document.all) ? ev.keyCode : ev.which;
             if (tecla == 8 || tecla == 13 || tecla == 0) return true;
             if (tecla >= 8226 && tecla <= 10175) { return false; }
             var regEx = /^[0-9\.]+$/i;
             return regEx.test(String.fromCharCode(tecla));
         }
     </script>
</asp:Content>
