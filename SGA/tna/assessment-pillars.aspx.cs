using DataTier;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class assessment_pillars : System.Web.UI.Page
    {
        public bool IsCurrent
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["IsCurrent"].ToString());
            }
            set
            {
                this.ViewState["IsCurrent"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SGACommon.AddPageTitle(this.Page, "Procurement Benchmark Assessment Pillars", "");
            //SGACommon.IsTakeTest("viewSGATest");
            if (!base.IsPostBack)
            {
                IsCurrent = false;
                this.lblName.Text = "Welcome " + SGACommon.GetName();
                BindTopics();
            }
        }
        protected void parentRepeater_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem || e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                HtmlGenericControl div = e.Item.FindControl("start") as HtmlGenericControl;
                HtmlGenericControl li = e.Item.FindControl("list") as HtmlGenericControl;
                HtmlAnchor a = (HtmlAnchor)e.Item.FindControl("anchorLink");
                int row = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetTopicQuestionAnswered", new SqlParameter[]
                 {
                    new SqlParameter("@topicId", Int32.Parse(DataBinder.Eval(e.Item.DataItem, "topicId").ToString())),
                 new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
                 }));



                if(Convert.ToInt16(DataBinder.Eval(e.Item.DataItem, "topicId")) == 1 && row == 0)
                {
                    IsCurrent = true;
                    div.Visible = true;
                    li.Attributes.Add("class", "active");
                    a.HRef = "assessments-pillar-quotes.aspx?pillerId=" + DataBinder.Eval(e.Item.DataItem, "topicId").ToString();
                }
                if(row < 9 && IsCurrent != true)
                {
                    IsCurrent = true;
                    div.Visible = true;
                    li.Attributes.Add("class", "active");
                    a.HRef = "assessments-pillar-quotes.aspx?pillerId=" + DataBinder.Eval(e.Item.DataItem, "topicId").ToString();
                }

                if(row==9)
                {
                   li.Attributes.Add("class", "selected");
                }
               
                
            }
        }
        void BindTopics()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSgaTopics");
            this.parentRepeater.DataSource = ds;
            this.parentRepeater.DataBind();
        }
    }
}