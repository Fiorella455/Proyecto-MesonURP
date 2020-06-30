<%@ Page Title="Mesón URP | Consultar Insumo" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarInsumo.aspx.cs" Inherits="MesonURPWEB.ConsultarInsumo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Actualizar Insumo</title>
</head>
<body>
    <form id="form1" runat="server">
 <div class="forms">
						<h3 class="title1"></h3>
							<div class="form-three widget-shadow">
								<div class="form-horizontal" runat="server">
									<asp:TextBox ID="txt1" runat="server" Visible="False"></asp:TextBox>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Nombre de Insumo</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtconsultarInsumo" runat="server" CssClass="form-control1"/>
                                            <asp:RequiredFieldValidator ID="rfvnombreI" runat="server" ControlToValidate="txtconsultarInsumo" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>                                    
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Unidad de Medida</label>
										<div class="col-sm-8">                                              
											  <asp:DropDownList id="ddlMedida" class="browser-default" runat="server">
													<asp:ListItem Text="--Seleccionar una medida--" Value=""></asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvmedida" runat="server" ControlToValidate="ddlMedida" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Precio Unitario</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control1"/>
                                            <asp:RequiredFieldValidator ID="rfvprecioU" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Fecha de Vencimiento</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtfechaV" runat="server" TextMode="Date" CssClass="form-control1" />
										    <asp:RequiredFieldValidator ID="rfvfechaV" runat="server" ControlToValidate="txtfechaV" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
									</div>                        
                                     <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Categoría</label>
										<div class="col-sm-8">                                              
											  <asp:DropDownList id="ddlCategorias" class="browser-default" runat="server">
													<asp:ListItem Text="--Seleccionar una categoría--" Value=""></asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvcategoria" runat="server" ControlToValidate="ddlCategorias" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                     <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Estado</label>
										<div class="col-sm-8">                                            
											  <asp:DropDownList id="ddlEstado" class="browser-default" runat="server">
													<asp:ListItem Text="--Seleccionar un Estado--" Value=""></asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvestado" runat="server" ControlToValidate="ddlEstado" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <hr/>
								    <p class="center-button">
										<asp:Button ID="btnconsultarInsumo" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" Text="Detalle" OnClick="btnconsultarInsumo_ServerClick" />
                                        <asp:Button ID="btnCancelar" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
							    	</p>
								</div>     
                 </div>
              </div>
            </div>
                       
    </form>
</body>
</html>
