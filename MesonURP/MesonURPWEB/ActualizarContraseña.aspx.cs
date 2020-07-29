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
    public partial class ActualizarContraseña : System.Web.UI.Page
    {
        Dto_Usuario dto_Usuario;
        Ctr_Usuario ctr_usuario;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_Usuario = new Dto_Usuario();
            ctr_usuario = new Ctr_Usuario();

            dto_Usuario.U_idUsuario = (int)Session["codUsuario"];
            if (ctr_usuario.getContraseñaU(dto_Usuario))
            {
                txtContraseñaAct.Text = dto_Usuario.U_Contraseña;
            }
        }

        public void Verificar_Contraseña()
        {
            if (txtContraseñaN.Text != "" && txtContraseñaNR.Text != "")
            {
                if (txtContraseñaN.Text.Equals(txtContraseñaNR.Text))
                {
                    dto_Usuario.U_Contraseña = txtContraseñaN.Text;
                    ctr_usuario.Cambiar_Contraseña(dto_Usuario);
                    lblMsj.Text = "Contraseña actualizada correctamente";
                }

                else
                {
                    lblMsj.Text = "Las contraseñas no coinciden";
                }
            }
            else 
            {
                lblMsj.Text = "Ingrese una nueva contraseña";
            }
           
        }

        protected void btnCambiarCont_Click(object sender, EventArgs e)
        {
            Verificar_Contraseña();
            
        }
    }
}