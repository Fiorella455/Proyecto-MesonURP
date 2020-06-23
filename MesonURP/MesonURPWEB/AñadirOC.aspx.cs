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
using System.Drawing;


namespace MesonURPWEB
{
    public partial class AñadirOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        CTR_OC ctr_oc;
        CTR_Estado_OC ctr_Estado_OC;
        CTR_Medida ctr_medida;
        DTO_Insumo dto_insumo;
        DTO_Estado_OCxOC dto_estado_OCxOC;
        CTR_EstadoOCxOC ctr_estado_OCxOC;
        DTO_Medida dto_medida;
        CTR_Categoria ctr_categoria;
        DataSet dtestado, dtcat, dtins, dtpro,dtmed;

        CTR_Insumo ctr_insumo;
        CTR_Proveedor pro;
        int id = 0;
        static double suma = 0;
        static List<DTO_OCxInsumo> pila = new List<DTO_OCxInsumo>();
        DTO_OCxInsumo dto_ocxinsumo;
        CTR_OCxInsumo ctr_ocxinsumo;
        static DataTable tin = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            dto_oc = new DTO_OC();
            ctr_oc = new CTR_OC();
            ctr_categoria = new CTR_Categoria();
            dto_estado_OCxOC = new DTO_Estado_OCxOC();
            ctr_estado_OCxOC = new CTR_EstadoOCxOC();
            ctr_Estado_OC = new CTR_Estado_OC();
            ctr_medida = new CTR_Medida();
            ctr_insumo = new CTR_Insumo();
            ctr_ocxinsumo = new CTR_OCxInsumo();
            pro = new CTR_Proveedor();
            dto_insumo = new DTO_Insumo();

            if (!this.IsPostBack)
            {

                dtestado = new DataSet();
                dtestado = ctr_Estado_OC.Leer_Estado_OC();
                DdlEstado.DataTextField = "EOC_NombreEstadoOC";
                DdlEstado.DataValueField = "EOC_idEstadoOC";
                DdlEstado.DataSource = dtestado;
                DdlEstado.DataBind();
                //-----------------------------------------------
                dtcat = new DataSet();
                dtcat = ctr_categoria.CTR_Leer_Categorias();
                DdlCategoria.DataTextField = "C_NombreCategoria";
                DdlCategoria.DataValueField = "C_idCategoria";
                DdlCategoria.DataSource = dtcat;
                DdlCategoria.DataBind();
                //-----------------------------------------------
                dtins = new DataSet();
                dtins = ctr_insumo.Ctr_Leer_Insumo_Categorias(Convert.ToInt32(DdlCategoria.SelectedValue));
                DdlInsumo.DataTextField = "I_NombreInsumo";
                DdlInsumo.DataValueField = "I_idInsumo";
                DdlInsumo.DataSource = dtins;
                DdlInsumo.DataBind();

                //------------------------------------------------
                dtpro = new DataSet();
                dtpro = pro.Leer_Proveedor();

                DdlProveedor.DataTextField = "P_RazonSocial";
                DdlProveedor.DataValueField = "P_idProveedor";
                DdlProveedor.DataSource = dtpro;
                DdlProveedor.DataBind();

                //-----------------------------------------------

                dtmed = new DataSet();
                dtmed = ctr_medida.Leer_Medida();

                //DdlUnidades.DataTextField = "M_NombreMedida";
                //DdlUnidades.DataValueField = "M_idMedida";
                //DdlUnidades.DataSource = dtmed;
                //DdlUnidades.DataBind();
                //---------------------------------------------------
                dto_insumo = ctr_insumo.Consultar_InsumoxID(int.Parse(DdlInsumo.SelectedValue));
                txtPrecioU.Text = dto_insumo.DR_PrecioUnitario.ToString();
                dto_medida = ctr_medida.Consultar_MedidaxInsumo(dto_insumo.PK_IR_Recurso);
                txtMedida.Text = dto_medida.M_NombreMedida;


            }
        }
     
        protected void GridViewEditarOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row =GridViewAñadirOC.SelectedRow;
            int id = Convert.ToInt32(GridViewAñadirOC.DataKeys[row.RowIndex].Value);

        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            tin.Rows[id].Delete();
            pila.RemoveAt(id);
            suma -= Convert.ToDouble(GridViewAñadirOC.Rows[id].Cells[4].Text);
            txtTotal.Text = suma.ToString();
            GridViewAñadirOC.DataSource = tin;
            GridViewAñadirOC.DataBind();
        }

       
        protected void btnAñadirInsumo_Click(object sender, EventArgs e)
        {
            dto_ocxinsumo = new DTO_OCxInsumo();
            dto_ocxinsumo.I_idInsumo = int.Parse(DdlInsumo.SelectedValue);
            DTO_Insumo insumo = ctr_insumo.Consultar_InsumoxID(dto_ocxinsumo.I_idInsumo);
            // dto_ocxinsumo.OC_idOrdenCompra = ctr_oc.ID_OC_Actual()+1;
            dto_ocxinsumo.OCxI_Cantidad = int.Parse(txtCantidad.Text);
            dto_ocxinsumo.OCxI_PrecioTotal = dto_ocxinsumo.OCxI_Cantidad * Convert.ToDouble( insumo.DR_PrecioUnitario);
            suma += dto_ocxinsumo.OCxI_PrecioTotal;
            dto_oc.OC_TotalCompra += Convert.ToDecimal(dto_ocxinsumo.OCxI_PrecioTotal);
            pila.Add(dto_ocxinsumo);
            txtTotal.Text = suma.ToString();


            if (tin.Columns.Count == 0)
            {
                tin.Columns.Add("I_idInsumo");
                tin.Columns.Add("I_NombreInsumo");
                tin.Columns.Add("OCxI_Cantidad");
                tin.Columns.Add("OCxI_PrecioTotal");
                tin.Columns.Add("I_PrecioUnitario");
            }
            DataRow row = tin.NewRow();
            row[0] = dto_ocxinsumo.I_idInsumo;
            row[1] = insumo.VR_NombreRecurso;
            row[2] = dto_ocxinsumo.OCxI_Cantidad;
            row[3] = dto_ocxinsumo.OCxI_PrecioTotal;
            row[4] = insumo.DR_PrecioUnitario;
            tin.Rows.Add(row);

            GridViewAñadirOC.DataSource = tin;
            GridViewAñadirOC.DataBind();

        }

    
  
      
       
        protected void btnAñadirOC_Click(object sender, EventArgs e)
        {

            dto_oc.OC_TipoComprobante = txtTipoComprobante.Text;
            dto_oc.OC_NumeroComprobante = txtNumeroComprobante.Text;
            dto_oc.OC_TotalCompra = Convert.ToDecimal(suma);
            dto_oc.OC_FechaEmision = DateTime.Today;
            dto_oc.OC_FormaPago = txtFormaPago.Text;
            dto_oc.OC_FechaEntrega = DateTime.Parse(txtFechaEntrega.Text);
            dto_oc.OC_FechaPago= DateTime.Parse(txtFechaEntrega.Text);
            dto_oc.P_idProveedor = int.Parse(DdlProveedor.SelectedValue);
            dto_oc.OC_NumeroComprobante = txtNumeroComprobante.Text;
            dto_oc.OC_TipoComprobante = txtTipoComprobante.Text;
            dto_oc.OC_TotalCompra = Convert.ToDecimal(txtTotal.Text);

            //----------------------------------------------------------

            dto_estado_OCxOC.EOC_idEstadoOC = Convert.ToInt32(DdlEstado.SelectedValue);
            //dto_estado_OCxOC.EOC_idEstadoOC = 5;
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