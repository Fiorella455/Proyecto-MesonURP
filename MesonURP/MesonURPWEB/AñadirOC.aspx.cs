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
using System.Windows.Forms;

namespace MesonURPWEB
{
    public partial class AñadirOC : System.Web.UI.Page
    {
        DTO_OC dto_oc = new DTO_OC();
        Dto_Usuario dto_usuario = new Dto_Usuario();
        Ctr_Usuario ctr_usuario = new Ctr_Usuario();
        CTR_OC ctr_oc = new CTR_OC();
        CTR_Estado_OC ctr_Estado_OC = new CTR_Estado_OC();
        DTO_Estado_OCxOC dto_estado_OCxOC = new DTO_Estado_OCxOC();
        CTR_EstadoOCxOC ctr_estado_OCxOC = new CTR_EstadoOCxOC();
        CTR_Medida _Cm = new CTR_Medida();
        CTR_Insumo ctr_insumo = new CTR_Insumo();
        CTR_Proveedor pro = new CTR_Proveedor();
        DTO_OCxInsumo dto_ocxinsumo = new DTO_OCxInsumo();
        CTR_OCxInsumo ctr_ocxinsumo = new CTR_OCxInsumo();
        DataSet  dtpro;
        static List<DTO_OCxInsumo> pila = new List<DTO_OCxInsumo>();
        static DataTable tin = new DataTable();
        int state = 0;
       
        static decimal suma = 0;
        static int id { get;set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                listarInsumo();

                dtpro = new DataSet();
                dtpro = pro.SelectProveedorxEstado();
                DdlProveedor.DataTextField = "P_RazonSocial";
                DdlProveedor.DataValueField = "P_idProveedor";
                DdlProveedor.DataSource = dtpro;
                DdlProveedor.DataBind();
                DdlProveedor.Items.Insert(0, "--seleccionar--");

                int n= ctr_oc.Consult_Incremento();
                int suma = n + 1;
                string s = suma.ToString("D5");
                txtNumeroComprobante.Text = s;     
                
            }
            else
            {
                if (DListTipoC.SelectedValue == "") { lblIndex0.Text = "Seleccione un tipo de comprobante"; }
                else
                {
                    lblIndex0.Text = "";
                    dto_oc.OC_NumeroComprobante = ctr_oc.Generar_Numero_Comprobante(Convert.ToInt32(DListTipoC.SelectedValue)).ToString();
                    txtNumeroComprobante.Text = dto_oc.OC_NumeroComprobante;
                }
            }
            Session["state"] = 1;
            lblMsjBorrar.Text = "";
        }
        protected void DdlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecioU.Text = ctr_insumo.SelectPrecioUnitario(Convert.ToInt32(DdlInsumo.SelectedValue));
            txtMedida.Text = _Cm.BuscarMedida(Convert.ToInt32(DdlInsumo.SelectedValue));
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(GridViewAñadirOC.SelectedRow.RowIndex);
            tin.Rows[id].Delete();
            pila.RemoveAt(id);
            suma -= Convert.ToDecimal(GridViewAñadirOC.Rows[id].Cells[3].Text);
            txtTotal.Text = suma.ToString();
            GridViewAñadirOC.DataSource = tin;
            GridViewAñadirOC.DataBind();
            string ins = GridViewAñadirOC.Rows[id].Cells[0].Text;
            lblMsjBorrar.Text = "Se eliminado el insumo:"+ins;

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
            dto_ocxinsumo.I_idInsumo = int.Parse(DdlInsumo.SelectedValue);
            dto_ocxinsumo.OCxI_Cantidad = int.Parse(txtCantidad.Text);
            DTO_Insumo insumo = ctr_insumo.Consultar_InsumoxID(dto_ocxinsumo.I_idInsumo);          
            state = (int)Session["state"];
            if (state==1)
            {
                if (dto_ocxinsumo.OCxI_Cantidad == 0)
                {
                    lblMje.Text = "Ingrese otra cantidad";
                    state = 2;
                    Session["state"] = state;
                }
                if (ctr_insumo.CTR_LimiteStockMax(dto_ocxinsumo.I_idInsumo, dto_ocxinsumo.OCxI_Cantidad) == 1)
                {
                    lblMje.Text = "Ingresar una cantidad menor";
                    state = 2;
                    Session["state"] = state;
                }
                if (Verficar_Insumo_Registrado(insumo))
                {
                    lblMje.Text = "Insumo ya agregado";
                    state = 2;
                    Session["state"] = state;
                }
            }


