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

namespace MesonURPWEB.paginas
{
    public partial class RegistrarIngreso : System.Web.UI.Page
    {
        CTR_MovimientoxInsumo _Cmxi = new CTR_MovimientoxInsumo();
        DTO_MovimientoxInsumo _Dmxi = new DTO_MovimientoxInsumo();
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        int movIngreso = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ListarInsumo();
                //ListarUnidad();
            }
            txtFecha2.Text = FechaActual;
        }
        protected void btnIngresar_ServerClick(object sender, EventArgs e)
        {
                _Dmxi.Cantidad = Convert.ToDecimal(txtCantidad2.Text);
                _Dmxi.FechaMovimiento = Convert.ToDateTime(txtFecha2.Text);
                _Dmxi.IdInsumo = Convert.ToInt32(ddlInsumos.SelectedValue);
                _Dmxi.IdMovimiento = movIngreso;

            txtMovimientoOculto.Text = _Cmxi.VerificarStockMax(_Dmxi.IdInsumo); //GRECIA AQUI LO PROBE Y TODO BIEN

            //   if (Convert.ToDecimal(txtCantidad2.Text) > Convert.ToDecimal(txtMovimientoOculto.Text))
            //    {
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "La cantidad de insumos no es permitida" + "');", true);
            //    return;
            //    }
            //   else
            //    {
            //    _Cmxi.RegistrarMovimientoxInsumo(_Dmxi);
            //    _Cmxi.UpdateStockIngreso(_Dmxi);
            //}
            _Cmxi.RegistrarMovimientoxInsumo(_Dmxi);
            _Cmxi.UpdateStockIngreso(_Dmxi);
        }
        protected void ddlMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void ListarInsumo()
        {
            ddlInsumos.DataSource = _Cmxi.CargarInsumoIngreso();
            ddlInsumos.DataTextField = "I_NombreInsumo";
            ddlInsumos.DataValueField = "I_idInsumo";
            ddlInsumos.DataBind();
        }
        public void ListarUnidad()
        {
            //ddlMedida.DataSource = _Cmxi.BuscarUnidad();
            ddlMedida.DataTextField = "M_NombreMedida";
            ddlMedida.DataValueField = "M_idMedida";
            ddlMedida.DataBind();
            ddlMedida.Items.Insert(0, new ListItem("--Seleccionar--", ""));
        }
    }
}