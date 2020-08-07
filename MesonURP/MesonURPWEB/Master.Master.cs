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

                        menuAdmi.Visible = true;
                        menuOrdenCompra.Visible = false;
                        menuProveedor.Visible = false;
                        menuStock.Visible = true;
                        menuReportes.Visible = true;
                        menuGestionarMerma.Visible = false;
                        menuCategoria.Visible = true;
                        menuUsuarios.Visible = true;
                        menuInsumo.Visible = true;
                        lblRol.Text = perfil;
                        lblNombre.Text = Convert.ToString(Session["NombreUsuario"]);
                        lblApellido.Text = Convert.ToString(Session["ApellidoUsuario"]);
                        break;

                    case "Encargado de Compra":

                        menuEncargado.Visible = true;
                        menuOrdenCompra.Visible = true;
                        menuProveedor.Visible = true;
                        menuStock.Visible = true;
                        menuReportes.Visible = false;
                        menuGestionarMerma.Visible = true;
                        menuCategoria.Visible = false;
                        menuUsuarios.Visible = false;
                        menuInsumo.Visible = false; 
                        lblRol.Text = perfil;
                        lblNombre.Text = Convert.ToString(Session["NombreUsuario"]);
                        lblApellido.Text = Convert.ToString(Session["ApellidoUsuario"]);
                        break;

                    case "Administrador del Sistema":

                        menuASistema.Visible = true;
                        menuOrdenCompra.Visible = false;
                        menuProveedor.Visible = false;
                        menuStock.Visible = false;
                        menuReportes.Visible = false;
                        menuGestionarMerma.Visible = false;
                        menuCategoria.Visible = true;
                        menuUsuarios.Visible = true;
                        menuInsumo.Visible = false;
                        lblRol.Text = perfil;
                        lblNombre.Text = Convert.ToString(Session["NombreUsuario"]);
                        lblApellido.Text = Convert.ToString(Session["ApellidoUsuario"]);
                        break;

                }
                
            }

        }

        protected void btnSalida_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            HttpContext.Current.Session.Abandon();
            Response.Redirect("Home.aspx?x=2");
        }
    }
}