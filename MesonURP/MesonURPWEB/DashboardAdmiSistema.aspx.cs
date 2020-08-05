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
    public partial class DashboardAdmiSistema : System.Web.UI.Page
    {
        Ctr_Usuario _Cu = new Ctr_Usuario();
        CTR_Proveedor _Cp = new CTR_Proveedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            ////if (Session["codUsuario"] == null)
            ////{
            ////    Response.Redirect("Home.aspx?x=1");
            ////}
            if (!Page.IsPostBack)
            {
                CargarUsuarios();
                CargarProveedor();
            }
        }
        protected string CargarUsuarios()
        {
            DataTable datos = new DataTable();
            datos = _Cu.ListarPieUser();

            StringBuilder js = new StringBuilder();
            string strDatos = "";

            js.Append("[");

            foreach (DataRow dr in datos.Rows)
            {
                js.Append(strDatos + "{");
                js.Append("\"Estado\":" + "\"" + dr[0] + "\",");
                js.Append("\"Total\":" + dr[1]);
                js.Append("}");
                strDatos = ",";
            }
            js.Append("]");
            return js.ToString();
        }
        protected string CargarProveedor()
        {
            DataTable datos = new DataTable();
            datos = _Cp.ListarPieProveedor();

            StringBuilder js = new StringBuilder();
            string strDatos = "";

            js.Append("[");

            foreach (DataRow dr in datos.Rows)
            {
                js.Append(strDatos + "{");
                js.Append("\"Estado\":" + "\"" + dr[0] + "\",");
                js.Append("\"Total\":" + dr[1]);
                js.Append("}");
                strDatos = ",";
            }
            js.Append("]");
            return js.ToString();
        }

    }
}