using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using DTO;

namespace MesonURPWEB
{
    public partial class GestionarMerma : System.Web.UI.Page
    {
        CTR_Merma _Cm = new CTR_Merma();
        DTO_Merma _Dm = new DTO_Merma();
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codUsuario"] == null)
            {
                Response.Redirect("Home.aspx?x=1");
            }
            if (!Page.IsPostBack)
            {
                buildTableMerma();
            }
            
        }

        public void buildTableMerma()
        {
            gvMerma.DataSource = _Cm.ConsultarMermas();
            gvMerma.DataBind();
        }
        protected void gvMerma_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMerma.PageIndex = e.NewPageIndex;
            buildTableMerma();
        }
        protected void btnSearchMerma_ServerClick(object sender, EventArgs e)
        {

            gvMerma.DataSource = _Cm.BusquedaInsumoMerma(txtInsumo.Text);
            gvMerma.DataBind();
            txtInsumo.Text = "";

        }
    
        protected void btnAgregarMerma_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMerma");

        }
        protected void gvMerma_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "selectItem1")
                {
                    int idMerma = Convert.ToInt32(gvMerma.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["T_idMerma"].ToString());
                    string Insumo = gvMerma.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_NombreInsumo"].ToString();
                    string Medida = gvMerma.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["M_NombreMedida"].ToString();
                    decimal pesoTotal = Convert.ToDecimal(gvMerma.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["PesoTotal"].ToString());
                    DateTime fecha = Convert.ToDateTime(gvMerma.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["M_Fecha"].ToString());
                    //string obv = gvMerma.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["M_observacion"].ToString();

                    //_Dm.T_idMerma = idMerma;

                    Session["T_idMerma"] = idMerma;
                    Session["I_NombreInsumo"] = Insumo;
                    Session["PesoTotal"] = pesoTotal;
                    Session["M_Fecha"] = fecha;
                    Session["M_NombreMedida"] = Medida;
                    //Session["M_observacion"] = obv;
                    Response.Redirect("ActualizarMerma");

                }
                
                else if (e.CommandName == "selectItem2")
                {
                    int idMerma = Convert.ToInt32(gvMerma.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["T_idMerma"].ToString());
                    _Dm.T_idMerma = idMerma;
                    _Cm.EliminarMerma(_Dm);
                    buildTableMerma();
                    ScriptManager.RegisterClientScriptBlock(this.PanelMerma, this.PanelMerma.GetType(), "alert", "alertEliminar()", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnDescargarExcel_ServerClick(object sender, EventArgs e)
        {
            try
            {
                ExportarGridViewExcel(gvMerma);
            }
            catch 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese otro dato para la busqueda');", true);

            }
        }
        public void ExportarGridViewExcel(GridView grd)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gvMerma.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(gvMerma);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=MesonURP_Merma-"+FechaActual+".xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write("Gestionar Merma" + "\n" + sb.ToString());
            Response.End();

        }

    }
}