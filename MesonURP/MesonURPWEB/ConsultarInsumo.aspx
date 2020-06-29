﻿<%@ Page Title="Gestionar Insumo | Consultar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarInsumo.aspx.cs" Inherits="MesonURPWEB.ConsultarInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Detalles del Insumo</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">N° Orden</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" placeholder="Ingrese el número de orden" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Emisión</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" TextMode="Date" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Entrega</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" TextMode="Date" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Estado</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Forma de Pago</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                       <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Fecha de Pago</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                      
                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Insumos</h4>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

