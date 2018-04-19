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

namespace SGA.tna
{
    public partial class my_results : System.Web.UI.Page
    {
        protected bool isSgaTest = false;
        protected bool takeSgaTest = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (!isProfileComplete())
                {
                    Response.Redirect("MyProfile.aspx");
                }
                else
                {
                    BindResults();
                }
            }
        }

        private void BindResults()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSGATests", new SqlParameter[]
            {
                new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
            });
            this.parentRepeater.DataSource = ds;
            this.parentRepeater.DataBind();
        }

        protected void parentRepeater_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "graph")
            {                
                Session["sgaTestId"] = e.CommandArgument;
                Response.Redirect("my-results-bar-graph.aspx");
            }
        }

        private bool isProfileComplete()
        {
            bool isComplete = false;
            int num = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(sector) from UserInfo where userid =" + SGACommon.LoginUserInfo.userId + " "));
            if (num == 1)
            {
                isComplete = true;
            }
            return isComplete;
        }
    }
}