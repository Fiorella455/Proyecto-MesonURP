using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

namespace MesonURPWEB
{
    public partial class GestionarProveedor : System.Web.UI.Page
    {
        CTR_Proveedor ctr_pro;
        DataSet dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ctr_pro = new CTR_Proveedor();
                dt = new DataSet();
                dt = ctr_pro.Leer_Proveedor();
                GridViewProveedor.DataSource = dt;
                GridViewProveedor.DataBind();
            }
        }

        protected void GridViewProveedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "ActualizarProveedor")
            {
                int id = Convert.ToInt32(GridViewProveedor.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["P_idProveedor"].ToString());
                Session.Add("id",id);
                Response.Redirect("ActualizarProveedor");
            }
            if (e.CommandName == "ConsultarProveedor")
            {
                int id = Convert.ToInt32(GridViewProveedor.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["P_idProveedor"].ToString());
                Session.Add("id", id);
                Response.Redirect("ConsultarProveedor");
            }
            if (e.CommandName == "EliminarProveedor")
            {
                //ScriptManager.RegisterClientScriptBlock(this.panelEliProv,this.panelEliProv.GetType(),"alert", "deleteProv()", true);
                 ClientScript.RegisterStartupScript(this.GetType(), "alert" , "deleteProv()", true);
                
                CTR_Proveedor cp = new CTR_Proveedor();
                int id = Convert.ToInt32(GridViewProveedor.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["P_idProveedor"].ToString());
                //Session.Add("id", id);
                cp.Eliminar_Proveedor(id);
                dt = new DataSet();
                dt = cp.Leer_Proveedor();
                GridViewProveedor.DataSource = dt;
                GridViewProveedor.DataBind();
                //Response.Redirect("EliminarProveedor.aspx");
            }
        }

        protected void GridViewProveedor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                CTR_Proveedor p = new CTR_Proveedor();
                bool abierto=p.Existe_Proveedor_OC(e.Row.Cells[1].Text);
                //string estado = e.Row.Cells[8].Text.ToString();
                //if(estado=="Activo")e.Row.Cells[11].Controls.Clear();
                if (abierto)e.Row.Cells[11].Controls.Clear();
                
            }
        }
        protected void btnRegistrarP_Click(object sender, EventArgs e)
        {
            Response.Redirect("AñadirProveedor");
        }
    }
}