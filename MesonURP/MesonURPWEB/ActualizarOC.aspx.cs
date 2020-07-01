﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;

namespace MesonURPWEB
{
    public partial class ActualizarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc;
        DTO_OCxInsumo dto_ocxinsumo;
        DTO_Medida dto_medida = new DTO_Medida();
        CTR_Medida ctr_medida = new CTR_Medida();
        CTR_OC ctr_oc = new CTR_OC();
        CTR_Proveedor pro = new CTR_Proveedor();
        CTR_Estado_OC ctr_Estado_OC = new CTR_Estado_OC();
        DataSet dtestado;
        CTR_OCxInsumo ctr_ocxinsumo = new CTR_OCxInsumo();
        CTR_Insumo ctr_insumo = new CTR_Insumo();
        DataTable dt = new DataTable();
        DataSet dtpro = new DataSet();
        DTO_Estado_OCxOC dto_estado_OCxOC = new DTO_Estado_OCxOC();
        DAO_EstadoOCxOC dao_estadoOCxOC = new DAO_EstadoOCxOC();
        CTR_EstadoOCxOC ctr_estado_OCxOC = new CTR_EstadoOCxOC();
        static List<DTO_OCxInsumo> pila = new List<DTO_OCxInsumo>();
        static DataTable tin = new DataTable();
        int id = 0;
        decimal suma = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_oc = (DTO_OC)Session["OCActual"];
           
            //dtcat = new DataSet();
            
            
            if (!IsPostBack)
            {
                listarInsumo();
                dtestado = new DataSet();

                //------------------------------------------------
                dtpro = new DataSet();
                dtpro = pro.Leer_Proveedor();

                DdlProveedor.DataTextField = "P_RazonSocial";
                DdlProveedor.DataValueField = "P_idProveedor";
                DdlProveedor.DataSource = dtpro;
                DdlProveedor.DataBind();
                
                //--------------------------------------------Llenar 

                ctr_oc.CTR_Leer_OC(dto_oc);
                txtNumComprobante.Text = dto_oc.OC_NumeroComprobante;
                txtTipoComprobante.Text = dto_oc.OC_TipoComprobante;                                                  
                DdlProveedor.Text = dto_oc.P_idProveedor.ToString();
                txtFormaPago.Text = dto_oc.OC_FormaPago;
                txtTotal.Text = dto_oc.OC_TotalCompra.ToString();
                //-------------------------------------------------------
                ctr_ocxinsumo = new CTR_OCxInsumo();
                
                dt = ctr_ocxinsumo.Leer_InsumoxOC(dto_oc.OC_idOrdenCompra);
                GridViewEditarOC.DataSource = dt;
                GridViewEditarOC.DataBind();

            }
        }
        public void listarInsumo()
        {
            DdlInsumo.DataSource = ctr_insumo.SelectInsumosOC();
            DdlInsumo.DataTextField = "I_NombreInsumo";
            DdlInsumo.DataValueField = "I_idInsumo";
            DdlInsumo.DataBind();
            DdlInsumo.Items.Insert(0, "--seleccionar--");
        }
        protected void DdlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecioU.Text = ctr_insumo.SelectPrecioUnitario(Convert.ToInt32(DdlInsumo.SelectedValue));
            txtMedida.Text = ctr_medida.BuscarMedida(Convert.ToInt32(DdlInsumo.SelectedValue));
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            
            dto_oc.OC_TipoComprobante = txtTipoComprobante.Text;          
            dto_oc.OC_FormaPago = txtFormaPago.Text;
            dto_oc.OC_NumeroComprobante = txtNumComprobante.Text;           
            dto_oc.P_idProveedor = int.Parse(DdlProveedor.SelectedValue);          
            dto_oc.OC_TotalCompra = Convert.ToDecimal(txtTotal.Text);
            ctr_oc.Actualizar_OC(dto_oc);

            //--------------------------------------------------------------
            //GridViewRow OCxI = (GridViewRow)((Button)sender).Parent.Parent;
            //DTO_OCxInsumo OCIAux = new DTO_OCxInsumo();
            //int i = OCxI.RowIndex;
            //OCIAux.R_idInsumo = Convert.ToInt32(GridViewEditarOC.Rows[i].Cells[1].Text);
            //OCIAux.I_idInsumo = Convert.ToInt32(GridViewEditarOC.Rows[i].Cells[2].Text);
            //OCIAux.OC_idOrdenCompra = Convert.ToInt32(GridViewEditarOC.Rows[i].Cells[3].Text);
            //OCIAux.OCxI_Cantidad = Convert.ToDecimal(GridViewEditarOC.Rows[i].Cells[4].Text);
            //OCIAux.OCxI_PrecioTotal = Convert.ToDecimal(GridViewEditarOC.Rows[i].Cells[5].Text);
            //Session.Add("OCIAux", OCIAux);

            Response.Redirect("GestionarOC.aspx");
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            tin.Rows[id].Delete();
            pila.RemoveAt(id);
            suma -= Convert.ToDecimal(GridViewEditarOC.Rows[id].Cells[3].Text);
            txtTotal.Text = suma.ToString();
            GridViewEditarOC.DataSource = dt;
            GridViewEditarOC.DataBind();
        }

        protected void GridViewEditarOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewEditarOC.SelectedRow;
            id = Convert.ToInt32(GridViewEditarOC.DataKeys[row.RowIndex].Value);
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            dto_ocxinsumo = new DTO_OCxInsumo();
            dto_ocxinsumo.I_idInsumo = int.Parse(DdlInsumo.SelectedValue);
            DTO_Insumo insumo = ctr_insumo.Consultar_InsumoxID(dto_ocxinsumo.I_idInsumo);
            // dto_ocxinsumo.OC_idOrdenCompra = ctr_oc.ID_OC_Actual()+1;
            dto_ocxinsumo.OCxI_Cantidad = int.Parse(txtCantidad.Text);
            dto_ocxinsumo.OCxI_PrecioTotal = dto_ocxinsumo.OCxI_Cantidad * Convert.ToDecimal(insumo.DR_PrecioUnitario);
            suma += dto_ocxinsumo.OCxI_PrecioTotal;
            dto_oc.OC_TotalCompra += Convert.ToDecimal(dto_ocxinsumo.OCxI_PrecioTotal);
            pila.Add(dto_ocxinsumo);
            txtTotal.Text = suma.ToString();
         
            if (tin.Columns.Count == 0)
            {
                tin.Columns.Add("I_idInsumo");
                tin.Columns.Add("I_NombreInsumo");
                tin.Columns.Add("OCxI_Cantidad");
                tin.Columns.Add("I_PrecioUnitario");
                tin.Columns.Add("OCxI_PrecioTotal");

            }
            DataRow row = tin.NewRow();
            row[0] = dto_ocxinsumo.I_idInsumo;
            row[1] = insumo.VR_NombreRecurso;
            row[2] = dto_ocxinsumo.OCxI_Cantidad;
            row[3] = insumo.DR_PrecioUnitario;
            row[4] = dto_ocxinsumo.OCxI_PrecioTotal;

            tin.Rows.Add(row);

            GridViewEditarOC.DataSource = tin;
            GridViewEditarOC.DataBind();



        }
    }
}