<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarMovimientos.aspx.cs" Inherits="MesonURPWEB.ConsultarMovimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Consultar Movimientos</h2>
                            <div class="stock-options">
                                    <div class="width-auto margin-5">
                                        <button type="button" class="btn btn-primary btn-flex">     
                                            <span class="material-icons marginR-15">cloud_download</span>
                                            <label>Descargar en Excel</label>
                                        </button>
                                    </div>                                
                            </div>
                        </div>
                        <div class="search-buttons">
                            <div class="search">                                
                                    <asp:TextBox  id="txtBuscarMovimientos" runat="server"  CssClass="form-control1"  onkeypress="return lettersOnly(event);"  placeholder="Buscar Movimientos ..."/>
                                    <button type="button" id="btnSearchMovimientos" runat="server">
                                        <span class="material-icons">search
                                        </span>
                                    </button>
                                   
                            </div>
                                   
                               <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Ingresos y Egresos</h4>
                                    </div>
                                    
                                     <div class="div-movflex">
                                        <label>Tipo de Movimiento : </label>
                                        <asp:DropDownList runat="server" CssClass="form-control1"  AutoPostBack="true">
                                            <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                            <asp:ListItem Text="Ingresos" Value="Ingresos">Ingresos</asp:ListItem>
                                            <asp:ListItem Text="Egresos" Value="Egresos">Egresos</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                       <asp:GridView ID="gvMovimientos" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" PageSize="3">
                                            <Columns>
                                                <asp:BoundField HeaderText="Insumo" />
                                                <asp:BoundField HeaderText="Cantidad" />
                                                <asp:BoundField HeaderText="Medida" />
                                                <asp:BoundField HeaderText="Tipo de Movimiento" />
                                                <asp:BoundField HeaderText="Fecha" />
                                                <asp:BoundField HeaderText="Usuario" />       
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
