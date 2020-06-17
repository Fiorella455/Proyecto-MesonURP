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

namespace MesonURPWEB.paginas
{
    public partial class ManejarStock : System.Web.UI.Page
    {
        CTR_Insumo _CI = new CTR_Insumo();
        //DTO_Insumo _DI = new DTO_Insumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarStockInsumo();
        }

        protected void brnSearchStock_ServerClick(object sender, EventArgs e)
        {

            try
            {
                if (txtBuscarInsumo.Text != "")
                {
                    gvInsumos.DataSource = _CI.BuscarInsumo(txtBuscarInsumo.Text);
                    gvInsumos.DataBind();
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un insumo para la busqueda');", true);
                
            }

            /*gvInsumos.DataSource = _CI.BuscarInsumo(txtBuscarInsumo.Text);
            gvInsumos.DataBind();*/


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