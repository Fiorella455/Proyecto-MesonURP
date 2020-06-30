using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class ConsultarInsumo : System.Web.UI.Page
    {
        protected void btnconsultarInsumo_ServerClick(object sender, EventArgs e)
        {
            if(txtconsultarInsumo.Text != "")
            {
                gvInsumo.DataSource = _CI.consultarInsumo(txtconsultarInsumo.Tex);
                gvInsumo.DataBind(); 
            }
            
        }
    }
}