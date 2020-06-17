using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login();
        }
        public void Login()
        {
            if (Session["Login"] != null)
            {

                string perfil = Convert.ToString(Session["TipoPerfil"]);

                switch (perfil)
                {
                    case "Administrador":

                        menuOrdenCompra.Visible = false;
                        menuProveedor.Visible = false;
                        menuGestionarDevoluciones.Visible = false;
                        menuStock.Visible = true;
                        menuRecursos.Visible = true;
                        menuReportes.Visible = false;
                        lblRol.Text = perfil;
                        lblNombre.Text = Convert.ToString(Session["NombreUsuario"]);
                        lblApellido.Text = Convert.ToString(Session["ApellidoUsuario"]);
                        break;

                    case "Encargado de Compra":

                        menuOrdenCompra.Visible = true;
                        menuProveedor.Visible = false;
                        menuGestionarDevoluciones.Visible = false;
                        menuStock.Visible = true;
                        menuRecursos.Visible = true;
                        menuReportes.Visible = false;
                        lblRol.Text = perfil;
                        lblNombre.Text = Convert.ToString(Session["NombreUsuario"]);
                        lblApellido.Text = Convert.ToString(Session["ApellidoUsuario"]);
                        break;

                }
                
            }

        }

        protected void btnSalida_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}