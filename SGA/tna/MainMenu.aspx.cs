using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblName.Text = "Hi " + SGACommon.GetName() + "!";
        }

        protected void lnkLogout_Click(object sender, System.EventArgs e)
        {
            base.Session.Abandon();
            FormsAuthentication.SignOut();
            base.Response.Redirect("~/index.aspx");
        }
    }
}