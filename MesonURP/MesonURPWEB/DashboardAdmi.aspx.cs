using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace MesonURPWEB
{
    public partial class DashboardAdmi : System.Web.UI.Page
    {
        CTR_MovimientoxInsumo _Cmxi = new CTR_MovimientoxInsumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            ////if (Session["codUsuario"] == null)
            ////{
            ////    Response.Redirect("Home.aspx?x=1");
            ////}
            if (!Page.IsPostBack)
            {
                CargarDatosD();
            }
        }
        protected string CargarDatosD()
        {
            DataTable datos = new DataTable();
            datos = _Cmxi.ListarDashboardMU();

            StringBuilder js = new StringBuilder();
            string strDatos = "";
            //strDatos = "[{'Insumo','Total'},";

            js.Append("[");

            foreach (DataRow dr in datos.Rows)
            {
                js.Append(strDatos + "{");
                js.Append("\"Usuario\":" + "\"" + dr[0] + "\",");
                js.Append("\"Total\":" + "\"" + dr[1] + "\",");
                js.Append("\"href\":" + "\"" + "https://www.amcharts.com/lib/images/faces/A04.png" + "\",");
                js.Append("}");
                strDatos = ",";

            }
            js.Append("]");
            return js.ToString();
        }
    }
}