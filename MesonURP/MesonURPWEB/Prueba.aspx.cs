using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace MesonURPWEB
{
    public partial class Prueba : System.Web.UI.Page
    {
        CTR_OC ctr_oc;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_oc = new CTR_OC();
            dt = new DataTable();
            dt = ctr_oc.Leer_OC_Recibido();
            GridViewConsultar.DataSource = dt;
            GridViewConsultar.DataBind();
        }

        protected void GridViewConsultar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}