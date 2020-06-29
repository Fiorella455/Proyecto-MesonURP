<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarInsumo.aspx.cs" Inherits="MesonURPWEB.GestionarInsumo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="widget widget-table action-table">
                                <div class="widget-header">
                                    <i class="icon-th-list"></i>
                                    <h3>Insumos</h3>
                                </div>
                                <div class="stock-options">
                                <div class="width-auto margin-5">
                                     <input type="button" class="btn btn-primary" value="RegistrarInsumo" onclick="window.location.href = 'RegistrarInsumo.aspx';"> 
                                </div>
                                </div>
                           <div class="w3-row-padding">
                                <div class="w3-third">            
                                    <label class="control-label">Paginacion:</label>
                                    <asp:DropDownList ID="ddlp" class="browser-default" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                                <div class="w3-row-padding">
                                    <div class="w3-panel w3-border">
                                        <div class="w3-responsive">
                                            <div class="centered">
                                                <asp:GridView ID="gvInsumos" class="w3-col w3-container w3-table-all" runat="server" AutoGenerateColumns="False"
                                                 DataKeyNames="I_idInsumo,I_NombreInsumo,C_NombreCategoria,I_CantidadTotal, M_NombreMedida,EI_NombreEstadoInsumo" 
                                                 OnPageIndexChanging="gvInsumos_PageIndexChanging" OnRowCommand="gvInsumos_RowCommand" Style="text-align: center" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                  <Columns>
                                                            <asp:BoundField DataField="I_idInsumo" HeaderText="I_idInsumo" Visible="false" />
                                                            <asp:BoundField DataField="I_NombreInsumo" HeaderText="Nombre"/>
                                                            <asp:BoundField DataField="C_NombreCategoria" HeaderText="Categoría" />
                                                            <asp:BoundField DataField="I_CantidadTotal" HeaderText="Cantidad Total" />
                                                            <asp:BoundField DataField="M_NombreMedida" HeaderText="Unidad de Medida" />
                                                            <asp:BoundField DataField="EI_NombreEstadoInsumo" HeaderText="Estado" />
                                                            <asp:TemplateField HeaderText="Accion">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnSelectItem" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                        CommandName="selectItem" Text="Actualizar" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
    </form>
</body>
</html>
