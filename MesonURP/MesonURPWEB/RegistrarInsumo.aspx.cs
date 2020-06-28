using System;
using System.Collections.Generic;
using System.Data;
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
        CTR_Categoria _Ccat = new CTR_Categoria();
        DataSet dtcat;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarCategorias();
        }
        public void ListarCategorias()
        {
            dtcat = new DataSet();
            dtcat = _Ccat.LeerCategorias();
            ddlCategorias.DataTextField = "C_NombreCategoria";
            ddlCategorias.DataValueField = "C_idCategoria";
            ddlCategorias.DataSource = dtcat;
            ddlCategorias.DataBind();
        }
        //public void ListarUnidades()
        //{
        //    dtcat = new DataSet();
        //    dtcat = _Ccat.LeerCategorias();
        //    ddlCategorias.DataTextField = "C_NombreCategoria";
        //    ddlCategorias.DataValueField = "C_idCategoria";
        //    ddlCategorias.DataSource = dtcat;
        //    ddlCategorias.DataBind();
        //}

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
                //_Di.Idcategoria =
                //_Di.IdEstadoInsumo =
                //_Di.Medida = 
                //_Ci.
                //ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('El insumo fue registrado correctamente');window.location='GestionarInsumo.aspx';", true);
            }
        }
    }
}