<%@ Page Title="MesónURP | Dashboard" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DashboardAdmiSistema.aspx.cs" Inherits="MesonURPWEB.DashboardAdmiSistema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
          <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Dashboard</h2>
            </div>
    <style>
        #chartdiv {
          width: 100%;
          height: 500px;
        }
    </style>
    <style>
        #chartdiv1 {
          width: 100%;
          height: 500px;
        }
    </style>

<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

<!-- Chart code -->
<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

<!-- Chart code -->
<script>
    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

        var chart = am4core.create("chartdiv", am4charts.PieChart3D);
        chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

        chart.legend = new am4charts.Legend();

        chart.data = <%=CargarUsuarios()%>;

        var series = chart.series.push(new am4charts.PieSeries3D());
        series.dataFields.value = "Total";
        series.dataFields.category = "Estado";

    }); // end am4core.ready()
</script>
<script>
    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

        var chart = am4core.create("chartdiv1", am4charts.PieChart3D);
        chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

        chart.legend = new am4charts.Legend();

        chart.data = <%=CargarProveedor()%>;

        var series = chart.series.push(new am4charts.PieSeries3D());
        series.dataFields.value = "Total";
        series.dataFields.category = "Estado";

    }); // end am4core.ready()
</script>

<!-- HTML -->
         <div class="panel panel-widget forms-panel">
                     <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Número de Usuarios de Sistema Activos - Inactivos</h4>
                        </div>
                    <div>
                        <div class="table-wrapper-scroll-y">
                            <div>
                               <div id="chartdiv"></div>
                            </div>
                        </div>
                    </div>

                        </div>
              <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Número de Proveedores Activos - Inactivos</h4>
                        </div>
                    <div>
                        <div class="table-wrapper-scroll-y">
                            <div>
                               <div id="chartdiv1"></div>
                            </div>
                        </div>
                    </div>

                        </div>
        </div>
 </div>  
    </asp:Content>
