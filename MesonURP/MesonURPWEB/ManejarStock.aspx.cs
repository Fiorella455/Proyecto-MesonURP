using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MesonURPWEB
{
    public partial class ManejarStock : System.Web.UI.Page
    {
        CTR_Insumo _CI = new CTR_Insumo();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarStockInsumo();
        }

        protected void brnSearchStock_ServerClick(object sender, EventArgs e)
        {
            if (txtBuscarInsumo.Text != "")
            {
                gvInsumos.DataSource = _CI.BuscarInsumo(txtBuscarInsumo.Text);
                gvInsumos.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.PanelBuscar, this.PanelBuscar.GetType(), "alert", "alertaError()", true);
                return;
            }
            
        }
        public void CargarStockInsumo()
        {
            gvInsumos.DataSource = _CI.ListarInsumo();
            gvInsumos.DataBind();
            
        }
        protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsumos.PageIndex = e.NewPageIndex;
            CargarStockInsumo();
        }
    }
}