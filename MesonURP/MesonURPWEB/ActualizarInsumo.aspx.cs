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
                txtstockMin.Text = Convert.ToString(filaP[2]);
                txtstockMax.Text = Convert.ToString(filaP[3]);
                txtPrecio.Text = Convert.ToString(filaP[4]);
                txtcant.Text = Convert.ToString(filaP[5]);
                txtfechaV.Text = Convert.ToString(filaP[6]);
                ddlEstado.SelectedValue = Convert.ToString(filaP[7]);
                ddlMedida.SelectedValue = Convert.ToString(filaP[8]);
                ddlCategorias.SelectedValue = Convert.ToString(filaP[9]);
            }

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (rfvnombreI.IsValid && rfvstockMax.IsValid && rfvstockMin.IsValid && rfvcantT.IsValid && rfvprecioU.IsValid)
            {
                int a = 0;
                if (Convert.ToDecimal(txtstockMax.Text) < Convert.ToDecimal(txtstockMin.Text) || Convert.ToDecimal(txtstockMax.Text) == Convert.ToDecimal(txtstockMin.Text))
                {
                    ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('" + "Debe digitar un número mayor al stock mínimo  " + txtstockMin.Text + "');", true);

                    a = 1;
                }
                if (a == 0)
                {
                    _Di.IdInsumo = Convert.ToInt16(txt1.Text);
                    _Di.NombreInsumo = txtnombreInsumo.Text;
                    _Di.StockMax = Convert.ToDecimal(txtstockMax.Text);
                    _Di.StockMin = Convert.ToDecimal(txtstockMin.Text);
                    _Di.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                    _Di.CantidadTotal = Convert.ToInt16(txtcant.Text);
                    _Di.FechaVencimiento = txtfechaV.Text;
                    _Di.Idcategoria = Convert.ToInt16(ddlCategorias.SelectedValue);
                    _Di.IdEstadoInsumo = Convert.ToInt16(ddlEstado.SelectedValue);
                    _Di.Medida = ddlMedida.Text;
                    _Ci.ActualizarInsumo(_Di);
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('El insumo fue actualizado correctamente');window.location='GestionarInsumo.aspx';", true);
                }
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