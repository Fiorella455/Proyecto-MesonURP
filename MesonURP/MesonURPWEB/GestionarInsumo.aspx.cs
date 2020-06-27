using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

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
            getTableInsumos();

        }
        public void getTableInsumos()
        {
            gvInsumos.DataSource = _Ci.consultarInsumo();
            gvInsumos.DataBind();
        }
        protected void gvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "selectItem")
                {

                    int pkInsumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());

                    Session["I_idInsumo"] = pkInsumo;

                    Response.Redirect("RegistrarInsumo.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}