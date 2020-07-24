using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using LinqToDB;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MesonURPWEB
{
	public partial class Probando : System.Web.UI.Page
	{
		CTR_Insumo _Ci = new CTR_Insumo();
        protected void Page_Load(object sender, EventArgs e)
		{
			CargarDatos();
		}
        protected string CargarDatos()
        {
            DataTable datos = new DataTable();
            datos = _Ci.ListarDashboard();
            string strDatos;
            strDatos = "[['Insumo','Total'],";
            
            foreach (DataRow dr in datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;

        }
        //private void CargarDatos()
        //{
        //    DataTable dt = new DataTable();
        //    StringBuilder str = new StringBuilder();
        //    try
        //    {
        //        dt = _Ci.ListarDashboard();
        //        str.Append(@"<script type='text/javascript'>  
        //             google.charts.load('visualization', '1', {packages: ['bar']});
        //               google.charts.setOnLoadCallback(drawChart);</script>  
        //            <script type='text/javascript'>  
        //            function drawChart() {   
        //            var data = google.visualization.arrayToDataTable([  
        //            ['Insumo', 'Total'],");

        //            foreach (DataRow row in dt.Rows)
        //            {
        //            str.Append("['" + row["Insumo"] + "'," + row["Total"] + "],");
        //        }
        //            str.Remove(str.Length - 1, 1);
        //        str.Append("]);");

        //        str.Append("var options = {chart: {title: 'Company Performance',subtitle: 'Sales, Expenses, and Profit: 2014-2017',}};");
        //        str.Append("var chart = new google.charts.Bar(document.getElementById('Ch_BarChart_Monthly'));  chart.draw(data, options); } google.setOnLoadCallback(drawChart)");
        //        str.Append(" </script>");
        //        lt.Text = str.ToString();

        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        dt.Dispose();
        //        str.Clear();
        //    }
        //}
    }
}