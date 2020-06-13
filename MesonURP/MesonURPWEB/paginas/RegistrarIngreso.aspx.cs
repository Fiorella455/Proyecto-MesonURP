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

        protected void Page_Load(object sender, EventArgs e)
        {
            ListarInsumo();
            ListarUnidad();
        }

        protected void btnIngresar_ServerClick(object sender, EventArgs e)
        {

        }

        protected void ddlInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
           // _Di.IdInsumo = Convert.ToInt32(ddlInsumos.SelectedValue);

           // txtUnidadMedida2.Text = Convert.ToString(_Cmxi.BuscarUnidad(_Di.IdInsumo));
           // txtUnidadMedida2.Text = "asdfghjklkjhgfdsdvbjklkjhgfd";

        }
        public void ListarInsumo()
        {
            ddlInsumos.DataSource = _Cmxi.CargarInsumoIngreso();
            ddlInsumos.DataTextField = "I_NombreInsumo";
            ddlInsumos.DataValueField = "I_idInsumo";
            ddlInsumos.DataBind();
         //   ddlInsumos.SelectedValue = txtUnidadMedida2.Text;

        }
        public void ListarUnidad()
        {
            _Di.IdInsumo = Convert.ToInt32(ddlInsumos.SelectedValue);

            txtUnidadMedida2.Text = Convert.ToString(_Cmxi.BuscarUnidad(_Di.IdInsumo));


            //_Di.IdInsumo = Convert.ToString(ddlInsumos.SelectedValue);
            //txtUnidadMedida2.Text = Convert.ToString(_Cmxi.BuscarUnidad(ddlInsumos.SelectedValue));
        }
            
        }
}