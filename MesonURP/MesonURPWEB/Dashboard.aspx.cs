using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace MesonURPWEB
{
    public partial class Dashboard : System.Web.UI.Page
    {
        CTR_OC ctr_oc;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_oc = new CTR_OC();
           // if(ctr_oc.CTR_Leer_OC())
        }
    }
}