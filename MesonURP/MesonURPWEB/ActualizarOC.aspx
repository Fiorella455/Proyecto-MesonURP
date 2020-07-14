<%@ Page Title="Gestionar OC | Actualizar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarOC.aspx.cs" Inherits="MesonURPWEB.ActualizarOC" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #616161;
            box-shadow: none !important;
            font-size: 14px;
            font-weight: 300;
            border-radius: 0;
            -webkit-appearance: none;
            resize: none;
            border: 1px solid #ccc;
            padding: 5px 8px;
            background: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Orden de Compra</h2>
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
                        <label for="focusedinput" class="col-sm-2 control-label">N° de Comprobante</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumComprobante" runat="server"  CssClass="form-control1" />
                        </div>
                    </div>
                    
                     <div class="form-group">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                    <label for="focusedinput" class="col-sm-2 control-label">Tipo de Comprobante</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtTipoComprobante" runat="server" CssClass="form-control1" />
                                    </div>
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                    <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList runat="server" CssClass="form-control1" AutoPostBack="true" ID="DdlProveedor">
                                        </asp:DropDownList>
                                    </div>
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                    <label for="selector1" class="col-sm-2 control-label">Forma de Pago</label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList runat="server" CssClass="form-control1" ID="DListFormaP"  AutoPostBack="true">
                                            <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                            <asp:ListItem Text="Efectivo" Value="Efectivo">Efectivo</asp:ListItem>
                                            <asp:ListItem Text="Crédito" Value="Crédito">Crédito</asp:ListItem>
                                        </asp:DropDownList>
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
                                        <asp:DropDownList ID="DdlInsumo" runat="server" CssClass="form-control1" AutoPostBack="true" OnSelectedIndexChanged="DdlInsumo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" CssClass="form-control1" ID="txtCantidad" onkeypress="return SoloNumeroIntDouble(event);"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                    <label for="focusedinput" class="col-sm-2 control-label">Precio Unitario</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" CssClass="form-control1" ID="txtPrecioU" ReadOnly="true" />
                                    </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                      <div class="form-group">
                          <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                    <label for="selector1" class="col-sm-2 control-label">Unidades de Medida</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox runat="server" CssClass="form-control1" ID="txtMedida" ReadOnly="true"/>
                                    </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                             <p class="center-button">
                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ValidationGroup="actOC" ID="btnAñadir" OnClick="btnAñadir_Click"/>
                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Quitar" ID="btnQuitar" OnClick="btnQuitar_Click" />
                             </p>
                             </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Detalles</h4>
                            </div>
                       <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="GridViewEditarOC" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible."  OnRowDataBound="GridViewEditarOC_OnRowDataBound" 
                                  DataKeyName=I_NombreInsumo CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" AutoGenerateColumns="false" OnSelectedIndexChanged="GridViewEditarOC_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField HeaderText="N°" DataField="I_idInsumo" />
                                        <asp:BoundField HeaderText="Descripción del Insumo" DataField="I_NombreInsumo" />
                                        <asp:BoundField HeaderText="Cantidad" DataField="OCxI_Cantidad" />
                    
                                        <asp:BoundField HeaderText="Costo Unitario" DataField="I_PrecioUnitario" />
                                        <asp:BoundField HeaderText="Total" DataField="OCxI_PrecioTotal" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="LightGreen"/>
                                </asp:GridView>
                            </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                             <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                    <label for="focusedinput" class="col-sm-2 control-label">Total</label>
                                    <div class="col-sm-1">
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="auto-style1" Width="90px" ReadOnly="true" />
                                        <asp:Label ID="lblDataT" runat="server"></asp:Label>
                                    </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                        </div>
                        <hr />
                        <p>
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Actualizar" ID="btnActualizar" OnClick="btnActualizar_Click" />
                            <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarOC';" class="btn btn-primary" id="btnRegresar" />
                            
                             <asp:Button Cssclass="btn btn-primary" runat="server" Text="Limpiar" ID="btnLimpiar" OnClick="btnLimpiar_Click" />
                        </p>
                    </div>
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
         function alertaExito() {
             Swal.fire({
                 title: 'Enhorabuena!',
                 text: 'Se ha logrado actualizar correctamente',
                 icon: 'success',
                 confirmButtonText: 'Aceptar'
             }).then((result) => {
                 if (result.value) {
                     window.location.href = "GestionarOC";
                 }
             })
         }
     </script>
</asp:Content>
