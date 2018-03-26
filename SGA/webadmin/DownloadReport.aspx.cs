using AjaxControlToolkit;
using DataTier;
using SGA.App_Code;
using SGA.controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.webadmin
{
    public partial class DownloadReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.txtFrom.Attributes.Add("readonly", "readonly");
            this.txtTo.Attributes.Add("readonly", "readonly");
            if (!base.IsPostBack)
            {
                this.BindCompany();
            }
        }

        private void BindCompany()
        {
            this.ddlCompany.DataSource = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetCompany");
            this.ddlCompany.DataTextField = "company";
            this.ddlCompany.DataValueField = "company";
            this.ddlCompany.DataBind();
            SGACommon.InsertDefaultItem(this.ddlCompany, "Select company", "");
        }

        protected void btnExport_Click(object sender, System.EventArgs e)
        {
            this.lblError.Text = "";
            int status = 0;
            if (this.rdoAll.Checked)
            {
                status = 0;
            }
            else if (this.rdoCompleted.Checked)
            {
                status = 1;
            }
            else if (this.rdoUncomplete.Checked)
            {
                status = 2;
            }
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@firstname", this.txtFname.Value.Trim()),
				new SqlParameter("@lastname", this.txtLname.Value.Trim()),
				new SqlParameter("@company", this.ddlCompany.SelectedValue),
				new SqlParameter("@email", this.txtEmail.Value.Trim()),
				new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
				new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
				null,
				null,
				new SqlParameter("@status", status)
			};
            switch (System.Convert.ToInt32(this.ddlAssessmentType.SelectedValue))
            {
                case 1:
                    param[6] = new SqlParameter("@programType", "1");
                    param[7] = new SqlParameter("@SGAType", "CMC");
                    break;
                case 2:
                    param[6] = new SqlParameter("@programType", "1");
                    param[7] = new SqlParameter("@SGAType", "SSA");
                    break;
                case 3:
                    param[6] = new SqlParameter("@programType", "1");
                    param[7] = new SqlParameter("@SGAType", "BA");
                    break;
                case 4:
                    param[6] = new SqlParameter("@programType", "1");
                    param[7] = new SqlParameter("@SGAType", "NP");
                    break;
                case 5:
                    param[6] = new SqlParameter("@programType", "1");
                    param[7] = new SqlParameter("@SGAType", "MP");
                    break;
                case 6:
                    param[6] = new SqlParameter("@programType", "3");
                    param[7] = new SqlParameter("@SGAType", "CMCQuartile");
                    break;
                case 7:
                    param[6] = new SqlParameter("@programType", "1");
                    param[7] = new SqlParameter("@SGAType", "CMA");
                    break;
                case 8:
                    param[6] = new SqlParameter("@programType", "3");
                    param[7] = new SqlParameter("@SGAType", "BAQuartile");
                    break;
                case 9:
                    param[6] = new SqlParameter("@programType", "3");
                    param[7] = new SqlParameter("@SGAType", "SSAQuartile");
                    break;
                case 10:
                    param[6] = new SqlParameter("@programType", "3");
                    param[7] = new SqlParameter("@SGAType", "MPQuartile");
                    break;
                case 11:
                    param[6] = new SqlParameter("@programType", "3");
                    param[7] = new SqlParameter("@SGAType", "NPQuartile");
                    break;
                case 12:
                    param[6] = new SqlParameter("@programType", "3");
                    param[7] = new SqlParameter("@SGAType", "CMAQuartile");
                    break;
                case 13:
                    param[6] = new SqlParameter("@programType", "4");
                    param[7] = new SqlParameter("@SGAType", "CMKE");
                    break;
                case 14:
                    param[6] = new SqlParameter("@programType", "5");
                    param[7] = new SqlParameter("@SGAType", "CMSA");
                    break;
                default:
                    this.lblError.Text = "Select assessment type to download report";
                    break;
            }
            SqlHelper.ExecuteNonQuery(new SqlConnection(ConfigurationManager.ConnectionStrings["EmailConfigConn"].ToString()), "spInsertSearchPara", param);
            this.lblError.Text = "Your report download request will be proecssed within next 1 hour time.";
        }

        private void DownloadCMCQuartileResult(string strName1, string strName2, string strName3, string strFileName)
        {
            DataSet dsAll = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, strName1, new SqlParameter[]
			{
				new SqlParameter("@firstname", ""),
				new SqlParameter("@lastname", ""),
				new SqlParameter("@company", ""),
				new SqlParameter("@userIds", ""),
				new SqlParameter("@dateFrom", ""),
				new SqlParameter("@dateTo", "")
			});
            string strQuartile = "";
            System.Collections.ArrayList topicId = new System.Collections.ArrayList
			{
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			};
            DataTable dtUserInfo = new DataTable();
            DataTable dtQuestionReply = new DataTable();
            string[] selectedColumns = new string[]
			{
				"marks"
			};
            for (int i = 0; i <= 3; i++)
            {
                strQuartile += "<tr>";
                for (int j = 0; j < 30; j++)
                {
                    if (j == 1)
                    {
                        string str = "";
                        switch (i)
                        {
                            case 0:
                                str = "Average";
                                break;
                            case 1:
                                str = "Lower Quartile";
                                break;
                            case 2:
                                str = "Median";
                                break;
                            case 3:
                                str = "Upper Quartile";
                                break;
                        }
                        strQuartile = strQuartile + "<td>" + str + "</td>";
                    }
                    else
                    {
                        strQuartile += "<td >&nbsp;</td>";
                    }
                }
                dtUserInfo = dsAll.Tables[3];
                dtQuestionReply = dsAll.Tables[1];
                DataView dvData = new DataView(dtUserInfo);
                DataView dvData2 = new DataView(dtQuestionReply);
                foreach (int id in topicId)
                {
                    dvData2.RowFilter = "topicId = '" + id + "'";
                    System.Collections.IEnumerator enumerator2 = dvData2.GetEnumerator();
                    try
                    {
                        DataRowView drV1;
                        while (enumerator2.MoveNext())
                        {
                            drV1 = (DataRowView)enumerator2.Current;
                            EnumerableRowCollection<DataRow> result = from r in dvData.Table.AsEnumerable()
                                                                      where r.Field<Int32>("QuestionId") == System.Convert.ToInt32(drV1["QuestionId"])
                                                                      select r;
                            DataTable dtResult = result.CopyToDataTable<DataRow>();
                            DataTable dt = new DataView(dtResult).ToTable(false, selectedColumns);
                            System.Collections.Generic.IEnumerable<double> list = DownloadReport.ConvertToDecimals(dt);
                            double value = 0.0;
                            switch (i)
                            {
                                case 0:
                                    value = System.Math.Round(list.Average(), 2);
                                    break;
                                case 1:
                                    value = Quartiles.FirstQuartile(from m in list
                                                                    orderby m
                                                                    select m);
                                    break;
                                case 2:
                                    value = Quartiles.MiddleQuartile(from m in list
                                                                     orderby m
                                                                     select m);
                                    break;
                                case 3:
                                    value = Quartiles.ThirdQuartile(from m in list
                                                                    orderby m
                                                                    select m);
                                    break;
                            }
                            object obj = strQuartile;
                            strQuartile = string.Concat(new object[]
							{
								obj,
								"<td >",
								value,
								"</td>"
							});
                        }
                    }
                    finally
                    {
                        System.IDisposable disposable = enumerator2 as System.IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                    DataSet dsMarks = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, strName2, new SqlParameter[]
					{
						new SqlParameter("@topicId", id)
					});
                    if (dsMarks != null)
                    {
                        if (dsMarks.Tables.Count > 0 && dsMarks.Tables[0].Rows.Count > 0)
                        {
                            EnumerableRowCollection<DataRow> result = from r in dsMarks.Tables[0].AsEnumerable()
                                                                      select r;
                            DataTable dtResult = result.CopyToDataTable<DataRow>();
                            DataTable dt = new DataView(dtResult).ToTable(false, selectedColumns);
                            System.Collections.Generic.IEnumerable<double> list = DownloadReport.ConvertToDecimals(dt);
                            double value = 0.0;
                            switch (i)
                            {
                                case 0:
                                    value = System.Math.Round(list.Average(), 2);
                                    break;
                                case 1:
                                    value = Quartiles.FirstQuartile(from m in list
                                                                    orderby m
                                                                    select m);
                                    break;
                                case 2:
                                    value = Quartiles.MiddleQuartile(from m in list
                                                                     orderby m
                                                                     select m);
                                    break;
                                case 3:
                                    value = Quartiles.ThirdQuartile(from m in list
                                                                    orderby m
                                                                    select m);
                                    break;
                            }
                            object obj = strQuartile;
                            strQuartile = string.Concat(new object[]
							{
								obj,
								"<td >",
								value,
								"</td><td ></td>"
							});
                        }
                    }
                }
                strQuartile += "</tr>";
            }
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, strName3, new SqlParameter[]
			{
				new SqlParameter("@testIds", "")
			});
            string innerValue = "";
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        innerValue += ds.Tables[1].Rows[i]["Value"].ToString();
                    }
                }
            }
            this.downloadFile(innerValue.Replace("#", strQuartile), strFileName);
        }

        private void DownloadCMCResults()
        {
            try
            {
                string html = "";
                string innerValue = "";
                int status = 0;
                if (this.rdoAll.Checked)
                {
                    status = 0;
                }
                else if (this.rdoCompleted.Checked)
                {
                    status = 1;
                }
                else if (this.rdoUncomplete.Checked)
                {
                    status = 2;
                }
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSgaReportUsers", new SqlParameter[]
				{
					new SqlParameter("@firstname", this.txtFname.Value.Trim()),
					new SqlParameter("@lastname", this.txtLname.Value.Trim()),
					new SqlParameter("@company", this.ddlCompany.SelectedValue),
					new SqlParameter("@email", this.txtEmail.Value.Trim()),
					new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
					new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
					new SqlParameter("@status", status)
				});
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            html += ds.Tables[0].Rows[i]["innerValue"].ToString();
                        }
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            innerValue += ds.Tables[1].Rows[i]["Value"].ToString();
                        }
                    }
                }
                this.downloadFile(innerValue.Replace("#", html), "CMCAllResult");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private static System.Collections.Generic.IEnumerable<double> ConvertToDecimals(DataTable dataTable)
        {
            return from row in dataTable.AsEnumerable()
                   select System.Convert.ToDouble(row["marks"]);
        }

        private void DownloadSSAResults()
        {
            try
            {
                string html = "";
                string value = "";
                int status = 0;
                if (this.rdoAll.Checked)
                {
                    status = 0;
                }
                else if (this.rdoCompleted.Checked)
                {
                    status = 1;
                }
                else if (this.rdoUncomplete.Checked)
                {
                    status = 2;
                }
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSsaReportUsers", new SqlParameter[]
				{
					new SqlParameter("@firstname", this.txtFname.Value.Trim()),
					new SqlParameter("@lastname", this.txtLname.Value.Trim()),
					new SqlParameter("@company", this.ddlCompany.SelectedValue),
					new SqlParameter("@email", this.txtEmail.Value.Trim()),
					new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
					new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
					new SqlParameter("@status", status)
				});
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            html += ds.Tables[0].Rows[i]["innerValue"].ToString();
                        }
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            value += ds.Tables[1].Rows[i]["Value"].ToString();
                        }
                    }
                }
                this.downloadFile(value.Replace("#", html), "SSAAllResult");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void DownloadBAResults()
        {
            try
            {
                string html = "";
                string value = "";
                int status = 0;
                if (this.rdoAll.Checked)
                {
                    status = 0;
                }
                else if (this.rdoCompleted.Checked)
                {
                    status = 1;
                }
                else if (this.rdoUncomplete.Checked)
                {
                    status = 2;
                }
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetBaReportUsers", new SqlParameter[]
				{
					new SqlParameter("@firstname", this.txtFname.Value.Trim()),
					new SqlParameter("@lastname", this.txtLname.Value.Trim()),
					new SqlParameter("@company", this.ddlCompany.SelectedValue),
					new SqlParameter("@email", this.txtEmail.Value.Trim()),
					new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
					new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
					new SqlParameter("@status", status)
				});
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            html += ds.Tables[0].Rows[i]["innerValue"].ToString();
                        }
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            value += ds.Tables[1].Rows[i]["Value"].ToString();
                        }
                    }
                }
                this.downloadFile(value.Replace("#", html), "BAAllResult");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void DownloadMPResults()
        {
            try
            {
                string html = "";
                string value = "";
                int status = 0;
                if (this.rdoAll.Checked)
                {
                    status = 0;
                }
                else if (this.rdoCompleted.Checked)
                {
                    status = 1;
                }
                else if (this.rdoUncomplete.Checked)
                {
                    status = 2;
                }
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetMPReportUsers", new SqlParameter[]
				{
					new SqlParameter("@firstname", this.txtFname.Value.Trim()),
					new SqlParameter("@lastname", this.txtLname.Value.Trim()),
					new SqlParameter("@company", this.ddlCompany.SelectedValue),
					new SqlParameter("@email", this.txtEmail.Value.Trim()),
					new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
					new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
					new SqlParameter("@status", status)
				});
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            html += ds.Tables[0].Rows[i]["innerValue"].ToString();
                        }
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            value += ds.Tables[1].Rows[i]["Value"].ToString();
                        }
                    }
                }
                this.downloadFile(value.Replace("#", html), "MPAllResult");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void DownloadNPResults()
        {
            try
            {
                string html = "";
                string value = "";
                int status = 0;
                if (this.rdoAll.Checked)
                {
                    status = 0;
                }
                else if (this.rdoCompleted.Checked)
                {
                    status = 1;
                }
                else if (this.rdoUncomplete.Checked)
                {
                    status = 2;
                }
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetNpReportUsers", new SqlParameter[]
				{
					new SqlParameter("@firstname", this.txtFname.Value.Trim()),
					new SqlParameter("@lastname", this.txtLname.Value.Trim()),
					new SqlParameter("@company", this.ddlCompany.SelectedValue),
					new SqlParameter("@email", this.txtEmail.Value.Trim()),
					new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
					new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
					new SqlParameter("@status", status)
				});
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            html += ds.Tables[0].Rows[i]["innerValue"].ToString();
                        }
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            value += ds.Tables[1].Rows[i]["Value"].ToString();
                        }
                    }
                }
                this.downloadFile(value.Replace("#", html), "NPAllResult");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void DownloadCMAResults()
        {
            try
            {
                string html = "";
                string value = "";
                int status = 0;
                if (this.rdoAll.Checked)
                {
                    status = 0;
                }
                else if (this.rdoCompleted.Checked)
                {
                    status = 1;
                }
                else if (this.rdoUncomplete.Checked)
                {
                    status = 2;
                }
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetCMAReportUsers", new SqlParameter[]
				{
					new SqlParameter("@firstname", this.txtFname.Value.Trim()),
					new SqlParameter("@lastname", this.txtLname.Value.Trim()),
					new SqlParameter("@company", this.ddlCompany.SelectedValue),
					new SqlParameter("@email", this.txtEmail.Value.Trim()),
					new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
					new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
					new SqlParameter("@status", status)
				});
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            html += ds.Tables[0].Rows[i]["innerValue"].ToString();
                        }
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            value += ds.Tables[1].Rows[i]["Value"].ToString();
                        }
                    }
                }
                this.downloadFile(value.Replace("#", html), "CMAAllResult");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void downloadFile(string html, string name)
        {
            TableRow tRow = new TableRow();
            tRow.CssClass = "tableRow";
            this.excel.Rows.Add(tRow);
            TableCell tCell = new TableCell();
            tCell.Text = html;
            tCell.CssClass = "tableCell";
            tRow.Cells.Add(tCell);
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment;filename=" + name + ".xls");
            base.Response.Charset = "";
            base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            base.Response.ContentType = "application/vnd.xls";
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    this.excel.RenderControl(htw);
                    base.Response.Write(sw.ToString());
                    base.Response.End();
                }
            }
        }
    }
}