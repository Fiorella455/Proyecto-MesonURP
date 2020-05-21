using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace MesonURPWEB.paginas
{
    public partial class AgregandoRecurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Dto_Recurso _DtoR = new Dto_Recurso();
            Ctr_Recurso _CtrR = new Ctr_Recurso();

            _DtoR.FK_IC_Categoria = 1;

            _DtoR.FK_IM_Medida = 1;

            _DtoR.FK_IER_EstadoRecurso = 1;

            _DtoR.VR_NombreRecurso = txtNombre.Text;
            _DtoR.DR_CantidadEntrada = Convert.ToDecimal(txtCEntrada.Text);
            _DtoR.DR_CantidadSalida = Convert.ToDecimal(txtCSalida.Text);
            _DtoR.DR_CantidadTotal = Convert.ToDecimal(txtCTotal.Text);
            _DtoR.DR_FechaIngreso = Convert.ToDateTime(txtFechaIng.Text);
            _DtoR.DR_FechaSalida = Convert.ToDateTime(txtFechaSal.Text);
            _DtoR.DR_PrecioUnitario = Convert.ToDecimal(txtPUnitario.Text);
            _DtoR.DR_StockMaximo = Convert.ToDecimal(txtStockMax.Text);


            _CtrR.Ctr_Registrar_Recurso(_DtoR);
        }

    }
}