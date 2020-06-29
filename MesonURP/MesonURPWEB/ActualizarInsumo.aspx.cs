using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class ActualizarInsumo : System.Web.UI.Page
    {
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();
        CTR_Categoria _Ccat = new CTR_Categoria();
        CTR_Medida _Cmed = new CTR_Medida();
        CTR_EstadoInsumo _CestI = new CTR_EstadoInsumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatos();
                ListarCategorias();
                ListarMedidas();
                ListarEstados();
            }
        }
        public void CargarDatos()
        {

            int id = Convert.ToInt32(Session["I_idInsumo"]);
            txt1.Text = id.ToString();
            DataTable dtParametros = _Ci.getInsumos(id);

            if (dtParametros.Rows.Count > 0)
            {
                DataRow filaP = dtParametros.Rows[0];
                txtnombreInsumo.Text = Convert.ToString(filaP[1]);
                txtstockMax.Text = Convert.ToString(filaP[2]);
                txtstockMin.Text = Convert.ToString(filaP[3]);
                txtPrecio.Text = Convert.ToString(filaP[4]);
                txtcant.Text = Convert.ToString(filaP[5]);
                txtfechaV. = Convert.ToDateTime(filaP[6]);
                ddlEstado.SelectedValue = Convert.ToString(filaP[7]);
                ddlMedida.SelectedValue = Convert.ToString(filaP[8]);
                ddlCategorias.SelectedValue = Convert.ToString(filaP[9]);
            }

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (rfvnombreI.IsValid && rfvstockMax.IsValid && rfvstockMin.IsValid && rfvcantT.IsValid && rfvprecioU.IsValid)
            {
                _Di.IdInsumo = Convert.ToInt32(txt1.Text);
                _Di.NombreInsumo = txtnombreInsumo.Text;
                _Di.StockMax = Convert.ToInt32(txtstockMax.Text);
                _Di.StockMin = Convert.ToInt32(txtstockMin.Text);
                _Di.PrecioUnitario = Convert.ToInt32(txtPrecio.Text);
                _Di.CantidadTotal = Convert.ToInt32(txtcant.Text);
                _Di.FechaVencimiento = Convert.ToDateTime(txtfechaV.Text);
                _Di.Idcategoria = Convert.ToInt32(ddlCategorias.SelectedValue);
                _Di.IdEstadoInsumo = Convert.ToInt32(ddlEstado.SelectedValue);
                _Di.Medida = ddlMedida.Text;
                _Ci.ActualizarInsumo(_Di);
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('El insumo fue actualizado correctamente');window.location='GestionarInsumo.aspx';", true);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarInsumo.aspx");
        }
        public void ListarCategorias()
        {
            ddlCategorias.DataSource = _Ccat.LeerCategorias();
            ddlCategorias.DataTextField = "C_NombreCategoria";
            ddlCategorias.DataValueField = "C_idCategoria";
            ddlCategorias.DataBind();
            //ddlCategorias.Items.Insert(0, "--seleccionar--");
        }
        public void ListarMedidas()
        {
            ddlMedida.DataSource = _Cmed.LeerMedidas();
            ddlMedida.DataTextField = "M_NombreMedida";
            ddlMedida.DataValueField = "M_idMedida";
            ddlMedida.DataBind();
            //ddlMedida.Items.Insert(0, "--seleccionar--");
        }
        public void ListarEstados()
        {
            ddlEstado.DataSource = _CestI.LeerEstadoI();
            ddlEstado.DataTextField = "EI_NombreEstadoInsumo";
            ddlEstado.DataValueField = "EI_idEstadoInsumo";
            ddlEstado.DataBind();
            //ddlEstado.Items.Insert(0, "--seleccionar--");
        }
    }
}