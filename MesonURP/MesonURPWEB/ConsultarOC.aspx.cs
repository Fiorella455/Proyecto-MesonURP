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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_oc = new CTR_OC();

            dto_oc = (DTO_OC)Session["indice"];
           
                Consultar_OC(dto_oc);   
        }

        public void Consultar_OC(DTO_OC dto_oc)
        {
            
            if (ctr_oc.CTR_Leer_OC(dto_oc)) 
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