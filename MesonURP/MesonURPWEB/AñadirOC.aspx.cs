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
        DTO_OC dto_oc;
        CTR_OC ctr_oc;
        CTR_Estado_OC ctr_Estado_OC;

        DTO_Estado_OCxOC dto_estado_OCxOC;
        CTR_EstadoOCxOC ctr_estado_OCxOC;

        CTR_Categoria ctr_categoria;
        DataSet dtestado, dtcat, dtins, dtpro;

        CTR_Insumo ctr_insumo;
        CTR_Proveedor pro;
        static double suma = 0;
        static Stack<DTO_OCxInsumo> pila = new Stack<DTO_OCxInsumo>();
        DTO_OCxInsumo dto_ocxinsumo;
        CTR_OCxInsumo ctr_ocxinsumo;
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_oc = new DTO_OC();
            ctr_oc = new CTR_OC();
            ctr_categoria = new CTR_Categoria();
            dto_estado_OCxOC = new DTO_Estado_OCxOC();
            ctr_estado_OCxOC = new CTR_EstadoOCxOC();

            ctr_insumo = new CTR_Insumo();
            ctr_ocxinsumo = new CTR_OCxInsumo();
            pro = new CTR_Proveedor();

            if (!this.IsPostBack)
            {
                ctr_Estado_OC = new CTR_Estado_OC();
                dtestado = new DataSet();
                dtestado = ctr_Estado_OC.Leer_Estado_OC();
                
                DdlEstado.DataTextField = "EOC_NombreEstadoOC";
                DdlEstado.DataValueField = "EOC_idEstadoOC";
                DdlEstado.DataSource = dtestado;
                DdlEstado.DataBind();
                //----
                dtcat = new DataSet();
                dtcat = ctr_categoria.CTR_Leer_Categorias();
                DdlCategoria.DataTextField = "C_NombreCategoria";
                DdlCategoria.DataValueField = "C_idCategoria";
                DdlCategoria.DataSource = dtcat;
                DdlCategoria.DataBind();
                //----
                //dtins = new DataSet();
                //if(DdlCategoria.SelectedValue!="")
                //{
                //    dtins = ctr_insumo.Ctr_Leer_Insumo_Categorias(Convert.ToInt32(DdlCategoria.SelectedValue)); 
                //} 
                //DdlInsumo.DataTextField = "I_NombreInsumo";
                //DdlInsumo.DataValueField = "I_idInsumo";
                //DdlInsumo.DataSource = dtins;
                //DdlInsumo.DataBind();
                
                //----
                dtpro = new DataSet();
                dtpro = pro.Leer_Proveedor();

                DdlProveedor.DataTextField = "P_RazonSocial";
                DdlProveedor.DataValueField = "P_idProveedor";
                DdlProveedor.DataSource = dtpro;
                DdlProveedor.DataBind();

            }
        }

        protected void btnAñadirI_Click(object sender, EventArgs e)
        {
            dto_ocxinsumo = new DTO_OCxInsumo();
            dto_ocxinsumo.I_idInsumo = int.Parse(DdlInsumo.SelectedValue);
            dto_ocxinsumo.OC_idOrdenCompra = ctr_oc.ID_OC_Actual() + 1;
            dto_ocxinsumo.OCxI_Cantidad = int.Parse(txtCantidad.Text);
            dto_ocxinsumo.OCxI_PrecioTotal = dto_ocxinsumo.OCxI_Cantidad * 5;
            suma += dto_ocxinsumo.OCxI_PrecioTotal;
            pila.Push(dto_ocxinsumo);
        }

        protected void btnAñadirOC_Click(object sender, EventArgs e)
        {

            dto_oc.OC_TipoComprobante = txtTipoComprobante.Text;
            dto_oc.OC_NumeroComprobante = txtNumeroComprobante.Text;
            dto_oc.OC_TotalCompra = Convert.ToDecimal(suma);
            dto_oc.OC_FechaEmision = DateTime.Today;
            dto_oc.P_idProveedor = int.Parse(DdlProveedor.SelectedValue);
            dto_oc.OC_NumeroComprobante = txtNumeroComprobante.Text;
            dto_oc.OC_TipoComprobante = txtTipoComprobante.Text;
            dto_oc.OC_TotalCompra = Convert.ToDecimal(suma);

            //---------------------------------------------------
            dto_estado_OCxOC.EOC_idEstadoOC = 1;
            dto_estado_OCxOC.OC_idOrdenCompra = ctr_oc.ID_OC_Actual();
            dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
            dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
            ctr_estado_OCxOC.Registrar_Estado_OCxOC(dto_estado_OCxOC);
            ctr_oc.Registrar_OC(dto_oc);

            while (pila.Count >= 1)
            {

                ctr_ocxinsumo.Registrar_OC_Insumo(pila.Pop());
            }

            Response.Redirect("Listas_OC.aspx");
        }

      
    }
}