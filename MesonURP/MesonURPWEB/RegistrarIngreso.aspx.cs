using CTR;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Web.Services.Description;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace MesonURPWEB
{
    public partial class RegistrarIngreso : System.Web.UI.Page
    {
        CTR_MovimientoxInsumo _Cmxi = new CTR_MovimientoxInsumo();
        DTO_MovimientoxInsumo _Dmxi = new DTO_MovimientoxInsumo();
        CTR_Medida _Cm = new CTR_Medida();
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        int movIngreso = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ListarInsumo();
            }
            txtFecha2.Text = FechaActual;
        }
        protected void btnIngresar_ServerClick(object sender, EventArgs e)
        {
                _Dmxi.Cantidad = Convert.ToDecimal(txtCantidad2.Text);
            _Dmxi.IdUsuarioMovimiento = Convert.ToInt32(Session["codUsuario"]);
            _Dmxi.FechaMovimiento = Convert.ToDateTime(txtFecha2.Text);
                _Dmxi.IdInsumo = Convert.ToInt32(ddlInsumos.SelectedValue);
                _Dmxi.IdMovimiento = movIngreso;

            txtOculto.Text = _Cmxi.VerificarStockMax(_Dmxi.IdInsumo); 

            if (Convert.ToDecimal(txtCantidad2.Text) > Convert.ToDecimal(txtOculto.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.panelIngreso, this.panelIngreso.GetType(), "alert", "alertaCantidad()", true);
                return;
            }
            else
            {
                _Cmxi.RegistrarMovimientoxInsumo(_Dmxi);
                _Cmxi.UpdateStockIngreso(_Dmxi);
            }
        }
        public void ListarInsumo()
        {
            ddlInsumos.DataSource = _Cmxi.CargarInsumoIngreso();
            ddlInsumos.DataTextField = "I_NombreInsumo";
            ddlInsumos.DataValueField = "I_idInsumo";
            ddlInsumos.DataBind();
            ddlInsumos.Items.Insert(0, "--seleccionar--");
        }
        public void Selection_Change(Object sender, EventArgs e)
        {
            txtUnidadMedida2.Text = _Cm.BuscarMedida(Convert.ToInt32(ddlInsumos.SelectedValue));
        }
    }
}