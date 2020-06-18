﻿<%@ Page Title="Manejar Stock | Registrar Ingreso" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarIngreso.aspx.cs" Inherits="MesonURPWEB.RegistrarIngreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Registrar Ingreso</h2>                            
                        </div>                                           
                    </div>
                    <div class="forms">
						<h3 class="title1"></h3>
							<div class="form-three widget-shadow">
								<div class="form-horizontal" runat="server">
                                    <div class="form-group">
									<label for="selector1" class="col-sm-2 control-label">Insumo</label>
									<div class="col-sm-8">                                            
                                            <asp:DropDownList id="ddlInsumos" runat="server" CssClass="form-control1" type="button" data-toggle="dropdown" AutoPostBack="true" OnSelectedIndexChanged="Selection_Change" aria-haspopup="true">
										        <asp:ListItem  Text="" Value="">ss</asp:ListItem>
											</asp:DropDownList></div>
                                             <asp:RequiredFieldValidator ID="validationInsumos" runat="server" ControlToValidate="ddlInsumos" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarIngreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
									</div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Fecha</label>
										<div class="col-sm-8">
                                            <asp:TextBox disabled="True" ID="txtFecha2" runat="server" CssClass="form-control1"/>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha2" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarIngreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtCantidad2" runat="server" placeholder="Seleccione la cantidad" CssClass="form-control1" onkeypress="return SoloNumeroIntDouble(event);"/>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCantidad2" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarIngreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Unidad de Medida</label>
										<div class="col-sm-8">
                                             <asp:TextBox  disabled="True" ID="txtUnidadMedida2" runat="server" placeholder="Unidad de Medida" CssClass="form-control1"/>
											 <asp:TextBox ID="txtOculto"  runat="server" CssClass="form-control1" Visible="false" />
										</div>
									</div>
                                    <hr/>
								    <p class="center-button">
						    		    <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnIngresar" onserverclick="btnIngresar_ServerClick"  ValidationGroup="registrarIngreso">Ingresar</button>
                                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'ManejarStock';" class="btn btn-primary" />
							    	    <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger"/> 
								    </p>
								</div>                                
                        </div>
                 </div>
            </div>
	<script>
        function SoloNumeroIntDouble(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9\.]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }
    </script>
</asp:Content>
