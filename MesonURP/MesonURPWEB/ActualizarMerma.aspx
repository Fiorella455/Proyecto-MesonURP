<%@ Page Title="Gestionar Merma | Actualizar Merma" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarMerma.aspx.cs" Inherits="MesonURPWEB.ActualizarMerma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Merma</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <%--<div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlInsumos" runat="server" CssClass="form-control1" AutoPostBack="true">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationInsumos" runat="server" ControlToValidate="ddlInsumos" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8" style="text-align: center;">
                            <asp:TextBox ID="txtInsumo" runat="server" CssClass="form-control1" disabled="false" />
                        </div>
                    </div>

                    <%--<div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad de Egresos</label>
                        <div class="col-sm-8" style="text-align:center;">
                            <asp:TextBox ID="txtEgresos" runat="server" CssClass="form-control1" disabled="false" />                            
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha</label>
                        <div class="col-sm-8" style="text-align: center;">
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control1" disabled="false" />
                        </div>
                    </div>
                    <div class="form-group" style="display: flex; width: 1188px; margin-left: 29px">
                        <label for="focusedinput" class="col-sm-2 control-label">Peso Total</label>
                        <div class="col-sm-8" style="text-align: center;">
                            <asp:TextBox ID="txtCantidadTotal" runat="server" CssClass="form-control1" disabled="false" />
                        </div>
                        <div>
                            <div class="col-sm-8" style="text-align: center;">
                                <asp:TextBox ID="txtmedida" runat="server" CssClass="form-control1" Style="width: 150px;" disabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group" style="width: 1205px; margin-left: 26px">
                        <asp:UpdatePanel ID="panelPesoRem" runat="server">
                            <ContentTemplate>
                                <label for="focusedinput" class="col-sm-2 control-label">Peso Merma</label>
                                <div class="col-sm-8" style="text-align: center; padding-right: 27px">
                                    <asp:TextBox ID="txtPesoMerma" runat="server" CssClass="form-control1" placeholder="Peso de Merma" OnTextChanged="txtPesoMerma_TextChange1" onkeypress="return SoloNumeroIntDouble(event);" />
                                    <asp:CompareValidator ID="Pesovalidacion" runat="server" ControlToValidate="txtPesoMerma" ControlToCompare="txtCantidadTotal" Operator="LessThanEqual" ValidationGroup="ActualizarMerma" ErrorMessage="El Peso de Merma debe ser menor al Peso Total" Display="Dynamic" ForeColor="Red" Font-Italic="true" />
                                    <asp:RequiredFieldValidator ID="validationPeso" runat="server" ControlToValidate="txtPesoMerma" ErrorMessage="Campo Obligatorio" ValidationGroup="ActualizarMerma" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div>
                                    <div>
                                        <asp:TextBox ID="txtmedida1" runat="server" CssClass="form-control1" Style="width: 150px;" disabled="false" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group" style="width: 1205px; margin-left: 26px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <label for="focusedinput" class="col-sm-2 control-label">Peso Rendimiento</label>
                                <div class="col-sm-8" style="text-align: center; padding-right: 27px">
                                    <asp:TextBox disabled="false" ID="txtPesoRendimiento" runat="server" CssClass="form-control1" />
                                </div>
                                <div>
                                    <div>
                                        <asp:TextBox ID="txtmedida2" runat="server" CssClass="form-control1" Style="width: 150px;" disabled="false" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%--<div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Observación</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlObservacion" runat="server" CssClass="form-control1" AutoPostBack="true" OnSelectedIndexChanged="SelectionObservacion_Change">
                                <asp:ListItem Text="" Value="">----Seleccionar----</asp:ListItem>
                                <asp:ListItem Text="" Value="1">Si</asp:ListItem>
                                <asp:ListItem Text="" Value="2">No</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlObservacion" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">
                            Observación<br />
                            <i style="color: red; font-weight: bold">(Opcional)</i></label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Height="100px" CssClass="form-control1" Visible="true" />

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtocultoId" runat="server" CssClass="form-control1" Visible="false" />

                        </div>
                    </div>

                    <hr />
                    <asp:UpdatePanel ID="panelActM" runat="server">
                        <ContentTemplate>
                            <p class="center-button">
                                <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnActualizar" onserverclick="btnActualizar_ServerClick">Actualizar</button>
                                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarMerma';" onserverclick="btnRegresar_ServerClick" class="btn btn-primary" />

                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </div>
    </div>
    <script>
        function SoloNumeroIntDouble(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9\,]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }

    </script>
    <!-- Alertas -->
    <script src="js/sweetalert.js"></script>
    <script>
        function alertaError() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No se ha logrado actualizar correctamente',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }

        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado actualizar correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "GestionarMerma";
                }
            })
        }
    </script>
</asp:Content>
