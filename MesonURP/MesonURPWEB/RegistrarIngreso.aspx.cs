using CTR;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Web.Services.Description;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using System.Data;
using TextBox = System.Windows.Forms.TextBox;

namespace MesonURPWEB
{
    public partial class RegistrarIngreso : System.Web.UI.Page
    {
        CTR_MovimientoxInsumo _Cmxi = new CTR_MovimientoxInsumo();
        DTO_MovimientoxInsumo _Dmxi = new DTO_MovimientoxInsumo();
        CTR_Insumo _Ci = new CTR_Insumo();
        DTO_Insumo _Di = new DTO_Insumo();
        static List<DTO_MovimientoxInsumo> pila = new List<DTO_MovimientoxInsumo>();
        DTO_Medida _Dm = new DTO_Medida();
        CTR_Medida _Cm = new CTR_Medida();
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        static DataTable tin = new DataTable();
        static int id { get; set; }
        int movIngreso = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ListarInsumo();
            }
            txtFecha2.Text = FechaActual;
        }
        public void ListarInsumo()
        {
            ddlInsumos.DataSource = _Cmxi.CargarInsumoIngreso();
            ddlInsumos.DataTextField = "I_NombreInsumo";
            ddlInsumos.DataValueField = "I_idInsumo";
            ddlInsumos.DataBind();
            ddlInsumos.Items.Insert(0, "--seleccionar--");
        }
        public void Selection_Change(Object sender, EventArgs e)
        {
            if (ddlInsumos.SelectedIndex != 0)
            {
                txtUnidadMedida2.Text = _Cm.BuscarMedida(Convert.ToInt32(ddlInsumos.SelectedValue));
                txtOculto.Text = _Cmxi.VerificarStockMax(Convert.ToInt32(ddlInsumos.SelectedValue));
            }
            else
            {
                txtUnidadMedida2.Text = "";
                txtOculto.Text ="";
                txtCantidad2.Text = "";
                ScriptManager.RegisterClientScriptBlock(this.PanelAñadir, this.PanelAñadir.GetType(), "alertaSeleccionar", "alertaSeleccionar();", true);
                return;
            }
        }
        protected void btnAñadirInsumo_Click(object sender, EventArgs e)
        {
            _Dmxi.Cantidad = Convert.ToDecimal(txtCantidad2.Text);
            _Dmxi.FechaMovimiento = Convert.ToDateTime(txtFecha2.Text);
            string fecha = Convert.ToString(txtFecha2.Text);
            _Dmxi.IdInsumo = Convert.ToInt32(ddlInsumos.SelectedValue);
            _Di = _Ci.Consultar_InsumoxID(Convert.ToInt32(ddlInsumos.SelectedValue));
            _Dm.M_NombreMedida = _Cm.BuscarMedida(Convert.ToInt32(ddlInsumos.SelectedValue));
            _Dmxi.IdUsuarioMovimiento = Convert.ToInt32(Session["codUsuario"]);
            _Dmxi.IdMovimiento = movIngreso;
            DataRow row = tin.NewRow();

            if (tin.Columns.Count == 0)
            {
                tin.Columns.Add("Fecha");
                tin.Columns.Add("Nombre insumo");
                tin.Columns.Add("Cantidad");
                tin.Columns.Add("Unidad de Medida");
            }
            if (Convert.ToDecimal(txtCantidad2.Text) > Convert.ToDecimal(_Cmxi.VerificarStockMax(_Dmxi.IdInsumo)) || Convert.ToDecimal(txtCantidad2.Text) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.PanelAñadir, this.PanelAñadir.GetType(), "alert", "alertaCantidad()", true);
                return;
            }
            else
            {
                if (tin.Rows.Count > 0)
                {
                    // Primero averigua si el registro existe:
                    bool existe = false;
                    for (int i = 0; i < tin.Rows.Count; i++)
                    {
                        if (Convert.ToString(gvInsumosIngreso.Rows[i].Cells[1].Text) == Convert.ToString(_Di.VR_NombreRecurso))
                        {
                            existe = true;
                            ScriptManager.RegisterClientScriptBlock(this.PanelAñadir, this.PanelAñadir.GetType(), "alert", "alertaDuplicado()", true);
                            break;
                        }
                    }
                    // Luego, ya fuera del ciclo, solo si no existe, realizas la insercion:
                    if (existe == false)
                    {
                        pila.Add(_Dmxi);

                        row[0] = fecha;
                        row[1] = _Di.VR_NombreRecurso;
                        row[2] = _Dmxi.Cantidad;
                        row[3] = _Dm.M_NombreMedida;
                        tin.Rows.Add(row);

                        gvInsumosIngreso.DataSource = tin;
                        gvInsumosIngreso.DataBind();
                    }
                }
                else
                {
                    pila.Add(_Dmxi);
                    row[0] = fecha;
                    row[1] = _Di.VR_NombreRecurso;
                    row[2] = _Dmxi.Cantidad;
                    row[3] = _Dm.M_NombreMedida;
                    tin.Rows.Add(row);

                    gvInsumosIngreso.DataSource = tin;
                    gvInsumosIngreso.DataBind();
                }
            }
        }
            protected void gvInsumosIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gvInsumosIngreso.SelectedRow.RowIndex);
            lblIndex.Text = id.ToString();
        }

        protected void gvInsumos_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvInsumosIngreso, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Haga click para seleccionar la fila.";
                id = e.Row.RowIndex;

            }
        }
        protected void gvInsumosEgreso_SelectedIndexChanged(object sender, EventArgs e)
        {

            id = Convert.ToInt32(gvInsumosIngreso.SelectedRow.RowIndex);
            lblIndex.Text = id.ToString();

        }
        protected void btnQuitarInsumo_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gvInsumosIngreso.SelectedRow.RowIndex);
            tin.Rows[id].Delete();
            pila.RemoveAt(id);
            gvInsumosIngreso.DataSource = tin;
            gvInsumosIngreso.DataBind();
        }
        protected void btnIngresar_ServerClick(object sender, EventArgs e)
        {
            if (pila.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.panelIngreso, this.panelIngreso.GetType(), "alert", "alertaError()", true);
                return;
            }
            while (pila.Count >= 1)
            {
                _Cmxi.RegistrarMovimientoxInsumo(pila[pila.Count - 1]);
                _Cmxi.UpdateStockIngreso(pila[pila.Count - 1]);
                pila.RemoveAt(pila.Count - 1);


            }

            tin.Clear();
            ScriptManager.RegisterClientScriptBlock(this.panelIngreso, this.panelIngreso.GetType(), "alert", "alertaExito()", true);
            return;
            
        }
        protected void btnRegresar_ServerClick(object sender, EventArgs e)
        {
            tin.Clear();
            return;
        }
        protected void btnLimpiar_ServerClick(object sender, EventArgs e)
        {
            txtOculto.Text = "";
            txtUnidadMedida2.Text = "";
            txtCantidad2.Text = "";
            if (ddlInsumos.SelectedIndex != 0)
            {
                ddlInsumos.SelectedIndex = 0;
            }
            if (pila.Count != 0)
            {
                for (int i = 0; i < pila.Count;)
                {
                    if (i % 5 == 0)
                        tin.Rows[i].Delete();
                    pila.Remove(pila[i]);
                }
                gvInsumosIngreso.DataSource = tin;
                gvInsumosIngreso.DataBind();
            }
         
        }
    }
}