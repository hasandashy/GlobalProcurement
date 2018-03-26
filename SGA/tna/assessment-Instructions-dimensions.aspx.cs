using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class assessment_Instructions_dimensions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SGACommon.AddPageTitle(this.Page, "Procurement Benchmark Assessment Instructions Page", "");
            //SGACommon.IsTakeTest("viewSGATest");
            if (!base.IsPostBack)
            {
                this.lblName.Text = SGACommon.GetName() + ", welcome to the";

            }
        }
    }
}