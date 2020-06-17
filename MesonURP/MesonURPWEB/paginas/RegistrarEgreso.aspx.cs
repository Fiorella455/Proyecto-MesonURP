using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB.paginas
{
    public partial class RegistrarEgreso : System.Web.UI.Page
    {
        CTR_MovimientoxInsumo _Cmxi = new CTR_MovimientoxInsumo();
        DTO_MovimientoxInsumo _Dmxi = new DTO_MovimientoxInsumo();
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        int movEgreso = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarInsumosxEgresar();
                //ListarMedida();
            }
            txtFecha.Text = FechaActual;
        }
        public void ListarInsumosxEgresar()
        {
            selectInsumo.DataSource = _Cmxi.CargarInsumoEgreso();
            selectInsumo.DataTextField = "I_NombreInsumo";
            selectInsumo.DataValueField = "I_idInsumo";
            selectInsumo.DataBind();
        }
        public void ListarMedida()
        {
            //ddlMedida.DataSource = _Cmxi.BuscarUnidad();
            ddlMedida.DataTextField = "M_NombreMedida";
            ddlMedida.DataValueField = "M_idMedida";
            ddlMedida.DataBind();
            ddlMedida.Items.Insert(0, new ListItem("--Seleccionar--", ""));
        }
        protected void btnEgresar_ServerClick(object sender, EventArgs e)
        {
            _Dmxi.Cantidad = Convert.ToDecimal(txtCantidad.Text);
            _Dmxi.FechaMovimiento = Convert.ToDateTime(txtFecha.Text);
            _Dmxi.IdInsumo = Convert.ToInt32(selectInsumo.SelectedValue);
            _Dmxi.IdMovimiento = movEgreso;

            // txtMovimientoOculto.Text = Convert.ToString(_Cmxi.VerificarStockMax(_Dmxi));
            /*if (Convert.ToDecimal(txtCantidad2.Text) > Convert.ToDecimal(txtMovimientoOculto.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "La cantidad de insumos no es permitida" + "');", true);
                return;
            }
            else
            {
 
            }*/
            _Cmxi.RegistrarMovimientoxInsumo(_Dmxi);
            _Cmxi.UpdateStockEgreso(_Dmxi);
        }
    }
}