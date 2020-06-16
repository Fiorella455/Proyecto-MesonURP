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
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();
        DTO_Movimiento _Dm = new DTO_Movimiento();
        DTO_MovimientoxInsumo _Dmxi = new DTO_MovimientoxInsumo();
        CTR_Movimiento _Cm = new CTR_Movimiento();
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        int movIngreso = 1;
        decimal stockmax;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ListarInsumo();
                ListarUnidad();
            }
            txtFecha2.Text = FechaActual;
            //txtMovimientoOculto.Text = Convert.ToString(_Cmxi.VerificarStockMax(_Dmxi));
        }

        protected void btnIngresar_ServerClick(object sender, EventArgs e)
        {
           
            
                _Dmxi.Cantidad = Convert.ToDecimal(txtCantidad2.Text);
                //_Dmxi.UsuarioMovimiento = "katya"; 
                _Dmxi.FechaMovimiento = Convert.ToDateTime(txtFecha2.Text);
                _Dmxi.IdInsumo = Convert.ToInt32(ddlInsumos.SelectedValue);
                _Dmxi.IdMovimiento = movIngreso;

                //txtMovimientoOculto.Text = Convert.ToString(_Cmxi.VerificarStockMax(_Dmxi.IdInsumo));
               
               if (Convert.ToDecimal(txtCantidad2.Text) > Convert.ToDecimal(txtMovimientoOculto.Text))
                {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "La cantidad de insumos no es permitida" + "');", true);
                return;
                }
               else
                {
                _Cmxi.RegistrarMovimientoxInsumo(_Dmxi);
                _Cmxi.UpdateStockIngreso(_Dmxi);
            }
            /*_Cmxi.RegistrarMovimientoxInsumo(_Dmxi);
            _Cmxi.UpdateStockIngreso(_Dmxi);*/
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
            //ddlInsumos.Items.Insert(0, new ListItem("--Seleccionar--", ""));

        }
        public void ListarUnidad()
        {
            ddlMedida.DataSource = _Cmxi.BuscarUnidad();
            ddlMedida.DataTextField = "M_NombreMedida";
            ddlMedida.DataValueField = "M_idMedida";
            ddlMedida.DataBind();
            ddlMedida.Items.Insert(0, new ListItem("--Seleccionar--", ""));
        }

    }
}