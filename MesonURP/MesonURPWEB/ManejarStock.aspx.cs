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
            CargarInsumo();
        }
        protected void fNombreMovimiento_TextChanged(object sender, EventArgs e)
        {
            CargarInsumo();
        }
        public void CargarInsumo()
        {
            gvInsumos.DataSource = _CI.BuscarInsumo(txtBuscarInsumo.Text);
            gvInsumos.DataBind();
        }
        
    }
}