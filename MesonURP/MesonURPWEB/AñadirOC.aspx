<%@ Page Title="Gestionar OC | Agregar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AñadirOC.aspx.cs" Inherits="MesonURPWEB.AñadirOC" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #616161;
            box-shadow: none !important;
            font-size: 14px;
            font-weight: 300;
            border-radius: 0;
            -webkit-appearance: none;
            resize: none;
            border: 1px solid #ccc;
            padding: 5px 8px;
            background: #fff;
        }
    </style>
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
                            <asp:TextBox ID="txtNumeroOrden" runat="server" placeholder="Ingrese el número de orden" CssClass="form-control1" />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Entrega</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFechaEntrega" runat="server" TextMode="Date" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Estado</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlEstado"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="DdlProveedor" runat="server" CssClass="form-control1" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Forma de Pago</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFormaPago" runat="server" placeholder="Ingrese forma de pago" CssClass="form-control1" />
                        </div>
                    </div>
                       
                           <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Numero de Comprobante</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumeroComprobante" runat="server" placeholder="Ingrese el número de comprobante" CssClass="form-control1" />
                        </div>
                    </div>
                           <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Tipo de Comprobante</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTipoComprobante" runat="server" placeholder="Ingrese  tipo de comprobante" CssClass="form-control1" />
                        </div>
                    </div>
                    </div>
                      <div class="input-info">
						<h3>Detalles de Compra</h3>
					</div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlCategoria" AutoPostBack="true" ></asp:DropDownList>
                        </div>
                    </div>
                      <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlInsumo"  AutoPostBack="true" ></asp:DropDownList>
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
                            <asp:TextBox ID="txtMedida" runat="server" placeholder="Ingrese el número de orden" CssClass="form-control1" />
                        </div>
                    </div>
                     <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirInsumo" OnClick="btnAñadirInsumo_Click" />
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Quitar" OnClick="Unnamed1_Click" />
                        </p>

                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Órdenes de Compra</h4>
                            </div>
                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="GridViewAñadirOC" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
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
    </div>
</asp:Content>
