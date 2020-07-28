using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace MesonURPWEB
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        CTR_Insumo _CI = new CTR_Insumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            Dashboard1();
        }
        public void Dashboard1()
        {
            Chart1.Titles["Title1"].Text = "Insumos por agotarse";

            Chart1.Series["Series1"].XValueMember = "Insumo";
            Chart1.Series["Series1"].YValueMembers = "Total";
            Chart1.Series["Series1"].SmartLabelStyle.Enabled = true;
            Chart1.DataSource = _CI.ListarDashboard();
            Chart1.DataBind();
        }
    }
}