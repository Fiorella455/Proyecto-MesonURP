using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;

namespace MesonURPWEB
{
    public partial class ActualizarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        DTO_Medida dto_medida = new DTO_Medida();
        CTR_Medida ctr_medida = new CTR_Medida();
        CTR_OC ctr_oc = new CTR_OC();
        CTR_Proveedor pro = new CTR_Proveedor();
        CTR_Estado_OC ctr_Estado_OC = new CTR_Estado_OC();
        DataSet dtestado;
        CTR_OCxInsumo ctr_ocxinsumo = new CTR_OCxInsumo();
        CTR_Insumo ctr_insumo = new CTR_Insumo();
        DataTable dt;
        DataSet dtpro = new DataSet();
        DTO_Estado_OCxOC dto_estado_OCxOC = new DTO_Estado_OCxOC();
        DAO_EstadoOCxOC dao_estadoOCxOC = new DAO_EstadoOCxOC();
        CTR_EstadoOCxOC ctr_estado_OCxOC = new CTR_EstadoOCxOC();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_oc = (DTO_OC)Session["OCActual"];
           
            //dtcat = new DataSet();
            //dtins = new DataSet();
            
            if (!IsPostBack)
            {
                dtestado = new DataSet();
                //dtestado = ctr_Estado_OC.Leer_Estado_OC();
                //listarInsumo();

                //DdlEstado.DataTextField = "EOC_NombreEstadoOC";
                //DdlEstado.DataValueField = "EOC_idEstadoOC";
                //DdlEstado.DataSource = dtestado;
                //DdlEstado.DataBind();

                //------------------------------------------------
                dtpro = new DataSet();
                dtpro = pro.Leer_Proveedor();

                DdlProveedor.DataTextField = "P_RazonSocial";
                DdlProveedor.DataValueField = "P_idProveedor";
                DdlProveedor.DataSource = dtpro;
                DdlProveedor.DataBind();
                
                //--------------------------------------------Llenar 

                ctr_oc.CTR_Leer_OC(dto_oc);
                txtIdOC.Text = dto_oc.OC_idOrdenCompra.ToString();
                txtTipoComprobante.Text = dto_oc.OC_TipoComprobante;             
                //txtFechaEmision.Text = dto_oc.OC_FechaEmision.ToShortDateString();           
                //txtEstado.Text = dao_estadoOCxOC.Consultar_Estado_OCxOC(dto_oc.OC_idOrdenCompra).EOC_NombreEstadoOC;
                txtFechaEntrega.Text = dto_oc.OC_FechaEntrega.ToShortDateString();
                DdlProveedor.Text = dto_oc.P_idProveedor.ToString();
                txtFormaPago.Text = dto_oc.OC_FormaPago;
                txtTotal.Text = dto_oc.OC_TotalCompra.ToString();
                //-------------------------------------------------------
                ctr_ocxinsumo = new CTR_OCxInsumo();
                dt = new DataTable();
                dt = ctr_ocxinsumo.Leer_InsumoxOC(dto_oc.OC_idOrdenCompra);
                GridViewEditarOC.DataSource = dt;
                GridViewEditarOC.DataBind();

            }
        }
        public void listarInsumo()
        {
            DdlInsumo.DataSource = ctr_insumo.SelectInsumosOC();
            DdlInsumo.DataTextField = "I_NombreInsumo";
            DdlInsumo.DataValueField = "I_idInsumo";
            DdlInsumo.DataBind();
            DdlInsumo.Items.Insert(0, "--seleccionar--");
        }
        protected void DdlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecioU.Text = ctr_insumo.SelectPrecioUnitario(Convert.ToInt32(DdlInsumo.SelectedValue));
            txtMedida.Text = ctr_medida.BuscarMedida(Convert.ToInt32(DdlInsumo.SelectedValue));
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            dto_oc.OC_idOrdenCompra = int.Parse(txtIdOC.Text);
            dto_oc.OC_TipoComprobante = txtTipoComprobante.Text;
            dto_oc.OC_TipoComprobante = txtTipoComprobante.Text;
          //  dto_oc.OC_FechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
            dto_oc.OC_FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            dto_oc.OC_FormaPago = txtFormaPago.Text;
            dto_oc.OC_FechaPago = Convert.ToDateTime(txtFechaEntrega.Text);
            dto_oc.P_idProveedor = int.Parse(DdlProveedor.SelectedValue);
            ctr_oc.Actualizar_OC(dto_oc);
            dto_oc.OC_TotalCompra = Convert.ToDecimal(txtTotal.Text);
            //-----------------------------------

            dto_estado_OCxOC.OC_idOrdenCompra = dto_oc.OC_idOrdenCompra;
            dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
            dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
            ctr_estado_OCxOC.Actualizar_Estado_OCxOC(dto_estado_OCxOC);
            //--------------------------------------------------------------
            GridViewRow OCxI = (GridViewRow)((Button)sender).Parent.Parent;
            DTO_OCxInsumo OCIAux = new DTO_OCxInsumo();
            int i = OCxI.RowIndex;
            OCIAux.R_idInsumo = Convert.ToInt32(GridViewEditarOC.Rows[i].Cells[1].Text);
            OCIAux.I_idInsumo = Convert.ToInt32(GridViewEditarOC.Rows[i].Cells[2].Text);
            OCIAux.OC_idOrdenCompra = Convert.ToInt32(GridViewEditarOC.Rows[i].Cells[3].Text);
            OCIAux.OCxI_Cantidad = Convert.ToDecimal(GridViewEditarOC.Rows[i].Cells[4].Text);
            OCIAux.OCxI_PrecioTotal = Convert.ToDecimal(GridViewEditarOC.Rows[i].Cells[5].Text);
            Session.Add("OCIAux", OCIAux);

            Response.Redirect("GestionarOC.aspx");
        }

    }
}