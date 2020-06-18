using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;
using System.Data;

namespace MesonURPWEB
{
  
    public partial class GestionarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        DAO_OC dao_oc;
        CTR_OC ctr_oc;
        DataTable dt;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_oc = new DTO_OC();

            if (!IsPostBack)
            {
                ctr_oc = new CTR_OC();
                dao_oc = new DAO_OC();
                dt = new DataTable();
                dto_oc = new DTO_OC();


                dt = ctr_oc.Leer_OC();
                GridViewOC.DataSource = dt;
                GridViewOC.DataBind();

            }
        }

        protected void btnVerDetallesOC_Click(object sender, EventArgs e)
        {
            //GridViewRow OC = (GridViewRow)((Button)sender).Parent.Parent;
            //int i = OC.RowIndex;
            //DTO_OC aux = new DTO_OC();
            //aux.OC_idOrdenCompra = Convert.ToInt32(GridViewOC.Rows[i].Cells[0].Text);
            //aux.OC_TipoComprobante = GridViewOC.Rows[i].Cells[1].Text;
            //aux.OC_NumeroComprobante = GridViewOC.Rows[i].Cells[2].Text;
            //aux.OC_FormaPago = GridViewOC.Rows[i].Cells[3].Text;
            //aux.OC_FechaPago = Convert.ToDateTime(GridViewOC.Rows[i].Cells[4].Text);
            //aux.OC_TotalCompra = Convert.ToDecimal(GridViewOC.Rows[i].Cells[5].Text);
            ////aux.P_idProveedor = int.Parse(GridViewOC.Rows[i].Cells[6].Text);
            //aux.OC_FechaEmision = DateTime.Parse(GridViewOC.Rows[i].Cells[6].Text);
            //Session.Add("indice", aux);
            //Response.Redirect("ConsultarOC.aspx");
            
        }

        protected void GridViewOC_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            
                if (e.CommandName == "EnviarEmailOC")
                {
                    int idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                    dto_oc.OC_idOrdenCompra = idOC;
                     ctr_oc = new CTR_OC();
                     ctr_oc.Enviar_OC(dto_oc);
                }
                if (e.CommandName == "EliminarOC")
                {
                    int idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                    dto_oc.OC_idOrdenCompra = idOC;
                    ctr_oc = new CTR_OC();
                    ctr_oc.Eliminar_OC(idOC);
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('"+"Orden de Compra Eliminada"+"');", true);
                }
                if (e.CommandName == "ConsultarOC")
               {
                int idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;
                
                Session.Add("indice", dto_oc);
                Response.Redirect("ConsultarOC.aspx");

                }
                if (e.CommandName == "ActualizarOC")
                {
                int idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;
                Session.Add("OCActual", dto_oc);
                Response.Redirect("ActualizarOC.aspx");

                }


        }
        
        
        protected void btnEditarOC_Click(object sender, EventArgs e)
        {
            GridViewRow OC = (GridViewRow)((Button)sender).Parent.Parent;
            int i = OC.RowIndex;

            dto_oc.OC_idOrdenCompra = Convert.ToInt32(GridViewOC.Rows[i].Cells[0].Text);
            
            Response.Redirect("ActualizarOC.aspx?idOC" + 1);
        }

        protected void btnEnviarEmailOC_Click(object sender, EventArgs e)
        {
           
           // GridViewRow OC = (GridViewRow)((Button)sender).Parent.Parent;
           // int i = OC.RowIndex;
           // DTO_OC aux = new DTO_OC();
           // aux.OC_idOrdenCompra = Convert.ToInt32(GridViewOC.Rows[i].Cells[0].Text);
           //Session.Add("indice", aux);
           // ctr_oc = new CTR_OC();
           // ctr_oc.Enviar_OC(aux);
        }

        protected void GridViewOC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //GridViewRow OC = (GridViewRow)((Button)sender).Parent.Parent;
            //DTO_OC OCAux = new DTO_OC();
            //int i = OC.RowIndex;
            //OCAux.OC_idOrdenCompra = Convert.ToInt32(GridViewOC.Rows[i].Cells[0].Text);
            //ctr_oc = new CTR_OC();
            //ctr_oc.Eliminar_OC(OCAux);
            //GridViewOC.DeleteRow(i);
            //Response.Write("<script languaje=javascript> alert('Eliminado Corectamente');</script>");
        }
    }
}