﻿using DataTier;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
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
    public partial class ctrlCMCPdf : System.Web.UI.UserControl
    {
        private const int LeftAlign = 0;

        private const int CenterAlign = 1;

        private const int RightAlign = 2;

        private Document doc;

        private string imagepath;

        private Font arial24Bold = FontFactory.GetFont("Arial", 24f, 1, new BaseColor(0, 0, 0));

        private Font arial2 = FontFactory.GetFont("Arial", 24f, new BaseColor(234, 66, 31));

        private Font arial3 = FontFactory.GetFont("Arial", 14f, new BaseColor(0, 0, 0));

        private BaseColor hcolor = new BaseColor(234, 66, 31);

        private BaseColor bcolor = new BaseColor(0, 0, 0);

        private BaseColor wcolor = new BaseColor(255, 255, 255);

        private BaseColor tablebackcolor = new BaseColor(241, 238, 233);

        private BaseColor tableborcolor = new BaseColor(241, 238, 233);

        private BaseColor tablelitebackcolor = new BaseColor(221, 218, 213);

        private BaseColor tableliteborcolor = new BaseColor(255, 255, 255);

        private int _testId;

        private int _userId;

        public int testId
        {
            get
            {
                return this._testId;
            }
            set
            {
                this._testId = value;
            }
        }

        public int userId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.imagepath = base.Server.MapPath("~/pdfBgImages/");
                string pdfPath = "~/pdfReports/";
                string newFile = base.Server.MapPath(string.Concat(new object[]
				{
					pdfPath,
					SGACommon.GetName(this.userId),
					"_",
					this.testId,
					"_cmctest.pdf"
				}));
                DataSet dsPages = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManageCMCText", new SqlParameter[]
				{
					new SqlParameter("@flag", 2)
				});
                SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@userId", SqlDbType.Int)
				};
                param[0].Value = this.userId;
                DataSet dsProfile = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetProfileDetails", param);
                System.DateTime dtEnd = System.Convert.ToDateTime(SqlHelper.ExecuteScalar(CommandType.Text, "select endTime from tbluserSgaTest where testId=" + this.testId));
                param = new SqlParameter[2];
                param[0] = new SqlParameter("@userId", SqlDbType.Int);
                param[0].Value = this.userId;
                param[1] = new SqlParameter("@testId", SqlDbType.Int);
                param[1].Value = this.testId;
                DataSet dsPercentage = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetTestTimePercentage", param);
                this.doc = new Document(PageSize.A4, 55f, 55f, 55f, 0f);
                DataSet dsJob = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManageJobRoleSuggestion", new SqlParameter[]
                {
                    new SqlParameter("@id", System.Convert.ToInt32(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["jobRole"].ToString()))),
                    new SqlParameter("@jobSuggestion", ""),
                    new SqlParameter("@flag", "4")
                });
                iTextSharp.text.Image imgBG = iTextSharp.text.Image.GetInstance(this.imagepath + "/img3_footer.jpg");
                imgBG.ScaleToFit(this.doc.PageSize.Width, this.doc.PageSize.Height);
                imgBG.Alignment = 8;
                imgBG.SetAbsolutePosition(1f, 3f);
                PdfWriter writer = PdfWriter.GetInstance(this.doc, new System.IO.FileStream(newFile, System.IO.FileMode.Create));
                HTMLWorker hw = new HTMLWorker(this.doc);
                try
                {
                    this.doc.Open();
                    this.doc.SetMargins(0f, 0f, 0f, 0f);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(this.imagepath + "/CMC_ProcurementKnowledgeEvaluation.png");
                    img.ScaleToFit(this.doc.PageSize.Width, this.doc.PageSize.Height);
                    img.Alignment = 8;
                    this.doc.NewPage();
                    this.doc.Add(img);

                    PdfContentByte cb = writer.DirectContent;
                    BaseFont f_cn = BaseFont.CreateFont("Helvetica", "Cp1252", false);
                    cb.BeginText();
                    cb.SetFontAndSize(f_cn, 12f);
                    cb.SetTextMatrix(80f, 380f);
                    cb.SetRGBColorFill(0, 0, 0);
                    cb.ShowText("Prepared for:");
                    cb.EndText();
                    if (dsProfile != null)
                    {
                        if (dsProfile.Tables.Count > 0 && dsProfile.Tables[0].Rows.Count > 0)
                        {
                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 24f);
                            cb.SetTextMatrix(80f, 340f);
                            cb.SetRGBColorFill(234, 66, 31);
                            cb.ShowText(SGACommon.UppercaseFirst(dsProfile.Tables[0].Rows[0]["firstname"].ToString()) + " " + SGACommon.UppercaseFirst(dsProfile.Tables[0].Rows[0]["lastname"].ToString()));
                            cb.EndText();
                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 12f);
                            cb.SetTextMatrix(80f, 310f);
                            cb.SetRGBColorFill(0, 0, 0);
                            cb.ShowText(dsProfile.Tables[0].Rows[0]["jobtitle"].ToString());
                            cb.EndText();
                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 12f);
                            cb.SetTextMatrix(80f, 290f);
                            cb.SetRGBColorFill(0, 0, 0);
                            cb.ShowText("Procurement Benchmark Assessment");
                            cb.EndText();
                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 12f);
                            cb.SetTextMatrix(80f, 200f);
                            cb.SetRGBColorFill(0, 0, 0);
                            cb.ShowText("Date completed: ");
                            cb.EndText();
                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 12f);
                            cb.SetTextMatrix(80f, 180f);
                            cb.SetRGBColorFill(0, 0, 0);
                            cb.ShowText(SGACommon.ToAusTimeZone(dtEnd).ToString("dddd, dd MMMM yyyy"));
                            cb.EndText();
                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 12f);
                            cb.SetTextMatrix(80f, 160f);
                            cb.SetRGBColorFill(0, 0, 0);
                            cb.ShowText("Email : info@comprara.com.au");
                            cb.EndText();
                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 16f);
                            cb.SetTextMatrix(80f, 130f);
                            cb.SetRGBColorFill(234, 66, 31);
                            cb.ShowText("www.comprara.com.au");
                            cb.EndText();
                        }
                    }

                    /*
                    this.AddBlankParagraph(8);
                    this.AddParagraph("Category Management Challenge", 0, this.arial24Bold);
                    this.AddBlankParagraphLowHeight(2);
                    this.AddParagraph("Report", 0, this.arial24Bold);
                    if (dsProfile != null)
                    {
                        if (dsProfile.Tables.Count > 0 && dsProfile.Tables[0].Rows.Count > 0)
                        {
                            this.AddBlankParagraph(2);
                            this.AddParagraph("Prepared for", 0, FontFactory.GetFont("Arial", 10f, new BaseColor(0, 0, 0)));
                            this.AddBlankParagraphLowHeight(2);
                            this.AddParagraph(dsProfile.Tables[0].Rows[0]["firstname"].ToString() + " " + dsProfile.Tables[0].Rows[0]["lastname"].ToString(), 0, FontFactory.GetFont("Arial", 24f, 1, new BaseColor(234, 66, 31)));
                            this.AddBlankParagraphLowHeight(2);
                            this.AddParagraph(dsProfile.Tables[0].Rows[0]["jobtitle"].ToString(), 0, FontFactory.GetFont("Arial", 14f, 1, new BaseColor(0, 0, 0)));
                            this.AddBlankParagraphLowHeight(1);
                            this.AddParagraph(dsProfile.Tables[0].Rows[0]["company"].ToString(), 0, FontFactory.GetFont("Arial", 14f, 1, new BaseColor(0, 0, 0)));
                            this.AddBlankParagraph(1);
                        }
                    }
                    this.AddParagraph("Date completed", 0, FontFactory.GetFont("Arial", 10f, 1, new BaseColor(0, 0, 0)));
                    this.AddParagraph(SGACommon.ToAusTimeZone(dtEnd).ToString("dddd, dd MMMM yyyy"), 0, FontFactory.GetFont("Arial", 10f, 1, new BaseColor(0, 0, 0)));
                    img = iTextSharp.text.Image.GetInstance(this.imagepath + "/page1img.jpg");
                    img.SetAbsolutePosition(0f, 0f);
                    img.ScaleToFit(600f, 600f);
                    img.Alignment = 4;
                    img.SetAbsolutePosition(0f, 25f);
                    this.doc.Add(img);
                    this.AddBlankParagraph(41);
                    this.AddParagraph("Powered by Comprara", 2, FontFactory.GetFont("Arial", 10f, new BaseColor(0, 0, 0)));
                    */
                    this.doc.SetMargins(0f, 0f, 0f, 0f);
                    this.doc.NewPage();
                    this.AddBlankParagraph(2);
                    PdfPTable table = this.GetTable(1, 560f);
                    this.Addrow(ref table, "", " ", "", "", "");
                    this.Addrow(ref table, "", " ", "", "", "");
                    this.Addrow(ref table, "", " ", "", "", "");
                    Chunk tc = new Chunk("  Table of contents", FontFactory.GetFont("Arial", 24f, 1, this.hcolor));
                    PdfPCell cell = new PdfPCell(new Phrase
					{
						tc
					});
                    cell.BackgroundColor = this.tablebackcolor;
                    cell.BorderColor = this.tableborcolor;
                    cell.PaddingBottom = 10f;
                    cell.PaddingLeft = 0f;
                    cell.PaddingTop = 4f;
                    table.AddCell(cell);
                    this.doc.Add(table);
                    table = this.GetTable(3, 560f);
                    float[] colwidth = new float[]
					{
						50f,
						45f,
						5f
					};
                    table.SetWidths(colwidth);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   Introduction", ".........................................................", "3", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "  Your organisation and you", ".........................................................", "4", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   Your assessment summary", ".........................................................", "5", true, true, false);
                    this.Addrow(ref table, "  1. Opportunity Analysis", ".........................................................", "6", false, true, false);
                    this.Addrow(ref table, "  2. Market Analysis", ".........................................................", "7", false, true, false);
                    this.Addrow(ref table, "  3. Strategy Development", ".........................................................", "8", false, true, false);
                    this.Addrow(ref table, "  4. Market Engagement", ".........................................................", "9", false, true, false);
                    this.Addrow(ref table, "  5. Negotiation", ".........................................................", "10", false, true, false);
                    this.Addrow(ref table, "  6. Contract Implementation", ".........................................................", "11", false, true, false);
                    this.Addrow(ref table, "  7. Supplier Relationship Management", ".........................................................", "12", false, true, false);
                    this.Addrow(ref table, "  8. Strategy Refresh", ".........................................................", "13", false, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "  E-Learning", ".........................................................", "14", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    //this.Addrow(ref table, "  The Behavioural Self-Assessment", ".........................................................", "15", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "   Report contributors", ".........................................................", "16", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "    ", "", "", true, true, false);
                    this.Addrow(ref table, "   Disclaimer", ".........................................................", "17", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.Addrow(ref table, "   ", "", "", true, true, false);
                    this.doc.Add(table);
                    this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    this.doc.Add(imgBG);
                    this.AddBlankParagraph(1);
                    if (dsPages != null)
                    {
                        if (dsPages.Tables.Count > 0 && dsPages.Tables[0].Rows.Count > 0)
                        {
                            this.AddParagraph(dsPages.Tables[0].Rows[0]["page1Heading"].ToString(), 0, FontFactory.GetFont("Arial", 24f, 1, this.hcolor));
                            this.AddBlankParagraph(1);
                            hw.Parse(new System.IO.StringReader(dsPages.Tables[0].Rows[0]["page1Text"].ToString()));
                        }
                    }
                    this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    this.doc.Add(imgBG);
                    string str = "Your organisation and you";
                    this.AddParagraph(str, 0, FontFactory.GetFont("Arial", 24f, 1, this.hcolor));
                    this.AddBlankParagraph(6);
                    this.AddBoldParagraph("ABOUT YOUR ORGANISATION");
                    this.AddBlankParagraph(1);
                    table = this.GetTable(2);
                    if (dsProfile != null)
                    {
                        if (dsProfile.Tables.Count > 0 && dsProfile.Tables[0].Rows.Count > 0)
                        {
                            this.Addrow(ref table, "Your industry", Profile.GetIndustry(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["industry"].ToString())));
                            this.Addrow(ref table, "Your organization's annualized revenues:", Profile.GetAnnualRevenue(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["arevenue"].ToString())));
                            this.doc.Add(table);
                            this.AddBlankParagraph(1);
                            this.AddBlankParagraph(1);
                            this.AddBoldParagraph("ABOUT YOUR PROCUREMENT FUNCTION");
                            this.AddBlankParagraph(1);
                            table = this.GetTable(2);
                            this.Addrow(ref table, "Procurement model:", Profile.GetProcurementModel(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["pmodel"].ToString())));
                            this.Addrow(ref table, "Reporting line:", Profile.GetReportLineTo(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["reportline"].ToString())));
                            this.Addrow(ref table, "Number of employees:", Profile.GetNoOfEmployee(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["noemployee"].ToString())));
                            this.Addrow(ref table, "Geographical influence:", Profile.GetGeoInfluence(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["geoInfluence"].ToString())));
                            this.doc.Add(table);
                            this.AddBlankParagraph(1);
                            this.AddBlankParagraph(1);
                            this.AddBoldParagraph("ABOUT YOU");
                            this.AddBlankParagraph(1);
                            table = this.GetTable(2);
                            this.Addrow(ref table, "Your role is best described as:", Profile.GetJobRole(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["jobRole"].ToString())));
                            this.Addrow(ref table, "The category you currently manage:", Profile.GetCategory(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["categoryId"].ToString())));
                            this.Addrow(ref table, "The spend under your influence:", Profile.GetAnnualRevenue(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["spendunder"].ToString())));
                            this.Addrow(ref table, "Geographical influence:", Profile.GetGeoInfluence(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["geoInfluence"].ToString())));
                            this.Addrow(ref table, "Your previous specialist category knowledge:", "Indirects Generalist");
                            this.Addrow(ref table, "Your procurement qualifications:", Profile.GetProcurementLevel(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["proLevel"].ToString())));
                            this.Addrow(ref table, "Your level of education:", Profile.GetEducation(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["education"].ToString())));
                            this.doc.Add(table);
                        }
                    }
                    this.AddBlankParagraph(1);
                    this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    this.doc.Add(imgBG);
                    str = "Your assessment summary";
                    this.AddParagraph(str, 0, FontFactory.GetFont("Arial", 24f, 1, this.hcolor));
                    this.AddBlankParagraph(3);
                    hw.Parse(new System.IO.StringReader(dsPages.Tables[0].Rows[0]["page5Text"].ToString().Replace("@v1", System.Convert.ToDecimal(dsPercentage.Tables[0].Rows[0]["percentage"].ToString()).ToString("#.##")).Replace("@v0", dsPercentage.Tables[0].Rows[0]["diff"].ToString().Split(new char[]
					{
						':'
					})[1].ToString() + " minutes")));
                    this.AddBlankParagraph(3);
                    table = this.GetTable(3);
                    colwidth = new float[]
					{
						25f,
						20f,
						55f
					};
                    table.SetWidths(colwidth);
                    this.AddrowHeader(ref table, "Category Phase", "Your Score", "Rating Scale");
                    DataSet dsSummary = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSgaGraph", new SqlParameter[]
					{
						new SqlParameter("@testId", this.testId)
					});
                    if (dsSummary != null)
                    {
                        if (dsSummary.Tables.Count > 0 && dsSummary.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsSummary.Tables[0].Rows.Count; i++)
                            {
                                this.Addrow(ref table, " " + dsSummary.Tables[0].Rows[i]["TopicName"].ToString().Replace("<br />", " "), dsSummary.Tables[0].Rows[i]["percentage"].ToString() + " %", "  " + dsSummary.Tables[0].Rows[i]["level"].ToString(), false, false, true);
                            }
                        }
                    }
                    this.doc.Add(table);
                    this.AddBlankParagraph(1);
                    DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetSuggestions", new SqlParameter[]
					{
						new SqlParameter("@flag", "1")
					});
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                this.doc.SetMargins(55f, 55f, 55f, 55f);
                                this.doc.NewPage();
                                this.doc.Add(imgBG);
                                this.AddParagraph(j + 1 + ". " + ds.Tables[0].Rows[j]["topicName"].ToString().Replace("<br />", " "), 0, FontFactory.GetFont("Arial", 24f, 1, new BaseColor(0, 0, 0)));
                                this.AddBlankParagraph(1);
                                hw.Parse(new System.IO.StringReader(ds.Tables[0].Rows[j]["SuggestionText"].ToString().Replace("@level", dsSummary.Tables[0].Rows[j]["level"].ToString()).Replace("@score", dsSummary.Tables[0].Rows[j]["percentage"].ToString())));
                                this.AddBlankParagraphLowHeight(1);
                                this.AddParagraph("FEEDBACK", 0, FontFactory.GetFont("Arial", 12f, 1, new BaseColor(234, 66, 31)));
                                this.AddBlankParagraphLowHeight(1);
                                hw.Parse(new System.IO.StringReader(dsSummary.Tables[0].Rows[j]["recommendation"].ToString().Replace("@level", dsSummary.Tables[0].Rows[j]["level"].ToString()).Replace("@v0", dsSummary.Tables[0].Rows[j]["training"].ToString())));
                            }
                        }
                    }

                    if (dsPages != null)
                    {
                        if (dsPages.Tables.Count > 0 && dsPages.Tables[0].Rows.Count > 0)
                        {
                            this.doc.SetMargins(55f, 55f, 55f, 55f);
                            this.doc.NewPage();
                            this.doc.Add(imgBG);
                            this.AddParagraph(dsPages.Tables[0].Rows[0]["page17Heading"].ToString(), 0, FontFactory.GetFont("Arial", 24f, 1, new BaseColor(0, 0, 0)));
                            this.AddBlankParagraph(1);
                            hw.Parse(new System.IO.StringReader(dsPages.Tables[0].Rows[0]["page17Text"].ToString().Replace("@v0", Profile.GetJobRole(System.Convert.ToInt32(dsProfile.Tables[0].Rows[0]["jobRole"].ToString()))).Replace("@v1", dsJob.Tables[0].Rows[0]["page14Para1"].ToString()).Replace("@v2", dsJob.Tables[0].Rows[0]["page14Para2"].ToString())));
                        }
                    }

                    DataSet dsPlans = DataTier.SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPlansByPercentageForCMC", new SqlParameter[] {
                        new SqlParameter("@tableType","3"),
                        new SqlParameter("@testId",testId),
                    });

                    if (dsPlans != null)
                    {
                        if (dsPlans.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            string strPageCode = dsPlans.Tables[0].Rows[0]["planDetails"].ToString();
                            this.doc.SetMargins(30f, 30f, 30f, 10f);
                            this.doc.NewPage();
                            this.doc.Add(imgBG);
                            string[] strArr = dsPlans.Tables[0].Rows[0]["timeweek"].ToString().Split(':');
                            DateTime dt = Convert.ToDateTime(dsPlans.Tables[0].Rows[0]["testDate"].ToString());
                            if (strArr.Length > 0)
                            {
                                for (int i = 0; i < strArr.Length; i++)
                                {
                                    int hours = Convert.ToInt32(strArr[i].ToString());
                                    double months = (((1.0 / 30.0) * (hours * 60.0)) / 4.0 + 1);
                                    dt = dt.AddMonths(Convert.ToInt32(months));
                                    strPageCode = strPageCode.Replace("@v" + i.ToString(), dt.ToString("dd MMM yyyy")).Replace("@per", Convert.ToDecimal(dsPlans.Tables[0].Rows[0]["percentage"].ToString()).ToString("#.##") + "%");
                                    //strPageCode = strPageCode.Replace("@v" + i.ToString(), Convert.ToDateTime(dsPlans.Tables[0].Rows[0]["testDate"].ToString()).AddMonths(months).ToString("dd/MM/yyyy"));

                                }
                            }
                            hw.Parse(new System.IO.StringReader(strPageCode.ToString()));
                        }
                    }

                    /*this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    this.doc.Add(imgBG);
                    if (dsPages != null)
                    {
                        if (dsPages.Tables.Count > 0 && dsPages.Tables[0].Rows.Count > 0)
                        {
                            this.AddParagraph(dsPages.Tables[0].Rows[0]["page14Heading"].ToString(), 0, FontFactory.GetFont("Arial", 24f, 1, this.hcolor));
                            this.AddBlankParagraph(1);
                            hw.Parse(new System.IO.StringReader(dsPages.Tables[0].Rows[0]["page14Text"].ToString()));
                        }
                    }
                    this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    this.doc.Add(imgBG);
                    if (dsPages != null)
                    {
                        if (dsPages.Tables.Count > 0 && dsPages.Tables[0].Rows.Count > 0)
                        {
                            this.AddParagraph(dsPages.Tables[0].Rows[0]["page14HeadingBA"].ToString(), 0, FontFactory.GetFont("Arial", 24f, 1, this.hcolor));
                            this.AddBlankParagraph(1);
                            hw.Parse(new System.IO.StringReader(dsPages.Tables[0].Rows[0]["page14TextBA"].ToString()));
                        }
                    }*/

                    this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    img = iTextSharp.text.Image.GetInstance(this.imagepath + "/NegotiationAd1.jpeg");
                    img.ScaleToFit(this.doc.PageSize.Width, this.doc.PageSize.Height);
                    img.Alignment = 8;
                    img.SetAbsolutePosition(1f, 3f);
                    this.doc.Add(img);

                    this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    img = iTextSharp.text.Image.GetInstance(this.imagepath + "/NegotiationAd2.jpeg");
                    img.ScaleToFit(this.doc.PageSize.Width, this.doc.PageSize.Height);
                    img.Alignment = 8;
                    img.SetAbsolutePosition(1f, 3f);
                    this.doc.Add(img);

                    /*this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    this.doc.Add(imgBG);
                    if (dsPages != null)
                    {
                        if (dsPages.Tables.Count > 0 && dsPages.Tables[0].Rows.Count > 0)
                        {
                            this.AddParagraph(dsPages.Tables[0].Rows[0]["page15Heading"].ToString(), 0, FontFactory.GetFont("Arial", 24f, 1, this.hcolor));
                            this.AddBlankParagraph(1);
                            img = iTextSharp.text.Image.GetInstance(this.imagepath + "/compraralogo.png");
                            img.ScaleToFit(200f, 130f);
                            img.Alignment = 4;
                            this.doc.Add(img);
                            this.AddBlankParagraph(9);
                            hw.Parse(new System.IO.StringReader(dsPages.Tables[0].Rows[0]["page15SubPara1"].ToString()));
                            this.AddBlankParagraph(1);
                        }
                    }
                    this.doc.SetMargins(55f, 55f, 55f, 55f);
                    this.doc.NewPage();
                    if (dsPages != null)
                    {
                        if (dsPages.Tables.Count > 0 && dsPages.Tables[0].Rows.Count > 0)
                        {
                            img = iTextSharp.text.Image.GetInstance(this.imagepath + "/img3_grey_bg.jpg");
                            img.ScaleToFit(this.doc.PageSize.Width, this.doc.PageSize.Height);
                            img.Alignment = 8;
                            img.SetAbsolutePosition(1f, 3f);
                            this.doc.Add(img);
                            img = iTextSharp.text.Image.GetInstance(this.imagepath + "/logo.png");
                            img.SetAbsolutePosition(170f, 610f);
                            img.ScaleToFit(222f, 108f);
                            img.Alignment = 5;
                            this.doc.Add(img);
                            this.AddBlankParagraph(15);
                            hw.Parse(new System.IO.StringReader(dsPages.Tables[0].Rows[0]["page16Address"].ToString()));
                            this.AddBlankParagraph(12);
                            hw.Parse(new System.IO.StringReader(dsPages.Tables[0].Rows[0]["Disclaimer"].ToString()));
                        }
                    }*/
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (this.doc != null)
                    {
                        this.doc.Close();
                    }
                }
                this.ShowPdf(newFile);
            }
        }

        protected PdfPTable GetTable(int columns)
        {
            return new PdfPTable(columns)
            {
                TotalWidth = 500f,
                LockedWidth = true,
                HorizontalAlignment = 0
            };
        }

        protected void AddBoldParagraph(string text)
        {
            Chunk c = new Chunk(text, FontFactory.GetFont("Arial", 10f, 1, this.bcolor));
            Phrase ph = new Phrase();
            ph.Add(c);
            Paragraph p = new Paragraph();
            p.Add(ph);
            p.Alignment = 0;
            p.SetLeading(0f, 1f);
            this.doc.Add(p);
        }

        protected PdfPTable GetTable(int columns, float width)
        {
            return new PdfPTable(columns)
            {
                TotalWidth = width,
                LockedWidth = true,
                HorizontalAlignment = 1
            };
        }

        protected void Addrow(ref PdfPTable tab, string lefttext, string righttext)
        {
            Chunk tc = new Chunk(lefttext, FontFactory.GetFont("Arial", 11f, 0, this.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingLeft = 5f;
            cell.PaddingTop = 4f;
            tab.AddCell(cell);
            tc = new Chunk(righttext, FontFactory.GetFont("Arial", 11f, 0, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BorderColor = this.tableborcolor;
            tab.AddCell(cell);
        }

        protected void AddNormalrow(ref PdfPTable tab, string lefttext, string righttext)
        {
            Chunk tc = new Chunk(lefttext, FontFactory.GetFont("Arial", 11f, 0, this.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BorderColor = this.wcolor;
            cell.PaddingBottom = 2f;
            cell.PaddingLeft = 5f;
            cell.PaddingTop = 2f;
            tab.AddCell(cell);
            tc = new Chunk(righttext, FontFactory.GetFont("Arial", 11f, 0, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BorderColor = this.wcolor;
            tab.AddCell(cell);
        }

        protected void Addrow(ref PdfPTable tab, string lefttext, string middletext, string righttext, bool isBold = true, bool isBackground = true, bool isPadding = false)
        {
            Chunk tc = new Chunk(lefttext, FontFactory.GetFont("Arial", 11f, isBold ? 1 : 0, this.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BorderColor = this.tableborcolor;
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = this.tablebackcolor;
            }
            tab.AddCell(cell);
            tc = new Chunk(middletext, FontFactory.GetFont("Arial", 11f, isBold ? 1 : 0, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BorderColor = this.tableborcolor;
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = this.tablebackcolor;
            }
            cell.HorizontalAlignment = 1;
            tab.AddCell(cell);
            tc = new Chunk(righttext, FontFactory.GetFont("Arial", 11f, isBold ? 1 : 0, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BorderColor = this.tableborcolor;
            if (isPadding)
            {
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
            }
            if (isBackground)
            {
                cell.BackgroundColor = this.tablebackcolor;
            }
            tab.AddCell(cell);
        }

        protected void Addrow(ref PdfPTable tab, string lefttext1, string lefttext2, string middletext, string righttext1, string righttext2)
        {
            Chunk tc = new Chunk(lefttext1, FontFactory.GetFont("Arial", 11f, 1, this.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            tab.AddCell(cell);
            tc = new Chunk(lefttext2, FontFactory.GetFont("Arial", 11f, 1, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            tab.AddCell(cell);
            tc = new Chunk(middletext, FontFactory.GetFont("Arial", 11f, 1, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            tab.AddCell(cell);
            tc = new Chunk(righttext1, FontFactory.GetFont("Arial", 11f, 0, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            tab.AddCell(cell);
            tc = new Chunk(righttext2, FontFactory.GetFont("Arial", 11f, 0, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            tab.AddCell(cell);
        }

        protected void AddrowHeader(ref PdfPTable tab, string lefttext, string middletext, string righttext)
        {
            Chunk tc = new Chunk(lefttext, FontFactory.GetFont("Arial", 11f, 1, this.bcolor));
            PdfPCell cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingLeft = 5f;
            cell.PaddingTop = 4f;
            tab.AddCell(cell);
            tc = new Chunk(middletext, FontFactory.GetFont("Arial", 11f, 1, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingLeft = 5f;
            cell.PaddingTop = 4f;
            tab.AddCell(cell);
            tc = new Chunk(righttext, FontFactory.GetFont("Arial", 11f, 1, this.bcolor));
            cell = new PdfPCell(new Phrase
			{
				tc
			});
            cell.BackgroundColor = this.tablebackcolor;
            cell.BorderColor = this.tableborcolor;
            cell.PaddingBottom = 10f;
            cell.PaddingLeft = 5f;
            cell.PaddingTop = 4f;
            tab.AddCell(cell);
        }

        protected void AddParagraph(string text, int alignment, Font f)
        {
            Chunk c = new Chunk(text, f);
            Phrase ph = new Phrase();
            ph.Add(c);
            Paragraph p = new Paragraph();
            p.Add(ph);
            p.SetLeading(0f, 1f);
            p.Alignment = alignment;
            this.doc.Add(p);
        }

        protected void AddNormalParagraph(string text)
        {
            Chunk c = new Chunk(text, FontFactory.GetFont("Arial", 10f, 0, this.bcolor));
            Phrase ph = new Phrase();
            ph.Add(c);
            Paragraph p = new Paragraph();
            p.Add(ph);
            p.Alignment = 0;
            p.SetLeading(0f, 1f);
            this.doc.Add(p);
        }

        protected void AddBlankParagraphLowHeight(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                Paragraph p = new Paragraph("\n");
                p.SetLeading(0f, 0.5f);
                this.doc.Add(new Paragraph(p));
            }
        }

        protected void AddBlankParagraph(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                Paragraph p = new Paragraph("\n");
                p.SetLeading(0f, 1f);
                this.doc.Add(new Paragraph(p));
            }
        }

        protected void AddColorBoldParagraph(string text)
        {
            Chunk c = new Chunk(text, FontFactory.GetFont("Arial", 10f, 1, this.hcolor));
            Phrase ph = new Phrase();
            ph.Add(c);
            Paragraph p = new Paragraph();
            p.Add(ph);
            p.Alignment = 0;
            p.SetLeading(0f, 1f);
            this.doc.Add(p);
        }

        private void ShowPdf(string s)
        {
            base.Response.ClearContent();
            base.Response.ClearHeaders();
            base.Response.AddHeader("Content-Disposition", "inline;filename=" + s);
            base.Response.ContentType = "application/pdf";
            base.Response.WriteFile(s);
            base.Response.Flush();
            base.Response.Clear();
        }
    }
}