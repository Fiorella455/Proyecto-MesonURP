<%@ Page Title="MesónURP | Dashboard" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DashboardAdmi.aspx.cs" Inherits="MesonURPWEB.DashboardAdmi" %>

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
  height: 600px;
}
</style>
<style>
#chartdiv1 {
  width: 100%;
  height: 500px;
}
</style>
<style>
#chartdiv2 {
  width: 100%;
  height: 500px;
}
</style>

<style>
#chartdiv3 {
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
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/moonrisekingdom.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/moonrisekingdom.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
<!-- Chart code -->
<script>
    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_moonrisekingdom);
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart instance
        var chart = am4core.create("chartdiv1", am4charts.XYChart);

        // Add data
        chart.data = <%=CargarDatosD1()%>;

        chart.dateFormatter.inputDateFormat = "yyyy-MM-dd";

        // Create axes
        var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

        // Create series
        var series = chart.series.push(new am4charts.LineSeries());
        series.dataFields.valueY = "Perdida";
        series.dataFields.dateX = "Fecha";
        series.tooltipText = "{Perdida}"
        series.strokeWidth = 2;
        series.minBulletDistance = 15;

        // Drop-shaped tooltips
        series.tooltip.background.cornerRadius = 20;
        series.tooltip.background.strokeOpacity = 0;
        series.tooltip.pointerOrientation = "vertical";
        series.tooltip.label.minWidth = 40;
        series.tooltip.label.minHeight = 40;
        series.tooltip.label.textAlign = "middle";
        series.tooltip.label.textValign = "middle";

        // Make bullets grow on hover
        var bullet = series.bullets.push(new am4charts.CircleBullet());
        bullet.circle.strokeWidth = 2;
        bullet.circle.radius = 4;
        bullet.circle.fill = am4core.color("#fff");

        var bullethover = bullet.states.create("hover");
        bullethover.properties.scale = 1.3;

        // Make a panning cursor
        chart.cursor = new am4charts.XYCursor();
        chart.cursor.behavior = "panXY";
        chart.cursor.xAxis = dateAxis;
        chart.cursor.snapToSeries = series;

        // Create vertical scrollbar and place it before the value axis
        chart.scrollbarY = new am4core.Scrollbar();
        chart.scrollbarY.parent = chart.leftAxesContainer;
        chart.scrollbarY.toBack();

        // Create a horizontal scrollbar with previe and place it underneath the date axis
        chart.scrollbarX = new am4charts.XYChartScrollbar();
        chart.scrollbarX.series.push(series);
        chart.scrollbarX.parent = chart.bottomAxesContainer;

        dateAxis.start = 0.79;
        dateAxis.keepSelection = true;

    }); // end am4core.ready()
</script>


