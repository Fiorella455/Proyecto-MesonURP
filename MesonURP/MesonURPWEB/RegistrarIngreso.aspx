<%@ Page Title="Manejar Stock | Registrar Ingreso" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarIngreso.aspx.cs" Inherits="MesonURPWEB.RegistrarIngreso" %>
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
                                            <asp:DropDownList id="selectInsumo2" runat="server" CssClass="form-control1">
										        <asp:ListItem Selected="True" Value="0">Seleccione un insumo</asp:ListItem>
                                                <asp:ListItem>Pollo</asp:ListItem>
										        <asp:ListItem>Papa</asp:ListItem>
                                                <asp:ListItem>Arroz</asp:ListItem>
									        </asp:DropDownList></div>
									</div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Fecha</label>
										<div class="col-sm-8">
                                            <asp:TextBox disabled ID="txtFecha2" runat="server" TextMode="Date" CssClass="form-control1"/>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtCantidad2" runat="server" placeholder="Seleccione la cantidad" CssClass="form-control1" />
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Unidad</label>
										<div class="col-sm-8">
                                            <asp:TextBox disabled ID="txtUnidadMedida2" runat="server" placeholder="Unidad de Medida" CssClass="form-control1"/>
										</div>
									</div>
                                    <hr/>
								    <p class="center-button">
						    		    <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnIngresar">Ingresar</button>
                                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'ManejarStock.aspx';" class="btn btn-primary" />
							    	    <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger"/> 
								    </p>
								</div>                                
                        </div>
                 </div>
            </div>
</asp:Content>
