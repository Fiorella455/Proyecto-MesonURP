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
    public partial class ConsultarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        CTR_OC ctr_oc;
        CTR_OCxInsumo ctr_ocxinsumo;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_oc = new CTR_OC();

            dto_oc = (DTO_OC)Session["indice"];
           
                Consultar_OC(dto_oc);

             ctr_ocxinsumo = new CTR_OCxInsumo();
            dt = new DataTable();
            dt = ctr_ocxinsumo.Leer_InsumoxOC(dto_oc.OC_idOrdenCompra);
            GridViewAñadirOC.DataSource = dt;
            GridViewAñadirOC.DataBind();

        }

        public void Consultar_OC(DTO_OC dto_oc)
        {
            
            if (ctr_oc.CTR_Leer_OC(dto_oc)) 
            {

                txtidOC.Text = dto_oc.OC_idOrdenCompra.ToString();
                txtTipoComprobante.Text = dto_oc.OC_TipoComprobante;
                txtFechaEmision.Text = dto_oc.OC_FechaEmision.ToString();
                txtProveedor.Text = dto_oc.P_idProveedor.ToString();
                txtFechaEntrega.Text = dto_oc.OC_FechaEntrega.ToString();
                txtFormaPago.Text = dto_oc.OC_FormaPago;
                //--------------------------------------------------------------
                ctr_ocxinsumo = new CTR_OCxInsumo();
                dt = new DataTable();
                dt = ctr_ocxinsumo.Leer_InsumoxOC(dto_oc.OC_idOrdenCompra);
                GridViewAñadirOC.DataSource = dt;
                GridViewAñadirOC.DataBind();
            }

        }

        protected void GridViewAñadirOC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
             GridViewAñadirOC.PageIndex = e.NewPageIndex;
        //     Consultar_OC(dto_oc);
        }

        //protected void GridViewAñadirOC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //     GridViewAñadirOC.PageIndex = e.NewPageIndex;
        //     Consultar_OC(dto_oc);
        //}
    }
}