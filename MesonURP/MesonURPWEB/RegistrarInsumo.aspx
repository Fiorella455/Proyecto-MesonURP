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
                            <h2 class="tittle-margin5">Registrar Insumo</h2>                            
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
                                            <asp:RegularExpressionValidator ID="revNombreI" runat="server" ErrorMessage="Por favor ingrese solo letras" ControlToValidate="txtnombreInsumo" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z ]*$" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
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
                                            <asp:TextBox ID="txtcant" runat="server" CssClass="form-control1" Text="0"/>
                                            <asp:RequiredFieldValidator ID="rfvcantT" runat="server" ControlToValidate="txtcant" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Unidad de Medida</label>
										<div class="col-sm-8">                                              
											  <asp:DropDownList id="ddlMedida" runat="server" CssClass="form-control1" AutoPostBack="true">
													<asp:ListItem Text="" Value="">Seleccione una medida</asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvmedida" runat="server" ControlToValidate="ddlMedida" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
                                    </div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Precio Unitario (S/.)</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control1"/>
                                            <asp:RegularExpressionValidator ID="revPrecio" runat="server" ErrorMessage="Por favor ingrese número enteros o decimales positivos, por ejemplo: '1,325'" ControlToValidate="txtPrecio" ForeColor="#CC0000" ValidationExpression="[0-9]+(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvprecioU" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                   <%-- <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Fecha de Vencimiento</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtfechaV" runat="server" TextMode="Date" CssClass="form-control1" />
										    <asp:RequiredFieldValidator ID="rfvfechaV" runat="server" ControlToValidate="txtfechaV" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
									</div> --%>        
									<%--<div class="form-group">--%>
										<%--<input name="chec" type="checkbox" id="chec" onChange="comprobar(this);"/>--%>
										<%--<asp:CheckBox ID="chec" AutoPostBack="true" Checked="true" OnCheckedChanged="CheckBox1_CheckedChanged" runat="server" onChange="comprobar(this);" />--%>
										<%--<asp:CheckBox ID="CheckBox1" runat="server" onclick="checkBox1OnClick(this);"/>--%>
											<%--<label for="chec">Fecha de Vencimiento </label>--%>
										<%--<div class="col-sm-8">   
											<asp:TextBox ID="txtfechaV" runat="server" TextMode="Date" CssClass="form-control1" Enabled="false"/>
											</div>--%>
									<%--</div>--%>
                                        <div class="form-group">
										<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>--%>
                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                                        <%--<ContentTemplate>--%>
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                            <label for="chec">Fecha de Vencimiento </label>
                                            <div class="col-sm-8">  
                                            <asp:TextBox ID="txtfechaV" runat="server" TextMode="Date" CssClass="form-control1" Visible="False"></asp:TextBox>
                                            </div>
                                        <%--</ContentTemplate>--%>
                                       <%-- <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
                                        </Triggers>--%>
                                     <%--</asp:UpdatePanel>--%>
                                            </div>

                                     <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Categoría</label>
										<div class="col-sm-8">                                              
											  <asp:DropDownList id="ddlCategorias" runat="server" CssClass="form-control1" AutoPostBack="true">
													<asp:ListItem Text="" Value="">Seleccione una categoría</asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvcategoria" runat="server" ControlToValidate="ddlCategorias" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Estado</label>
										<div class="col-sm-8">                                            
											  <asp:DropDownList id="ddlEstado" runat="server" CssClass="form-control1" AutoPostBack="true">
													<asp:ListItem Text="agotado" Value="2">Agotado</asp:ListItem>
  											  </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="rfvestado" runat="server" ControlToValidate="ddlEstado" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
								   
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
		<%--<script>
            function comprobar(obj) {
                if (obj.checked) {

					document.getElementById('txtfechaV').style.display = "";
					document.getElementById('txtfechaV').
                } else {

                    document.getElementById('txtfechaV').style.display = "none";
                }
            }
        </script>--%>
	<%--	<asp:CheckBox ID="CheckBox2" runat="server" onclick="checkBox1OnClick(this);" Text=" "></asp:CheckBox>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>

<%--<script type="text/javascript">
<!--
    function checkBox1OnClick(elementRef) {
        var textBoxRef = document.getElementById('<%= txtfechaV.ClientID %>');

        textBoxRef.disabled = (elementRef.checked == true) ? false : true;
    }
    function windowOnLoad() {
        var elementRef = document.getElementById('<%= CheckBox1.ClientID %>');
        checkBox1OnClick(elementRef);
    }

    window.onload = windowOnLoad;
// -->
</script>--%>
    </form>
</body>
</html>
