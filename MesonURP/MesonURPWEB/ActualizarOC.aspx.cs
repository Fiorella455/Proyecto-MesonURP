using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using DTO;
using DAO;
using CTR;
using System.Drawing;

namespace MesonURPWEB
{
    public partial class ActualizarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        DTO_OCxInsumo dto_ocxinsumo= new DTO_OCxInsumo();
        DTO_Medida dto_medida = new DTO_Medida();
        CTR_Medida ctr_medida = new CTR_Medida();
        CTR_OC ctr_oc = new CTR_OC();
        CTR_Proveedor pro = new CTR_Proveedor();
        CTR_Estado_OC ctr_Estado_OC = new CTR_Estado_OC();
        DataSet dtestado;
        CTR_OCxInsumo ctr_ocxinsumo = new CTR_OCxInsumo();
        CTR_Insumo ctr_insumo = new CTR_Insumo();
        DataTable dt = new DataTable();
        DataSet dtpro = new DataSet();
        DTO_Estado_OCxOC dto_estado_OCxOC = new DTO_Estado_OCxOC();
        DAO_EstadoOCxOC dao_estadoOCxOC = new DAO_EstadoOCxOC();
        CTR_EstadoOCxOC ctr_estado_OCxOC = new CTR_EstadoOCxOC();
        static List<DTO_OCxInsumo> pila = new List<DTO_OCxInsumo>();

        int id = 0;
        decimal suma = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_oc = (DTO_OC)Session["OCActual"];

            if (!IsPostBack)
            {
                listarInsumo();
                dtestado = new DataSet();

                //------------------------------------------------
                dtpro = new DataSet();
                dtpro = pro.Leer_Proveedor();

                DdlProveedor.DataTextField = "P_RazonSocial";
                DdlProveedor.DataValueField = "P_idProveedor";
                DdlProveedor.DataSource = dtpro;
                DdlProveedor.DataBind();

                //--------------------------------------------Llenar 

                ctr_oc.CTR_Leer_OC(dto_oc);
                txtNumComprobante.Text = dto_oc.OC_NumeroComprobante;
                txtTipoComprobante.Text = dto_oc.OC_TipoComprobante;
                DdlProveedor.Text = dto_oc.P_idProveedor.ToString();
                DListFormaP.Text = dto_oc.OC_FormaPago;
                txtTotal.Text = dto_oc.OC_TotalCompra.ToString();
                //-------------------------------------------------------
                ctr_ocxinsumo = new CTR_OCxInsumo();
                dt = ctr_ocxinsumo.Leer_InsumoxOC(dto_oc.OC_idOrdenCompra);
                GridViewEditarOC.DataSource = dt;
                GridViewEditarOC.DataBind();
                SumaTotal();

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

        protected void GridViewEditarOC_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridViewEditarOC, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Haga click para seleccionar la fila.";
                id = e.Row.RowIndex;

            }
        }
       
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            
            dto_oc.OC_TipoComprobante = txtTipoComprobante.Text;          
            dto_oc.OC_FormaPago = DListFormaP.Text;
            dto_oc.OC_NumeroComprobante = txtNumComprobante.Text;           
            dto_oc.P_idProveedor = int.Parse(DdlProveedor.SelectedValue);
            dto_oc.OC_TotalCompra = Convert.ToDecimal(txtTotal.Text);
            ctr_oc.Actualizar_OC(dto_oc);

            //--------------------------------------------------------------


            ClientScript.RegisterStartupScript(Page.GetType(), "alertaExito", "alertaExito('Se ha logrado ingresar correctamente');", true);
        }
        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridViewEditarOC.SelectedRow;
            int idOC = dto_oc.OC_idOrdenCompra;
            int idIns = Convert.ToInt32(row.Cells[0].Text);
            ctr_ocxinsumo.Eliminar_OCxInsumo(idOC, idIns);
            suma -= Convert.ToDecimal(GridViewEditarOC.Rows[id].Cells[4].Text);
            dt = ctr_ocxinsumo.Leer_InsumoxOC(dto_oc.OC_idOrdenCompra);
            GridViewEditarOC.DataSource = dt;
            GridViewEditarOC.DataBind();
            SumaTotal();

        }


        protected void GridViewEditarOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewEditarOC.SelectedRow;
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
                  
            dto_ocxinsumo = new DTO_OCxInsumo();
            if (DdlInsumo.SelectedValue == "") { lblMsj1.Text = "Seleccione un insumo"; }
            else { dto_ocxinsumo.I_idInsumo = int.Parse(DdlInsumo.SelectedValue); }
            DTO_Insumo insumo = ctr_insumo.Consultar_InsumoxID(dto_ocxinsumo.I_idInsumo);
            if (int.Parse(txtCantidad.Text) == 0 || int.Parse(txtCantidad.Text) < 0)
            {
                lblMsj.Text = "Ingrese otra cantidad";
            }
            if (ctr_insumo.CTR_LimiteStockMax(int.Parse(DdlInsumo.SelectedValue), int.Parse(txtCantidad.Text)) == 1)
            {
                lblMsj.Text = "Ingresar una cantidad menor";
            }
            else if (txtCantidad.Text == "")
            {
                lblMsj.Text = "Ingrese una cantidad";
            }
            else
            {
                dto_ocxinsumo.OCxI_Cantidad = int.Parse(txtCantidad.Text);
            }          
            dto_ocxinsumo.OCxI_PrecioTotal = dto_ocxinsumo.OCxI_Cantidad * Convert.ToDecimal(insumo.DR_PrecioUnitario);
            dto_ocxinsumo.OC_idOrdenCompra = dto_oc.OC_idOrdenCompra;

            //Registrar y bindear
            ctr_ocxinsumo.Registrar_OC_Insumo(dto_ocxinsumo);
            dt = ctr_ocxinsumo.Leer_InsumoxOC(dto_oc.OC_idOrdenCompra);
            GridViewEditarOC.DataSource = dt;
            GridViewEditarOC.DataBind();
            SumaTotal();
        }
        public void SumaTotal()
        {
            foreach (GridViewRow row in GridViewEditarOC.Rows)
            {
                suma += Convert.ToDecimal(row.Cells[4].Text);
            }
            txtTotal.Text = suma.ToString();
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumComprobante.Text = "";
            txtTipoComprobante.Text = "";           
            txtCantidad.Text = "";
            txtMedida.Text = "";
            txtPrecioU.Text = "";
            txtTotal.Text = "";
        }
    }
}