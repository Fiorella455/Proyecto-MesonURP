using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesonURPWEB
{
    public partial class PruebaAnñadirOC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCantidad.Text) == 0)
            {
                Label2.Text = "Es cero";
            }
            if (Convert.ToInt32(txtCantidad.Text) == 1)
            {
                Label2.Text = "Es uno";
            }
            else 
            {
                Label2.Text = "Sí funciona";
            }
        }
    }
}