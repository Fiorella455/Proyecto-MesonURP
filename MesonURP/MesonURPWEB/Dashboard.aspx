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
        range.grid.stroke = am4core.color("#396478");
        range.grid.strokeWidth = 1;
        range.grid.strokeOpacity = 1;
        range.grid.strokeDasharray = "3,3";
        range.label.inside = true;
        range.label.text = "Average";
        range.label.fill = range.grid.stroke;
        range.label.verticalCenter = "bottom";

    }); // end am4core.ready()
</script>
        <div>  
            <div id="chartdiv"></div>	
        </div>
         <div>  
            <div id="chartdiv1"></div>	
        </div>
   </div>
    </asp:Content>

