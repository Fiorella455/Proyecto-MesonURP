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
                                    <input type="button" class="btn btn-primary" value="Registar Ingreso" onclick="window.location.href = 'RegistrarIngreso.aspx';">           
                                </div>
                                
                                <div class="width-auto">
                                      <input type="button" class="btn btn-primary" value="Registar Egreso" onclick="window.location.href = 'RegistrarEgreso.aspx';">    
                                </div>
                            </div>
                        </div>
                        <div class="search-buttons">
                            <div class="search">                                
                                    <asp:TextBox id="txtSearchStock" runat="server"  CssClass="form-control1"  onkeypress="return lettersOnly(event);"  placeholder="Buscar..."/>
                                    <button type="button" id="brnSearchStock" runat="server">
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
                                        <asp:GridView ID="GridViewInsumos" allowpaging="True" runat="server" emptydatatext="No hay información disponible."
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
                                                <asp:BoundField HeaderText="Insumo" />
                                                <asp:BoundField HeaderText="Categoría" />
                                                <asp:BoundField HeaderText="Stock" />
                                                <asp:BoundField HeaderText="Unidad" />                                                        
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
