using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Data;

namespace MesonURPWEB
{
    public partial class GestionarCategoria : System.Web.UI.Page
    {
        CTR_Categoria _Ccat = new CTR_Categoria();
        DTO_Categoria _Dcat = new DTO_Categoria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codUsuario"] == null)
            {
                Response.Redirect("Home.aspx?x=1");
            }
            if (!Page.IsPostBack)
            {
                buildTableCategoria();
                lblvacio.Text = "";
            }
        }
        public void buildTableCategoria()
        {
            gvCategoria.DataSource = _Ccat.CTR_Leer_Categorias();
            gvCategoria.DataBind();
        }
        protected void gvCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCategoria.PageIndex = e.NewPageIndex;
            buildTableCategoria();
        }
        protected void gvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "selectItem")
                {
                    int pkCategoria = Convert.ToInt32(gvCategoria.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCategoria"].ToString());

                    Session["C_idCategoria"] = pkCategoria;

                    Response.Redirect("ActualizarCategoria");
                }
                else if (e.CommandName == "selectItem1")
                {
                    int pkID = Convert.ToInt32(gvCategoria.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCategoria"].ToString());
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);
                    upModal.Update();
                    var modal = _Ccat.CTR_InsumosxCategoria(pkID);

                    lblModalTitle.Text = "Detalles de la Categoria";

                    GridView1.DataSource = modal;
                    GridView1.DataBind();
                }
                else if (e.CommandName == "selectItem2")
                {
                    int a = 0;
                    int pkID = Convert.ToInt32(gvCategoria.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCategoria"].ToString());
                    bool vextcat = _Ccat.CTR_ExisteInsumoxCategoria(pkID);
                    if (vextcat)
                    {
                        ClientScript.RegisterStartupScript(
                        this.GetType(), "prueba", "prueba('" + "No se puede eliminar la categoría, existe insumos" + "');", true);
                        a = 1;
                    }
                    if (a == 0)
                    {
                        _Dcat.C_idCategoria = pkID;
                        _Ccat.CTR_EliminarCategoria(_Dcat);
                        ClientScript.RegisterStartupScript(Page.GetType(), "prueba1", "prueba1('La categoría fue eliminado correctamente');", true);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
                int a = 0;
                _Dcat.C_NombreCategoria = txtCategoria.Text;
                bool vc = _Ccat.CTR_ExisteCategoria(_Dcat);
                if (vc)
                {
                    ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "myalert('" + "Ya existe una categoría con el nombre" + "');", true);
                    a = 1;
                }
                if (a == 0)
                {
                    if(txtCategoria.Text != "")
                    {
                        _Dcat.C_NombreCategoria = txtCategoria.Text;
                        _Ccat.CTR_AgregarCategoria(_Dcat);
                        ClientScript.RegisterStartupScript(Page.GetType(), "myalertCorrecto", "myalertCorrecto('La categoría fue registrado correctamente');", true);
                    }
                    else
                    {
                        lblvacio.Text = "Campo Obligatorio";
                    }
                }

        }

    }
}


