using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace MesonURPWEB
{
    public partial class AñadirInsumo : System.Web.UI.Page
    {
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();
        CTR_Categoria _Ccat = new CTR_Categoria();
        CTR_Medida _Cmed = new CTR_Medida();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarCategorias();
                ListarMedidas();
                //ListarEstados();
                txtcant.Enabled = false;
                ddlEstado.Enabled = false;
                CheckBox1.Enabled = false;
            }
        }
        public void ListarCategorias()
        {
            ddlCategorias.DataSource = _Ccat.CTR_Leer_Categorias();
            ddlCategorias.DataTextField = "C_NombreCategoria";
            ddlCategorias.DataValueField = "C_idCategoria";
            ddlCategorias.DataBind();
            ddlCategorias.Items.Insert(0, "--seleccionar--");
        }
        public void ListarMedidas()
        {
            ddlMedida.DataSource = _Cmed.LeerMedidas();
            ddlMedida.DataTextField = "M_NombreMedida";
            ddlMedida.DataValueField = "M_idMedida";
            ddlMedida.DataBind();
            ddlMedida.Items.Insert(0, "--seleccionar--");
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (rfvnombreI.IsValid && rfvstockMax.IsValid && rfvstockMin.IsValid && rfvcantT.IsValid && rfvprecioU.IsValid)
            {
                int a = 0;
                _Di.VR_NombreRecurso = txtnombreInsumo.Text;
                bool vi = _Ci.VerificarExisteInsumo(_Di);
                if (vi)
                {
                    ClientScript.RegisterStartupScript(
                    //ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "alert", "alertaIgualNombre()", true);
                   
                    this.GetType(), "myalert", "myalert('" + "Ya existe un insumo con el nombre  " + txtnombreInsumo.Text + "');", true);

                    a = 1;
                }
                if (Convert.ToDecimal(txtstockMax.Text) < Convert.ToDecimal(txtstockMin.Text) || Convert.ToDecimal(txtstockMax.Text) == Convert.ToDecimal(txtstockMin.Text))
                {
                    ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert2", "myalert2('" + "Debe digitar un número mayor al stock mínimo  " + txtstockMin.Text + "');", true);

                    a = 1;
                }
                if (a == 0)
                {
                    _Di.VR_NombreRecurso = txtnombreInsumo.Text;
                    _Di.DR_StockMaximo = Convert.ToDecimal(txtstockMax.Text);
                    _Di.DR_StockMinimo = Convert.ToDecimal(txtstockMin.Text);
                    _Di.DR_PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                    _Di.DR_CantidadTotal = Convert.ToInt16(txtcant.Text);
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
                    _Di.FK_IM_Medida = Convert.ToInt16(ddlEstado.Text); // revisar yo
                    _Ci.RegistrarInsumo(_Di);

                    ClientScript.RegisterStartupScript(Page.GetType(), "alertCorrecto", "alert('El insumo fue registrado correctamente');window.location='GestionarInsumo.aspx';", true);
                }

            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBox1.Checked)
            {
                txtfechaV.Visible = true;
            }
            else
            {
                txtfechaV.Visible = false;

            }

        }
    }
}