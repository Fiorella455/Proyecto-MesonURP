<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarInsumo.aspx.cs" EnableEventValidation="true" Inherits="MesonURPWEB.ConsultarInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Consultar Insumo</h2>
            </div>
            <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList disabled="true" runat="server" CssClass="form-control1" ID="DdlInsumo" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-sm-8">
                            <asp:DropDownList disabled="true" runat="server" CssClass="form-control1" ID="DdlCategoria" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Cantidad Total</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled="true" ID="txtCantidadT" placeholder="Ingrese la cantidad total" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Unidad de Medida</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled="true" ID="txtUnidadMedida" runat="server" CssClass="form-control1"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Estado</label>
                        <div class="col-sm-8">
                            <asp:DropDownList disabled="true" runat="server" CssClass="form-control1" ID="ddlEstado" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <p class="center-button">
                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarInsumo';" class="btn btn-primary" />
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
