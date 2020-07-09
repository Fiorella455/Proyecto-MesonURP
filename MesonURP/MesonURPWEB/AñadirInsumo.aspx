﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AñadirInsumo.aspx.cs" Inherits="MesonURPWEB.AñadirInsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Agregar Nuevo Insumo</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtnombreInsumo" placeholder="Ingrese un nombre de insumo" runat="server" CssClass="form-control1" onkeypress="return soloLetras(event);"/>
                          <%--  <asp:RegularExpressionValidator ID="revNombreI" runat="server" ErrorMessage="Por favor ingrese solo letras" ControlToValidate="txtnombreInsumo" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z_áéíóúñ\s]*$" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                            <asp:RequiredFieldValidator ID="rfvnombreI" runat="server" ControlToValidate="txtnombreInsumo" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Stock Mínimo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtstockMin" placeholder="Ingrese un stock mínimo" runat="server" CssClass="form-control1"/>
                            <asp:RegularExpressionValidator ID="revStockMin" runat="server" ErrorMessage="Por favor ingrese de 1 hasta 3 dígitos números enteros o decimales positivos" ControlToValidate="txtstockMin" ForeColor="#CC0000" ValidationExpression="[0-9]{1,3}(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvstockMin" runat="server" ControlToValidate="txtstockMin" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Stock Máximo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtstockMax" placeholder="Ingrese un stock máximo" runat="server" CssClass="form-control1" />
                            <asp:RegularExpressionValidator ID="revStockMax" runat="server" ErrorMessage="Por favor ingrese de 1 hasta 3 dígitos números enteros o decimales positivos" ControlToValidate="txtstockMax" ForeColor="#CC0000" ValidationExpression="[0-9]{1,3}(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvstockMax" runat="server" ControlToValidate="txtnombreInsumo" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <label for="focusedinput" class="col-sm-2 control-label">Categoría</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList runat="server" CssClass="form-control1" ID="ddlCategorias" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvcategoria" runat="server" ControlToValidate="ddlCategorias" ErrorMessage="Campo Obligatorio"  CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                           </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Cantidad Total</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtcant" placeholder="Ingrese la cantidad total" runat="server" CssClass="form-control1" Text="0"/>
                            <asp:RequiredFieldValidator ID="rfvcantT" runat="server" ControlToValidate="txtcant" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                             <ContentTemplate>
                                <label for="selector1" class="col-sm-2 control-label">Unidad de Medida</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList runat="server" CssClass="form-control1" ID="ddlMedida" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvmedida" runat="server" ControlToValidate="ddlMedida" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                             </ContentTemplate>
                         </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Precio Unitario (S/.)</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPrecio" placeholder="Ingrese un precio unitario" runat="server" CssClass="form-control1" />
                            <asp:RegularExpressionValidator ID="revPrecio" runat="server" ErrorMessage="Por favor ingrese números enteros o decimales positivos" ControlToValidate="txtPrecio" ForeColor="#CC0000" ValidationExpression="[0-9]+(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvprecioU" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
					<%--					<asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>--%>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" Visible="False" />
                                <div class="col-sm-8">  
                            <asp:TextBox ID="txtfechaV" runat="server" TextMode="Date" CssClass="form-control1" Visible="False"></asp:TextBox>
                       </div>
                      <%-- </ContentTemplate>
                            <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
                            </Triggers>
                    </asp:UpdatePanel>  --%>
                    </div>
                    <div class="form-group">
                        <%--<label for="focusedinput" class="col-sm-2 control-label">Estado</label>--%>
						<div class="col-sm-8">                                            
							<asp:DropDownList id="ddlEstado" runat="server" CssClass="form-control1" AutoPostBack="true" Visible="false">
								<asp:ListItem Text="agotado" Value="2">Agotado</asp:ListItem>
  							</asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    
                            <p class="center-button">
                                <%--<asp:Button ID="btnRegistrarI" CssClass="btn btn-primary" runat="server" Onserverclick="btnRegistrar_Click" ValidationGroup="añadirInsumo" Text="Agregar Insumo" />--%>
                                <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="Button1" onserverclick="btnRegistrar_Click">Agregar Insumo</button>
                                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarInsumo';" class="btn btn-primary" />
                                <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                            </p>
                </div>
                </div>
            </div>
        </div>
    <script>
        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
            especiales = [8, 37, 39, 46];

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial)
                return false;
        }

    </script>
    
    
    
    <script src="js/sweetalert.js"></script>
    <script>
        function myalert() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ya existe un insumo con el nombre',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function myalert2() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Debe digitar un número mayor al Stock Mínimo',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertCorrecto() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'El insumo fue registrado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = 'GestionarInsumo.aspx';
                }
            })
        }
    </script>
</asp:Content>
