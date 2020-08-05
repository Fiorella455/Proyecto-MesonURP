<%@ Page Title="MesónURP | Consultar Movimiento" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarMovimientos.aspx.cs" Inherits="MesonURPWEB.ConsultarMovimientos" %>
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
                                        <button type="button" class="btn btn-primary btn-flex" runat="server" onserverclick="btnDescargarExcel_ServerClick">     
                                            <span class="material-icons marginR-15">cloud_download</span>
                                            <h>Descargar en Excel</h>
                                        </button>
                                    </div>                                
                            </div>
                        </div>
                        <div class="search-buttons">
                            <div class="search">              
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                             <asp:TextBox  id="txtBuscarMovimientos" runat="server" AutoPostBack="True" CssClass="form-control1" OnTextChanged="fNombreMovimiento_TextChanged" onkeypress="return soloLetras(event);"  placeholder="Buscar Movimientos ..."/></asp:TextBox>  
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                             </div>
                                   
                               <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Ingresos y Egresos</h4>
                                    </div>
                                    
                                     <div class="div-movflex modal-header">
                                        <label>Tipo de Movimiento : </label>
                                        <asp:DropDownList id="ddlMovimientos" runat="server" CssClass="form-control1"  AutoPostBack="true"  type="button" data-toggle="dropdown"  OnSelectedIndexChanged="Selection_Change" aria-haspopup="true">
                                            <asp:ListItem  Value="">Todo</asp:ListItem>
                                            <asp:ListItem Text="Ingreso" Value=1>Ingreso</asp:ListItem>
                                            <asp:ListItem Text="Egreso" Value=2>Egreso</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                       <asp:GridView ID="gvMovimientos" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="fechamov,M_TipoMovimiento,I_NombreInsumo,nomcategoria,MxI_Cantidad,M_NombreMedida,usuariomov">
                                            <Columns>
                                                <asp:BoundField DataField="fechamov" HeaderText="Fecha" />
                                                <asp:BoundField DataField="M_TipoMovimiento" HeaderText="Tipo" />
                                                <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                                <asp:BoundField DataField="nomcategoria" HeaderText="Categoria" />
                                                <asp:BoundField DataField="MxI_Cantidad" HeaderText="Cantidad" />
                                                <asp:BoundField DataField="M_NombreMedida" HeaderText="Medida" />
                                                <asp:BoundField DataField="usuariomov" HeaderText="Usuario" />       
                                            </Columns>
                                        </asp:GridView>
                                          </ContentTemplate>
                                     </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                     </div>
                  </div>
         <script>
             function soloLetras(e) {
                 key = e.keyCode || e.which;
                 tecla = String.fromCharCode(key).toLowerCase();
                 letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
                 especiales = [8, 37, 39, 46];

                 tecla_especial = false
                 for (var i in especiales) {
                     if (key == especiales[i]) {
                         tecla_especial = true;
                         break;
                     }
                 }

                 if (letras.indexOf(tecla) == -1 && !tecla_especial)
                     return false;
             }
             function alertaError() {
                 Swal.fire({
                     title: 'Oh, no!',
                     text: 'Por favor, ingrese solo letras',
                     icon: 'error',
                     confirmButtonText: 'Aceptar'
                 })
             }
             function alertad() {
                 Swal.fire({
                     title: 'Oh, no!',
                     text: 'Por favor, ingrese solo letras',
                     icon: 'error',
                     confirmButtonText: 'Aceptar'
                 })
             }
         </script>
      
</asp:Content>
