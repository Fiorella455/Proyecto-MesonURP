using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;

namespace MesonURPWEB.paginas
{
    public partial class RegistrarOC : System.Web.UI.Page
    {
        CTR_Categoria ctr_categoria;
        DTO_Categoria dto_categoria;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void cargarCategoria()
        {
            ctr_categoria = new CTR_Categoria();
            List<DTO_Categoria> lisAreas = ctr_categoria.CTR_Leer_Categoria();
            AreaLegal objAreaLegal = new AreaLegal("00", "Selecione Area Legal", "");
            lisAreas.Insert(0, objAreaLegal);
            ddlCategoria.DataSource = lisAreas;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "AreaId";
            ddlCategoria.DataBind();
        }
    }
}