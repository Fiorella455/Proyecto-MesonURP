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
    public partial class RegistrarInsumo : System.Web.UI.Page
    {
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ListarCategorias()
        {
            
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (rfvnombreI.IsValid && rfvstockMax.IsValid && rfvstockMin.IsValid && rfvcantT.IsValid && rfvprecioU.IsValid && rfvfechaV.IsValid)
            {
                _Di.NombreInsumo = txtnombreInsumo.Text;
                _Di.StockMax = Convert.ToInt32(txtstockMax.Text);
                _Di.StockMin= Convert.ToInt32(txtstockMin.Text);
                _Di.PrecioUnitario = Convert.ToInt32(txtPrecio.Text);
                _Di.CantidadTotal = Convert.ToInt32(txtcant.Text);
                _Di.FechaVencimiento = Convert.ToDateTime(txtfechaV.Text);
                _Di.Idcategoria =
                _Di.IdEstadoInsumo =
                _Di.Medida = 
                _Ci.
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('El insumo fue registrado correctamente');window.location='GestionarInsumo.aspx';", true);
            }
        }
    }
}