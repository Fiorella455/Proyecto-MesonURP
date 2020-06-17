<%@ Page Title="Mesón URP | Gestionar OC" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarOC.aspx.cs" Inherits="MesonURPWEB.GestionarOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Gestionar Orden de Compra</h2>
                            <div class="stock-options">
                                <div class="width-auto margin-5">
                                     <input type="button" class="btn-new btn-fifth" value="Agregar Nueva Orden de Compra" onclick="window.location.href = 'AñadirOC';"> 
                                </div>
                            </div>
                        </div>
                        <div class="search-buttons">
                            <div class="search">
                                    <asp:TextBox id="txtSearchStock" runat="server"  CssClass="form-control1" placeholder="search..."/>
                                    <button type="button" id="btnSearchOC" runat="server">
                                        <span class="material-icons">search
                                        </span>
                                    </button>
                            </div>
                               <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Órdenes de Compra</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                         <asp:GridView ID="GridViewOC" allowpaging="True" runat="server" emptydatatext="No hay información disponible."  
                                                      CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                            
                                            <Columns>
                                                   <asp:BoundField HeaderText="ID Compra" DataField="OC_idOrdenCompra" />
                                                   <asp:BoundField HeaderText="Tipo de Comprobante" DataField="OC_TipoComprobante" />
                                                   <asp:BoundField HeaderText="Número de comprobante" DataField="OC_NumeroComprobante"/>
                                                   <asp:BoundField HeaderText="Total de Compra" DataField="OC_TotalCompra"/>
                                                   <asp:BoundField  HeaderText="Estado" />
                                                   <asp:BoundField  HeaderText="Fecha de Emisión"  DataField="OC_FechaEmision"/>  
                                                   <asp:BoundField  HeaderText="ID Proveedor" DataField="P_idProveedor" />
                                                   <asp:TemplateField  HeaderText="Enviar">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnEnviarEmailOC" class="btn btn-primary" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Enviar" OnClick="btnEnviarEmailOC_Click" />
                                                       </ItemTemplate>                                                     
                                                   </asp:TemplateField>  
                                                   <asp:TemplateField  HeaderText="Editar">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnEditarOC" class="btn btn-primary" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Actualizar" />
                                                       </ItemTemplate>              
                                                       
                                                   </asp:TemplateField> 
                                                   <asp:TemplateField  HeaderText="Ver Detalles">
                                                       <ItemTemplate>
                                                           <asp:Button ID="btnVerDetallesOC" class="btn btn-primary" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Consultar" OnClick="btnVerDetallesOC_Click" />
                                                       </ItemTemplate>                                                     
                                                   </asp:TemplateField>                                                    
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
     
                                <div class="clearfix"></div>
                            </div>

                        </div>
</asp:Content>
