using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class ConsultarMovimientos : System.Web.UI.Page
    {
        CTR_MovimientoxInsumo _CmxI = new CTR_MovimientoxInsumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMovimientoxInsumo();
        }
        public void CargarMovimientoxInsumo()
        {
            gvMovimientos.DataSource = _CmxI.SelectMovimientosxInsumo();
            gvMovimientos.DataBind();
        }
        protected void gvMovimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMovimientos.PageIndex = e.NewPageIndex;
            CargarMovimientoxInsumo();
        }
        protected void brnSearchStock_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarMovimientos.Text != "")
                {
                    gvMovimientos.DataSource = _CmxI.BusquedaMovimientoxInsumo(txtBuscarMovimientos.Text);
                    gvMovimientos.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese otro dato para la busqueda');", true);

            }
        }
        public void Selection_Change(Object sender, EventArgs e)
        {
            try
            {
                if (ddlMovimientos.SelectedValue != "")
                {
                    gvMovimientos.DataSource = _CmxI.BusquedaMovimientoxInsumoTipo(Convert.ToInt32(ddlMovimientos.SelectedValue));
                    gvMovimientos.DataBind();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un insumo para la busqueda');", true);
            }
            //gvMovimientos.DataSource = _CmxI.BusquedaMovimientoxInsumoTipo(Convert.ToInt32(ddlMovimientos.SelectedValue));
            //gvMovimientos.DataBind();
        }
    }
}