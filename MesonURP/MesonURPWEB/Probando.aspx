<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Probando.aspx.cs" Inherits="MesonURPWEB.Probando" %>

<!DOCTYPE html>
<style>
#chartdiv {
  width: 100%;
  height: 500px;
}

.amcharts-export-menu-top-right {
  top: 10px;
  right: 0;
}
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://www.amcharts.com/lib/3/amcharts.js"></script>
<script src="https://www.amcharts.com/lib/3/serial.js"></script>
<script src="https://www.amcharts.com/lib/3/plugins/export/export.min.js"></script>
<link rel="stylesheet" href="https://www.amcharts.com/lib/3/plugins/export/export.css" type="text/css" media="all" />
<script src="https://www.amcharts.com/lib/3/themes/light.js"></script>
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
     var chart = AmCharts.makeChart("chartdiv", {
         "type": "serial",
         "theme": "light",
         "marginRight": 70,
         "dataProvider": <%=CargarDatos()%>,
         "valueAxes": [{
             "axisAlpha": 0,
             "position": "left",
             "title": "Insumos por agotarse"
         }],
         "startDuration": 1,
         "graphs": [{
             "balloonText": "<b>[[category]]: [[value]]</b>",
             "fillColorsField": "color",
             "fillAlphas": 0.9,
             "lineAlpha": 0.2,
             "type": "column",
             "valueField": "Total"
         }],
         "chartCursor": {
             "categoryBalloonEnabled": false,
             "cursorAlpha": 0,
             "zoomable": false
         },
         "categoryField": "Insumo",
         "categoryAxis": {
             "gridPosition": "start",
             "labelRotation": 45
         },
         "export": {
             "enabled": true
         }

     });
 </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>  
            <div id="chartdiv"></div>	
        </div>
    </form>
</body>
</html>

