using DataTier;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.ifpsmtna
{
    public partial class personalised_dashboard : System.Web.UI.Page
    {
        protected bool isSgaResult = false;


       

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string sessionId = string.Empty;
            SGACommon.IsViewResult("viewSGA");
            //if (Request.QueryString["_directsend"] != null)
            //{
            //    _deirectsend = Request.QueryString["_directsend"].ToString();
            //}
            DataSet dsPermission = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPremission", new SqlParameter[]
            {
                new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
            });
            if (dsPermission != null)
            {
                if (dsPermission.Tables.Count > 0 && dsPermission.Tables[0].Rows.Count > 0)
                {
                    this.isSgaResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewSGA"].ToString());

                }
            }

            if (Session["sgaTestId"] != null)
            {
                sessionId = Session["sgaTestId"].ToString();
            }
            else
            {
                Response.Redirect("TestDenied.aspx");
            }

            if (!isProfileComplete(sessionId))
            {
                Response.Redirect("TestDenied.aspx");
            }
            if (!base.IsPostBack)
            {
                if (!String.IsNullOrEmpty(sessionId))
                {
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@userId", SGACommon.LoginUserInfo.userId),
                        new SqlParameter("@testId", sessionId)
                    };
                    this.graph1.testId = System.Convert.ToInt32(sessionId);
                    this.graph2.testId = System.Convert.ToInt32(sessionId);
                   
                }
                else
                {
                    base.Response.Redirect("default.aspx", false);
                }
            }
        }

        private bool isProfileComplete(string testId)
        {
            bool isComplete = false;
            int num = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(sector) from UserInfo where sector != 0 and sector is not null and userid =" + SGACommon.LoginUserInfo.userId + " "));

            int num2 = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(1) from tblUserSgaTest where userid =" + SGACommon.LoginUserInfo.userId + " and isCompleted = 1 and testId=" + testId));
            if (num > 0 && num2 >= 1)
            {
                isComplete = true;
            }
            return isComplete;
        }
    }
}