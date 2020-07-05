using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using DAO;
using CTR;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB.paginas
{
    public partial class AgregarOC : System.Web.UI.Page
    {
        CTR_Categoria ctr_categoria;
        DataSet dataset;
        protected void Page_Load(object sender, EventArgs e)
        {

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
        public void CargarInsumoxCategoria()
        { 
            
        
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}