<script>
    am4core.ready(function () {

    // Themes begin
    am4core.useTheme(am4themes_animated);

    var chart = am4core.create("chartdiv", am4charts.XYChart);
    chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

    chart.paddingRight = 40;

    chart.data = <%=CargarDatosD()%>;

    var categoryAxis = chart.yAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = "Usuario";
    categoryAxis.renderer.grid.template.strokeOpacity = 0;
    categoryAxis.renderer.minGridDistance = 10;
    categoryAxis.renderer.labels.template.dx = -40;
    categoryAxis.renderer.minWidth = 120;
    categoryAxis.renderer.tooltip.dx = -40;

    var valueAxis = chart.xAxes.push(new am4charts.ValueAxis());
    valueAxis.renderer.inside = true;
    valueAxis.renderer.labels.template.fillOpacity = 0.3;
    valueAxis.renderer.grid.template.strokeOpacity = 0;
    valueAxis.min = 0;
    valueAxis.cursorTooltipEnabled = false;
    valueAxis.renderer.baseGrid.strokeOpacity = 0;
    valueAxis.renderer.labels.template.dy = 20;

    var series = chart.series.push(new am4charts.ColumnSeries);
    series.dataFields.valueX = "Total";
    series.dataFields.categoryY = "Usuario";
    series.tooltipText = "{valueX.value}";
    series.tooltip.pointerOrientation = "vertical";
    series.tooltip.dy = - 30;
    series.columnsContainer.zIndex = 100;

    var columnTemplate = series.columns.template;
    columnTemplate.height = am4core.percent(50);
    columnTemplate.maxHeight = 50;
    columnTemplate.column.cornerRadius(60, 10, 60, 10);
    columnTemplate.strokeOpacity = 0;

    series.heatRules.push({ target: columnTemplate, property: "fill", dataField: "valueX", min: am4core.color("#e5dc36"), max: am4core.color("#5faa46") });
    series.mainContainer.mask = undefined;

    var cursor = new am4charts.XYCursor();
    chart.cursor = cursor;
    cursor.lineX.disabled = true;
    cursor.lineY.disabled = true;
    cursor.behavior = "none";

    var bullet = columnTemplate.createChild(am4charts.CircleBullet);
    bullet.circle.radius = 30;
    bullet.valign = "middle";
    bullet.align = "left";
    bullet.isMeasured = true;
    bullet.interactionsEnabled = false;
    bullet.horizontalCenter = "right";
    bullet.interactionsEnabled = false;

    var hoverState = bullet.states.create("hover");
    var outlineCircle = bullet.createChild(am4core.Circle);
    outlineCircle.adapter.add("radius", function (radius, target) {
        var circleBullet = target.parent;
        return circleBullet.circle.pixelRadius + 10;
    })

    var image = bullet.createChild(am4core.Image);
    image.width = 60;
    image.height = 60;
    image.horizontalCenter = "middle";
    image.verticalCenter = "middle";
    image.propertyFields.href = "href";

    image.adapter.add("mask", function (mask, target) {
        var circleBullet = target.parent;
        return circleBullet.circle;
    })

    var previousBullet;
    chart.cursor.events.on("cursorpositionchanged", function (event) {
        var dataItem = series.tooltipDataItem;

        if (dataItem.column) {
            var bullet = dataItem.column.children.getIndex(1);

            if (previousBullet && previousBullet != bullet) {
                previousBullet.isHover = false;
            }

            if (previousBullet != bullet) {

                var hs = bullet.states.getKey("hover");
                hs.properties.dx = dataItem.column.pixelWidth;
                bullet.isHover = true;

                previousBullet = bullet;
            }
        }
    })

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
<script>
    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_moonrisekingdom);
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart instance
        var chart = am4core.create("chartdiv3", am4charts.PieChart);

        // Add and configure Series
        var pieSeries = chart.series.push(new am4charts.PieSeries());
        pieSeries.dataFields.value = "Total";
        pieSeries.dataFields.category = "Estado";

        // Let's cut a hole in our Pie chart the size of 30% the radius
        chart.innerRadius = am4core.percent(30);

        // Put a thick white border around each Slice
        pieSeries.slices.template.stroke = am4core.color("#fff");
        pieSeries.slices.template.strokeWidth = 2;
        pieSeries.slices.template.strokeOpacity = 1;
        pieSeries.slices.template
            // change the cursor on hover to make it apparent the object can be interacted with
            .cursorOverStyle = [
                {
                    "property": "cursor",
                    "value": "pointer"
                }
            ];

        pieSeries.alignLabels = false;
        pieSeries.labels.template.bent = true;
        pieSeries.labels.template.radius = 3;
        pieSeries.labels.template.padding(0, 0, 0, 0);

        pieSeries.ticks.template.disabled = true;

        // Create a base filter effect (as if it's not there) for the hover to return to
        var shadow = pieSeries.slices.template.filters.push(new am4core.DropShadowFilter);
        shadow.opacity = 0;

        // Create hover state
        var hoverState = pieSeries.slices.template.states.getKey("hover"); // normally we have to create the hover state, in this case it already exists

        // Slightly shift the shadow and make it more prominent on hover
        var hoverShadow = hoverState.filters.push(new am4core.DropShadowFilter);
        hoverShadow.opacity = 0.7;
        hoverShadow.blur = 5;

        // Add a legend
        chart.legend = new am4charts.Legend();

        chart.data = <%=CargaPieEstadoOC()%>;

    }); // end am4core.ready()
</script>

 <div class="panel panel-widget forms-panel">
             <div class="form-grids widget-shadow" data-example-id="basic-forms">
                  <div class="form-title color-white">
                    <h4>Cantidad de Merma originado por día</h4>
                </div>
            <div>
                <div class="table-wrapper-scroll-y">
                    <div>
                       <div id="chartdiv1"></div>
                    </div>
                </div>
            </div>
                </div>
     <div class="panel panel-widget forms-panel" style="display:flex">
         <div class="form-grids widget-shadow" style="width:100%; margin-right:21px" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Número de Movimientos por Usuario</h4>
                </div>
            <div>
                <div class="table-wrapper-scroll-y">
                    <div>
                       <div id="chartdiv"></div>
                    </div>
                </div>
            </div>

                </div>
           <div class="form-grids widget-shadow" style="width:100%;" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Estados de las Órdenes de Compras</h4>
                </div>
            <div>
                <div class="table-wrapper-scroll-y">
                    <div>
                       <div id="chartdiv3"></div>
                    </div>
                </div>
            </div>

                </div>
           </div>
      <div class="form-grids widget-shadow" data-example-id="basic-forms">
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