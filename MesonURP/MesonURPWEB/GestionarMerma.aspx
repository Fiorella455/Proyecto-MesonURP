<%@ Page Title="Mesón URP | Gestionar Merma" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarMerma.aspx.cs" Inherits="MesonURPWEB.GestionarMerma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Merma</h2>
                <div class="stock-options">
                    <div class="width-auto margin-5" style="z-index: 100;">
                        <button type="button" class="btn btn-primary btn-flex" runat="server" onserverclick="btnAgregarMerma_Click">
                            <span class="material-icons marginR-15">add_circle_outline</span>
                            <h>Agregar Merma</h>
                        </button>
                    </div>
                    <div class="width-auto margin-5">
                        <button type="button" class="btn btn-primary btn-flex" runat="server" onserverclick="btnDescargarExcel_ServerClick">
                            <span class="material-icons marginR-15">cloud_download</span>
                            <h>Descargar en Excel</h>
                        </button>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="PanelMerma" runat="server">
                <ContentTemplate>
                    <div class="search-buttons">
                        <div class="search">
                            <asp:TextBox ID="txtInsumo" runat="server" CssClass="form-control1" onkeypress="return lettersOnly(event);" placeholder="Buscar Insumo ..." />
                            <button type="button" id="btnSearchMerma" runat="server" onserverclick="btnSearchMerma_ServerClick">
                                <span class="material-icons">search
                                </span>
                            </button>
                        </div>
                    </div>
                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Stock Actual</h4>
                            </div>

                            <div class="table-wrapper-scroll-y">
                                <asp:GridView ID="gvMerma" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
                                    CssClass="table table-bordered table-striped mb-0" DataKeyNames="T_idMerma,M_Fecha,I_NombreInsumo,PesoTotal,M_PesoMerma, M_PesoRendimiento,M_NombreMedida,M_Observacion"
                                    OnPageIndexChanging="gvMerma_PageIndexChanging" OnRowCommand="gvMerma_RowCommand" Style="text-align: center" CellPadding="4" GridLines="None">
                                    <Columns>

                                        <asp:BoundField DataField="T_idMerma" HeaderText="ID" />
                                        <asp:BoundField DataField="M_Fecha" HeaderText="Fecha" />
                                        <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                        <asp:BoundField DataField="PesoTotal" HeaderText="Peso Total" />
                                        <asp:BoundField DataField="M_PesoMerma" HeaderText="Peso Merma" />
                                        <asp:BoundField DataField="M_PesoRendimiento" HeaderText="Peso Rendimiento" />
                                        <asp:BoundField DataField="M_NombreMedida" HeaderText="UM" />
                                        <asp:BoundField DataField="M_Observacion" HeaderText="Observaciones" />

                                        <asp:TemplateField HeaderText="Editar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelectItem1" ImageUrl="img/editar.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar.png'" runat="server" CommandName="selectItem1" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelectItem2" ImageUrl="img/delete.png" onmouseover="this.src='img/basura-b.png'" onmouseout="this.src='img/delete.png'" runat="server" CommandName="selectItem2" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Eliminar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="clearfix"></div>

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
        function alertEliminar() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'La merma fue eliminada correctamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = 'GestionarMerma';
                }
            })
        }
    </script>
</asp:Content>
