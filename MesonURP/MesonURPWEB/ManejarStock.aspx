<%@ Page Title="Mesón URP | Manejar Stock" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ManejarStock.aspx.cs" Inherits="MesonURPWEB.ManejarStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Manejar Stock</h2>
                            <div class="stock-options">
                                <div class="width-auto margin-5">
                                    <input type="button" class="btn btn-primary" value="Registar Ingreso" onclick="window.location.href = 'RegistrarIngreso';">           
                                </div>
                                
                                <div class="width-auto">
                                      <input type="button" class="btn btn-primary" value="Registar Egreso" onclick="window.location.href = 'RegistrarEgreso';">    
                                </div>
                            </div>
                        </div>
                        <div class="search-buttons">
                            <div class="search">                                
                                    <asp:TextBox  id="txtBuscarInsumo" runat="server"  CssClass="form-control1"  onkeypress="return lettersOnly(event);"  placeholder="Buscar Insumo ..."/>
                                    <button type="button" id="brnSearchStock" runat="server" onserverclick="brnSearchStock_ServerClick">
                                        <span class="material-icons">search
                                        </span>
                                    </button>
                            </div>
                               <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Stock Actual</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                       <asp:GridView ID="gvInsumos" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_NombreInsumo,C_NombreCategoria,I_StockMinimo,I_StockMaximo,I_CantidadTotal,M_NombreMedida" 
                                            OnPageIndexChanging="gvInsumos_PageIndexChanging" PageSize="3">
                                            <Columns>
                                                <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                                <asp:BoundField DataField="C_NombreCategoria" HeaderText="Categoria" />
                                                <asp:BoundField DataField="I_StockMinimo" HeaderText="Stock Mínimo" />
                                                <asp:BoundField DataField="I_StockMaximo" HeaderText="Stock Máximo" />
                                                <asp:BoundField DataField="I_CantidadTotal" HeaderText="Stock Actual" />
                                                <asp:BoundField DataField="M_NombreMedida" HeaderText="Unidad de Medida" />       
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                     </div>
                  </div>
         <script>
             function lettersOnly(evt) {
                 evt = (evt) ? evt : event;
                 var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                     ((evt.which) ? evt.which : 0));
                 if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                     (charCode < 97 || charCode > 122)) {
                     alert("Por favor, ingrese solo letras.");
                     return false;
                 }
                 return true;
             }
         </script>
</asp:Content>
