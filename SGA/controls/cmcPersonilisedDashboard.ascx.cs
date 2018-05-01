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

namespace SGA.controls
{
    public partial class cmcPersonilisedDashboard : System.Web.UI.UserControl
    {

        private int _showCompare;

        protected decimal topic1mark = 0m;

        protected decimal topic2mark = 0m;

        protected decimal topic3mark = 0m;

        protected decimal topic4mark = 0m;

        protected decimal topic5mark = 0m;

        protected decimal topic6mark = 0m;

        protected decimal topic7mark = 0m;

        protected decimal topic8mark = 0m;

        protected decimal medain1 = 0.0m;

        protected decimal medain2 = 0.0m;

        protected decimal medain3 = 0.0m;

        protected decimal medain4 = 0.0m;

        protected decimal medain5 = 0.0m;

        protected decimal medain6 = 0.0m;

        protected decimal medain7 = 0.0m;

        protected double medain8 = 0.0;

        protected decimal sectormedain1 = 0.0m;

        protected decimal sectormedain2 = 0.0m;

        protected decimal sectormedain3 = 0.0m;

        protected decimal sectormedain4 = 0.0m;

        protected decimal sectormedain5 = 0.0m;

        protected decimal sectormedain6 = 0.0m;

        protected decimal sectormedain7 = 0.0m;

        protected string topic1name = "";

        protected string topic2name = "";

        protected string topic3name = "";

        protected string topic4name = "";

        protected string topic5name = "";

        protected string topic6name = "";

        protected string topic7name = "";

        protected string topic8name = "";

        protected string median = "";

        public int testId
        {
            get
            {
                return (this.ViewState["testId"] == null) ? 0 : System.Convert.ToInt32(this.ViewState["testId"].ToString());
            }
            set
            {
                this.ViewState["testId"] = value;
            }
        }

        public int showCompare
        {
            get
            {
                return this._showCompare;
            }
            set
            {
                this._showCompare = value;
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                //tblCompare.Visible = (this.showCompare == 1);
                BindGraph();
                //Page.ClientScript.RegisterStartupScript(base.GetType(), "CallMyFunction", "drawChart()", true);
            }
        }

