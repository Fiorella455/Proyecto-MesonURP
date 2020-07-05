﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

namespace MesonURPWEB
{
    public partial class AñadirProveedor : System.Web.UI.Page
    {
        DataSet dsTipoDocumento;
        CTR_Tipo_Documento ctr_tipo_documento;
        //-----------------------------------
        DTO_Proveedor dto_proveedor;
        CTR_Proveedor ctr_proveedor;
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_proveedor = new DTO_Proveedor();
            ctr_proveedor = new CTR_Proveedor();
            if (!IsPostBack)
            {
                ctr_tipo_documento = new CTR_Tipo_Documento();
                dsTipoDocumento = new DataSet();
                dsTipoDocumento = ctr_tipo_documento.Consultar_Tipos_Documento();

                DdlTipoDocumento.DataTextField = "TD_NombreTipoDocumento";
                DdlTipoDocumento.DataValueField = "TD_idTipoDocumento";
                DdlTipoDocumento.DataSource = dsTipoDocumento;
                DdlTipoDocumento.DataBind();
            }
            
        }

        protected void btnAñadirProveedor_Click(object sender, EventArgs e)
        {
            dto_proveedor.P_RazonSocial = txtRazonSocial.Text;
            dto_proveedor.TD_idTipoDocumento = Convert.ToInt32(DdlTipoDocumento.SelectedValue);
            dto_proveedor.P_NumeroDocumento = txtNumeroDoc.Text;
            dto_proveedor.P_Direccion = txtDireccion.Text;
            dto_proveedor.P_NombreContacto = txtNombre.Text;
            dto_proveedor.P_TelefonoContacto = txtTelefono.Text;
            dto_proveedor.P_CorreoContacto = txtCorreo.Text;
            dto_proveedor.EP_idEstadoProveedor = 1;
            ctr_proveedor.Registrar_Proveedor(dto_proveedor);
            Response.Redirect("GestionarProveedor.aspx");
        }
    }
}