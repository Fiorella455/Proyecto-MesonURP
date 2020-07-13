using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Data;

namespace MesonURPWEB
{
    public partial class ActualizarProveedor : System.Web.UI.Page
    {
        
        //----------------------------
        DTO_Proveedor dto_proveedor;
        CTR_Proveedor ctr_proveedor;
        //----------------------------
        DTO_Estado_Proveedor dto_estado_proveedor;
        CTR_Estado_Proveedor ctr_estado_proveedor;
        DataSet dsEstado_Proveedor;
        //----------------------------
        DTO_Tipo_Documento dto_tipo_documento;
        CTR_Tipo_Documento ctr_tipo_documento;
        DataSet dsTipoDocumento;
        //----------------------------
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            i = (int)Session["id"];
            dto_proveedor = new DTO_Proveedor();
            ctr_proveedor = new CTR_Proveedor();
            if(!IsPostBack)
            {
                //Mostrar Proveedor-----------------------------------------------
                dto_proveedor = ctr_proveedor.Consultar_Proveedor(i);
                txtRazonSocial.Text = dto_proveedor.P_RazonSocial;
                txtNumeroDoc.Text = dto_proveedor.P_NumeroDocumento;
                txtDireccion.Text = dto_proveedor.P_Direccion;
                txtNombre.Text = dto_proveedor.P_NombreContacto;
                txtTelefono.Text = dto_proveedor.P_TelefonoContacto;
                txtCorreo.Text = dto_proveedor.P_CorreoContacto;
                //Mostrar Estado Proveedor-----------------------------------------------
                ctr_estado_proveedor = new CTR_Estado_Proveedor();
                dto_estado_proveedor = ctr_estado_proveedor.Consultar_Estado_Proveedor_ID(dto_proveedor.EP_idEstadoProveedor);
                txtEstado.Text = dto_estado_proveedor.EP_NombreEstadoProveedor;
                //Mostrar en el Ddl el estado actual y los demas
                dsEstado_Proveedor = new DataSet();
                dsEstado_Proveedor = ctr_estado_proveedor.Consultar_Estados_Proveedor();
                DdlEstado.DataTextField = "EP_NombreEstadoProveedor";
                DdlEstado.DataValueField = "EP_idEstadoProveedor";
                DdlEstado.DataSource = dsEstado_Proveedor;
                DdlEstado.DataBind();
                DdlEstado.SelectedIndex = dto_estado_proveedor.EP_idEstadoProveedor - 1;
                //Mostrar Tipo Documento-----------------------------------------------
                ctr_tipo_documento = new CTR_Tipo_Documento();
                dto_tipo_documento = ctr_tipo_documento.Consultar_Tipo_Documento_ID(dto_proveedor.TD_idTipoDocumento);
                txtTipo.Text = dto_tipo_documento.TD_NombreTipoDocumento;
                //Mostrar en el Ddl el tipo actual y los demas-----------------------------------------------
                dsTipoDocumento = new DataSet();
                dsTipoDocumento = ctr_tipo_documento.Consultar_Tipos_Documento();
                DdlTipoDocumento.DataTextField = "TD_NombreTipoDocumento";
                DdlTipoDocumento.DataValueField = "TD_idTipoDocumento";
                DdlTipoDocumento.DataSource = dsTipoDocumento;
                DdlTipoDocumento.DataBind();
                DdlTipoDocumento.SelectedIndex = dto_tipo_documento.TD_idTipoDocumento - 1;
            }


        }

        protected void btnActualizarProveedor_Click(object sender, EventArgs e)
        {
            dto_proveedor.P_idProveedor = i;
            dto_proveedor.P_RazonSocial = txtRazonSocial.Text;
            dto_proveedor.P_NumeroDocumento = txtNumeroDoc.Text;
            dto_proveedor.P_Direccion = txtDireccion.Text;
            dto_proveedor.P_NombreContacto = txtNombre.Text;
            dto_proveedor.P_TelefonoContacto = txtTelefono.Text;
            dto_proveedor.P_CorreoContacto = txtCorreo.Text;
            dto_proveedor.EP_idEstadoProveedor = Convert.ToInt32(DdlEstado.SelectedValue);
            dto_proveedor.TD_idTipoDocumento = Convert.ToInt32(DdlTipoDocumento.SelectedValue);
            DTO_Proveedor aux = ctr_proveedor.Consultar_Proveedor(i);

            if (ctr_proveedor.Hay_Proveedor(dto_proveedor)&&aux.P_RazonSocial!= txtRazonSocial.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this.panelActProv, this.panelActProv.GetType(), "alert", "alertaExiste()", true);

            }
            else
            {
                ctr_proveedor.Actualizar_Proveedor(dto_proveedor);
                ScriptManager.RegisterClientScriptBlock(this.panelActProv, this.panelActProv.GetType(), "alert", "alertaExito()", true);
                
            }

        }

        protected void DdlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(DdlTipoDocumento.SelectedValue) == 5)
            {
                revNumDoc.ValidationExpression = @"\d{8,9}";
                revNumDoc.ErrorMessage = "DNI Inválido";
            }//DNI
            else if (int.Parse(DdlTipoDocumento.SelectedValue) == 6)

            {
                revNumDoc.ValidationExpression = @"([A-Z]|\d){10,12}";
                revNumDoc.ErrorMessage = "Pasaporte Inválido";
            }
        }
    }
}