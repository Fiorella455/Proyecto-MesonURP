using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace MesonURPWEB
{
    public partial class Home : System.Web.UI.Page
    {
        Ctr_Usuario _Cu = new Ctr_Usuario();
        Dto_Usuario _Du = new Dto_Usuario();
        Dto_TipoUsuario _Ctu = new Dto_TipoUsuario();
        Dto_TipoUsuario _Dtu = new Dto_TipoUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensajeAyuda.Text = "Ingrese sus datos por favor";
            lblMensaje.Text = "";
        }

        protected void goToIndex(object sender, EventArgs e)
        {
            _Du.U_Correo = correo.Value;
            _Du.U_Contraseña = contraseña.Value;

            bool validaUsuario = _Cu.validarUsuario(_Du);
            if (correo.Value != "" || contraseña.Value != "")
            {
                if (validaUsuario == true)
                {
                    _Du.U_Correo = correo.Value;
                    _Cu.getPerfil(_Du, _Dtu);
                    _Cu.getUsuario(_Du);

                    _Cu.getNomApellUsuario(_Du);
                    Session["NombreUsuario"] = _Du.U_Nombre;
                    Session["ApellidoUsuario"] = _Du.U_APaterno;

                    Session["codUsuario"] = _Du.U_idUsuario;
                    string perfil = _Dtu.TU_NombreTipoUsuario;
                    string[] dataArray = new string[] { _Du.U_Correo, perfil };
                    Session["Login"] = dataArray;
                    if (perfil == "Encargado de Compra")
                    {
                        Response.Redirect("GestionarOC.aspx");
                    }
                    else if (perfil == "Administrador")
                    {
                        Response.Redirect("RegistrarEgreso.aspx");
                    }
                    else
                    {
                    }

                }
            }
            lblMensaje.Text = "Sus datos no son validos, por favor vuelva a intentar";
        }
    }
}