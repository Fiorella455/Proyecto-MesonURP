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
    public partial class GestionarUsuario : System.Web.UI.Page
    {
        Ctr_Usuario ctr_usuario;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ctr_usuario = new Ctr_Usuario();
                ds = ctr_usuario.Consultar_Usuarios();
                GridViewUsuario.DataSource = ds;
                GridViewUsuario.DataBind();
            }
        }

        protected void GridViewUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActualizarUsuario")
            {
                int id = Convert.ToInt32(GridViewUsuario.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["U_idUsuario"].ToString());
                Session.Add("id", id);
                Response.Redirect("ActualizarUsuario");
            }
            else if(e.CommandName== "ConsultarUsuario")
            {
                int id = Convert.ToInt32(GridViewUsuario.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["U_idUsuario"].ToString());
                Session.Add("id", id);
                Response.Redirect("ConsultarUsuario");
            }
            else if(e.CommandName== "EliminarUsuario")
            {
                Ctr_Usuario cu = new Ctr_Usuario();
                int id = Convert.ToInt32(GridViewUsuario.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["U_idUsuario"].ToString());
                cu.Eliminar_Usuario(id);
                ds = cu.Consultar_Usuarios();
                GridViewUsuario.DataSource = ds;
                GridViewUsuario.DataBind();
            }

        }

        protected void GridViewUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                e.Row.Cells[7].Text = Convert.ToDateTime(e.Row.Cells[7].Text).ToShortDateString();
                string estado = e.Row.Cells[12].Text;
                if(estado=="Activo") e.Row.Cells[16].Controls.Clear();

            }
        }
    }
}