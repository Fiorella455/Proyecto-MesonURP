<%--<%--<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarInsumo.aspx.cs" Inherits="MesonURPWEB.ActualizarInsumo" %>

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
                                            <asp:TextBox ID="txtnombreInsumo" runat="server" CssClass="form-control1" ReadOnly="true"/>
                                            <asp:RequiredFieldValidator ID="rfvnombreI" runat="server" ControlToValidate="txtnombreInsumo" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Stock Mínimo</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtstockMin" runat="server" CssClass="form-control1"/>
                                            <asp:RegularExpressionValidator ID="revStockMin" runat="server" ErrorMessage="Por favor ingrese número enteros o decimales positivos, por ejemplo: '1,325'" ControlToValidate="txtstockMin" ForeColor="#CC0000" ValidationExpression="[0-9]+(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
											<asp:RequiredFieldValidator ID="rfvstockMin" runat="server" ControlToValidate="txtstockMin" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Stock Máximo</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtstockMax" runat="server" CssClass="form-control1"/>
                                           <asp:RegularExpressionValidator ID="revStockMax" runat="server" ErrorMessage="Por favor ingrese número enteros o decimales positivos, por ejemplo: '1,325'" ControlToValidate="txtstockMax" ForeColor="#CC0000" ValidationExpression="[0-9]+(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
											<asp:RequiredFieldValidator ID="rfvstockMax" runat="server" ControlToValidate="txtstockMax" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                      <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Cantidad Total</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtcant" runat="server" CssClass="form-control1" ReadOnly="true"/>
                                            <asp:RequiredFieldValidator ID="rfvcantT" runat="server" ControlToValidate="txtcant" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Unidad de Medida</label>
										<div class="col-sm-8">                                              
											  <asp:DropDownList id="ddlMedida" class="browser-default" runat="server" Enabled="false">
													<asp:ListItem Text="--Seleccionar una medida--" Value=""></asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvmedida" runat="server" ControlToValidate="ddlMedida" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Precio Unitario (S/.)</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control1"/>
											<asp:RegularExpressionValidator ID="revPrecio" runat="server" ErrorMessage="Por favor ingrese número enteros o decimales positivos, por ejemplo: '1,325'" ControlToValidate="txtPrecio" ForeColor="#CC0000" ValidationExpression="[0-9]+(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvprecioU" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <%--<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Fecha de Vencimiento</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtfechaV" runat="server" class="date" CssClass="form-control1" />
										    <asp:RequiredFieldValidator ID="rfvfechaV" runat="server" ControlToValidate="txtfechaV" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
									</div>  --%>         
									<%--	 <div class="form-group">
										<asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                            <label for="chec">Fecha de Vencimiento </label>
                                            <div class="col-sm-8">  
                                            <asp:TextBox ID="txtfechaV" runat="server" TextMode="Date" CssClass="form-control1" Visible="False"></asp:TextBox>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
                                        </Triggers>
                                     </asp:UpdatePanel>
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
										<asp:Button ID="btnActualizar" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" Text="Editar" OnClick="btnActualizar_Click" />
                                        <asp:Button ID="btnCancelar" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
							    	</p>
								</div>     
                 </div>
              </div>
            </div>
                       
    </form>
</body>
</html>--%>--%>--%>--%>
