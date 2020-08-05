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

</style>
<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/kelly.js"></script>

<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
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

         var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
         valueAxis.min = 0;
         valueAxis.title.text = "Cantidad";

         // Create series
         function createSeries(field, name, stacked) {
             var series = chart.series.push(new am4charts.ColumnSeries());
             series.dataFields.valueY = field;
             series.dataFields.categoryX = "Insumo";
             series.name = name;
             series.columns.template.tooltipText = "{name}: [bold]{valueY}[/]";
             series.stacked = stacked;
             series.stroke = am4core.color("#DBC299");
             series.fill = am4core.color("#DBC299");
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
        am4core.useTheme(am4themes_kelly);
        am4core.useTheme(am4themes_animated);
        // Themes end



        // Create chart instance
        var chart = am4core.create("chartdiv1", am4charts.XYChart);

        // Add data
        chart.data = [{
            "date": "2012-03-01",
            "price": 20
        }, {
            "date": "2012-03-02",
            "price": 75
        }, {
            "date": "2012-03-03",
            "price": 15
        }, {
            "date": "2012-03-04",
            "price": 75
        }, {
            "date": "2012-03-05",
            "price": 158
        }, {
            "date": "2012-03-06",
            "price": 57
        }, {
            "date": "2012-03-07",
            "price": 107
        }, {
            "date": "2012-03-08",
            "price": 89
        }, {
            "date": "2012-03-09",
            "price": 75
        }, {
            "date": "2012-03-10",
            "price": 132
        }, {
            "date": "2012-03-11",
            "price": 380
        }, {
            "date": "2012-03-12",
            "price": 56
        }, {
            "date": "2012-03-13",
            "price": 169
        }, {
            "date": "2012-03-14",
            "price": 24
        }, {
            "date": "2012-03-15",
            "price": 147
        }];

        // Create axes
        var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
        dateAxis.renderer.grid.template.location = 0;
        dateAxis.renderer.minGridDistance = 50;

        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.logarithmic = true;
        valueAxis.renderer.minGridDistance = 20;

        // Create series
        var series = chart.series.push(new am4charts.LineSeries());
        series.dataFields.valueY = "price";

        series.dataFields.dateX = "date";
        series.tensionX = 0.8;
        series.strokeWidth = 3;
        series.stroke = am4core.color("#D1CDAA");

        var bullet = series.bullets.push(new am4charts.CircleBullet());
        bullet.circle.fill = am4core.color("#fff");
        bullet.circle.strokeWidth = 3;

        // Add cursor
        chart.cursor = new am4charts.XYCursor();
        chart.cursor.fullWidthLineX = true;
        chart.cursor.xAxis = dateAxis;
        chart.cursor.lineX.strokeWidth = 0;
        chart.cursor.lineX.fill = am4core.color("#000");
        chart.cursor.lineX.fillOpacity = 0.1;

        // Add scrollbar
        chart.scrollbarX = new am4core.Scrollbar();

        // Add a guide
        let range = valueAxis.axisRanges.create();
        range.value = 90.4;
        range.grid.stroke = am4core.color("#DBC299");
        range.grid.strokeWidth = 1;
        range.grid.strokeOpacity = 1;
        range.grid.strokeDasharray = "3,3";
        range.label.inside = true;
        range.label.text = "Average";
        range.label.fill = range.grid.stroke;
        range.label.verticalCenter = "bottom";

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
           
         <div>  
            <div id="chartdiv1"></div>	
        </div>
   </div>
    </asp:Content>

