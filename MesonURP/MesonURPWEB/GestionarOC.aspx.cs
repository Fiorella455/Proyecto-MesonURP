﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using DAO;
using CTR;
using System.Data;

namespace MesonURPWEB
{

    public partial class GestionarOC : System.Web.UI.Page
    {
        DTO_OC dto_oc = new DTO_OC();
        DTO_MovimientoxInsumo dto_movxinsumo = new DTO_MovimientoxInsumo();
        DTO_Estado_OCxOC dto_estado_OCxOC = new DTO_Estado_OCxOC();
        DAO_OC dao_oc = new DAO_OC();
        CTR_OC ctr_oc = new CTR_OC();
        CTR_OCxInsumo ctr_ocxinsumo = new CTR_OCxInsumo();
        CTR_MovimientoxInsumo ctr_movxinsumo = new CTR_MovimientoxInsumo();
        CTR_EstadoOCxOC ctr_estado_OCxOC = new CTR_EstadoOCxOC();
        CTR_OC _OC = new CTR_OC();
        DataTable dt;
        DataSet ds_movxinsumo = new DataSet();
        DataTable dt_ocxinsumo = new DataTable();
        int idOC = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["codUsuario"] == null)
            //{
            //    Response.Redirect("Home.aspx?x=1");
            //}
            if (!IsPostBack)
            {
                dt = new DataTable();
                dto_oc = new DTO_OC();
                dt = ctr_oc.Leer_OC();
                GridViewOC.DataSource = dt;
                GridViewOC.DataBind();
            }
        }
        protected void GridViewOC_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string state = e.Row.Cells[1].Text.ToString();
                if (state == "En Espera" || state == "En \nEspera")
                {
                    e.Row.Cells[7].FindControl("btnEnviarEmailOC").Visible = false;
                    e.Row.Cells[8].FindControl("btnEditarOC").Visible = false;
                    e.Row.Cells[9].FindControl("btnVerDetallesOC").Visible = true;
                    var button = (ImageButton)e.Row.FindControl("btnRecibido"); //
                    if (button != null) { button.Visible = false; }
                    var btn1 = (ImageButton)e.Row.FindControl("btnEliminar"); //
                    if (btn1 != null) { btn1.Visible = false; }
                }
                if (state == "Aceptado")
                {
                    e.Row.Cells[7].FindControl("btnEnviarEmailOC").Visible = false;
                    e.Row.Cells[8].FindControl("btnEditarOC").Visible = false;
                    e.Row.Cells[10].FindControl("btnEliminar").Visible = false;

                    var button = (ImageButton)e.Row.FindControl("btnRecibido"); //
                    if (button != null) { button.Visible = true; }
                    var btn2 = (ImageButton)e.Row.FindControl("btnAceptado"); //
                    if (btn2 != null) { btn2.Visible = false; }
                    e.Row.Cells[11].Controls.Clear();
                    var btn3 = (ImageButton)e.Row.FindControl("btnRechazado"); //
                    if (btn3 != null) { btn3.Visible = false; }
                }
                if (state == "Rechazado")
                {
                    e.Row.Cells[7].FindControl("btnEnviarEmailOC").Visible = false;
                    e.Row.Cells[8].FindControl("btnEditarOC").Visible = false;
                    e.Row.Cells[11].FindControl("btnAceptado").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazado").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibido").Visible = false;
                }
                if (state == "Recibido")
                {
                    e.Row.Cells[7].FindControl("btnEnviarEmailOC").Visible = false;
                    e.Row.Cells[8].FindControl("btnEditarOC").Visible = false;
                    e.Row.Cells[10].FindControl("btnEliminar").Visible = false;
                    e.Row.Cells[11].FindControl("btnAceptado").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazado").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibido").Visible = false;
                }
                if (state == "Creado")
                {
                    e.Row.Cells[11].FindControl("btnAceptado").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazado").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibido").Visible = false;
                }

            }

        }

        protected void GridViewOC_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "EnviarEmailOC")
            {
                idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;
                ctr_oc = new CTR_OC();

                string tipoComprobante = GridViewOC.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                string numeroComprobante = GridViewOC.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                string formaPago = GridViewOC.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                string totalCompra = GridViewOC.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                string fechaEmision = GridViewOC.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;


                string htmlBody = Resource.MensajeOC;
                htmlBody = htmlBody.Replace("#IDOC#", dto_oc.OC_idOrdenCompra.ToString());
                htmlBody = htmlBody.Replace("#TIPOCOMPROBANTE#", tipoComprobante);
                htmlBody = htmlBody.Replace("#NUMEROCOMPROBANTE#", numeroComprobante);
                htmlBody = htmlBody.Replace("#FORMADEPAGO#", formaPago);
                htmlBody = htmlBody.Replace("#MONTOTOTAL#", totalCompra);
                htmlBody = htmlBody.Replace("#FECHAEMISION#", fechaEmision);

                ctr_oc.Enviar_OC(dto_oc, htmlBody);
                //-----------------------------------------------------------------------
                dto_oc.OC_idOrdenCompra = idOC;
                dto_estado_OCxOC.OC_idOrdenCompra = dto_oc.OC_idOrdenCompra;
                dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
                dto_estado_OCxOC.EOC_idEstadoOC = 2;
                dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
                ctr_estado_OCxOC.Actualizar_Estado_OCxOC(dto_estado_OCxOC);
                CargarOrdenesCompra();
                ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaCorreo('');", true);



            }
            if (e.CommandName == "EliminarOC")
            {
                idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;
                ctr_oc = new CTR_OC();
                ctr_oc.Eliminar_OC(idOC);
                CargarOrdenesCompra();
                ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaEliminar('');", true);
            }
            if (e.CommandName == "ConsultarOC")
            {
                idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;

                Session.Add("indice", dto_oc);
                Response.Redirect("ConsultarOC");

            }
            if (e.CommandName == "ActualizarOC")
            {
                idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;
                Session.Add("OCActual", dto_oc);
                Response.Redirect("ActualizarOC");
            }
            if (e.CommandName == "AceptarOC")
            {
                idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;
                //-----------------------------------------------------------------------

                dto_estado_OCxOC.OC_idOrdenCompra = dto_oc.OC_idOrdenCompra;
                dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
                dto_estado_OCxOC.EOC_idEstadoOC = 3;
                dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
                ctr_estado_OCxOC.Actualizar_Estado_OCxOC(dto_estado_OCxOC);
                CargarOrdenesCompra();

                //ScriptManager.RegisterStartupScript(this.panelOC, this.panelOC.GetType(), "alertIns", "alertaAceptado()", true);
                ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaAceptado('');", true);

            }
            if (e.CommandName == "RechazarOC")
            {
                idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;
                //-----------------------------------------------------------------------

                dto_oc.OC_idOrdenCompra = idOC;
                dto_estado_OCxOC.OC_idOrdenCompra = dto_oc.OC_idOrdenCompra;
                dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
                dto_estado_OCxOC.EOC_idEstadoOC = 4;
                dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
                ctr_estado_OCxOC.Actualizar_Estado_OCxOC(dto_estado_OCxOC);

                CargarOrdenesCompra();
                ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaRechazado('');", true);
                //ScriptManager.RegisterStartupScript(this.panelOC, this.panelOC.GetType(), "alertIns", "alertaRechazado()", true);

            }
            if (e.CommandName == "RecibirOC")
            {
                idOC = Convert.ToInt32(GridViewOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOrdenCompra"].ToString());
                dto_oc.OC_idOrdenCompra = idOC;
                //-----------------------------------------------------------------------

                dto_oc.OC_idOrdenCompra = idOC;
                dto_estado_OCxOC.OC_idOrdenCompra = dto_oc.OC_idOrdenCompra;
                dto_estado_OCxOC.EOCxOC_FechaRegistro = DateTime.Today;
                dto_estado_OCxOC.EOC_idEstadoOC = 5;
                dto_estado_OCxOC.EOCxOC_UsuarioRegistro = 5;
                ctr_estado_OCxOC.Actualizar_Estado_OCxOC(dto_estado_OCxOC);

                RegistrarMov(idOC);

                CargarOrdenesCompra();

                ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaRecibido('');", true);
                //ScriptManager.RegisterStartupScript(this.panelOC, this.panelOC.GetType(), "alertIns", "alertaRecibido()", true);
            }
        }


        protected void btnEditarOC_Click(object sender, EventArgs e)
        {
            GridViewRow OC = (GridViewRow)((Button)sender).Parent.Parent;
            int i = OC.RowIndex;

            dto_oc.OC_idOrdenCompra = Convert.ToInt32(GridViewOC.Rows[i].Cells[0].Text);

            Response.Redirect("ActualizarOC.aspx?idOC" + 1);
        }

        public void CargarOrdenesCompra()
        {
            GridViewOC.DataSource = _OC.Leer_OC();
            GridViewOC.DataBind();
        }
        public void RegistrarMov(int idOC)
        {

            dt_ocxinsumo = ctr_ocxinsumo.Leer_InsumoxOC(idOC);
            foreach (DataRow row in dt_ocxinsumo.Rows)
            {

                dto_movxinsumo.IdInsumo = Convert.ToInt32(row["I_idInsumo"]);
                dto_movxinsumo.Cantidad = Convert.ToInt32(row["OCxI_Cantidad"]);
                dto_movxinsumo.FechaMovimiento = DateTime.Now;
                dto_movxinsumo.IdMovimiento = 1;
                dto_movxinsumo.IdUsuarioMovimiento = 5;
                ctr_movxinsumo.RegistrarMovimientoxInsumo(dto_movxinsumo);

            }

        }

        protected void GridViewOC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewOC.PageIndex = e.NewPageIndex;
            CargarOrdenesCompra();

        }
        protected void btnRegistrarOC_Click(object sender, EventArgs e)
        {
            Response.Redirect("AñadirOC");
        }
    }
}