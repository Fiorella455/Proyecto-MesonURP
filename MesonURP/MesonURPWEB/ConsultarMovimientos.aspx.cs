using CTR;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace MesonURPWEB
{
    public partial class ConsultarMovimientos : System.Web.UI.Page
    {
        CTR_MovimientoxInsumo _CmxI = new CTR_MovimientoxInsumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMovimientoxInsumo();
        }
        public void CargarMovimientoxInsumo()
        {
            gvMovimientos.DataSource = _CmxI.SelectMovimientosxInsumo();
            gvMovimientos.DataBind();
        }
        protected void gvMovimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMovimientos.PageIndex = e.NewPageIndex;
            CargarMovimientoxInsumo();
        }
        protected void btnSearchStock_ServerClick(object sender, EventArgs e)
        {

            if (txtBuscarMovimientos.Text != "")
            {
                gvMovimientos.DataSource = _CmxI.BusquedaMovimientoxInsumo(txtBuscarMovimientos.Text);
                gvMovimientos.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese otro dato para la busqueda');", true);
                //ScriptManager.RegisterClientScriptBlock(this.PanelAñadir, this.PanelAñadir.GetType(), "alert", "alertaCantidad()", true);
                return;
            }
        }
        public void Selection_Change(Object sender, EventArgs e)
        {
            
                if (ddlMovimientos.SelectedIndex != 0)
                {
                    gvMovimientos.DataSource = _CmxI.BusquedaMovimientoxInsumoTipo(Convert.ToInt32(ddlMovimientos.SelectedValue));
                    gvMovimientos.DataBind();
                }
        }
        protected void btnDescargarExcel_ServerClick(object sender, EventArgs e)
        {
            try
            {
                ExportarGridViewExcel(gvMovimientos);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
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

            gvMovimientos.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(gvMovimientos);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=MesonURP_Ingresos y Egresos.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write("Ingresos y Egresos del Meson URP" + "\n"+ sb.ToString());
            Response.End();

        }
    
    public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}