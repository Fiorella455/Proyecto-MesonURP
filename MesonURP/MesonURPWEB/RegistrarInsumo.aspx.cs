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
    public partial class RegistrarInsumo : System.Web.UI.Page
    {
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();
        CTR_Categoria _Ccat = new CTR_Categoria();
        CTR_Medida _Cmed = new CTR_Medida();
        CTR_EstadoInsumo _CestI = new CTR_EstadoInsumo();
        //DataSet dtcat, dtmed;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                ListarCategorias();
                ListarMedidas();
                ListarEstados();
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
        public void ListarEstados()
        {
            ddlEstado.DataSource = _CestI.LeerEstadoI();
            ddlEstado.DataTextField = "EI_NombreEstadoInsumo";
            ddlEstado.DataValueField = "EI_idEstadoInsumo";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, "--seleccionar--");
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (rfvnombreI.IsValid && rfvstockMax.IsValid && rfvstockMin.IsValid && rfvcantT.IsValid && rfvprecioU.IsValid && rfvfechaV.IsValid)
            {
                _Di.NombreInsumo = txtnombreInsumo.Text;
                _Di.StockMax = Convert.ToInt32(txtstockMax.Text);
                _Di.StockMin = Convert.ToInt32(txtstockMin.Text);
                _Di.PrecioUnitario = Convert.ToInt32(txtPrecio.Text);
                _Di.CantidadTotal = Convert.ToInt32(txtcant.Text);
                _Di.FechaVencimiento = Convert.ToDateTime(txtfechaV.Text);
                _Di.Idcategoria = Convert.ToInt32(ddlCategorias.SelectedValue);
                _Di.IdEstadoInsumo = Convert.ToInt32(ddlEstado.SelectedValue);
                _Di.Medida = ddlMedida.Text;
                _Ci.RegistrarInsumo(_Di);
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('El insumo fue registrado correctamente');window.location='GestionarInsumo.aspx';", true);
            }
        }
    }
}