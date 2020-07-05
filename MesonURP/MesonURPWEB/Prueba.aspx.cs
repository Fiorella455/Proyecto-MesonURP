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
    public partial class Prueba : System.Web.UI.Page
    {
        CTR_OC ctr_oc;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_oc = new CTR_OC();
            dt = new DataTable();
            dt = ctr_oc.Leer_OC_Recibido();
            GridViewConsultar.DataSource = dt;
            GridViewConsultar.DataBind();
            CargarDdlMes();
            //---------------------------------------

            if (ddlMes.SelectedValue != null)
            { 
                   //switch(ddlMes.SelectedValue)
                   
            }

        }

        protected void GridViewConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void CargarDdlMes()
        {
            ListItem i;
            i = new ListItem("Enero","1");
            ddlMes.Items.Add(i);           
            i = new ListItem("Febrero","2");
            ddlMes.Items.Add(i);         
            i = new ListItem("Marzo","3");
            ddlMes.Items.Add(i);        
            i = new ListItem("Abril","4");
            ddlMes.Items.Add(i);         
            i = new ListItem("Mayo","5");
            ddlMes.Items.Add(i);        
            i = new ListItem("Junio","6");
            ddlMes.Items.Add(i);        
            i = new ListItem("Julio","7");
            ddlMes.Items.Add(i);
            i = new ListItem("Agosto","8");
            ddlMes.Items.Add(i);         
            i = new ListItem("Septiembre","9");
            ddlMes.Items.Add(i);
            i = new ListItem("Octubre", "10");
            ddlMes.Items.Add(i);
            i = new ListItem("Noviembre", "11");
            ddlMes.Items.Add(i);
            i = new ListItem("Diciembre", "12");
            ddlMes.Items.Add(i);
        }
    }
}