using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;
using System.Windows.Forms;

namespace MesonURPWEB
{
    public partial class GestionarInsumo : System.Web.UI.Page
    {
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();
        CTR_Categoria _Ccat = new CTR_Categoria();
        DTO_Categoria _Dc = new DTO_Categoria();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                buildTableInsumos();
                ListItem ddl1 = new ListItem("10", "10");
                ddlp.Items.Insert(0, ddl1);
                ListItem ddl2 = new ListItem("15", "15");
                ddlp.Items.Insert(1, ddl2);
                ListItem ddl3 = new ListItem("20", "20");
                ddlp.Items.Insert(2, ddl3);
            }
        }
        public void buildTableInsumos()
        {
            gvInsumos.DataSource = _Ci.consultarInsumo();
            gvInsumos.DataBind();
        }
        protected void fNombre_TextChanged(object sender, EventArgs e)
        {
            buildTableInsumos();
        }
        protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsumos.PageIndex = e.NewPageIndex;
            buildTableInsumos();
        }
        protected void gvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "selectItem")
                {
                    int pkInsumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());

                    Session["I_idInsumo"] = pkInsumo;

                    Response.Redirect("ActualizarInsumo.aspx");
                }
                else if (e.CommandName == "selectItem1")//VER 
                {
                    int pkInsumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());

                    this.lblModalTitle.Text = "Validation Errors List for HP7 Citation";
                    this.lblModalBody.Text = "This is modal body";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    this.upModal.Update();

                    //Response.Redirect("ActualizarInsumo.aspx");
                }
                else if (e.CommandName == "selectItem2")//ELIMINAR 
                {
                    int pkInsumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());
                    _Ci.eliminarInsumo(pkInsumo);
                    buildTableInsumos();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvInsumos.PageSize = Convert.ToInt32(ddlp.SelectedValue);
            buildTableInsumos();
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            buildTableInsumos();
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarInsumo.aspx");
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarInsumo.aspx");
        }
         
    }
}