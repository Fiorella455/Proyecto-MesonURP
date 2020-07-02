﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;

namespace MesonURPWEB
{
    public partial class GestionarProveedor : System.Web.UI.Page
    {
        CTR_Proveedor ctr_pro;
        DataSet dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ctr_pro = new CTR_Proveedor();
                dt = new DataSet();
                dt = ctr_pro.Leer_Proveedor();
                GridViewProveedor.DataSource = dt;
                GridViewProveedor.DataBind();
            }
        }

        protected void GridViewProveedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "ActualizarProveedor")
            {
                int id = Convert.ToInt32(GridViewProveedor.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["P_idProveedor"].ToString());
                Session.Add("id",id);
                Response.Redirect("ActualizarProveedor.aspx");
            }
            if (e.CommandName == "ConsultarProveedor")
            {
                int id = Convert.ToInt32(GridViewProveedor.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["P_idProveedor"].ToString());
                Session.Add("id", id);
                Response.Redirect("ConsultarProveedor.aspx");
            }
            if (e.CommandName == "EliminarProveedor")
            {
                int id = Convert.ToInt32(GridViewProveedor.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["P_idProveedor"].ToString());
                Session.Add("id", id);
                Response.Redirect("EliminarProveedor.aspx");
            }
        }

        protected void GridViewProveedor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                string estado = e.Row.Cells[8].Text.ToString();
                if(estado=="Activo")
                {
                    e.Row.Cells[11].Controls.Clear();
                }
            }
        }
    }
}