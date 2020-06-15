using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Data;

namespace MesonURPWEB
{
  
    public partial class GestionarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        CTR_OC ctr_oc;
        DataTable dt;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                ctr_oc = new CTR_OC();

                dt = new DataTable();
                dto_oc = new DTO_OC();

                dt = ctr_oc.Leer_OC();
                GridViewOC.DataSource = dt;
                GridViewOC.DataBind();

            }
        }

        protected void btnVerDetallesOC_Click(object sender, EventArgs e)
        {
            GridViewRow OC = (GridViewRow)((Button)sender).Parent.Parent;
            int i = OC.RowIndex;
            dto_oc.OC_idOrdenCompra = Convert.ToInt32(GridViewOC.Rows[i].Cells[0].Text);
            ConsultarOC objConsultarOC = new ConsultarOC(dto_oc);
            Response.Redirect("Consultar_OC.aspx");
        }

        protected void btnEnviarEmailOC_Click(object sender, EventArgs e)
        {
            GridViewRow OC = (GridViewRow)((Button)sender).Parent.Parent;
            int i = OC.RowIndex;
            int idOC = Convert.ToInt32(GridViewOC.Rows[i].Cells[0].Text);
            ctr_oc.Enviar_OC(idOC);
        }

        protected void btnEditarOC_Click(object sender, EventArgs e)
        {
            GridViewRow OC = (GridViewRow)((Button)sender).Parent.Parent;
            int i = OC.RowIndex;
            dto_oc.OC_idOrdenCompra = Convert.ToInt32(GridViewOC.Rows[i].Cells[0].Text);
            //ActualizarOC objConsultarOC = new ConsultarOC(dto_oc);
            Response.Redirect("Actualizar_OC.aspx");
        }

       
    }
}