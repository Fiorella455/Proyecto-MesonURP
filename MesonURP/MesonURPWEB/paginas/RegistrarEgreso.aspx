<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarEgreso.aspx.cs" Inherits="MesonURPWEB.paginas.RegistrarEgreso" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Manejar Stock | Registrar Egreso</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
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
                            <h2 class="tittle-margin5">Registrar Egreso</h2>                            
                        </div>                                           
                    </div>
                    <div class="forms">
						<h3 class="title1"></h3>
							<div class="form-three widget-shadow">
								<form class="form-horizontal" runat="server">
                                    <div class="form-group">
									<label for="selector1" class="col-sm-2 control-label">Insumo</label>
									<div class="col-sm-8">                                            
                                            <asp:DropDownList id="selectInsumo1" runat="server" CssClass="form-control1" OnSelectedIndexChanged="selectInsumo1_SelectedIndexChanged">
										        <asp:ListItem Selected="True" Value="0">Seleccione un insumo</asp:ListItem>
                                                <asp:ListItem>Pollo</asp:ListItem>
										        <asp:ListItem>Papa</asp:ListItem>
                                                <asp:ListItem>Arroz</asp:ListItem>
									        </asp:DropDownList></div>
									</div>
									<div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Fecha</label>
										<div class="col-sm-8">
                                            <asp:TextBox disabled ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control1"/>
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
										<div class="col-sm-8">
                                            <asp:TextBox ID="txtCantidad" runat="server" placeholder="Seleccione la cantidad" CssClass="form-control1" />
										</div>
									</div>
                                    <div class="form-group">
										<label for="focusedinput" class="col-sm-2 control-label">Unidad</label>
										<div class="col-sm-8">
                                            <asp:TextBox disabled ID="txtUnidadMedida" runat="server" placeholder="Unidad de Medida" CssClass="form-control1"/>
										</div>
									</div>
                                    <hr/>
								    <p class="center-button">
						    		    <button type="button" name="sub-1" class="btn btn-primary" runat="server" onserverclick="btnEgresar_ServerClick" id="btnEgresar">Egresar</button>
                                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'ManejarStock.aspx';" class="btn btn-primary" />
							    	    <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger"/> 
								    </p>
								</form>     
                 </div>
              </div>
            </div>
        </div>
          <div class="fo-top-di no-margin">
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
                            <input type="text" placeholder="Tu correo electrónico" required="" />
                        </form>
                    </div>
                    <div class="btn-1">
                        <form>
                            <input type="submit" value="join" />
                        </form>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="footer">
            <div class="clearfix"></div>
            <p>© 2020 MesónURP  | <a href="http://www.urp.edu.pe//">Universidad Ricardo Palma</a></p>
        </div>
    </div>
        <div class="clearfix"></div>
    </div>
  
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
                        <li id="menu-oc-consulta"><a href="GestionarOC.aspx">Consultar Compras</a></li>
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
        <script > 
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
</body>
</html>
