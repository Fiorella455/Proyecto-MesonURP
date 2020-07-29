using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class GenerarReporteMovimiento : System.Web.UI.Page
    {
        int Mes = 0;
        CTR_MovimientoxInsumo _CmxI = new CTR_MovimientoxInsumo();
        protected void Page_Load(object sender, EventArgs e)
        {

            Mes = DateTime.Today.Month;
            CargarMovimientoxInsumoMes(Mes);
            if (IsPostBack)

            {
                if (ddlMes.SelectedIndex == 0)
                {
                    Mes = DateTime.Today.Month;

                }
                else
                {
                    Mes = Convert.ToInt32(ddlMes.SelectedValue);
                }
                CargarMovimientoxInsumoMes(Mes);

            }
        }
        public void CargarMovimientoxInsumoMes(int mes)
        {
            gvMovimientos.DataSource = _CmxI.SelectMovimientoxInsumoxMes(mes);
            gvMovimientos.DataBind();
        }
       
        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlMes.SelectedValue != "")
            {
                Mes = Convert.ToInt32(ddlMes.SelectedValue);
                gvMovimientos.DataSource = _CmxI.SelectMovimientoxInsumoxMes(Convert.ToInt32(Mes));
                gvMovimientos.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un insumo para la busqueda');", true);
            }

        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Session.Add("Mes", Mes);
            Response.Redirect("VistaPreviaReporteMovimiento.aspx");

        }

        protected void gvMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Selection_Change(object sender, EventArgs e)
        {

        }
    }
}