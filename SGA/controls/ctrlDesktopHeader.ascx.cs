using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.controls
{
    public partial class ctrlDesktopHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }

        protected void lnkLogout_Click(object sender, System.EventArgs e)
        {
            base.Session.Abandon();
            FormsAuthentication.SignOut();
            base.Response.Redirect("~/index.aspx");
        }
    }
}