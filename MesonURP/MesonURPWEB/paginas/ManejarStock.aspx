<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManejarStock.aspx.cs" Inherits="MesonURPWEB.paginas.ManejarStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Mesón URP | Manejar Stock</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!--Google Icons-->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
    <!-- Custom CSS -->
    <link href="../css/Home.css" rel="stylesheet" />
    <link href="../css/manejarStock.css" rel="stylesheet" />
    <!-- Graph CSS -->    
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <link href='https://fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css' />
    <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css' />
    <!-- lined-icons -->
    <link href="../css/icon-font.min.css" rel="stylesheet" />
    <script src="../js/simpleCart.min.js"></script>
    <script src="../js/amcharts.js"></script>
    <script src="../js/serial.js"></script>
    <script src="../js/light.js"></script>
    <!-- //lined-icons -->
    <script src="../js/jquery-1.10.2.min.js"></script>
    <!--pie-chart--->
    <script src="../js/pie-chart.js"></script>
    </head>
    <body>
    <div class="page-container margin-cont5">
        <!--/content-inner-->
        <div class="left-content">
            <div class="inner-content">
                <!-- header-starts -->
                <div class="header-section">
                    <!-- top_bg -->
                    <div class="top_bg">
                        <div class="header_top padding0-header center-header">
                             <div class="logo">
                                <a href="index.html">
                                    <img src="../img/MesonURP_logofinal2.png" class="img-responsive2" alt="" />
                                </a>
                              </div>
                            <div class="top_left margin--10">
                                <h2><span></span>Call us : 032 2352 782</h2>
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
            <!-- //header-ends -->

            <!--content-->
            <div class="content">
                <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Manejar Stock</h2>
                            <div class="stock-options">
                                <div class="width-auto margin-5">
                                    <button class="btn-new btn-fifth" onclick="window.location.href='registrarIngreso.aspx'">Registrar Ingreso</button>                     
                                </div>
                                <div class="width-auto">
                                    <button class="btn-new btn-fifth" onclick="window.location.href='registrarEgreso.aspx'">Registrar Egreso</button>
                                </div>
                            </div>
                        </div>
                        <div class="search-buttons">
                            <div class="search">
                                <form runat="server">
                                    <asp:TextBox id="txtBuscarInsumo" runat="server"  CssClass="form-control1" placeholder="Buscar Insumo..."/>
                                    <button type="button" id="brnSearchStock" runat="server" onserverclick="brnSearchStock_ServerClick">
                                        <span class="material-icons">search</span>
                                    </button>
                                <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Stock Actual</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                        <asp:GridView ID="gvInsumos" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_NombreInsumo,C_NombreCategoria,I_CantidadTotal,M_NombreMedida" 
                                            OnPageIndexChanging="gvInsumos_PageIndexChanging" PageSize="3">
                                            <Columns>
                                                <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                                <asp:BoundField DataField="C_NombreCategoria" HeaderText="Categoria" />
                                                <asp:BoundField DataField="I_StockMinimo" HeaderText="Categorihga" />
                                                <asp:BoundField DataField="I_StockMaximo" HeaderText="Categoa" />
                                                <asp:BoundField DataField="I_CantidadTotal" HeaderText="Stock" />
                                                <asp:BoundField DataField="M_NombreMedida" HeaderText="Unidad de Medida" />       
                                            </Columns>
                                        </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                             </form>
                            </div>
                        </div>
     
                                <div class="clearfix"></div>
                            </div>

                        </div>


                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="fo-top-di">
            <div class="foot-top">

                <div class="col-md-6 s-c">
                    <li>
                        <div class="fooll">
                            <h1>Contáctanos</h1>
                        </div>
                    </li>
                    <li>
                        <div class="social-ic">
                            <ul>
                                <li><a href="#"><i class="facebok"></i></a></li>
                                <li><a href="#"><i class="twiter"></i></a></li>
                                <li><a href="#"><i class="goog"></i></a></li>
                                <li><a href="#"><i class="be"></i></a></li>
                                <div class="clearfix"></div>
                            </ul>
                        </div>
                    </li>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-6 s-c">
                    <div class="stay">
                        <div class="stay-left">
                            <form>
                                <input type="text" placeholder="Tu correo electrónico" required=""/>
                            </form>
                        </div>
                        <div class="btn-1">
                            <form>
                                <input type="submit" value="join"/>
                            </form>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="clearfix"></div>

            </div>
            <div class="footer">
                <div class="clearfix"></div>
                <p>© 2020 MesónURP  | <a target="_blank" href="http://www.urp.edu.pe//">Universidad Ricardo Palma</a></p>
            </div>
        </div>
    </div>
    <!--content-->
    <!--/sidebar-menu-->
    <div class="sidebar-menu">
        <header class="logo1">
            <a href="#" class="sidebar-icon"><span class="fa fa-bars"></span></a>
        </header>
        <div style="border-top: 1px ridge rgba(255, 255, 255, 0.15)"></div>
        <div class="menu">
            <ul id="menu">
                <li><a href="Dashboard.aspx"><i class="fa fa-tachometer"></i><span>Inicio</span></a></li>
                <li id="menu-oc"><a href="#"><i class="fa fa-table"></i><span>Orden de Compra</span> <span class="fa fa-angle-right" style="float: right"></span></a>
                    <ul id="menu-oc-sub">
                        <li id="menu-oc-gestion"><a href="gestionarOC.html">Gestionar Orden de Compra</a></li>
                        <li id="menu-oc-consulta"><a href="consultarCompras.aspx">Consultar Compras</a></li>
                    </ul>
                </li>
                <li id="menu-proveedor"><a href="gestionarProveedor.aspx"><i class="fa fa-file-text-o"></i><span>Gestionar Proveedor</span></a></li>
                <li><a href="gestionarDevoluciones.aspx"><i class="lnr lnr-pencil"></i><span>Gestionar Devolución</span></a></li>
                <li id="menu-stock"><a href="#"><i class="fa fa-table"></i><span>Stock</span> <span class="fa fa-angle-right" style="float: right"></span></a>
                    <ul id="menu-stock-sub">
                        <li id="menu-stock-manejo"><a href="ManejarStock.aspx">Manejar Stock</a></li>
                        <li id="menu-stock-movimientos"><a href="consultarMovimientos.aspx">Consultar Movimientos</a></li>
                    </ul>
                </li>
                <li id="menu-recursos"><a href="administrarRecursos.aspx"><i class="lnr lnr-book"></i><span>Administrar Recursos</span></a></li>
                <li id="menu-reportes"><a href="#"><i class="fa fa-table"></i><span>Reportes</span> <span class="fa fa-angle-right" style="float: right"></span></a>
                    <ul id="menu-academico-sub">
                        <li id="menu-reportes-compras"><a href="reporteMovimientos.aspx">Generar Reporte de Compras</a></li>
                        <li id="menu-reportes-movimientos"><a href="reporteCompras.aspx">Generar Reporte de Movimientos</a></li>
                    </ul>
                </li>
                <li><a href="gestionarCategoria.aspx"><i class="lnr lnr-chart-bars"></i><span>Gestionar Categoría</span></a></li>
                <li><a href="gestionarUsuarios.aspx"><i class="lnr lnr-chart-bars"></i><span>Gestionar Usuarios</span></a></li>
            </ul>
        </div>
    </div>
    <div class="clearfix"></div>
     <!--js -->
    <script src="../js/jquery.nicescroll.js"></script>
    <script src="../js/scripts.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="../js/bootstrap.min.js"></script>
    <!-- /Bootstrap Core JavaScript -->
    <!-- real-time -->
    <script src="../js/jquery.fn.gantt.js"></script>
    <script src="../js/menu_jquery.js"></script>
</body>
</html>
