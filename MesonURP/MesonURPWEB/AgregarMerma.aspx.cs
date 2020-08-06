using CTR;
using DevExpress.Utils.Design;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class AgregarMerma : System.Web.UI.Page
    {
        CTR_Merma _Cm = new CTR_Merma();
        DTO_Merma _Dm = new DTO_Merma();

        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarInsumosEgresados();
               //Text_Change();
            }
            txtFecha.Text = FechaActual;
            // txtCantidadTotal.Text = "2";
            // txtPesoMerma.Text = "1";
            //txtPesoRendimiento.Text = "HOLA";

        }

        public void ListarInsumosEgresados()
        {
            ddlInsumos.DataSource = _Cm.ListarInsumos(Convert.ToDateTime(FechaActual));
            ddlInsumos.DataTextField = "I_NombreInsumo";
            ddlInsumos.DataValueField = "I_idInsumo";
            ddlInsumos.DataBind();
            ddlInsumos.Items.Insert(0, "--- Seleccionar ---");
        }
        protected void Selection_Change(Object sender, EventArgs e)
        {
            if (ddlInsumos.SelectedIndex != 0)
            {
                txtEgresos.Text = _Cm.MostrarEgreseos(Convert.ToInt32(ddlInsumos.SelectedValue), Convert.ToDateTime(FechaActual));
                txtCantidadTotal.Text = _Cm.SumarEgreseos(Convert.ToInt32(ddlInsumos.SelectedValue), Convert.ToDateTime(FechaActual));
                txtocultoId.Text = _Cm.selectIdMovxIns(Convert.ToInt32(ddlInsumos.SelectedValue));

            }
        }
        //protected void txtPesoMerma_Text1_Change(object sender, EventArgs e)
        //{
        //    txtCantidadTotal.Text = _Cm.SumarEgreseos(Convert.ToInt32(ddlInsumos.SelectedValue));
        //    if (txtPesoMerma.Text != null)
        //    {
        //        txtPesoRendimiento.Text = txtPesoMerma.Text;
        //       // txtPesoRendimiento.Text = Convert.ToString(Convert.ToDecimal(txtCantidadTotal.Text) - Convert.ToDecimal(txtPesoMerma.Text));
        //        //txtPesoRendimiento.Text = Convert.ToString(_Cm.Rendimiento(Convert.ToInt32(ddlInsumos.SelectedValue), Convert.ToDecimal(txtPesoMerma.Text)));
        //    }
        //}
        //protected void SelectionObservacion_Change(Object sender, EventArgs e)
        //{
        //    if(ddlObservacion.SelectedValue == "1")
        //    {
        //        TextBox1.Visible = true;
        //        TextBox1.Text = "¡Hola, Mundo!";
        //        // MessageBox.Show(TextBox1.Text)
        //    }
        //    else
        //    {
        //        TextBox1.Visible = false;
        //    }
        //}
        
        protected void btnAgregar_ServerClick(object sender, EventArgs e)
        {

            try
            {
                _Dm.M_Fecha = Convert.ToDateTime(txtFecha.Text);
                _Dm.M_PesoMerma = Convert.ToDecimal(TextBox1.Text);
                _Dm.M_PesoRendimiento = Convert.ToDecimal(txtPesoRendi.Text);
                _Dm.M_Observacion = txtObservacion.Text;
                _Dm.MxI_idMovimientoxInsumo = Convert.ToInt32(txtocultoId.Text);
                _Cm.agregarMerma(_Dm);
                //_Ccat.CTR_AgregarCategoria(_Dcat);
                ScriptManager.RegisterClientScriptBlock(this.panelActM, this.panelActM.GetType(), "alert", "alertaExito()", true);
            }
            catch 
            {
                ScriptManager.RegisterClientScriptBlock(this.panelActM, this.panelActM.GetType(), "alert", "alertaError()", true);
                return;
            }

        }
        protected void btnLimpiar_ServerClick(object sender, EventArgs e)
        {

            if (ddlInsumos.SelectedIndex != 0)
            {
               ddlInsumos.SelectedIndex = 0;
            }
            txtEgresos.Text = "";
            txtFecha.Text = "";
            txtCantidadTotal.Text = "";
            TextBox1.Text = "";
            txtPesoRendi.Text = "";
            txtObservacion.Text = "";
        }

        //protected void txtPesoMerma_TextChange(object sender, EventArgs e)
        //{
        //    txtCantidadTotal.Text = _Cm.SumarEgreseos(Convert.ToInt32(ddlInsumos.SelectedValue));
        //    if (txtPesoMerma.Text != null)
        //    {
        //        txtPesoRendimiento.Text = Convert.ToString(Convert.ToDecimal(txtCantidadTotal.Text) - Convert.ToDecimal(txtPesoMerma.Text));
        //    }
        //}

        //txtCantidadTotal.Text = _Cm.SumarEgreseos(Convert.ToInt32(ddlInsumos.SelectedValue));

        //if (txtPesoMerma.Text != null)
        //{
        //    txtPesoRendimiento.Text = Convert.ToString(Convert.ToDecimal(txtCantidadTotal.Text) - Convert.ToDecimal(txtPesoMerma.Text));
        //}        

        protected void txtPesoMerma_TextChange1(object sender, EventArgs e)
        {
           if (TextBox1.Text != null)
            {
                txtPesoRendi.Text = Convert.ToString(Convert.ToDecimal(txtCantidadTotal.Text) - Convert.ToDecimal(TextBox1.Text));
            }
        }
    }
}

