using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{

    public partial class RegistrarEgreso : System.Web.UI.Page
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
        int id = 0;
        int movEgreso = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarInsumosxEgresar();
            }
            txtFecha.Text = FechaActual;
        }
        public void ListarInsumosxEgresar()
        {
            ddlInsumos.DataSource = _Cmxi.CargarInsumoEgreso();
            ddlInsumos.DataTextField = "I_NombreInsumo";
            ddlInsumos.DataValueField = "I_idInsumo";
            ddlInsumos.DataBind();
            ddlInsumos.Items.Insert(0, "--seleccionar--");
        }
        protected void btnAñadirInsumo_Click(object sender, EventArgs e)
        {

            _Dmxi.Cantidad = Convert.ToDecimal(txtCantidad.Text);
            _Dmxi.FechaMovimiento = Convert.ToDateTime(txtFecha.Text);
            _Dmxi.IdInsumo = Convert.ToInt32(ddlInsumos.SelectedValue);
            _Di = _Ci.Consultar_InsumoxID(Convert.ToInt32(ddlInsumos.SelectedValue));
            _Dm.M_NombreMedida = _Cm.BuscarMedida(Convert.ToInt32(ddlInsumos.SelectedValue));
            _Dmxi.IdUsuarioMovimiento = Convert.ToInt32( Session["codUsuario"]);
            _Dmxi.IdMovimiento = movEgreso;
            txtOculto.Text = _Cmxi.VerificarStockMin(_Dmxi.IdInsumo);
            
            if (tin.Columns.Count == 0)
            {
                tin.Columns.Add("Fecha");
                tin.Columns.Add("Nombre insumo");
                tin.Columns.Add("Cantidad");
                tin.Columns.Add("Unidad de Medida");
            }
            if (Convert.ToDecimal(txtCantidad.Text) > Convert.ToDecimal(txtOculto.Text))
            {
                //PIO ESTA ALERTA NO DEJA ACTUALIZAR LA GRIDVIEW :(
                //ScriptManager.RegisterClientScriptBlock(this.panelEgreso, this.panelEgreso.GetType(), "alert", "alertaCantidad()", true);
                //return;
            }
            else
            {
                pila.Add(_Dmxi);

                DataRow row = tin.NewRow();
               row[0] = _Dmxi.FechaMovimiento;
               row[1] = _Di.VR_NombreRecurso; 
               row[2] = _Dmxi.Cantidad;
               row[3] = _Dm.M_NombreMedida;
               tin.Rows.Add(row);

                gvInsumosEgreso.DataSource = tin;
                gvInsumosEgreso.DataBind();
            }
        }
        protected void gvInsumosEgreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pila.Count > 0) {
                GridViewRow row = gvInsumosEgreso.SelectedRow;
                id = Convert.ToInt32(gvInsumosEgreso.DataKeys[row.RowIndex].Value) + 1;

            }
        }
        protected void btnQuitarInsumo_Click(object sender, EventArgs e)
        {  if (pila.Count != 0)
                {
                    tin.Rows[id].Delete();
                    pila.RemoveAt(id);
                    gvInsumosEgreso.DataSource = tin;
                    gvInsumosEgreso.DataBind();
                } 
        }
        protected void btnEgresar_ServerClick(object sender, EventArgs e)
        {
            while (pila.Count >= 1)
            {
                    //pila[pila.Count - 1].IdMovxInsumo = _Cmxi.ID_MAX();
                    _Cmxi.RegistrarMovimientoxInsumo(pila[pila.Count - 1]);
                    _Cmxi.UpdateStockEgreso(pila[pila.Count - 1]);
                    pila.RemoveAt(pila.Count - 1);
            }

            tin.Clear();
            //PIO AQUI DEBE IR LA ALERTA DE EXITO :( CUANDO LA PONGO NO REGISTRA
            ScriptManager.RegisterClientScriptBlock(this.panelEgreso, this.panelEgreso.GetType(), "alert", "alertaExito()", true);
            return;
        }
        protected void Selection_Change(Object sender, EventArgs e)
        {
            txtUnidadMedida.Text = _Cm.BuscarMedida(Convert.ToInt32(ddlInsumos.SelectedValue));
        }
    }
}
