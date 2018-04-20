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
    public partial class my_results_bar_graph_gap : System.Web.UI.Page
    {
        protected bool isSgaResult = false;



        protected void Page_Load(object sender, System.EventArgs e)
        {
            string sessionId = string.Empty;
            SGACommon.IsViewResult("viewSGA");
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
                }
                else
                {
                    base.Response.Redirect("default.aspx", false);
                }
            }
        }

        protected void lnkLower_Click(object sender, System.EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;

            if (lnk != null)
            {
                lnk.Attributes["class"] = "active";
            }
        }
    }
}