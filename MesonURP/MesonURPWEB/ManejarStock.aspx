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
                        <input type="button" class="btn btn-primary" value="Registar Egreso" onclick="window.location.href = 'RegistrarEgreso';">
                    </div>
                    <div class="width-auto">
                        <input type="button" class="btn btn-primary" value="Devolver Egreso" onclick="window.location.href = 'RegistrarIngreso';">
                    </div>
                </div>
            </div>

            <div class="search-buttons">
                <div class="search">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtBuscarInsumo" runat="server" AutoPostBack="True" CssClass="form-control1" OnTextChanged="fNombreMovimiento_TextChanged" onkeypress="return soloLetras(event);" placeholder="Buscar Insumo ..." />
                            </asp:TextBox> 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Stock Actual</h4>
                        </div>
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                            <asp:UpdatePanel ID="PanelBuscar" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvInsumos" AutoGenerateColumns="False" runat="server" EmptyDataText="No hay información disponible."
                                        CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_NombreInsumo,C_NombreCategoria,I_StockMinimo,I_StockMaximo,I_CantidadTotal,M_NombreMedida"
                                        Style="text-align: center">
                                        <Columns>
                                            <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                            <asp:BoundField DataField="C_NombreCategoria" HeaderText="Categoria" />
                                            <asp:BoundField DataField="I_StockMinimo" HeaderText="Stock Mínimo" />
                                            <asp:BoundField DataField="I_StockMaximo" HeaderText="Stock Máximo" />
                                            <asp:BoundField DataField="I_CantidadTotal" HeaderText="Stock Actual" />
                                            <asp:BoundField DataField="M_NombreMedida" HeaderText="Unidad de Medida" />
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
                text: 'Ingrese un insumo para la busqueda',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
    </script>
</asp:Content>