        private void BindGraph()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSgaGraph", new SqlParameter[]
            {
                new SqlParameter("@testId", this.testId)
            });
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                this.topic1mark = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["percentage"].ToString());
                                this.topic1name = ds.Tables[0].Rows[i]["topicname"].ToString().Replace("<br />", " ");
                                this.medain1 = GetAverageByTopic(1);
                                this.sectormedain1 = GetAverageBySector(1);
                                break;
                            case 1:
                                this.topic2mark = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["percentage"].ToString());
                                this.topic2name = ds.Tables[0].Rows[i]["topicname"].ToString().Replace("<br />", " ");
                                this.medain2 = GetAverageByTopic(2);
                                this.sectormedain2 = GetAverageBySector(2);
                                break;
                            case 2:
                                this.topic3mark = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["percentage"].ToString());
                                this.topic3name = ds.Tables[0].Rows[i]["topicname"].ToString().Replace("<br />", " ");
                                this.medain3 = GetAverageByTopic(3);
                                this.sectormedain3 = GetAverageBySector(3);
                                break;
                            case 3:
                                this.topic4mark = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["percentage"].ToString());
                                this.topic4name = ds.Tables[0].Rows[i]["topicname"].ToString().Replace("<br />", " ");
                                this.medain4 = GetAverageByTopic(4);
                                this.sectormedain4 = GetAverageBySector(4);
                                break;
                            case 4:
                                this.topic5mark = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["percentage"].ToString());
                                this.topic5name = ds.Tables[0].Rows[i]["topicname"].ToString().Replace("<br />", " ");
                                this.medain5 = GetAverageByTopic(5);
                                this.sectormedain5 = GetAverageBySector(5);
                                break;
                            case 5:
                                this.topic6mark = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["percentage"].ToString());
                                this.topic6name = ds.Tables[0].Rows[i]["topicname"].ToString().Replace("<br />", " ");
                                this.medain6 = GetAverageByTopic(6);
                                this.sectormedain6 = GetAverageBySector(6);
                                break;
                            case 6:
                                this.topic7mark = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["percentage"].ToString());
                                this.topic7name = ds.Tables[0].Rows[i]["topicname"].ToString().Replace("<br />", " ");
                                this.medain7 = GetAverageByTopic(7);
                                this.sectormedain7 = GetAverageBySector(7);
                                break;
                            case 7:
                                this.topic8mark = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["percentage"].ToString());
                                this.topic8name = ds.Tables[0].Rows[i]["topicname"].ToString().Replace("<br />", " ");
                                break;
                        }
                    }
                }
            }
        }
        
        public decimal GetAverageByTopic(int topicId)
        {
            decimal marks = 0.00m;
            DataSet dsMarks = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPercentageByTopics", new SqlParameter[]
               {
                    new SqlParameter("@topicId", topicId)
               });

            DataSet dtTestRole = SqlHelper.ExecuteDataset(CommandType.Text, "select testId from tblUserSgaTest where userId in (select id from tblUsers where jobRole = (select jobrole from tblusers where Id =" + SGACommon.LoginUserInfo.userId + "))");

            List<int> roleTest = new List<int>();
            List<Test> testList = new List<Test>();

            foreach (DataRow row in dtTestRole.Tables[0].Rows)
            {
                roleTest.Add(Convert.ToInt32(row["testId"]));
            }
            if (dsMarks != null)
            {
                if (dsMarks.Tables.Count > 0 && dsMarks.Tables[0].Rows.Count > 0)
                {
                    //Get TestIds by role/sector
                    //marks = System.Convert.ToDecimal(dsMarks.Tables[0].Rows[0]["marks"].ToString());

                    testList = (from DataRow dr in dsMarks.Tables[0].Rows
                                select new Test()
                                {
                                    TestId = Convert.ToInt32(dr["testid"]),
                                    Marks = System.Convert.ToDecimal(dr["marks"])
                                }).ToList();
                }
            }

            marks = ((from e in testList
                      where roleTest.Contains(e.TestId)
                      select e.Marks).Sum() / roleTest.Count);

            return marks;
        }

        public decimal GetAverageBySector(int topicId)
        {
            decimal marks = 0.00m;
            DataSet dsMarks = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPercentageByTopics", new SqlParameter[]
               {
                    new SqlParameter("@topicId", topicId)
               });

            DataSet dtTestSector = SqlHelper.ExecuteDataset(CommandType.Text, "select testId from tblUserSgaTest where userId in (select userId from UserInfo where sector = (select sector from UserInfo where userId =" + SGACommon.LoginUserInfo.userId + "))");

            List<int> roleTest = new List<int>();
            List<Test> testList = new List<Test>();

            foreach (DataRow row in dtTestSector.Tables[0].Rows)
            {
                roleTest.Add(Convert.ToInt32(row["testId"]));
            }
            if (dsMarks != null)
            {
                if (dsMarks.Tables.Count > 0 && dsMarks.Tables[0].Rows.Count > 0)
                {
                    //Get TestIds by role/sector
                    //marks = System.Convert.ToDecimal(dsMarks.Tables[0].Rows[0]["marks"].ToString());

                    testList = (from DataRow dr in dsMarks.Tables[0].Rows
                                select new Test()
                                {
                                    TestId = Convert.ToInt32(dr["testid"]),
                                    Marks = System.Convert.ToDecimal(dr["marks"])
                                }).ToList();
                }
            }

            marks = ((from e in testList
                      where roleTest.Contains(e.TestId)
                      select e.Marks).Sum() / roleTest.Count);

            return marks;
        }

        private static System.Collections.Generic.IEnumerable<double> ConvertToDecimals(DataTable dataTable)
        {
            return from row in dataTable.AsEnumerable()
                   select System.Convert.ToDouble(row["Marks"]);
        }


    }
}