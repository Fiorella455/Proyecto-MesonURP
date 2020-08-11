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
    public partial class ActualizarUsuario : System.Web.UI.Page
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
        //---------------------
        DataSet dsTipoDocumento, dsTipoUsuario, dsEstadoUsuario;
        int i;


        protected void DdlTipoDocumento_SelectedIndexChanged1(object sender, EventArgs e)
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
                revNumDoc.ValidationExpression = @"(10|15|16|17|20)\d{9}";
                revNumDoc.ErrorMessage = "RUC Inválido";
            }//Ruc
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            i = (int)Session["id"];
            ctr_usuario = new Ctr_Usuario();
            dto_usuario = new Dto_Usuario();
            if (!IsPostBack)
            {
                //--Usuario-----------------------------------------


                dto_usuario = ctr_usuario.Consultar_Usuario_ID(i);
                txtNombre.Text = dto_usuario.U_Nombre;
                txtAPaterno.Text = dto_usuario.U_APaterno;
                txtAMaterno.Text = dto_usuario.U_AMaterno;
                txtCelular.Text = dto_usuario.U_Celular;
                txtCorreo.Text = dto_usuario.U_Correo;
                txtDireccion.Text = dto_usuario.U_Direccion;
                txtFecha.Text = dto_usuario.U_FechaNacimiento.ToString("yyyy-MM-dd");
                ddlSexo.SelectedValue = dto_usuario.U_Sexo;
                txtContra.Text = dto_usuario.U_Contraseña;
                txtDni.Text = dto_usuario.U_Dni;
                //--Estado Usuario-----------------------------------------
                ctr_estado_usuario = new CTR_Estado_Usuario();
                dto_estado_usuario = ctr_estado_usuario.Consultar_Estado_Usuario_ID(dto_usuario.EU_idEstadoUsuario);
                // txtEstadoUsuario.Text = dto_estado_usuario.EU_NombreEstadoUsuario;
                dsEstadoUsuario = ctr_estado_usuario.Consultar_Estados_Usuario();

                DdlEstadoUsuario.DataTextField = "EU_NombreEstadoUsuario";
                DdlEstadoUsuario.DataValueField = "EU_idEstadoUsuario";
                DdlEstadoUsuario.DataSource = dsEstadoUsuario;
                DdlEstadoUsuario.DataBind();
                DdlEstadoUsuario.SelectedIndex = dto_estado_usuario.EU_idEstadoUsuario - 1;

                //--Tipo Usuario-------------------------------------------
                ctr_tipo_usuario = new Ctr_TipoUsuario();
                dto_tipo_usuario = ctr_tipo_usuario.Consultar_Tipo_Usuario_ID(dto_usuario.TU_idTipoUsuario);
                // txtTipoUsuario.Text = dto_tipo_usuario.TU_NombreTipoUsuario;
                dsTipoUsuario = ctr_tipo_usuario.Consultar_Tipos_Usuario();

                DdlTipoUsuario.DataTextField = "TU_NombreTipoUsuario";
                DdlTipoUsuario.DataValueField = "TU_idTipoUsuario";
                DdlTipoUsuario.DataSource = dsTipoUsuario;
                DdlTipoUsuario.DataBind();
                DdlTipoUsuario.SelectedIndex = dto_tipo_usuario.TU_idTipoUsuario - 1;  

                //--Tipo Documento------------------------------------------
                ctr_tipo_documento = new CTR_Tipo_Documento();
                dto_tipo_documento = ctr_tipo_documento.Consultar_Tipo_Documento_ID(dto_usuario.TD_idTipoDocumento);
               // txtTipoDocumento.Text = dto_tipo_documento.TD_NombreTipoDocumento;
                dsTipoDocumento = ctr_tipo_documento.Consultar_Tipos_Documento();

                DdlTipoDocumento.DataTextField = "TD_NombreTipoDocumento";
                DdlTipoDocumento.DataValueField = "TD_idTipoDocumento";
                DdlTipoDocumento.DataSource = dsTipoDocumento;
                DdlTipoDocumento.DataBind();
                DdlTipoDocumento.SelectedIndex = dto_tipo_documento.TD_idTipoDocumento - 1;




            }
        }

        protected void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            dto_usuario.U_idUsuario = i;
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
            dto_usuario.EU_idEstadoUsuario = Convert.ToInt32(DdlEstadoUsuario.SelectedValue);
            dto_usuario.TD_idTipoDocumento = Convert.ToInt32(DdlTipoDocumento.SelectedValue);
            //   ctr_usuario.Actualizar_Usuario(dto_usuario);
            // Response.Redirect("GestionarUsuario.aspx");

            Dto_Usuario aux = ctr_usuario.Consultar_Usuario_ID(i);

            if (ctr_usuario.Existe_Usuario(dto_usuario) && aux.U_Dni != txtDni.Text && aux.TD_idTipoDocumento!=Convert.ToInt32(DdlTipoDocumento.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(this.panelActualizarUser, this.panelActualizarUser.GetType(), "alert", "alertaExiste()", true);

            }
            else
            {
                ctr_usuario.Actualizar_Usuario(dto_usuario);
                ScriptManager.RegisterClientScriptBlock(this.panelActualizarUser, this.panelActualizarUser.GetType(), "alert", "alertaExito()", true);

            }
        }
    }
}