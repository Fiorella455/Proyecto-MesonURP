using CTR;
using DTO;
using System;
using System.Web.UI;

namespace MesonURPWEB
{
    public partial class RegistrarEgreso : System.Web.UI.Page
    {
        CTR_MovimientoxInsumo _Cmxi = new CTR_MovimientoxInsumo();
        DTO_MovimientoxInsumo _Dmxi = new DTO_MovimientoxInsumo();
        CTR_Medida _Cm = new CTR_Medida();
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        int movEgreso = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarInsumosxEgresar();
            }
            txtFecha.Text = FechaActual;
        }
        public void ListarInsumosxEgresar()
        {
            ddlInsumos.DataSource = _Cmxi.CargarInsumoEgreso();
            ddlInsumos.DataTextField = "I_NombreInsumo";
            ddlInsumos.DataValueField = "I_idInsumo";
            ddlInsumos.DataBind();
            ddlInsumos.Items.Insert(0, "--seleccionar--");
        }
        protected void btnEgresar_ServerClick(object sender, EventArgs e)
        {

            _Dmxi.Cantidad = Convert.ToDecimal(txtCantidad.Text);
            _Dmxi.IdUsuarioMovimiento = Convert.ToInt32( Session["codUsuario"]);
            _Dmxi.FechaMovimiento = Convert.ToDateTime(txtFecha.Text);
            _Dmxi.IdInsumo = Convert.ToInt32(ddlInsumos.SelectedValue);
            _Dmxi.IdMovimiento = movEgreso;

            txtOculto.Text = _Cmxi.VerificarStockMin(_Dmxi.IdInsumo);

            if (Convert.ToDecimal(txtCantidad.Text) > Convert.ToDecimal(txtOculto.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "La cantidad de insumos no es permitida" + "');", true);
                return;
            }
            else
            {
                _Cmxi.RegistrarMovimientoxInsumo(_Dmxi);
                _Cmxi.UpdateStockEgreso(_Dmxi);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "La cantidad de insumos no es permitida" + "');", true);
                return;
            }
        }
        protected void Selection_Change(Object sender, EventArgs e)
        {
            txtUnidadMedida.Text = _Cm.BuscarMedida(Convert.ToInt32(ddlInsumos.SelectedValue));
        }
    }
}
