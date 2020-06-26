<%@ Page Title="Gestionar OC | Consultar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarOC.aspx.cs" Inherits="MesonURPWEB.ConsultarOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Detalles de la Orden de Compra</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">N° Orden</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtidOC" runat="server" CssClass="form-control1"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Tipo de Comprobante</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTipoComprobante" runat="server" CssClass="form-control1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Emisión</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" CssClass="form-control1" ID="txtFechaEmision" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Entrega</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server"  CssClass="form-control1" ID="txtFechaEntrega" />
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" CssClass="form-control1" ID="txtProveedor" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Forma de Pago</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" CssClass="form-control1" ID="txtFormaPago" />
                        </div>
                    </div>
                    <%-- <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Fecha de Pago</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" CssClass="form-control1" ID="txtFechaPago" />
                        </div>
                    </div>--%>
                      
                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Insumos</h4>
                            </div>
                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="GridViewAñadirOC" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
                                    CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" PageSize="3"
                                     DataKeyNames="OC_idOrdenCompra, I_NombreInsumo, OCxI_Cantidad,OCxI_PrecioTotal" OnPageIndexChanging="GridViewAñadirOC_PageIndexChanging">                                  
                                    <Columns>
                                        <asp:BoundField DataField="OC_idOrdenCompra" HeaderText="ID Orden de compra" />
                                        <asp:BoundField DataField="I_NombreInsumo" HeaderText="Nombre del Insumo" />                                                                        <asp:BoundField DataField="OCxI_Cantidad" HeaderText="Cantidad" />                                                                         <asp:BoundField DataField="OCxI_PrecioTotal" HeaderText="Precio Total" />

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <hr />                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
