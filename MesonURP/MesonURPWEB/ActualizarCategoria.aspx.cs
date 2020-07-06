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
    public partial class ActualizarCategoria : System.Web.UI.Page
    {
        CTR_Categoria _Ccat = new CTR_Categoria();
        DTO_Categoria _Dcat = new DTO_Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatos();
            }
        }
        public void CargarDatos()
        {
            int pkCategoria = Convert.ToInt32(Session["C_idCategoria"]);
            txt1.Text = pkCategoria.ToString();
            DataTable dtParametros = _Ccat.CTR_getCategoria(pkCategoria);

            if (dtParametros.Rows.Count > 0)
            {
                DataRow filaP = dtParametros.Rows[0];
                txtCategoria.Text = Convert.ToString(filaP[1]);
            }
        }
        protected void btnActualizarCategoria_Click(object sender, EventArgs e)
        {
            if (rfvCategoria.IsValid)
            {
                int a = 0;
                _Dcat.C_NombreCategoria = txtCategoria.Text;
                bool vc = _Ccat.CTR_ExisteCategoria(_Dcat);
                if (vc)
                {
                    ClientScript.RegisterStartupScript(
                    this.GetType(), "myalertCat", "myalertCat('" + "Ya existe una categoría con el nombre" + "');", true);
                    a = 1;
                }
                if (a == 0)
                {
                    _Dcat.C_idCategoria = Convert.ToInt16(txt1.Text);
                    _Dcat.C_NombreCategoria = txtCategoria.Text;
                    _Ccat.CTR_ActualizarCategoria(_Dcat);
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertActualizacion", "alertActualizacion('La categoría fue actualizado correctamente');window.location='GestionarCategoria.aspx';", true);
                }
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarCategoria.aspx");
        }
    }
}