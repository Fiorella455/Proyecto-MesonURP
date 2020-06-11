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
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();
        CTR_Movimiento _Cm = new CTR_Movimiento();
        CTR_MovimientoxInsumo _CMxI = new CTR_MovimientoxInsumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            BuscarInsumo();
        }

        /*public void ListarInsumosxEgresar()
        {
           selectInsumo.DataSource = _Cm.CargarInsumoEgreso(); //no esta este en ctr Movimiento
            selectInsumo.DataTextField = "I_NombreInsumo";
            selectInsumo.DataValueField = "I_NombreInsumo";
            selectInsumo.DataBind();
        }*/
        public void BuscarInsumo()
        {
            //txtUnidadMedida.Text = _CMxI.BuscarUnidad(Convert.ToString(Convert.ToInt32(selectInsumo.SelectedValue)));
            
        }
        protected void btnEgresar_ServerClick(object sender, EventArgs e)
        {
        }

        protected void selectInsumo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectInsumo.DataSource = _Cm.CargarInsumoEgreso(); //no esta este en ctr Movimiento
            selectInsumo.DataTextField = "I_NombreInsumo";
            selectInsumo.DataValueField = "I_NombreInsumo";
            selectInsumo.DataBind();
        }
    }
}