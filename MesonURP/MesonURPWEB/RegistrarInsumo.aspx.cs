using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CTR;
using DTO;

namespace MesonURPWEB
{
    public partial class RegistrarInsumo : System.Web.UI.Page
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
            }

        }
        public void ListarCategorias()
        {
            ddlCategorias.DataSource = _Ccat.LeerCategorias();
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
        //public void ListarEstados()
        //{
        //    ddlEstado.DataSource = _CestI.LeerEstadoI();
        //    ddlEstado.DataTextField = "EI_NombreEstadoInsumo";
        //    ddlEstado.DataValueField = "EI_idEstadoInsumo";
        //    ddlEstado.DataBind();
        //    ddlEstado.Items.Insert(1, "");
        //}
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (rfvnombreI.IsValid && rfvstockMax.IsValid && rfvstockMin.IsValid && rfvcantT.IsValid && rfvprecioU.IsValid)
            {
                int a = 0;
                _Di.NombreInsumo = txtnombreInsumo.Text;
                bool vi = _Ci.VerificarExisteInsumo(_Di);
                if (vi)
                {
                    ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('" + "Ya existe un insumo con el nombre  " + txtnombreInsumo.Text + "');", true);

                    a = 1;
                }
                if(Convert.ToDecimal(txtstockMax.Text) < Convert.ToDecimal(txtstockMin.Text) || Convert.ToDecimal(txtstockMax.Text) == Convert.ToDecimal(txtstockMin.Text))
                {
                    ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('" + "Debe digitar un número mayor al stock mínimo  " + txtstockMin.Text + "');", true);

                    a = 1;
                }
                if (a == 0)
                {
                    _Di.NombreInsumo = txtnombreInsumo.Text;
                    _Di.StockMax = Convert.ToDecimal(txtstockMax.Text);
                    _Di.StockMin = Convert.ToDecimal(txtstockMin.Text);
                    _Di.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                    _Di.CantidadTotal = Convert.ToInt16(txtcant.Text);
                    if(txtfechaV.Text == "")
                    {
                        _Di.FechaVencimiento = "";
                    }else
                    {
                        _Di.FechaVencimiento = txtfechaV.Text;
                    }
                    _Di.Idcategoria = Convert.ToInt16(ddlCategorias.SelectedValue);
                    _Di.IdEstadoInsumo = Convert.ToInt16(ddlEstado.SelectedValue);
                    _Di.IdEstadoInsumo = Convert.ToInt16(ddlEstado.SelectedValue);
                    _Di.Medida = ddlMedida.Text;
                    _Ci.RegistrarInsumo(_Di);
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('El insumo fue registrado correctamente');window.location='GestionarInsumo.aspx';", true);
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