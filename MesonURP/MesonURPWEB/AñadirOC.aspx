<%@ Page Title="Gestionar OC | Agregar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AñadirOC.aspx.cs" Inherits="MesonURPWEB.AñadirOC" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Agregar Nueva Orden de Compra</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="input-info">
                        <h3>Detalles de Compra</h3>
                    </div>   
                    
                    <div class="form-group">
                         <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                        <label for="focusedinput" class="col-sm-2 control-label">N° Orden Compra</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumeroComprobante" runat="server" placeholder="Ingrese el número de comprobante" CssClass="form-control1" ReadOnly="true"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumeroComprobante" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            <%--                            <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="" ForeColor="#CC0000" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                        </div>
                                    </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                               <label for="selector1" class="col-sm-2 control-label">Tipo de Comprobante</label>
                               <div class="col-sm-8">
                               <asp:DropDownList runat="server" CssClass="form-control1" ID="DListTipoC"  AutoPostBack="true">
                                <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                <asp:ListItem Text="Factura" Value="1">Factura</asp:ListItem>
                                <asp:ListItem Text="Boleta" Value="2">Boleta</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblTCom" runat="server"></asp:Label>
                        </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%-- <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                            <ContentTemplate>
                               <label for="selector1" class="col-sm-2 control-label">N° Orden</label>
                               <div class="col-sm-8">
                               <asp:DropDownList runat="server" CssClass="form-control1" ID="DropDownList1"  AutoPostBack="true">
                                <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                <asp:ListItem Text="Factura" Value="1">Factura</asp:ListItem>
                                <asp:ListItem Text="Boleta" Value="2">Boleta</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="DdlProveedor" runat="server" CssClass="form-control1" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationProveedorOC" runat="server" ControlToValidate="DdlProveedor" ErrorMessage="Campo Obligatorio"  CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                            <br />
                            <asp:Label ID="lblProv" runat="server"></asp:Label>

                        </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                               <label for="selector1" class="col-sm-2 control-label">Forma de pago</label>
                               <div class="col-sm-8">
                               <asp:DropDownList runat="server" CssClass="form-control1" ID="DListFormaP"  AutoPostBack="true">
                                <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                <asp:ListItem Text="Efectivo" Value="Efectivo">Efectivo</asp:ListItem>
                                <asp:ListItem Text="Crédito" Value="Crédito">Crédito</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DListFormaP" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                   <br />
                                   <asp:Label ID="lblFormaP" runat="server"></asp:Label>
                        </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                      <div class="input-info">
						<h3>Detalles de Insumo</h3>
					</div>
                   
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlInsumo"  AutoPostBack="true" OnSelectedIndexChanged="DdlInsumo_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DdlInsumo" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                         <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                              <ContentTemplate>
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" placeholder="Ingrese una cantidad" CssClass="form-control1" ID="txtCantidad" onkeypress="return SoloNumeroIntDouble(event);" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>                      
                            <asp:Label ID="lblMje" runat="server"></asp:Label>
                        </div>
                                   </ContentTemplate>
                             </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                        <label for="focusedinput" class="col-sm-2 control-label">Precio Unitario</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" CssClass="form-control1" ID="txtPrecioU" ReadOnly="true" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPrecioU" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                        <label for="selector1" class="col-sm-2 control-label">Unidades de Medida</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtMedida" runat="server" CssClass="form-control1"  onkeypress="return lettersOnly(event);" ReadOnly="true" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMedida" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                     <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirInsumo" OnClick="btnAñadirInsumo_Click" AutoPostBack="true" />
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Quitar" OnClick="Unnamed1_Click" />
                        </p>
                                 <asp:Label ID="lblMsjBorrar" runat="server"></asp:Label>
                    </ContentTemplate>
                        </asp:UpdatePanel>
                   </div>

                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Insumos</h4>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="GridViewAñadirOC" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"  OnRowDataBound="GridViewAñadirOC_OnRowDataBound"
                                   DataKeyNames="I_NombreInsumo,OCxI_Cantidad,I_PrecioUnitario,OCxI_PrecioTotal" CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnSelectedIndexChanged="GridViewAñadirOC_SelectedIndexChanged">
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Orden de Compra" DataField="OC_idOrdenCompra" />--%>
                                        <asp:BoundField HeaderText="Insumo" DataField="I_NombreInsumo"  />
                                        <asp:BoundField HeaderText="Cantidad" Datafield="OCxI_Cantidad"/>
                                        <asp:BoundField HeaderText="Precio unitario" DataField="I_PrecioUnitario" />
                                        <asp:BoundField HeaderText="Precio Total" Datafield="OCxI_PrecioTotal"/>
                                        
                                    </Columns>   
                                    
                                    <SelectedRowStyle BackColor="LightGreen"/>
          
                                </asp:GridView>
                            </div>
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                             <div class="form-group">
                                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                        <label for="selector1" class="col-sm-2 control-label">Total</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTotal" runat="server" align="left" CssClass="special" Width="102px" ReadOnly="true" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                           
                        </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                        </div>
                        <hr />
                        <p class="center-button">
                            <asp:Button ID="btnAñadirOC" CssClass="btn btn-primary" runat="server" OnClick="btnAñadirOC_Click" Text="Agregar" ValidationGroup="añadirOC" />
                            <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarOC';" class="btn btn-primary" />
                            <%--<asp:BoundField HeaderText="Orden de Compra" DataField="OC_idOrdenCompra" />--%>
                            <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                            &nbsp;</p>
                    </div>
                </div>
            </div>
        </div>

    <script>
        function BlockChars(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; } //BlockAltCtrl
            var regEx = /[\~`!#$%^&§¥£│øƒ×®️¿¬¡©️¢┐└┴┬├─┼ãÃ╚╔╩╦╠═╬¤ðÐÊËÈıÍÎÏ┘┌█▬¦▬▀­­­±­¶@_*\+\=\\[\]\\\´'\{}|\":<>?()]/;
            return !regEx.test(String.fromCharCode(tecla));
        }
        function SoloNumeroInt(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }
        function SoloNumeroIntDouble(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9\.]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }
        function lettersOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado ingresar correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "GestionarOC";
                }
            })
        }
    </script>
    <script type="text/javascript">

        function SetColor(GridView) {

            if (GridView != null) {                
              GridView.style.backgroundColor = "#47FF33";
            }

        }
</script>
  
    <script  type="text/javascript">

        var gridViewCtlId = '<%=GridViewAñadirOC.ClientID%>';

        var gridViewCtl = null;

        var curSelRow = null;

        var curRowIdx = -1;

        function getGridViewControl() {

            if (null == gridViewCtl) {

                gridViewCtl = document.getElementById(gridViewCtlId);

            }

        }

        function onGridViewRowSelected(rowIdx) {

            var selRow = getSelectedRow(rowIdx);

            if (null != selRow) {

                selRow.style.backgroundColor = "#47FF33";
              
            }

        }

        function getSelectedRow(rowIdx) {

            return getGridRow(rowIdx);

        }

        function getGridRow(rowIdx) {

            getGridViewControl();

            if (null != gridViewCtl) {

                return gridViewCtl.rows[rowIdx];

            }
            return null;
        }   
   
</script>
</asp:Content>
