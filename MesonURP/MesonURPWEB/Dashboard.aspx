<%@ Page Title="MesónURP | Dashboard" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MesonURPWEB.Probando" %>
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
#chartdiv2 {
  width: 100%;
  height: 500px;
}
</style>
<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/moonrisekingdom.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/moonrisekingdom.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/moonrisekingdom.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

     <%--<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawMultSeries);

        function drawMultSeries() {
            var data = google.visualization.arrayToDataTable(<%=CargarDatos()%>);
            var options = {
                title: 'Population of Largest U.S. Cities',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Total',
                    minValue: 0
                },
                vAxis: {
                    title: 'Insumo'
                }
            };

            var chart = new google.visualization.BarChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>--%>
 <script>
     am4core.ready(function () {

         // Themes begin
         am4core.useTheme(am4themes_moonrisekingdom);
         am4core.useTheme(am4themes_animated);
         // Themes end

         // Create chart instance
         var chart = am4core.create("chartdiv", am4charts.XYChart);
         chart.scrollbarX = new am4core.Scrollbar();
       
         chart.data = <%=CargarDatos()%>;
     
         
         var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
         categoryAxis.dataFields.category = "Insumo";
         categoryAxis.title.text = "Insumo";
         categoryAxis.renderer.grid.template.location = 0;
         categoryAxis.renderer.minGridDistance = 20;
         categoryAxis.renderer.cellStartLocation = 0.1;
         categoryAxis.renderer.cellEndLocation = 0.9;
         //categoryAxis.fill = am4core.color("#DBC299");
         //categoryAxis.stroke = am4core.color("#DBC299");

         var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
         valueAxis.min = 0;
         valueAxis.title.text = "Cantidad";
         //valueAxis.fill = am4core.color("#F8A45E");
         //valueAxis.stroke = am4core.color("#F8A45E");
         // Create series
         chart.colors.list = [
             am4core.color("#9C746B"),
             am4core.color("#DC7633"),
             am4core.color("#FF6F91"),
             am4core.color("#FF9671"),
             am4core.color("#FFC75F"),
             am4core.color("#F9F871"),
         ];

         function createSeries(field, name, stacked) {
             var series = chart.series.push(new am4charts.ColumnSeries());
             series.dataFields.valueY = field;
             series.dataFields.categoryX = "Insumo";
             series.name = name;
             series.columns.template.tooltipText = "{name}: [bold]{valueY}[/]";
             series.stacked = stacked;
             series.columns.template.width = am4core.percent(95);
             
         }
         createSeries("Total", "Cantidad Total", false);
         createSeries("Compra", "Cantidad de Compra", true);

         // Add legend
         chart.legend = new am4charts.Legend();
         chart.legend.position = "right";
         
     }); // end am4core.ready()
 </script>

 <script>
    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_moonrisekingdom);
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart instance
        var chart = am4core.create("chartdiv1", am4charts.XYChart);

        //
        // Increase contrast by taking evey second color
        chart.colors.step = 2;

        // Add data
        chart.data = <%=CargarSegundoDT()%>;

        // Create axes
        var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
        dateAxis.renderer.minGridDistance = 50;

        // Create series
        function createAxisAndSeries(field, name, opposite, bullet) {
            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
           
            if (chart.yAxes.indexOf(valueAxis) != 0) {
                valueAxis.syncWithAxis = chart.yAxes.getIndex(0);
            }

            var series = chart.series.push(new am4charts.LineSeries());
            series.dataFields.valueY = field;
            series.dataFields.dateX = "Fecha";
            series.strokeWidth = 2;
            series.yAxis = valueAxis;
            series.name = name;
            series.tooltipText = "{name}: [bold]{valueY}[/]";
            series.tensionX = 0.8;
            series.showOnInit = true;

            //var series1 = chart.series1.push(new am4charts.ColumnSeries());
            //series1.columns.template.tooltipText = "Series: {Insumo}\nCategory: {categoryX}\nValue: {valueY}";

            var interfaceColors = new am4core.InterfaceColorSet();

            switch (bullet) {
                case "triangle":
                    var bullet = series.bullets.push(new am4charts.Bullet());
                    bullet.width = 12;
                    bullet.height = 12;
                    bullet.horizontalCenter = "middle";
                    bullet.verticalCenter = "middle";

                    var triangle = bullet.createChild(am4core.Triangle);
                    triangle.stroke = interfaceColors.getFor("background");
                    triangle.strokeWidth = 2;
                    triangle.direction = "top";
                    triangle.width = 12;
                    triangle.height = 12;
                    break;
                case "rectangle":
                    var bullet = series.bullets.push(new am4charts.Bullet());
                    bullet.width = 10;
                    bullet.height = 10;
                    bullet.horizontalCenter = "middle";
                    bullet.verticalCenter = "middle";

                    var rectangle = bullet.createChild(am4core.Rectangle);
                    rectangle.stroke = interfaceColors.getFor("background");
                    rectangle.strokeWidth = 2;
                    rectangle.width = 10;
                    rectangle.height = 10;
                    break;
                default:
                    var bullet = series.bullets.push(new am4charts.CircleBullet());
                    bullet.circle.stroke = interfaceColors.getFor("background");
                    bullet.circle.strokeWidth = 2;
                    break;
            }

            valueAxis.renderer.line.strokeOpacity = 1;
            valueAxis.renderer.line.strokeWidth = 2;
            valueAxis.renderer.line.stroke = series.stroke;
            valueAxis.renderer.labels.template.fill = series.stroke;
            valueAxis.renderer.opposite = opposite;
        }

        createAxisAndSeries("Egreso", "Egreso", false, "circle");
        createAxisAndSeries("Ingreso", "Ingreso", true, "rectangle");
        // Add legend
        chart.legend = new am4charts.Legend();

        // Add cursor
        chart.cursor = new am4charts.XYCursor();
        
    }); // end am4core.ready()
 </script>
