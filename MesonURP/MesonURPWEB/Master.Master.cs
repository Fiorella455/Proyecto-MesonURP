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
                li1.Visible = false;
                li2.Visible = false;
                li3.Visible = false;
                li4.Visible = false;
                //li4.Visible = false;
                //li5.Visible = false;
                //li6.Visible = false;
                //li7.Visible = false;
                //li8.Visible = false;

                string[] localarray = (string[])Session["Login"];
                string perfil = localarray[1];

                if (perfil == "Encargado de Compra")
                {
                    string nombre = localarray[0];
                    li1.Visible = true;
                    li2.Visible = true;
                    li3.Visible = true;
                    li4.Visible = true;
                    li5.Visible = true;
                    lblNombre.Text = Convert.ToString(Session["NombreUsuario"]);
                    lblApellido.Text = Convert.ToString(Session["ApellidoUsuario"]);
                }

                else if (perfil == "Administrador")
                {
                    string nombre = localarray[0];
                    li5.Visible = true;
                    li7.Visible = true;
                    li9.Visible = true;
                    lblNombre.Text = Convert.ToString(Session["NombreUsuario"]);
                    lblApellido.Text = Convert.ToString(Session["ApellidoUsuario"]);
                }

                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }

        protected void btnSalida_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}