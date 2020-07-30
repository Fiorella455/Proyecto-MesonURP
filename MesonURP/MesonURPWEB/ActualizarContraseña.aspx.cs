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
        int state = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            dto_Usuario = new Dto_Usuario();
            ctr_usuario = new Ctr_Usuario();
            dto_Usuario.U_idUsuario = (int)Session["codUsuario"];

            if (!IsPostBack)
            {
                Session["st"] = 1;
                state = (int)Session["st"];

            }
            if(state==1)
            {
                btnCambiarCont.Text = "Verificar";
                txtContraseñaN.Visible = false;
                txtContraseñaNR.Visible = false;
                lblContraseñaN.Visible = false;
                lblContraseñaNR.Visible = false;
            }

        }
        public void Verificar_Contraseña_Actual()
        {

            if (txtContraseñaAct.Text != "")
            {
                if (ctr_usuario.getContraseñaU(dto_Usuario))
                {
                    if (dto_Usuario.U_Contraseña == txtContraseñaAct.Text)
                    {
                        lblMsj.Text = "Contraseña Correcta";
                        btnCambiarCont.Text = "Cambiar Contraseña";
                        txtContraseñaN.Visible = true;
                        txtContraseñaNR.Visible = true;
                        lblContraseñaN.Visible = true;
                        lblContraseñaNR.Visible = true;
                        Session["st"]=2;
                    }
                    else
                    {
                        lblMsj.Text = "Contraseña Incorrecta";
                       
                    }
                }
            }
            else { lblMsj.Text = "Escriba su contraseña actual"; }
            
        }
        public void Verificar_Nueva_Contraseña()
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
            state = (int)Session["st"];
            if (state==2)
            {
                Verificar_Nueva_Contraseña();
            }
            if(state==1)
            {
                Verificar_Contraseña_Actual();
            }
                     
        }
    }
}