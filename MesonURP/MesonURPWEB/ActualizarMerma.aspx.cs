using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class ActualizarMerma : System.Web.UI.Page
    {
        DTO_Merma _Dm = new DTO_Merma();
        CTR_Merma _Cm = new CTR_Merma();

        DateTime Fecha;
        string obv;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                int idMerma = Convert.ToInt32(Session["T_idMerma"]);
                string Insumo = Session["I_NombreInsumo"].ToString();
                string Medida = Session["M_NombreMedida"].ToString();
                decimal pesoTotal = Convert.ToDecimal(Session["PesoTotal"]);//CAMBIO
                _Dm = _Cm.ConsultarMermaxId(idMerma);
                txtInsumo.Text = Insumo;
                txtCantidadTotal.Text = Convert.ToString(pesoTotal); //CAMBIO
                txtFecha.Text = _Dm.M_Fecha.ToString("dd/MM/yyyy");
                txtPesoMerma.Text = Convert.ToString(Convert.ToDecimal(_Dm.M_PesoMerma));
                txtPesoRendimiento.Text = Convert.ToString(Convert.ToDecimal(_Dm.M_PesoRendimiento));
                txtObservacion.Text = _Dm.M_Observacion;
                txtmedida.Text = Medida;
                txtmedida1.Text = Medida;
                txtmedida2.Text = Medida;

            }
            
        }
        
        protected void txtPesoMerma_TextChange1(object sender, EventArgs e)
        {
            //string Insumo = Session["I_NombreInsumo"].ToString();
            Fecha = Convert.ToDateTime(Session["M_Fecha"].ToString());
            //obv = Session["M_observacion"].ToString();
            //txtInsumo.Text = Insumo;
           decimal pesoTotal = Convert.ToDecimal(Session["PesoTotal"]); //CAMBIO
            
           

            if (txtPesoMerma.Text != null)
            {
                string Insumo = Session["I_NombreInsumo"].ToString();
                string Medida = Session["M_NombreMedida"].ToString();
                Fecha = Convert.ToDateTime(Session["M_Fecha"].ToString());
                txtInsumo.Text = Insumo;
                txtCantidadTotal.Text = Convert.ToString(pesoTotal);
                txtmedida.Text = Medida;
                txtPesoRendimiento.Text = Convert.ToString(Convert.ToDecimal(txtCantidadTotal.Text) - Convert.ToDecimal(txtPesoMerma.Text));
                txtFecha.Text = Fecha.ToString("dd/MM/yyyy");
                txtmedida1.Text = Medida;
                txtmedida2.Text = Medida;
            }
            
                 
        }
        protected void btnActualizar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int idMerma = Convert.ToInt32(Session["T_idMerma"]);
                _Dm.T_idMerma = idMerma;
                //TextBox1.Text = Convert.ToString(idMerma);
                _Dm.M_PesoMerma = Convert.ToDecimal(txtPesoMerma.Text);
                _Dm.M_PesoRendimiento = Convert.ToDecimal(txtPesoRendimiento.Text);
                _Dm.M_Observacion = txtObservacion.Text;
                _Cm.actualizarMerma(_Dm);
                //_Ccat.CTR_AgregarCategoria(_Dcat);
                ScriptManager.RegisterClientScriptBlock(this.panelActM, this.panelActM.GetType(), "alert", "alertaExito()", true);
                
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.panelActM, this.panelActM.GetType(), "alert", "alertaError()", true);
                return;
            }

        }

        
    }
}
