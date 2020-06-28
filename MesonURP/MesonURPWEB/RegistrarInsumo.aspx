<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarInsumo.aspx.cs" Inherits="MesonURPWEB.RegistrarInsumo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
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
										<label for="focusedinput" class="col-sm-2 control-label">Nombre de Insumo</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtnombreInsumo" runat="server" CssClass="form-control1"/>
                                            <asp:RequiredFieldValidator ID="rfvnombreI" runat="server" ControlToValidate="txtnombreInsumo" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Stock Mínimo</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtstockMin" runat="server" CssClass="form-control1"/>
                                            <asp:RequiredFieldValidator ID="rfvstockMin" runat="server" ControlToValidate="txtstockMin" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Stock Máximo</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtstockMax" runat="server" CssClass="form-control1"/>
                                            <asp:RequiredFieldValidator ID="rfvstockMax" runat="server" ControlToValidate="txtstockMax" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                      <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Cantidad Total</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtcant" runat="server" CssClass="form-control1"/>
                                            <asp:RequiredFieldValidator ID="rfvcantT" runat="server" ControlToValidate="txtcant" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
									  <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Unidad de Medida</label>
										<div class="col-sm-8">
                                            <asp:TextBox Disabled="true" ID="TextBox2" runat="server" placeholder="Unidad de Medida" CssClass="form-control1"/>
										    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUnidadMedida" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
											<asp:TextBox ID="TextBox3"  runat="server" CssClass="form-control1" Visible="false" />
										</div>
									</div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Precio Unitario</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control1"/>
                                            <asp:RequiredFieldValidator ID="rfvprecioU" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Fecha Vencimiento</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtfechaV" runat="server" placeholder="Seleccione la cantidad" CssClass="form-control1" onkeypress="return SoloNumeroIntDouble(event);" />
										    <asp:RequiredFieldValidator ID="rfvfechaV" runat="server" ControlToValidate="txtfechaV" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
									</div>
                                     <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Categoría</label>
										<div class="col-sm-8">                                            
											  <asp:DropDownList id="ddlCategorias" runat="server" CssClass="form-control1" AutoPostBack="true" OnSelectedIndexChanged="Selection_Change">
													<asp:ListItem Text="" Value="">Seleccione una categoría</asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvcategoria" runat="server" ControlToValidate="ddlCategorias" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                     <%--<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Estado</label>
										<div class="col-sm-8">                                            
											  <asp:DropDownList id="ddlEstado" runat="server" CssClass="form-control1" AutoPostBack="true" OnSelectedIndexChanged="Selection_Change">
													<asp:ListItem Text="" Value="">Seleccione un estado</asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvestado" runat="server" ControlToValidate="ddlEstado" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>--%>
                                    <hr/>
								    <p class="center-button">
						    		    <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnRegistrarI" onserverclick="btnRegistrar_Click"  ValidationGroup="registrarInsumo">Registrar</button>
                                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarInsumo';" class="btn btn-primary" />
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
        </div>
    </form>
</body>
</html>
