<%@ Page Title="Gestionar Insumo | Gestionar " Language="C#" AutoEventWireup="true" CodeBehind="GestionarInsumo.aspx.cs" Inherits="MesonURPWEB.GestionarInsumo" EnableEventValidation="false" %>

<!DOCTYPE html>

<html>
<head>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
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
    <script src="../js/jquery-1.10.2.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body>


    <form id="form1" runat="server">






        <div class="page-container">
            <!--/content-inner-->
            <div class="left-content">
                <div class="inner-content">
                    <!-- header-starts -->
                    <div class="header-section">
                        <!-- top_bg -->
                        <div class="top_bg">
                            <div class="header_top padding0-header center-header">
                                <div class="logo">
                                    <a href="Dashboard">
                                        <img src="../img/MesonURP_logofinal2.png" class="img-responsive2" alt="" />
                                    </a>
                                </div>

                                <div class="top_left">
                                    <h2>
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="True" ForeColor="white"></asp:Label>
                                        </strong>
                                        <p></p>
                                        <asp:Label ID="Label2" runat="server" Text="Label" Visible="True" ForeColor="white"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="Label" Visible="True" ForeColor="white"></asp:Label>
                                    </h2>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <!-- /top_bg -->
                    </div>
                    <div class="header_bg">
                        <div class="header">
                            <div class="head-t">
                                <!-- start header_right -->
                                <div class="header_right">
                                    <div class="rgt-bottom">
                                        <div class="log">
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="sidebar-menu">
                    <header class="logo1">
                        <a href="#" class="sidebar-icon"><span class="fa fa-bars"></span></a>

                    </header>
                    <div style="border-top: 1px ridge rgba(255, 255, 255, 0.15)"></div>
                    <div class="menu">
                        <ul id="menu">
                            <li><a href="Dashboard"><i class="fa fa-tachometer"></i><span>Inicio</span></a></li>
                            <li id="Li1" runat="server"><a href="#"><i class="fa fa-table"></i><span>Orden de Compra</span><span class="fa fa-angle-right" style="float: right"></span></a>
                                <ul id="submenuOrdenCompra">
                                    <li id="Li2" runat="server"><a href="GestionarOC">Gestionar Orden de Compra</a></li>
                                    <li id="Li4" runat="server"><a href="ConsultarOC">Consultar Orden de Compra</a></li>
                                </ul>
                            </li>
                            <li id="Li5" runat="server"><a href="gestionarProveedor"><i class="fa fa-file-text-o"></i><span>Gestionar Proveedor</span></a></li>
                            <li id="Li6" runat="server"><a href="gestionarDevoluciones"><i class="lnr lnr-pencil"></i><span>Gestionar Devolución</span></a></li>
                            <li id="Li7" runat="server"><a href="#"><i class="fa fa-table"></i><span>Stock</span> <span class="fa fa-angle-right" style="float: right"></span></a>
                                <ul id="submenuStock">
                                    <li id="lblmenuManejoStock"><a href="ManejarStock">Manejar Stock</a></li>
                                    <li id="lblmenuMovimientosStock"><a href="consultarMovimientos">Consultar Movimientos</a></li>
                                </ul>
                            </li>
                            <li id="Li8" runat="server"><a href="AdministrarRecursos"><i class="fa fa-file-text-o"></i><span>Administrar Recursos</span></a></li>
                            <li id="Li9" runat="server"><a href="#"><i class="fa fa-table"></i><span>Reportes</span> <span class="fa fa-angle-right" style="float: right"></span></a>
                                <ul id="menu-academico-sub">
                                    <li id="lblReporteCompras"><a href="reporteMovimientos">Generar Reporte de Compras</a></li>
                                    <li id="lblReportesMovimientos"><a href="reporteCompras">Generar Reporte de Movimientos</a></li>
                                </ul>
                            </li>
                            <li id="Li10" runat="server"><a href="gestionarCategoria"><i class="lnr lnr-chart-bars"></i><span>Gestionar Categoría</span></a></li>
                            <li id="Li11" runat="server"><a href="gestionarUsuarios"><i class="lnr lnr-chart-bars"></i><span>Gestionar Usuarios</span></a></li>


                            <li id="Li12" runat="server"><a href="#"><i class="fa fa-table"></i><span>Gestionar Insumo</span><span class="fa fa-angle-right" style="float: right"></span></a>
                                <ul id="submenuGestionarInsumo">
                                    <li id="Li13" runat="server"><a href="GestionarInsumo.aspx">Registrar Insumo</a></li>
                                    <li id="Li14" runat="server"><a href="ConsultarOC">Consultar Orden de Compra</a></li>
                                </ul>
                            </li>

                        </ul>





                        <%-- <div class="cerrar-sesion">
                   
                  <button class="btn btn-link" runat="server" onClick="btnSalida_Click">
                       <img src="img/baseline_exit_to_app_white_18dp.png" />
                  </button>
            </div>--%>
                        <%--<div class="cerrar-sesion">
                    <asp:LinkButton ID="Button1" class="btn btn-link" runat="server" onClick="btnSalida_Click">
                 <img src="img/baseline_exit_to_app_white_18dp.png" /></asp:LinkButton>
             </div>--%>
                    </div>
                </div>
                <div class="clearfix"></div>
                <!--js -->
                <script> 
                    $(document).ready(function () {
                        addEventListener("load", function () { setTimeout(hideURLbar, 0); }, false);
                        function hideURLbar() { window.scrollTo(0, 1); }
                    });
                </script>
                <script src="../js/jquery.nicescroll.js"></script>
                <script src="../js/scripts.js"></script>
                <!-- Bootstrap Core JavaScript -->
                <script src="../js/bootstrap.min.js"></script>
                <!-- /Bootstrap Core JavaScript -->
                <!-- real-time -->
                <script src="../js/jquery.fn.gantt.js"></script>
                <script src="../js/menu_jquery.js"></script>












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

                        <div class="left-content">
                            <label class="control-label">Paginacion:</label>
                            <asp:DropDownList ID="ddlp" class="browser-default" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="w3-row-padding">
                        <div class="w3-panel w3-border">
                            <div class="left-content">
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
                                            <asp:TemplateField HeaderText="Editar">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSelectItem" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        CommandName="selectItem" Text="Editar" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Detalle">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSelectItem1" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        CommandName="selectItem1" Text="Ver" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eliminar">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSelectItem2" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-solicitar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        CommandName="selectItem2" Text="Eliminar" />
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


                                        <label for="lblnombreInsumo" class="control-label">Nombre:</label>
                                        <asp:TextBox id="txtnombreInsumo" runat="server" class="form-control1" type="text" placeholder="Nombre del insumo"></asp:TextBox>
                                        
                                        <label for="lblstockMaximo" class="control-label">Stock Máximo:</label>
                                        <asp:TextBox id="txtstockMaximo" runat="server" class="form-control1" type="text" placeholder="Stock Máximo"></asp:TextBox>

                                        <label for="lblstockMinimo" class="control-label">Stock Mínimo:</label>
                                        <asp:TextBox id="txtstockMinimo" runat="server" class="form-control1" type="text" placeholder="Stock Mínimo"></asp:TextBox>

                                        <label for="lblprecioUnitario" class="control-label">Precio Unitario:</label>
                                        <asp:TextBox id="txtprecioUnitario" runat="server" class="form-control1" type="text" placeholder="Precio Unitario"></asp:TextBox>

                                        <label for="lblcantidadTotal" class="control-label">Cantidad Total:</label>
                                        <asp:TextBox id="txtcantidadTotal" runat="server" class="form-control1" type="text" placeholder="Cantidad Total"></asp:TextBox>

                                        <label for="lblfechaVencimiento" class="control-label">Fecha de Vencimiento:</label>
                                        <asp:TextBox id="txtfechaVencimiento" runat="server" class="form-control1" type="text" placeholder="Fecha de Vencimiento"></asp:TextBox>

                                        <label for="lblestadoInsumo" class="control-label">Estado del Insumo:</label>
                                        <asp:TextBox id="txtestadoInsumo" runat="server" class="form-control1" type="text" placeholder="Estado del Insumo"></asp:TextBox>

                                        <label for="lblnestadoInsumo" class="control-label">Nombre del Estado:</label>
                                        <asp:TextBox id="txtnestadoInsumo" runat="server" class="form-control1" type="text" placeholder="Estado del Insumo"></asp:TextBox>

                                        <label for="lblunidadMedida" class="control-label">Unidad de Medida:</label>
                                        <asp:TextBox id="txtunidadMedida" runat="server" class="form-control1" type="text" placeholder="Unidad de Medida"></asp:TextBox>

                                        <label for="lblcategoriaInsumo" class="control-label">Categoría del Insumo:</label>
                                        <asp:TextBox id="txtcategoriaInsumo" runat="server" class="form-control1" type="text" placeholder="Categoría del Insumo"></asp:TextBox>

                                    </div>
                                    <div class="modal-footer">
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">OK</button>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>


                <div class="footer">
                    <div class="clearfix"></div>
                    <p>© 2020 MesónURP  | <a href="http://www.urp.edu.pe//">Universidad Ricardo Palma</a></p>
                </div>


            </div>
        </div>
    </form>
</body>

</html>

