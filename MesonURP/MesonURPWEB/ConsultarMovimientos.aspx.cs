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
    }
}