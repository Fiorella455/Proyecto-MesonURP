<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarInsumo.aspx.cs" EnableEventValidation="false" Inherits="MesonURPWEB.ActualizarInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Insumo</h2>
            </div>
        </div>
     <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <asp:TextBox ID="txt1" runat="server" Visible="False"></asp:TextBox>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtnombreInsumo" runat="server" CssClass="form-control1" ReadOnly="true"/>
                            <asp:RequiredFieldValidator ID="rfvnombreI" runat="server" ControlToValidate="txtnombreInsumo" ErrorMessage="Campo Obligatorio" ValidationGroup="actualizarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
						<label for="focusedinput" class="col-sm-2 control-label">Stock Mínimo</label>
						<div class="col-sm-8">
                            <asp:TextBox ID="txtstockMin" runat="server" CssClass="form-control1"/>
                            <asp:RegularExpressionValidator ID="revStockMin" runat="server" ErrorMessage="Por favor ingrese número enteros o decimales positivos, por ejemplo: '1,325'" ControlToValidate="txtstockMin" ForeColor="#CC0000" ValidationExpression="[0-9]{1,3}(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvstockMin" runat="server" ControlToValidate="txtstockMin" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
						</div>
					</div>
                    <div class="form-group">
						<label for="focusedinput" class="col-sm-2 control-label">Stock Máximo</label>
						<div class="col-sm-8">
                            <asp:TextBox ID="txtstockMax" runat="server" CssClass="form-control1"/>
                            <asp:RegularExpressionValidator ID="revStockMax" runat="server" ErrorMessage="Por favor ingrese número enteros o decimales positivos, por ejemplo: '1,325'" ControlToValidate="txtstockMax" ForeColor="#CC0000" ValidationExpression="[0-9]{1,3}(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
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
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
					            <label for="focusedinput" class="col-sm-2 control-label">Unidad de Medida</label>
					            <div class="col-sm-8">                                              
							            <asp:DropDownList id="ddlMedida" runat="server" CssClass="form-control1" AutoPostBack="true">
								            <asp:ListItem Text="" Value="">Seleccione una medida</asp:ListItem>
  							            </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvmedida" runat="server" ControlToValidate="ddlMedida" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
					            </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
						<label for="focusedinput" class="col-sm-2 control-label">Precio Unitario (S/.)</label>
						<div class="col-sm-8">
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control1"/>
                            <asp:RegularExpressionValidator ID="revPrecio" runat="server" ErrorMessage="Por favor ingrese número enteros o decimales positivos, por ejemplo: '1,325'" ControlToValidate="txtPrecio" ForeColor="#CC0000" ValidationExpression="[0-9]+(,[0-9]{1,3})?" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvprecioU" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
						</div>
					</div>
                    <div class="form-group">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                               <div class="col-sm-8"> 
                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    <label for="chec">Fecha de Vencimiento </label>
                               </div>
                                <div class="col-md-7 col-md-push-2">  
                                    <asp:TextBox ID="txtfechaV" runat="server" TextMode="Date" CssClass="form-control1" Visible="False"></asp:TextBox>
                                    <asp:RangeValidator ID ="rvDateValidator" runat ="server" ControlToValidate="txtfechaV" ErrorMessage="Por favor ingrese una fecha válida" Type="Date" Display="Dynamic" ForeColor="#CC0000"></asp:RangeValidator>
                               
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="CheckBox1" EventName="CheckedChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                     </div>
                     <div class="form-group">
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
						        <label for="focusedinput" class="col-sm-2 control-label">Categoría</label>
						        <div class="col-sm-8">                                              
								    <asp:DropDownList id="ddlCategorias" runat="server" CssClass="form-control1" AutoPostBack="true">
									    <asp:ListItem Text="" Value="">Seleccione una categoría</asp:ListItem>
  								    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvcategoria" runat="server" ControlToValidate="ddlCategorias" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
						        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
					  </div>
                    <div class="form-group">
						<%--<label for="focusedinput" class="col-sm-2 control-label">Estado</label>--%>
						<div class="col-sm-8">                                            
								<asp:DropDownList id="ddlEstado" runat="server" CssClass="form-control1" AutoPostBack="true">
									<asp:ListItem Text="agotado" Value="2">Agotado</asp:ListItem>
  								</asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvestado" runat="server" ControlToValidate="ddlEstado" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarInsumo" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
						</div>
					</div>
                    <hr />
                    <p class="center-button">
                        <asp:Button ID="btnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar Insumo" OnClick="btnActualizar_Click" />
                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarInsumo';" class="btn btn-primary" />
                        <%--<asp:Button ID="btnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />--%>
                        <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                    </p>
                </div>
              </div>
            </div>
        </div>
    <script src="js/sweetalert.js"></script>
    <script>
        function alert1() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Debe digitar un número mayor al Stock Mínimo',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alert2() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Debe digitar un intervalo adecuado de Stock Máximo para la Cantidad Total',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alert3() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Debe digitar un intervalo adecuado de Stock Mínimo para la Cantidad Total',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertActualizacion() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'El insumo fue actualizado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
    </script>
</asp:Content>