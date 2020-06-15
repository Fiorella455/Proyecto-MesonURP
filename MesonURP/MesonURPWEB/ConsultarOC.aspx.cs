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
    public partial class ConsultarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        CTR_OC ctr_oc;

        public ConsultarOC() { }
        public ConsultarOC(DTO_OC dto_oc_aux)
        {
            dto_oc.OC_idOrdenCompra = dto_oc_aux.OC_idOrdenCompra;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dto_oc=new DTO_OC();
                ctr_oc = new CTR_OC();
            }
        }

        public void Consultar_OC()
        {
            
            if (ctr_oc.CTR_Leer_OC(dto_oc))
            {
                txtNumeroOC.Text = dto_oc.OC_TipoComprobante;
                txtFechaEntrega.Text = dto_oc.OC_NumeroComprobante;
                txtEstado.Text = dto_oc.OC_TotalCompra.ToString();
                txtFechaEmision.Text = dto_oc.OC_FechaEmision.ToString();
                txtFechaPago.Text = dto_oc.OC_FechaEntrega.ToString();
                txtFormaPago.Text = dto_oc.OC_FormaPago;
                txtProveedor.Text = dto_oc.P_idProveedor.ToString();
            }
            else
            {
                Response.Write("<script languaje=javascript> alert('Orden de Comprar no encontrada);</script>");
            }

        }
    }
}