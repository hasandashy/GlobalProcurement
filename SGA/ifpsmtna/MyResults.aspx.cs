using System;
using System.Collections.Generic;
using DataTier;
using SGA.App_Code;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace SGA.ifpsmtna
{
    public partial class MyResults : System.Web.UI.Page
    {
        private const int LeftAlign = 0;

        private const int CenterAlign = 1;

        private const int RightAlign = 2;      
        private string imagepath;

        public int pgNum
        {
            get
            {
                int result;
                if (this.ViewState["PgNum"] != null)
                {
                    result = System.Convert.ToInt32(this.ViewState["PgNum"]);
                }
                else
                {
                    result = 0;
                }
                return result;
            }
            set
            {
                this.ViewState["PgNum"] = value;
            }
        }

        public int pgNumPd
        {
            get
            {
                int result;
                if (this.ViewState["pgNumPd"] != null)
                {
                    result = System.Convert.ToInt32(this.ViewState["pgNumPd"]);
                }
                else
                {
                    result = 0;
                }
                return result;
            }
            set
            {
                this.ViewState["pgNumPd"] = value;
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            SGACommon.AddPageTitle(this.Page, "Procurement Benchmark Association Result Page", "");
            SGACommon.IsViewResult("viewSGA");
            if (!base.IsPostBack)
            {
              
                this.BindResults();
                //base.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                base.ClientScript.RegisterStartupScript(this.Page.GetType(), "abc", "$(document).ready(function(){\r\nStyleRadio();\r\n});", true);
            }
        }

        private void BindResults()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSGATests", new SqlParameter[]
            {
                new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
            });
            int cnt = ds.Tables[0].Rows.Count;

            if(cnt < 1)
            {
                Response.Redirect("ResultDenied.aspx");
            }
            PagedDataSource paged = new PagedDataSource();
            paged.DataSource = ds.Tables[0].DefaultView;
            paged.AllowPaging = true;
            paged.PageSize = 10;
            paged.CurrentPageIndex = this.pgNumPd;
            this.ViewState["pgNumPd"] = this.pgNumPd;
            int vcnt = cnt / paged.PageSize;
            this.btnprev.Visible = !paged.IsFirstPage;
            this.btnnext.Visible = !paged.IsLastPage;
            this.rptSgaTest.DataSource = paged;
            this.rptSgaTest.DataBind();
        }

        protected void btnprev_Click(object sender, System.EventArgs e)
        {
            this.pgNumPd--;
            this.BindResults();
            base.ClientScript.RegisterStartupScript(this.Page.GetType(), "abc", "$(document).ready(function(){\r\nStyleRadio();\r\n});", true);
        }

        protected void btnnext_Click(object sender, System.EventArgs e)
        {
            this.pgNumPd++;
            this.BindResults();
            base.ClientScript.RegisterStartupScript(this.Page.GetType(), "abc", "$(document).ready(function(){\r\nStyleRadio();\r\n});", true);
        }

        protected void rptSgaTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label lblConvertedDate = (Label)e.Item.FindControl("lblConvertedDate");
                Label lblTimeTaken = (Label)e.Item.FindControl("lblTimeTaken");
                System.DateTime dtTestdate = System.Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "testDate"));
                string timeDiff = DataBinder.Eval(e.Item.DataItem, "diff").ToString();
                if (lblConvertedDate != null)
                {
                    lblConvertedDate.Text = SGACommon.ToAusTimeZone(dtTestdate).ToString("dd/MM/yyyy HH:mm tt");
                }
                if (lblTimeTaken != null)
                {
                    string[] strArr = timeDiff.Split(new char[]
                    {
                        ':'
                    });
                    lblTimeTaken.Text = strArr[1] + " min " + strArr[2] + " sec ";
                }
            }
        }

        protected void lnkResults_Click(object sender, System.EventArgs e)
        {
        }

        protected void rptSgaTest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bar")
            {
                this.Session["sgaTestId"] = e.CommandArgument;
                base.Response.Redirect("my-results-bar-graph.aspx", false);
            }
        }

   
        
    }
}