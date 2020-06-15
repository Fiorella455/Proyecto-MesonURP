using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace MesonURPWEB
{
    public partial class ActualizarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        CTR_OC ctr_oc;
        CTR_Estado_OC ctr_Estado_OC;
        DataSet dtestado;
        CTR_OCxInsumo ctr_ocxinsumo;
        DataTable dt;
        DTO_Estado_OCxOC dto_estado_OCxOC;
        CTR_EstadoOCxOC ctr_estado_OCxOC;
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_oc = (DTO_OC)Session["OCActual"];
            ctr_oc = new CTR_OC();
            dto_estado_OCxOC = new DTO_Estado_OCxOC();
            ctr_estado_OCxOC = new CTR_EstadoOCxOC();
            if (!IsPostBack)
            {
                ctr_Estado_OC = new CTR_Estado_OC();
                dtestado = new DataSet();
                dtestado = ctr_Estado_OC.Leer_Estado_OC();

               // DdlEstado.DataTextField = "EOC_NombreEstadoOC";
               // Estados.DataValueField = "EOC_idEstadoOC";
               //Estados.DataSource = dtestado;
               //Estados.DataBind();


                txtIdOC.Text = dto_oc.OC_idOrdenCompra.ToString();
                txtTipoCom.Text = dto_oc.OC_TipoComprobante;
                txtNumeroCom.Text = dto_oc.OC_NumeroComprobante;
                //txtTotalCompra.Text = dto_oc.OC_TotalCompra.ToString();
                txtFechaEmision.Text = dto_oc.OC_FechaEmision.ToShortDateString();
                DdlProveedor.Text = dto_oc.P_idProveedor.ToString();

                ctr_ocxinsumo = new CTR_OCxInsumo();
                dt = new DataTable();
                dt = ctr_ocxinsumo.Leer_InsumoxOC(dto_oc.OC_idOrdenCompra);
                GridViewAñadirOC.DataSource = dt;
                GridViewAñadirOC.DataBind();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            dto_oc.OC_idOrdenCompra = int.Parse(txtIdOC.Text);
            dto_oc.OC_TipoComprobante = txtTipoCom.Text;
            dto_oc.OC_NumeroComprobante = txtNumeroCom.Text;
           // dto_oc.OC_TotalCompra = Convert.ToDecimal(txtTotalCompra.Text);
            dto_oc.P_idProveedor = int.Parse(DdlProveedor.SelectedValue);
            ctr_oc.Actualizar_OC(dto_oc);
            //-----------------------------------
            
            dto_estado_OCxOC.OC_idOrdenCompra = dto_oc.OC_idOrdenCompra;
            dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
            dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
            ctr_estado_OCxOC.Actualizar_Estado_OCxOC(dto_estado_OCxOC);

            Response.Redirect("Listas_OC.aspx");
        }

    }
}