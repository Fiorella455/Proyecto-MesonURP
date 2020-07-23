<%@ Page Title="Mesón URP | Dashboard" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MesonURPWEB.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Dashboard</h2>
            </div>
        </div>
      <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Insumos por Agotarse</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                       <asp:GridView ID="gvInsumosAgotados" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_NombreInsumo,I_CantidadTotal,M_NombreMedida" 
                                            OnPageIndexChanging="gvInsumosAgotados_PageIndexChanging" PageSize="3">
                                            <Columns>
                                                <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                                <asp:BoundField DataField="I_CantidadTotal" HeaderText="Stock" />
                                                <asp:BoundField DataField="M_NombreMedida" HeaderText="Unidad de Medida" />       
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
</asp:Content>
