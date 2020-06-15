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
                            <asp:TextBox runat="server" placeholder="Ingrese el número de orden" CssClass="form-control1" ID="txtIdOC" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Emisión</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" TextMode="Date" CssClass="form-control1" ID="txtFechaEmision" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Entrega</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFechaEntrega" runat="server" TextMode="Date" CssClass="form-control1" />
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Número de Comprobante</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumeroCom" runat="server" TextMode="Date" CssClass="form-control1" />
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label"Tipo de Comprobante</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTipoCom" runat="server" TextMode="Date" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlProveedor">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Forma de Pago</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlFormaPago"></asp:DropDownList>
                        </div>
                    </div>
                       <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Fecha de Pago</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlFechaPago"></asp:DropDownList>
                        </div>
                    </div>
                      <div class="input-info">
						<h3>Detalles de Insumo</h3>
					</div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-sm-8">
                            <asp:DropDownList disabled runat="server" CssClass="form-control1" ID="DdlCategoria"></asp:DropDownList>
                        </div>
                    </div>
                      <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList disabled runat="server" CssClass="form-control1" ID="DdlInsumo"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" CssClass="form-control1" ID="txtCantidad" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Precio Unitario</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" CssClass="form-control1" ID="txtPrecioU" />
                        </div>
                    </div>
                      <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Unidades</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlUnidades"></asp:DropDownList>
                        </div>
                    </div>
                     <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" />
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
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Actualizar" ID="btnActualizar" OnClick="btnActualizar_Click" />
                            <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarOC';" class="btn btn-primary" id="btnRegresar" />
                            <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
