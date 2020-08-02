using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Data;

namespace MesonURPWEB
{
    public partial class AñadirUsuario : System.Web.UI.Page
    {
        DataSet dsTipoDocumento, dsTipoUsuario;
        //-------------------------------------
        CTR_Tipo_Documento ctr_tipo_documento;
        //-------------------------------------
        Ctr_TipoUsuario ctr_tipo_usuario;
        //-------------------------------------
        Ctr_Usuario ctr_usuario;
        Dto_Usuario dto_usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_usuario = new Ctr_Usuario();
            dto_usuario = new Dto_Usuario();
            if (!IsPostBack)
            {
                ctr_tipo_documento = new CTR_Tipo_Documento();
                dsTipoDocumento = ctr_tipo_documento.Consultar_Tipos_Documento();

                DdlTipoDocumento.DataTextField = "TD_NombreTipoDocumento";
                DdlTipoDocumento.DataValueField = "TD_idTipoDocumento";
                DdlTipoDocumento.DataSource = dsTipoDocumento;
                DdlTipoDocumento.DataBind();
                //----------------------------------------------------------
                ctr_tipo_usuario = new Ctr_TipoUsuario();
                dsTipoUsuario = ctr_tipo_usuario.Consultar_Tipos_Usuario();

                DdlTipoUsuario.DataTextField = "TU_NombreTipoUsuario";
                DdlTipoUsuario.DataValueField = "TU_idTipoUsuario";
                DdlTipoUsuario.DataSource = dsTipoUsuario;
                DdlTipoUsuario.DataBind();

            }

        }

        protected void btnAñadirUsuario_Click(object sender, EventArgs e)
        {
            dto_usuario.U_Nombre = txtNombre.Text;
            dto_usuario.U_APaterno = txtAPaterno.Text;
            dto_usuario.U_AMaterno = txtAMaterno.Text;
            dto_usuario.U_Celular = txtCelular.Text;
            dto_usuario.U_Correo = txtCorreo.Text;
            dto_usuario.U_Direccion = txtDireccion.Text;
            dto_usuario.U_FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            //dto_usuario.U_Sexo = txtSexo.Text;
            dto_usuario.U_Sexo = ddlSexo.SelectedValue;
            dto_usuario.U_Contraseña = txtContra.Text;
            dto_usuario.U_Dni = txtDni.Text;
            dto_usuario.TU_idTipoUsuario = Convert.ToInt32(DdlTipoUsuario.SelectedValue);
            dto_usuario.EU_idEstadoUsuario = 1;
            dto_usuario.TD_idTipoDocumento = Convert.ToInt32(DdlTipoDocumento.SelectedValue);
           // ctr_usuario.Registrar_Usuario(dto_usuario);
         //   Response.Redirect("GestionarUsuario.aspx");

            if (ctr_usuario.Existe_Usuario(dto_usuario))
            {
                ScriptManager.RegisterClientScriptBlock(this.panelAñadirUser, this.panelAñadirUser.GetType(), "alert", "alertaExiste()", true);

            }
            else
            {
                ctr_usuario.Registrar_Usuario(dto_usuario);
                ScriptManager.RegisterClientScriptBlock(this.panelAñadirUser, this.panelAñadirUser.GetType(), "alert", "alertaExito()", true);

            }
        }

        protected void DdlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(DdlTipoDocumento.SelectedValue) == 1)//este valor se puede cambiar según como se encuentre en la BD
            {
                revNumDoc.ValidationExpression = @"\d{8}";
                revNumDoc.ErrorMessage = "DNI Inválido";
            }//DNI
            else if (int.Parse(DdlTipoDocumento.SelectedValue) == 2)
            {
                revNumDoc.ValidationExpression = @"([A-Z]|\d){10,12}";
                revNumDoc.ErrorMessage = "Pasaporte Inválido";
            }//PASAPORTE
            else if (int.Parse(DdlTipoDocumento.SelectedValue) == 3)
            {
                revNumDoc.ValidationExpression = @"\d{10,12}";
                revNumDoc.ErrorMessage = "RUC Inválido";
            }//Ruc
        }


    }
}