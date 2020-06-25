using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTO;
using DAO;
using CTR;


namespace MesonURPWEB
{
    public partial class AñadirOC : System.Web.UI.Page
    {
        DTO_OC dto_oc = new DTO_OC();
        CTR_OC ctr_oc = new CTR_OC();
        CTR_Estado_OC ctr_Estado_OC = new CTR_Estado_OC();
        DTO_Estado_OCxOC dto_estado_OCxOC = new DTO_Estado_OCxOC();
        CTR_EstadoOCxOC ctr_estado_OCxOC = new CTR_EstadoOCxOC();
        CTR_Medida _Cm = new CTR_Medida();
        CTR_Insumo ctr_insumo = new CTR_Insumo();
        CTR_Proveedor pro = new CTR_Proveedor();
        DTO_OCxInsumo dto_ocxinsumo = new DTO_OCxInsumo();
        CTR_OCxInsumo ctr_ocxinsumo = new CTR_OCxInsumo();
        DataSet dtestado, dtpro;
        static List<DTO_OCxInsumo> pila = new List<DTO_OCxInsumo>();
        static DataTable tin = new DataTable();
        static decimal suma = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                listarInsumo();
                dtestado = new DataSet();
                dtestado = ctr_Estado_OC.Leer_Estado_OC();
                DdlEstado.DataTextField = "EOC_NombreEstadoOC";
                DdlEstado.DataValueField = "EOC_idEstadoOC";
                DdlEstado.DataSource = dtestado;
                DdlEstado.DataBind();
                //-----------------------------------------------

                dtpro = new DataSet();
                dtpro = pro.Leer_Proveedor();

                DdlProveedor.DataTextField = "P_RazonSocial";
                DdlProveedor.DataValueField = "P_idProveedor";
                DdlProveedor.DataSource = dtpro;
                DdlProveedor.DataBind();

                //txtFechaEntrega.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        protected void DdlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecioU.Text = ctr_insumo.SelectPrecioUnitario(Convert.ToInt32(DdlInsumo.SelectedValue));
            txtMedida.Text = _Cm.BuscarMedida(Convert.ToInt32(DdlInsumo.SelectedValue));
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).Parent.Parent;
            int i = row.RowIndex;

            tin.Rows[i].Delete();
            pila.RemoveAt(i);
            suma -= Convert.ToDecimal(GridViewAñadirOC.Rows[i].Cells[3].Text);
            txtTotal.Text = suma.ToString();
            GridViewAñadirOC.DataSource = tin;
            GridViewAñadirOC.DataBind();
        }

        public void listarInsumo()
        {
            DdlInsumo.DataSource = ctr_insumo.SelectInsumosOC();
            DdlInsumo.DataTextField = "I_NombreInsumo";
            DdlInsumo.DataValueField = "I_idInsumo";
            DdlInsumo.DataBind();
            DdlInsumo.Items.Insert(0, "--seleccionar--");
        }
       
        protected void btnAñadirInsumo_Click(object sender, EventArgs e)
        {
            dto_ocxinsumo = new DTO_OCxInsumo();
            dto_ocxinsumo.I_idInsumo = Convert.ToInt32(DdlInsumo.SelectedValue);
            dto_ocxinsumo.OCxI_Cantidad = int.Parse(txtCantidad.Text);
            dto_ocxinsumo.OCxI_PrecioTotal = dto_ocxinsumo.OCxI_Cantidad * Convert.ToDecimal(ctr_insumo.SelectPrecioUnitario(dto_ocxinsumo.I_idInsumo));
            suma += dto_ocxinsumo.OCxI_PrecioTotal;
            dto_oc.OC_TotalCompra += Convert.ToDecimal(dto_ocxinsumo.OCxI_PrecioTotal);
            pila.Add(dto_ocxinsumo);
            txtTotal.Text = suma.ToString();
        }
       
        protected void btnAñadirOC_Click(object sender, EventArgs e)
        {

            dto_oc.OC_TipoComprobante = DListTipoC.Text;
            dto_oc.OC_NumeroComprobante = txtNumeroComprobante.Text;
            dto_oc.OC_TotalCompra = Convert.ToDecimal(suma);
            dto_oc.OC_FechaEmision = DateTime.Today;
            dto_oc.OC_FormaPago = DListFormaP.Text;
            //dto_oc.OC_FechaEntrega = DateTime.Parse(txtFechaEntrega.Text);
            //dto_oc.OC_FechaPago= DateTime.Parse(txtFechaEntrega.Text);
            dto_oc.P_idProveedor = int.Parse(DdlProveedor.SelectedValue);
            dto_oc.OC_TotalCompra = Convert.ToDecimal(txtTotal.Text);
            
            dto_estado_OCxOC.EOC_idEstadoOC = Convert.ToInt32(DdlEstado.SelectedValue);
            dto_estado_OCxOC.OC_idOrdenCompra = ctr_oc.ID_OC_Actual();
            dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
            dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
            ctr_estado_OCxOC.Registrar_Estado_OCxOC(dto_estado_OCxOC);
            ctr_oc.Registrar_OC(dto_oc);
            while (pila.Count >= 1)
            {
                pila[pila.Count - 1].OC_idOrdenCompra = ctr_oc.ID_OC_Actual();
                ctr_ocxinsumo.Registrar_OC_Insumo(pila[pila.Count - 1]);
                pila.RemoveAt(pila.Count - 1);
            }
            suma = 0;
            tin.Clear();
            

            Response.Redirect("GestionarOC.aspx");
        }
    }
}