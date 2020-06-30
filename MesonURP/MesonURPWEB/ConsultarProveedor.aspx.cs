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
    public partial class ConsultarProveedor : System.Web.UI.Page
    {
        DTO_Proveedor dto_proveedor;
        CTR_Proveedor ctr_proveedor;
        //----------------------------
        DTO_Estado_Proveedor dto_estado_proveedor;
        CTR_Estado_Proveedor ctr_estado_proveedor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int i = (int)Session["id"];
                ctr_proveedor = new CTR_Proveedor();
                dto_proveedor = ctr_proveedor.Consultar_Proveedor(i);
                txtRazonSocial.Text = dto_proveedor.P_RazonSocial;
                txtNumeroDoc.Text = dto_proveedor.P_NumeroDocumento;
                txtDireccion.Text = dto_proveedor.P_Direccion;
                txtNombre.Text = dto_proveedor.P_NombreContacto;
                txtTelefono.Text = dto_proveedor.P_TelefonoContacto;
                txtCorreo.Text = dto_proveedor.P_CorreoContacto;
                //-----------------------------------------------
                ctr_estado_proveedor = new CTR_Estado_Proveedor();
                dto_estado_proveedor = ctr_estado_proveedor.Consultar_Estado_Proveedor_ID(dto_proveedor.EP_idEstadoProveedor);
                txtEstado.Text = dto_estado_proveedor.EP_NombreEstadoProveedor;
            }
        }
    }
}