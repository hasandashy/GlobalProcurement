using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using Hammock.Authentication.OAuth;
using Hammock;
using SGA.App_Code;

namespace SGA
{
    public partial class Site : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    base.Response.Redirect("~/index.aspx", false);
                }
            }

        }

      
        
    }
}