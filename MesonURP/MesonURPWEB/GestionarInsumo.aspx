<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarInsumo.aspx.cs" Inherits="MesonURPWEB.GestionarInsumo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--        <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/Home.css" rel="stylesheet" />
    <link href="css/manejarStock.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <!-- Graph CSS -->
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <link href='https://fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css' />
    <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css' />
    <!-- lined-icons -->
    <link href="../css/icon-font.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
      rel="stylesheet">
    <script src="../js/jquery-1.10.2.min.js"></script>--%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                    <asp:BoundField DataField="I_NombreInsumo" HeaderText="Nombre" />
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
                                    <asp:TemplateField HeaderText="Detalle">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelectItem1" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                CommandName="selectItem1" Text="Ver" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>




        <!-- Bootstrap Modal Dialog -->
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>



    </form>
</body>

</html>
