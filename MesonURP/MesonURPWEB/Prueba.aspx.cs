using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DAO;

namespace MesonURPWEB
{
    public partial class Prueba : System.Web.UI.Page
    {
        DAO_OC dao_oc;
        CTR_OC ctr_oc;
        DataTable dt;
        int mes = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            dao_oc = new DAO_OC();
            ctr_oc = new CTR_OC();
            dt = new DataTable();
            mes = DateTime.Today.Month;
            CargarOC(mes);
           

        }
        public void CargarOC(int m)
        {      
                dt = ctr_oc.Leer_OCxMes(m);
                GridViewConsultar.DataSource = dt;
                GridViewConsultar.DataBind();
                CargarDdlMes();         
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

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlMes.SelectedValue != null)
            {

                mes = Convert.ToInt32(ddlMes.SelectedValue);
                
                   // Label1.Text = "Mes:" + mes.ToString()+ " Hay Registros" + dao_oc.Count_OCxMes(mes);
                    CargarOC(mes);
               
               
                
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("PruebaReporte.aspx");
        }
    }
}