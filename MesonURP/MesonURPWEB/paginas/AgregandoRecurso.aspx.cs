using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;

namespace MesonURPWEB.paginas
{
    public partial class AgregandoRecurso : System.Web.UI.Page
    {
        CTR_Categoria ctr_categoria;
        DTO_Categoria dto_categoria;
        DataSet dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarCategoria();

            }
        }
        public void CargarCategoria()
        {
            ctr_categoria = new CTR_Categoria();
            dataset = new DataSet();
            dataset = ctr_categoria.CTR_Leer_Categorias();
            
            ddlcategoria.DataTextField = "C_NombreCategoria";
            
            ddlcategoria.DataValueField = "C_idCategoria";
            ddlcategoria.DataSource = dataset;
            ddlcategoria.DataBind();
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