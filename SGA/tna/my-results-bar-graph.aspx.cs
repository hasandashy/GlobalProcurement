using DataTier;
using SGA.App_Code;
using SGA.controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class my_results_bar_graph : System.Web.UI.Page
    {


        protected void Page_Load(object sender, System.EventArgs e)
        {
            string sessionId = string.Empty;
            if (Session["sgaTestId"] != null)
            {
                sessionId = Session["sgaTestId"].ToString();
            }
            if (!isProfileComplete(sessionId))
            {
                Response.Redirect("TestDenied.aspx");
            }
            if (!base.IsPostBack)
            {
                if (!String.IsNullOrEmpty(sessionId))
                {
                    this.graph1.testId = System.Convert.ToInt32(sessionId);
                }
                else
                {
                    Response.Redirect("default.aspx");
                }

            }


        }


        private bool isProfileComplete(string testId)
        {
            bool isComplete = false;
            int num = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(sector) from UserInfo where userid =" + SGACommon.LoginUserInfo.userId + " "));

            int num2 = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(1) from tblUserSgaTest where userid =" + SGACommon.LoginUserInfo.userId + " and isCompleted = 1 and testId=" + testId));
            if (num == 1 && num2 == 1)
            {
                isComplete = true;
            }
            return isComplete;
        }




    }
}