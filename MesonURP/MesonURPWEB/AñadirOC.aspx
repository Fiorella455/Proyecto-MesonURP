<%@ Page Title="Gestionar OC | Agregar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AñadirOC.aspx.cs" Inherits="MesonURPWEB.AñadirOC" %>
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

                                            <div class="form-group">
										        <label for="focusedinput" class="col-sm-2 control-label">N° Orden</label>
										        <div class="col-sm-8">
                                                    <asp:TextBox ID="txtNumeroOrden" runat="server" placeholder="Ingrese el número de orden" CssClass="form-control1" />
										        </div>
									        </div>
                                            <div class="form-group">
										        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Emisión</label>
										        <div class="col-sm-8">
                                                    <asp:TextBox disabled ID="txtFechaEmision" runat="server" TextMode="Date" CssClass="form-control1"/>
										        </div>
									        </div>
                                            <div class="form-group">
										        <label for="focusedinput" class="col-sm-2 control-label">Fecha de Entrega</label>
										        <div class="col-sm-8">
                                                    <asp:TextBox ID="txtFechaEntrega" runat="server" TextMode="Date" CssClass="form-control1"/>
										        </div>
									        </div>
                                            <div class="form-group">
									            <label for="selector1" class="col-sm-2 control-label">Estado</label>
									            <div class="col-sm-8">     
                                                        <asp:DropDownList disabled  ID="selectEstadoAñadirOC" runat="server" CssClass="form-control1"></asp:DropDownList>
            						            </div>
                                            </div>
                                            <div class="form-group">
									            <label for="selector1" class="col-sm-2 control-label">Forma de Pago</label>
									            <div class="col-sm-8">                 
                                                        <asp:DropDownList ID="selectFormaPagoOC" runat="server" CssClass="form-control1" AutoPostBack="true"></asp:DropDownList>
									            </div>
                                            </div>
                                            <div class="form-group">
									            <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
									            <div class="col-sm-8">                                            
                                                        <asp:DropDownList ID="selectProveedorOC" runat="server" CssClass="form-control1"  AutoPostBack="true">										                    
									                    </asp:DropDownList></div>
									        </div>
									
                                <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Órdenes de Compra</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                        <asp:GridView ID="GridViewAñadirOC" allowpaging="True" runat="server" emptydatatext="No hay información disponible."  
                                                      CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                            <HeaderStyle BackColor="#A77F5D" Font-Bold="True" ForeColor="#000000"></HeaderStyle>
                                            <PagerStyle HorizontalAlign="Center" BackColor="#A77F5D" ForeColor="#333333"></PagerStyle>
                                            <RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered" BackColor="#FAFAFA" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#A77F5D" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>
                                            <SortedAscendingCellStyle BackColor="#214E3F"></SortedAscendingCellStyle>
                                            <SortedAscendingHeaderStyle BackColor="#A77F5D"></SortedAscendingHeaderStyle>
                                            <SortedDescendingCellStyle BackColor="#214E3F"></SortedDescendingCellStyle>
                                            <SortedDescendingHeaderStyle BackColor="#A77F5D"></SortedDescendingHeaderStyle>
                                            <Columns>
                                                   <asp:BoundField HeaderText="Cantidad" />
                                                   <asp:BoundField HeaderText="Descripción" />
                                                   <asp:BoundField  HeaderText="Unidad" />
                                                   <asp:BoundField  HeaderText="Costo Unitario" />                                                      
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>     
                                    <hr/>
								    <p class="center-button">
                                        <asp:Button ID="btnAñadirOC" CssClass="btn btn-primary" runat="server" OnClick="btnAñadirOC_Click" Text="Agregar"/>					
                                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarOC.aspx';" class="btn btn-primary" />
							    	    <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger"/> 
								    </p>
								</div>                                
                        </div>
                 </div>
            </div>
</asp:Content>
