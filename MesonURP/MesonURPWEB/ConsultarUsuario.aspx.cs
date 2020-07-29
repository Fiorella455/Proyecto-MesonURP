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
    public partial class ConsultarUsuario : System.Web.UI.Page
    {
        Ctr_Usuario ctr_usuario;
        Dto_Usuario dto_usuario;
        //---------------------
        CTR_Estado_Usuario ctr_estado_usuario;
        Dto_EstadoUsuario dto_estado_usuario;
        //---------------------
        Ctr_TipoUsuario ctr_tipo_usuario;
        Dto_TipoUsuario dto_tipo_usuario;
        //---------------------
        CTR_Tipo_Documento ctr_tipo_documento;
        DTO_Tipo_Documento dto_tipo_documento;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //--Usuario-----------------------------------------
                int i = (int)Session["id"];
                ctr_usuario = new Ctr_Usuario();
                dto_usuario = ctr_usuario.Consultar_Usuario_ID(i);
                txtNombre.Text = dto_usuario.U_Nombre;
                txtAPaterno.Text = dto_usuario.U_APaterno;
                txtAMaterno.Text = dto_usuario.U_AMaterno;
                txtCelular.Text = dto_usuario.U_Celular;
                txtCorreo.Text = dto_usuario.U_Correo;
                txtDireccion.Text = dto_usuario.U_Direccion;
                txtFecha.Text = dto_usuario.U_FechaNacimiento.ToShortDateString();
                txtSexo.Text = dto_usuario.U_Sexo;
                txtContra.Text = dto_usuario.U_Contraseña;
                txtDni.Text = dto_usuario.U_Dni;
                //--Estado Usuario-----------------------------------------
                ctr_estado_usuario = new CTR_Estado_Usuario();
                dto_estado_usuario = ctr_estado_usuario.Consultar_Estado_Usuario_ID(dto_usuario.EU_idEstadoUsuario);
                txtEstadoUsuario.Text = dto_estado_usuario.EU_NombreEstadoUsuario;
                //--Tipo Usuario-------------------------------------------
                ctr_tipo_usuario = new Ctr_TipoUsuario();
                dto_tipo_usuario = ctr_tipo_usuario.Consultar_Tipo_Usuario_ID(dto_usuario.TU_idTipoUsuario);
                txtTipoUsuario.Text = dto_tipo_usuario.TU_NombreTipoUsuario;
                //--Tipo Documento------------------------------------------
                ctr_tipo_documento = new CTR_Tipo_Documento();
                dto_tipo_documento = ctr_tipo_documento.Consultar_Tipo_Documento_ID(dto_usuario.TD_idTipoDocumento);
                txtTipoDocumento.Text = dto_tipo_documento.TD_NombreTipoDocumento;
            }
        }
    }
}