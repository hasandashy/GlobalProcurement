using CookComputing.XmlRpc;
using DataTier;
using InfusionSoftDotNet;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.tna
{

    public partial class procurement_benchmark_assessment_test : System.Web.UI.Page
    {
        public string pillarId;
        public int testId
        {
            get
            {
                return Convert.ToInt32(this.ViewState["testId"].ToString());
            }
            set
            {
                this.ViewState["testId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spInitalizeSgaTest", new SqlParameter[]
                {
                    new SqlParameter("@userId", SGACommon.LoginUserInfo.userId),
                    new SqlParameter("@testDate", System.DateTime.UtcNow.ToString()),
                    new SqlParameter("@startDate", System.DateTime.UtcNow.ToString()),
                    new SqlParameter("@endDate", System.DateTime.UtcNow.ToString()),
                    new SqlParameter("@sessionId", this.Session.SessionID)

                });
                this.testId = System.Convert.ToInt32(ds.Tables[0].Rows[0]["testId"].ToString());

            }

            pillarId = Request.QueryString["pillerId"];
            if (pillarId != null)
            {
                this.BindTopicsQuestions(Convert.ToInt32(pillarId));
            }

        }

        private void BindTopicsQuestions(int topicId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSgaQuestions", new SqlParameter[]
            {
                new SqlParameter("@topicId", topicId)
            });
            this.parentRepeater.DataSource = ds;
            this.parentRepeater.DataBind();
            //this.hdCount.Value = this.parentRepeater.Items.Count.ToString();

            string pillarName = SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spPillarThoughtsMaster", new SqlParameter[]
               {
                    new SqlParameter("@action", "getPillarNameById"),
                new SqlParameter("@pillarId", pillarId)}).ToString();
            pillarNameSpan.InnerText = pillarName.Replace("<span>", "").Replace("</span>", "");
        }

        protected DataSet GetData(int qid)
        {
            return SqlHelper.ExecuteDataset(CommandType.Text, "select * from tblSgaOptions where questionId=" + qid + " ");
        }

        [WebMethod]
        public static string GetSelectedOption(int questionId, int testId)
        {
            string strQuery = string.Concat(new object[]
              {
                    "SELECT isNull(optionId,'') from  tblSgaOptions where optionId = (select optionId from tblSgaQuestionReply where testId=",
                   testId ,
                    " and questionId=",
                    questionId,
                    ")"
              });
            object strOption = SqlHelper.ExecuteScalar(CommandType.Text, strQuery);
            return strOption != null ? strOption.ToString() : "";
        }

        protected void parentRepeater_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem || e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                int CurrentPage = ((DataPager1.StartRowIndex) / DataPager1.MaximumRows) + 1;
                Label lblNumber = (Label)e.Item.FindControl("lblNumber");
                pgLbl.InnerText = "Question " + CurrentPage + " of " + (DataPager1.TotalRowCount == 0 ? 9 : DataPager1.TotalRowCount);
                if (lblNumber != null)
                {
                    if (CurrentPage <= 9)
                    {
                        lblNumber.Text = "0" + CurrentPage;
                    }
                    else
                    {
                        lblNumber.Text = CurrentPage.ToString();
                    }
                }

                int questionId = System.Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "questionid"));
                //HtmlGenericControl rdb = e.Item.FindControl("start") as HtmlGenericControl;

                //object strOption = SqlHelper.ExecuteScalar(CommandType.Text, strQuery);
                //if (strOption != null)
                //{
                //    HtmlGenericControl li = (HtmlGenericControl)e.Item.FindControl(strOption.ToString());
                //    if (li != null)
                //    {
                //        li.ID = "selected";
                //        li.Attributes.Add("class", "itemselected");
                //    }
                //}
            }
        }

        protected void parentRepeater_PagePropertiesChanged(object sender, EventArgs e)
        {
            parentRepeater.DataBind();
        }

        protected void pager(object sender, DataPagerCommandEventArgs e)
        {
            e.NewMaximumRows = e.Item.Pager.MaximumRows;

            switch (e.CommandName)
            {
                case "Previous":
                    if (e.Item.Pager.StartRowIndex > 0)
                        e.NewStartRowIndex = e.Item.Pager.StartRowIndex - 1;
                    break;

                case "Next":
                    e.NewStartRowIndex = e.Item.Pager.StartRowIndex + 1;
                    break;
            }
        }

        [WebMethod]
        public static void SaveData(int questionId, int optionId, int testId)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@questionId", questionId);
            param[1] = new SqlParameter("@OptionId", optionId);
            param[2] = new SqlParameter("@testId", testId);
            param[3] = new SqlParameter("@endDate", System.DateTime.UtcNow.ToString());
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spUpdateOptions", param);
        }

        [WebMethod]
        public static void CompleteAssessment(int testId)
        {
            string[] strField = new string[]
                      {
                            "Id"
                      };
            XmlRpcStruct[] resultFound = isdnAPI.findByEmail(SGACommon.LoginUserInfo.name, strField);
            int userId;
            XmlRpcStruct Contact = new XmlRpcStruct();
            if (resultFound.Length > 0)
            {
                userId = System.Convert.ToInt32(resultFound[0]["Id"].ToString());
                isdnAPI.addToGroup(userId, 4229);
                isdnAPI.dsUpdate("Contact", userId, Contact);
            }
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spRestrictTest", new SqlParameter[]
            {
                new SqlParameter("@flag", "0"),
                new SqlParameter("@testId", testId),
                new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
            });
        }

    }
}