<script>
    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_moonrisekingdom);
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart instance
        var chart = am4core.create("chartdiv2", am4charts.XYChart);
        chart.scrollbarX = new am4core.Scrollbar();

        // Add data
        chart.data = <%=CargarDatosD2()%>;

        // Create axes
        var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
        categoryAxis.dataFields.category = "Insumo";
        categoryAxis.renderer.grid.template.location = 0;
        categoryAxis.renderer.minGridDistance = 30;
        categoryAxis.renderer.labels.template.horizontalCenter = "right";
        categoryAxis.renderer.labels.template.verticalCenter = "middle";
        categoryAxis.renderer.labels.template.rotation = 270;
        categoryAxis.tooltip.disabled = true;
        categoryAxis.renderer.minHeight = 110;

        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.renderer.minWidth = 50;

        // Create series
        var series = chart.series.push(new am4charts.ColumnSeries());
        series.sequencedInterpolation = true;
        series.dataFields.valueY = "Total";
        series.dataFields.categoryX = "Insumo";
        series.tooltipText = "[{categoryX}: bold]{valueY}[/]";
        series.columns.template.strokeWidth = 0;

        series.tooltip.pointerOrientation = "vertical";

        series.columns.template.column.cornerRadiusTopLeft = 10;
        series.columns.template.column.cornerRadiusTopRight = 10;
        series.columns.template.column.fillOpacity = 0.8;

        // on hover, make corner radiuses bigger
        var hoverState = series.columns.template.column.states.create("hover");
        hoverState.properties.cornerRadiusTopLeft = 0;
        hoverState.properties.cornerRadiusTopRight = 0;
        hoverState.properties.fillOpacity = 1;

        series.columns.template.adapter.add("fill", function (fill, target) {
            return chart.colors.getIndex(target.dataItem.index);
        });

        // Cursor
        chart.cursor = new am4charts.XYCursor();

    }); // end am4core.ready()
</script>
         <div class="panel panel-widget forms-panel">
             <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Seguimiento de Insumos en Orden de Compra - Por Agotarse</h4>
                </div>
            <div>
                <div class="table-wrapper-scroll-y">
                    <div>
                       <div id="chartdiv"></div>
                    </div>
                </div>
            </div>

                </div>
         </div>
           <div class="panel panel-widget forms-panel" style="display:flex">
         <div class="form-grids widget-shadow" style="width:150%; margin-right:21px" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Ingresos - Egresos</h4>
                </div>
            <div>
                <div class="table-wrapper-scroll-y">
                    <div>  
                        <div id="chartdiv1"></div>	
                    </div>
                </div>
            </div>

                </div>
           <div class="form-grids widget-shadow" style="width:150%;" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Insumos Disponibles</h4>
                </div>
            <div>
                <div class="table-wrapper-scroll-y">
                    <div>
                       <div id="chartdiv2"></div>
                    </div>
                </div>
            </div>

                </div>
           </div>
   </div>
    </asp:Content>

