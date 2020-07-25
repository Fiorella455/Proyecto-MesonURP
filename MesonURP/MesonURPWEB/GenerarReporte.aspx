<%@ Page Title="Generar Reporte" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GenerarReporte.aspx.cs" Inherits="MesonURPWEB.GenerarReporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!--start content-->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Generar Reporte Compras</h2>
                <div class="stock-options">
                    <div class="width-auto margin-5">
                        <%--        <input type="button" class="btn btn-primary" value="Consultar" onclick="btnConsultar_Click"> --%>
                        <asp:Button ID="btnConsultarC" class="btn btn-primary" runat="server" OnClick="btnConsultarC_Click" Text="Consultar Compras" />
                    </div>
                </div>
            </div>
            <div class="search-buttons">
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Órdenes de Compra del Mes</h4>
                        </div>
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                            <asp:GridView ID="GridViewConsultar" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay información disponible."
                                CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                <Columns>
                                    <asp:BoundField HeaderText="ID Compra" DataField="OC_idOrdenCompra" />
                                    <asp:BoundField HeaderText="Estado" DataField="EOC_NombreEstadoOC" />
                                    <asp:BoundField HeaderText="Tipo de Comprobante" DataField="OC_TipoComprobante" />
                                    <%-- <asp:BoundField HeaderText="Forma de Pago" DataField="OC_FormaPago"/>--%>
                                    <asp:BoundField HeaderText="Total de Compra" DataField="OC_TotalCompra" />
                                    <asp:BoundField HeaderText="Fecha de Emisión" DataField="OC_FechaEmision" />
                                    <asp:BoundField HeaderText="Proveedor" DataField="P_RazonSocial" />
                                    <asp:TemplateField HeaderText="Ver Detalles">
                                        <ItemTemplate>
                                            <%--<asp:Button ID="btnConsultar" runat="server" CommandName="ConsultarOC_R" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  Text="Consultar" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
                <div class="text-center">
                     <asp:DropDownList ID="ddlMes" CssClass="form-control1" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="true" text-align="center" Width="126px">
                     </asp:DropDownList>
            </div>
            </div>
            

        </div>
    </div>
</asp:Content>

