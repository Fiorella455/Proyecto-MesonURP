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
        int i;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_oc = new CTR_OC();
            //int indice = (int)Session["indice"];
            dto_oc = (DTO_OC)Session["indice"];
           // dto_oc = new DTO_OC();
           // Consultar_OC(indice);
            if (!IsPostBack)
            {
               
                txtProveedor.Text = dto_oc.OC_TipoComprobante;
                txtFormaPago.Text = dto_oc.OC_NumeroComprobante;
                txtFechaEntrega.Text = dto_oc.OC_FechaEntrega.ToString();
                txtProveedor.Text = dto_oc.P_idProveedor.ToString();
                txtFechaPago.Text = dto_oc.OC_FechaEntrega.ToString();
                txtFormaPago.Text = dto_oc.OC_FormaPago;
            }
        }

        public void Consultar_OC(int i)
        {
            
            if (ctr_oc.CTR_Leer_OC(i)) 
            {
                txtNumeroOC.Text = dto_oc.OC_TipoComprobante;
                txtFechaEmision.Text = dto_oc.OC_FechaEmision.ToString();
                txtFechaEntrega.Text = dto_oc.OC_NumeroComprobante;
                txtEstado.Text = dto_oc.OC_TotalCompra.ToString();
                txtProveedor.Text = dto_oc.P_idProveedor.ToString();
                txtFechaPago.Text = dto_oc.OC_FechaEntrega.ToString();
                txtFormaPago.Text = dto_oc.OC_FormaPago;
                
            }
            else
            {
                Response.Write("<script languaje=javascript> alert('Orden de Comprar no encontrada);</script>");
            }


        }
    }
}