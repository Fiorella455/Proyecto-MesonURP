<%@ Page Title="Gestionar Merma | Agregar Merma" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarMerma.aspx.cs" Inherits="MesonURPWEB.AgregarMerma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Agregar Merma</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            
                     
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlInsumos" runat="server" CssClass="form-control1" AutoPostBack="true" OnSelectedIndexChanged="Selection_Change">
                                <asp:ListItem Text="" Value="">Seleccione un insumo</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationInsumos" runat="server" ControlToValidate="ddlInsumos" ErrorMessage="Campo Obligatorio" ValidationGroup="AgregarMerma" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad de Egresos</label>
                        <div class="col-sm-8" style="text-align:center;">
                            <asp:TextBox ID="txtEgresos" runat="server" CssClass="form-control1" disabled="false" />  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEgresos" ErrorMessage="Campo Obligatorio" ValidationGroup="AgregarMerma" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha</label>
                        <div class="col-sm-8" style="text-align:center;">
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control1" disabled="false"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha"  ErrorMessage="Campo Obligatorio" ValidationGroup="AgregarMerma" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Peso Total</label>
                        <div class="col-sm-8" style="text-align:center;">
                            <asp:TextBox ID="txtCantidadTotal" runat="server" CssClass="form-control1" disabled="false" />                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidadTotal"  ErrorMessage="Campo Obligatorio" ValidationGroup="AgregarMerma" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                   
                   <div class="form-group">
                       <asp:UpdatePanel ID="panelPesoMerma" runat="server">
                       <ContentTemplate>
                        <label for="focusedinput" class="col-sm-2 control-label">Peso Merma</label>
                        <div class="col-sm-8" style="text-align:center;">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control1" placeholder="Peso de Merma" OnTextChanged="txtPesoMerma_TextChange1" onkeypress="return SoloNumeroIntDouble(event);"/>
                            <asp:CompareValidator ID="Pesovalidacion1" runat="server" controltovalidate="TextBox1" ControlToCompare="txtCantidadTotal" operator="LessThanEqual" ValidationGroup="AgregarMerma" ErrorMessage="El Peso de Merma debe ser menor al Peso Total" Display="Dynamic" ForeColor="Red" Font-Italic="true"/>
                            <asp:RequiredFieldValidator ID="validationPeso1" runat="server" ControlToValidate="TextBox1"  ErrorMessage="Campo Obligatorio" ValidationGroup="AgregarMerma" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                           </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                        
                    
                    <div class="form-group">
                        <asp:UpdatePanel ID="panelPesoRem" runat="server">
                       <ContentTemplate>
                        <label for="focusedinput" class="col-sm-2 control-label">Peso Rendimiento</label>
                        <div class="col-sm-8" style="text-align:center;">
                            <asp:TextBox ID="txtPesoRendi"  disabled="false" runat="server" CssClass="form-control1"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPesoRendi" ErrorMessage="Campo Obligatorio" ValidationGroup="AgregarMerma" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                           </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                    
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Observación<br/><i style="color:red; font-weight:bold">(Opcional)</i></label>
                        <div class="col-sm-8">
                            <asp:TextBox  ID="txtObservacion" runat="server" TextMode="MultiLine" Height="100px" CssClass="form-control1" Visible="true" />
                            
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8">
                            <asp:TextBox  ID="txtocultoId" runat="server"  CssClass="form-control1" Visible="false" />
                        </div>
                    </div>
                                       
                    <hr />   
                    <asp:UpdatePanel ID="panelActM" runat="server">
                         <ContentTemplate>
                            <p class="center-button">
                                <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnAgregar" onserverclick="btnAgregar_ServerClick" ValidationGroup="AgregarMerma">Agregar</button>
                                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarMerma';" onserverclick="btnRegresar_ServerClick"  class="btn btn-primary" />
                                <asp:Button CssClass="btn btn-primary" runat="server" Text="Limpiar" onserverclick="btnLimpiar_ServerClick" />
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
        function alertaCantidad() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La cantidad de insumos no es permitida',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaDuplicado() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No puedes añadir el mismo Insumo',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaError() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No has añadido ninguna merma',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado agregar una merma',
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
