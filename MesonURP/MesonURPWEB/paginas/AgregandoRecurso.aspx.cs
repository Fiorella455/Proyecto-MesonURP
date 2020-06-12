using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;

namespace MesonURPWEB.paginas
{
    public partial class AgregandoRecurso : System.Web.UI.Page
    {
       
        CTR_Categoria ctr_categoria;
        DataSet dataset;
        DTO_OC dto_oc = new DTO_OC();
        CTR_OC ctr_oc = new CTR_OC();
        DAO_OC dao_oc = new DAO_OC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                
                    ctr_categoria = new CTR_Categoria();
                    dataset = new DataSet();
                    dataset = ctr_categoria.CTR_Leer_Categorias();
                    ddlcategoria.Items.Insert(0, new ListItem("Seleccione Categoria"));
                    ddlcategoria.DataTextField = "C_NombreCategoria";
                    ddlcategoria.DataValueField = "C_idCategoria";
                    ddlcategoria.DataSource = dataset;
                    ddlcategoria.DataBind();
                   
                }
        }


        public void Consultar_OC()
        {
            dto_oc.OC_idOrdenCompra = int.Parse(txtID.Text);
            if (ctr_oc.CTR_Leer_OC(dto_oc))
            {
                txtTipoComp.Text = dto_oc.OC_TipoComprobante;
                txtNumeroComp.Text = dto_oc.OC_NumeroComprobante;
                txtTotal.Text = dto_oc.OC_TotalCompra.ToString();
                txtFechaEmi.Text = dto_oc.OC_FechaEmision.ToString();
                txtProveedor.Text = dto_oc.P_idProveedor.ToString();
            }
            if (dto_oc.Estado == 100)
            {
                //Existe este registro
            }

        }
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
  
                
                //int catselect= int.Parse(ddlcategoria.SelectedItem.Value);
                //Ctr_Recurso ctr_recurso = new Ctr_Recurso();
                //dataset = new DataSet();
                //dataset = ctr_recurso.Ctr_Leer_RecursoxCategoria(catselect);
                //ddlInsumo.DataTextField = "VR_NombreInsumo";
                //ddlInsumo.DataValueField = "PK_idInsumo";
                //ddlInsumo.DataSource = dataset;
                Consultar_OC();
                
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            txtMsj.Text= dao_oc.EnviarCorreo(int.Parse(txt_idOC.Text));
        }
    }
}