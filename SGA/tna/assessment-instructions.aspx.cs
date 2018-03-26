using DataTier;
using SGA.App_Code;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class assessment_instructions : System.Web.UI.Page
    {
        protected int directSend = 0;


        protected void Page_Load(object sender, System.EventArgs e)
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