using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

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
                ddlEstado.Enabled = false;
                ddlEstado.Visible = false;
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
                if (txtfechaV.Text != "")
                {
                    CheckBox1.Checked = true;
                    CheckBox1.Enabled = true;
                    txtfechaV.Visible = true;
                }
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
                    this.GetType(), "alert1", "alert1('" + "Debe digitar un número mayor al stock mínimo  " + txtstockMin.Text + "');", true);

                    a = 1;
                }
                if (Convert.ToDecimal(txtstockMax.Text) <= Convert.ToDecimal(txtcant.Text))
                {
                    ClientScript.RegisterStartupScript(
                    this.GetType(), "alert2", "alert2('" + "Debe digitar un intervalo adecuado de Stock Máximo para  " + txtcant.Text + "');", true);

                    a = 1;
                }
                if (Convert.ToDecimal(txtstockMin.Text) >= Convert.ToDecimal(txtcant.Text))
                {
                    ClientScript.RegisterStartupScript(
                    this.GetType(), "alert3", "alert3('" + "Debe digitar un intervalo adecuado de Stock Mínimo para  " + txtcant.Text + "');", true);

                    a = 1;
                }
                if (a == 0)
                {
                    _Di.PK_IR_Recurso = Convert.ToInt16(txt1.Text);
                    _Di.VR_NombreRecurso = txtnombreInsumo.Text;
                    _Di.DR_StockMaximo = Convert.ToDecimal(txtstockMax.Text);
                    _Di.DR_StockMinimo = Convert.ToDecimal(txtstockMin.Text);
                    _Di.DR_PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                    _Di.DR_CantidadTotal = Convert.ToDecimal(txtcant.Text);
                    if (txtfechaV.Text == "")
                    {
                        _Di.I_FechaVencimiento = "";
                    }
                    else
                    {
                        _Di.I_FechaVencimiento = txtfechaV.Text;
                    }
                    _Di.FK_IC_Categoria = Convert.ToInt16(ddlCategorias.SelectedValue);
                    _Di.FK_IER_EstadoRecurso = Convert.ToInt16(ddlEstado.SelectedValue);
                    _Di.FK_IM_Medida = Convert.ToInt16(ddlMedida.SelectedValue);
                    _Ci.ActualizarInsumo(_Di);
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertActualizacion", "alertActualizacion('El insumo fue actualizado correctamente');window.location='GestionarInsumo.aspx';", true);
                }
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarInsumo.aspx");
        }
        public void ListarCategorias()
        {
            ddlCategorias.DataSource = _Ccat.CTR_Leer_Categorias();
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
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBox1.Checked && txtfechaV.Text=="")
            {
                txtfechaV.Visible = true;
            }
            else
            {
                //CheckBox1.Checked = true;
                txtfechaV.Visible = false;
                txtfechaV.Text = "";
            }

        }
    }
}