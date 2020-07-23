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
        char contr_1;
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_Usuario.U_idUsuario=(int)Session["codUsuario"];
            if (ctr_usuario.getContraseñaU(dto_Usuario))
            {
                txtContraseñaAct.Text = dto_Usuario.U_Contraseña;
            }
        }

        public void Verificar_Contraseña()
        {
            contr_1 = Convert.ToChar(txtContraseñaAct0.Text);
        }
    }
}