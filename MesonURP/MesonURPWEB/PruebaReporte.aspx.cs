using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;


namespace MesonURPWEB
{
    public partial class PruebaReporte : System.Web.UI.Page
    {
        
        CTR_OCxInsumo ctr_ocxinsumo;
        CTR_OC ctr_oc;
        DataTable dt_ocxi;
        DataTable dt_oc;
        int mes = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_ocxinsumo = new CTR_OCxInsumo();           
            dt_ocxi = new DataTable();
            mes = (int)Session["mes"];
            dt_ocxi=ctr_ocxinsumo.Leer_InsumoxMes(mes);
            GridViewInsumoxOC.DataSource=dt_ocxi;
            GridViewInsumoxOC.DataBind();
         //------------------------------------------
            ctr_oc = new CTR_OC();
            dt_ocxi = new DataTable();
            dt_oc = ctr_oc.Leer_OCxMes(mes);
            GridViewOC.DataSource = dt_oc;
            GridViewOC.DataBind();
        //------------------------------------------ 
            Label1.Text = "Mes:" + mes;


        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prueba.aspx");
        }
    }
}