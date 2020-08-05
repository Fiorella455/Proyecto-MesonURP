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
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MesonURPWEB
{
	public partial class Probando : System.Web.UI.Page
	{
		CTR_Insumo _Ci = new CTR_Insumo();
        protected void Page_Load(object sender, EventArgs e)
		{
            ////if (Session["codUsuario"] == null)
            ////{
            ////    Response.Redirect("Home.aspx?x=1");
            ////}
            if (!Page.IsPostBack)
            {
                CargarDatos();
                //CargarSegundoDT();
            }
		}
        protected string CargarDatos()
        {
            DataTable datos = new DataTable();
            datos = _Ci.ListarDashboard();

            StringBuilder js = new StringBuilder();
            string strDatos = "";
            //strDatos = "[{'Insumo','Total'},";

            js.Append("[");

            foreach (DataRow dr in datos.Rows)
            {
                js.Append(strDatos + "{");
                js.Append("\"Insumo\":" + "\"" + dr[0] + "\",");
                js.Append("\"Total\":" + "\"" + dr[1] + "\",");
                js.Append("\"Compra\":" + dr[2]);
                js.Append("}");
                strDatos = ",";
            }
            js.Append("]");
            return js.ToString();
        }

        //protected string CargarSegundoDT()
        //{
        //    DataTable datos = new DataTable();
        //    datos = _Ci.ListarDashboardT();

        //    StringBuilder js = new StringBuilder();
        //    string strDatos = "";

        //    js.Append("[");

        //    foreach (DataRow dr in datos.Rows)
        //    {
        //        js.Append(strDatos + "{");
        //        js.Append("\"Fecha\":" + "\"" + dr[0] + "\",");
        //        js.Append("\"Insumo\":" + "\"" + dr[1] + "\",");
        //        js.Append("\"Perdida\":" + dr[2]);
        //        js.Append("}");
        //        strDatos = ",";
        //    }
        //    js.Append("]");
        //    return js.ToString();
        //}

    }
}