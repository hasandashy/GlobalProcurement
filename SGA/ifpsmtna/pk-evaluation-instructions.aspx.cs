using DataTier;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.ifpsmtna
{
    public partial class pk_evaluation_instructions : System.Web.UI.Page
    {
        protected int directSend = 1;


        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!isProfileComplete())
            {
                Response.Redirect("MyProfile.aspx?_directsend=1");
            }
            SGACommon.AddPageTitle(this.Page, "Procurement Benchmark Assessment Instructions Page", "");
            //SGACommon.IsTakeTest("viewPkeTest");
            if (!base.IsPostBack)
            {
                this.lblName.Text = "Hi " + SGACommon.GetName() + "!";
                //this.PassProfile();
            }
        }

        private bool isProfileComplete()
        {
            bool isComplete = false;
            int num = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(sector) from UserInfo where sector != 0 and sector is not null and userid =" + SGACommon.LoginUserInfo.userId + " "));
            if (num > 0)
            {
                isComplete = true;
            }
            return isComplete;
        }
    }
}