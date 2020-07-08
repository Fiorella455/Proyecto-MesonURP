using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;
using System.Windows.Forms;

namespace MesonURPWEB
{
    public partial class GestionarInsumo : System.Web.UI.Page
    {
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                buildTableInsumos();
            }
        }
        public void buildTableInsumos()
        {
            gvInsumos.DataSource = _Ci.consultarInsumo();
            gvInsumos.DataBind();
        }
        protected void fNombre_TextChanged(object sender, EventArgs e)
        {
            buildTableInsumos();
        }
        protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsumos.PageIndex = e.NewPageIndex;
            buildTableInsumos();
        }
        protected void gvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "selectItem")
                {
                    int pkInsumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());

                    Session["I_idInsumo"] = pkInsumo;

                    Response.Redirect("ActualizarInsumo.aspx");
                }
                else if (e.CommandName == "selectItem1")//VER 
                {
                    
                    int pkInsumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);
                    upModal.Update();
                    var modal = _Ci.consultarInsumo2(pkInsumo);

                    lblModalTitle.Text = "Detalles del insumo";

                    txtnombreInsumo.Text = modal.Rows[0]["I_NombreInsumo"].ToString();
                    txtnombreInsumo.Enabled = false;
                    txtstockMaximo.Text = modal.Rows[0]["I_StockMaximo"].ToString();
                    txtstockMaximo.Enabled = false;
                    txtstockMinimo.Text = modal.Rows[0]["I_StockMinimo"].ToString();
                    txtstockMinimo.Enabled = false;
                    txtprecioUnitario.Text = modal.Rows[0]["I_PrecioUnitario"].ToString();
                    txtprecioUnitario.Enabled = false;
                    txtcantidadTotal.Text = modal.Rows[0]["I_CantidadTotal"].ToString();
                    txtcantidadTotal.Enabled = false;
                    txtfechaVencimiento.Text = modal.Rows[0]["FechaVencimiento"].ToString();
                    txtfechaVencimiento.Enabled = false;
                    txtnestadoInsumo.Text = modal.Rows[0]["EI_NombreEstadoInsumo"].ToString();
                    txtnestadoInsumo.Enabled = false;
                    txtunidadMedida.Text = modal.Rows[0]["M_NombreMedida"].ToString();
                    txtunidadMedida.Enabled = false;
                    txtcategoriaInsumo.Text = modal.Rows[0]["C_NombreCategoria"].ToString();
                    txtcategoriaInsumo.Enabled = false;


                    ////txtestadoInsumo.Text = modal.Rows[0]["EI_idEstadoInsumo"].ToString();
                    ////txtestadoInsumo.Enabled = false;

                    //Response.Redirect("ActualizarInsumo.aspx");
                }
                else if (e.CommandName == "selectItem2")//ELIMINAR 
                {
                    int a = 0;
                    int pkInsumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());
                    bool veixoc = _Ci.CTR_Consultar_Relacion_InsumoxOC(pkInsumo);
                    bool veixmov = _Ci.CTR_Consultar_Relacion_InsumoxM(pkInsumo);
                    bool veixmxoc = _Ci.CTR_Consultar_Relacion_InsumoxMxOC(pkInsumo);
                    if (veixoc)
                    {
                        ClientScript.RegisterStartupScript(
                        this.GetType(), "myalertixoc", "myalertixoc('" + "El insumo se encuentra usado en una Orden de Compra" + "');", true);
                        a = 1;
                    }
                    if (veixmov)
                    {
                        ClientScript.RegisterStartupScript(
                        this.GetType(), "myalertixm", "myalertixm('" + "El insumo se encuentra usado en Movimientos" + "');", true);
                        a = 1;
                    }
                    if (veixmxoc)
                    {
                        ClientScript.RegisterStartupScript(
                        this.GetType(), "myalertixmxoc", "myalertixmxoc('" + "El insumo existe en una Orden de Compra y Movimiento" + "');", true);
                        a = 1;
                    }
                    if (a == 0)
                    {
                        _Di.PK_IR_Recurso = pkInsumo;
                        _Ci.eliminarInsumo(_Di);
                        ClientScript.RegisterStartupScript(Page.GetType(), "myalertEliminar", "myalertEliminar('El insumo fue eliminado correctamente');window.location='GestionarInsumo.aspx';", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            buildTableInsumos();
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarInsumo.aspx");
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarInsumo.aspx");
        }
         
    }
}