            if ((int)Session["state"]!=2)
            {
                dto_ocxinsumo.OCxI_PrecioTotal = dto_ocxinsumo.OCxI_Cantidad * Convert.ToDecimal(insumo.DR_PrecioUnitario);
                suma += dto_ocxinsumo.OCxI_PrecioTotal;
                dto_oc.OC_TotalCompra += Convert.ToDecimal(dto_ocxinsumo.OCxI_PrecioTotal);
                pila.Add(dto_ocxinsumo);
                txtTotal.Text = suma.ToString();
                lblMje.Text = "";
                if (tin.Columns.Count == 0)
                {
                    tin.Columns.Add("I_idInsumo");
                    tin.Columns.Add("I_NombreInsumo");
                    tin.Columns.Add("OCxI_Cantidad");
                    tin.Columns.Add("I_PrecioUnitario");
                    tin.Columns.Add("OCxI_PrecioTotal");

                }
                DataRow row = tin.NewRow();
                row[0] = dto_ocxinsumo.I_idInsumo;
                row[1] = insumo.VR_NombreRecurso;
                row[2] = dto_ocxinsumo.OCxI_Cantidad;
                row[3] = insumo.DR_PrecioUnitario;
                row[4] = dto_ocxinsumo.OCxI_PrecioTotal;

                tin.Rows.Add(row);

                GridViewAñadirOC.DataSource = tin;
                GridViewAñadirOC.DataBind();

            } 

        }

        protected void btnAñadirOC_Click(object sender, EventArgs e)
        {           
                dto_oc.OC_FechaEmision = DateTime.Today.Date.ToString("yyyy-MM-dd");
                dto_oc.OC_FormaPago = DListFormaP.Text;
                dto_oc.P_idProveedor = int.Parse(DdlProveedor.SelectedValue);
                dto_oc.OC_TipoComprobante = DListTipoC.SelectedItem.Text;
                dto_oc.OC_NumeroComprobante = txtNumeroComprobante.Text;
                dto_oc.OC_TotalCompra = Convert.ToDecimal(txtTotal.Text);
                ctr_oc.Registrar_OC(dto_oc);

                //----------------------------------------------------------

                dto_estado_OCxOC.EOC_idEstadoOC = 1;
                dto_estado_OCxOC.OC_idOrdenCompra = ctr_oc.ID_OC_Actual();
                dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
                dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
                ctr_estado_OCxOC.Registrar_Estado_OCxOC(dto_estado_OCxOC);
                //-----------------------------------------------------------------



            while (pila.Count >= 1)
            {
                pila[pila.Count - 1].OC_idOrdenCompra = ctr_oc.ID_OC_Actual();
                ctr_ocxinsumo.Registrar_OC_Insumo(pila[pila.Count - 1]);
                pila.RemoveAt(pila.Count - 1);
            }
            suma = 0;
            tin.Clear();
            ClientScript.RegisterStartupScript(Page.GetType(), "alertaExito", "alertaExito('Se ha logrado ingresar correctamente');", true);
        }
        protected void GridViewAñadirOC_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridViewAñadirOC, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Haga click para seleccionar la fila.";
                id = e.Row.RowIndex;

            }
        }

        protected void GridViewAñadirOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            id = Convert.ToInt32(GridViewAñadirOC.SelectedRow.RowIndex);
        }

        protected void btnLimpiarOC_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
            txtTotal.Text = "";
            dto_oc.OC_FechaEmision = "";
            dto_oc.OC_FormaPago = "";
            dto_oc.OC_TipoComprobante = "";
            dto_oc.OC_NumeroComprobante = "";
            dto_oc.P_idProveedor = 0;

        }
        public bool Verficar_Insumo_Registrado( DTO_Insumo dto_i)
        {
            foreach (GridViewRow row in GridViewAñadirOC.Rows)
            {              
               
                string nomIns=row.Cells[0].Text;


                if ( nomIns == dto_i.VR_NombreRecurso)
                   
                {
                    return true; 
                }

            }
            return false;
        }
    }
}