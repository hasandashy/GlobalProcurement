﻿using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class SuccessMessage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                lblName.Text = "Well done " + SGACommon.GetName();
            }
        }
    }
}