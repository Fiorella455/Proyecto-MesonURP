using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class Dashboard : System.Web.UI.Page
    {
        CTR_Insumo _CI = new CTR_Insumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarInsumosAgotados();
        }

        protected void gvInsumosAgotados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsumosAgotados.PageIndex = e.NewPageIndex;
            CargarInsumosAgotados();
        }
        public void CargarInsumosAgotados()
        {
            gvInsumosAgotados.DataSource = _CI.ListarDashboard();
            gvInsumosAgotados.DataBind();
        }
    }
}