﻿using AjaxControlToolkit;
using CookComputing.XmlRpc;
using DataTier;
using InfusionSoftDotNet;
using SGA.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.webadmin
{
    public partial class UserDetails : Page
    {
        private int userId = 0;

        protected string _direct = "";

        protected string _indirect = "";

        

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["Id"] != null)
            {
                this.userId = System.Convert.ToInt32(base.Request.QueryString["Id"].ToString());
            }
            if (!base.IsPostBack)
            {
                if (this.userId > 0)
                {
                    this.LoadProfile();
                    this.BindPermission();
                    this.BindCMCTest();
                  
                }
            }
        }

        private void BindPermission()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetUserResult", new SqlParameter[]
			{
				new SqlParameter("@userIds", this.userId)
			});
            this.dtgPermission.DataSource = ds;
            this.dtgPermission.DataBind();
        }

        private void LoadProfile()
        {
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@userId", SqlDbType.Int)
			};
            param[0].Value = this.userId;
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetProfileDetailsAdmin", param);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    SGACommon.SelectListItem(this.ddlEditCatExp, ds.Tables[0].Rows[0]["prevCatExp"].ToString());
                    SGACommon.SelectListItem(this.ddEditSector, ds.Tables[0].Rows[0]["sector"].ToString());
                    SGACommon.SelectListItem(this.ddlMembeship, ds.Tables[0].Rows[0]["membershipAssociation"].ToString());
                    SGACommon.SelectListItem(this.ddlEditModel, ds.Tables[0].Rows[0]["pmodel"].ToString());
                    SGACommon.SelectListItem(this.ddlEditEmployeeCompany, ds.Tables[0].Rows[0]["noemployee"].ToString());
                    SGACommon.SelectListItem(this.ddlEditSpentUnder, ds.Tables[0].Rows[0]["spentunder"].ToString());
                    SGACommon.SelectListItem(this.ddlEditProcurementYear, ds.Tables[0].Rows[0]["experience"].ToString());
                    SGACommon.SelectListItem(this.cboEditQualifications, ds.Tables[0].Rows[0]["education"].ToString());
                    SGACommon.SelectListItem(this.ddlEditExpertise, ds.Tables[0].Rows[0]["categoryId"].ToString());
                    SGACommon.SelectListItem(this.ddlEditReportingLine, ds.Tables[0].Rows[0]["reportline"].ToString());
                    SGACommon.SelectListItem(this.ddlEditSpendUnder, ds.Tables[0].Rows[0]["spendUnder"].ToString());
                    SGACommon.SelectListItem(this.ddlEditJobRole, ds.Tables[0].Rows[0]["jobRole"].ToString());
                    SGACommon.SelectListItem(this.ddlEditProLevel, ds.Tables[0].Rows[0]["proLevel"].ToString());
                    SGACommon.SelectListItem(this.ddlEditGeographical, ds.Tables[0].Rows[0]["geoInfluence"].ToString());
                    SGACommon.SelectListItem(this.ddlEditCountry, ds.Tables[0].Rows[0]["country"].ToString());
                    this.txtEditFname.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
                    this.txtEditLname.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
                    
                    this.txtEditPassword.Text = ds.Tables[0].Rows[0]["plainpassword"].ToString();
                    //this.txtEditPhone.Text = ((ds.Tables[0].Rows[0]["Phone"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["Phone"].ToString() : "");
                    //this.txtEditstate.Text = ((ds.Tables[0].Rows[0]["State"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["State"].ToString() : "");
                    //this.txtEditpostcode.Text = ((ds.Tables[0].Rows[0]["postcode"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["postcode"].ToString() : "");
                    //this.txtEditJobTitle.Text = ((ds.Tables[0].Rows[0]["jobtitle"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["jobtitle"].ToString() : "");
                    this.txtEditExiryDate.Text = System.Convert.ToDateTime(ds.Tables[0].Rows[0]["expiryDate"]).ToShortDateString();
                    if (System.Convert.ToBoolean(ds.Tables[0].Rows[0]["expired"]))
                    {
                        this.btnEditProfileExpire.Visible = false;
                    }
                    else
                    {
                        this.btnEditProfileExpire.Visible = true;
                    }
                    this.txtEditEmailAddress.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    this.lblEditStatus.Text = (System.Convert.ToBoolean(ds.Tables[0].Rows[0]["expired"]) ? "Expired" : "Running");
                    this._direct = ds.Tables[0].Rows[0]["directgenneral"].ToString();
                    this._indirect = ds.Tables[0].Rows[0]["specialist"].ToString();
                    //trLinkedIn.Visible = false;
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["isLinkedinAssociated"].ToString()))
                    //{
                    //    trLinkedIn.Visible = true; 
                    //    lblLinkedIn.Text = ds.Tables[0].Rows[0]["linkedinProfileUrl"].ToString();
                    //}

                    //if (ds.Tables[0].Rows[0]["facebookProfileId"].ToString().Length > 0) {
                    //    trFacebook.Visible = true;
                    //    lblFacebook.Text = ds.Tables[0].Rows[0]["facebookProfileId"].ToString();
                    //}
                    

                }
            }
        }

        public void UpdateProfile(string fname, string lname, string password, int jobRole, string membership, string country, int pmodel,int reportingLine, int spendUnder, int noemployee, int sector,int category,int spentUnder,int geoInfluence, int experience, int proLevel, int education,int catExp, System.DateTime dtExpiryDate, bool isExpired)
        {
            string passwordSalt = SGACommon.CreateSalt(5);
            string passwordHash = SGACommon.CreatePasswordHash(password, passwordSalt);
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@fname", SqlDbType.VarChar);
            param[1].Value = fname;
            param[2] = new SqlParameter("@lname", SqlDbType.VarChar);
            param[2].Value = lname;
            param[3] = new SqlParameter("@passwordSalt", SqlDbType.VarChar);
            param[3].Value = passwordSalt;
            param[4] = new SqlParameter("@passwordHash", SqlDbType.VarChar);
            param[4].Value = passwordHash;
            param[5] = new SqlParameter("@plainpassword", SqlDbType.VarChar);
            param[5].Value = password;
            param[6] = new SqlParameter("@jobRole", SqlDbType.Int);
            param[6].Value = jobRole;
            param[7] = new SqlParameter("@membership", SqlDbType.VarChar);
            param[7].Value = membership;
            param[8] = new SqlParameter("@country", SqlDbType.VarChar);
            param[8].Value = country;
            param[9] = new SqlParameter("@pmodel", SqlDbType.Int);
            param[9].Value = pmodel;
            param[10] = new SqlParameter("@reportline", SqlDbType.Int);
            param[10].Value = reportingLine;
            param[11] = new SqlParameter("@spendunder", SqlDbType.Int);
            param[11].Value = spendUnder;
            param[12] = new SqlParameter("@noemployee", SqlDbType.Int);
            param[12].Value = noemployee;
            param[13] = new SqlParameter("@sector", SqlDbType.Int);
            param[13].Value = sector;
            param[14] = new SqlParameter("@categoryId", SqlDbType.Int);
            param[14].Value = category;
            param[15] = new SqlParameter("@spentUnder", SqlDbType.Int);
            param[15].Value = spentUnder;
            param[16] = new SqlParameter("@geoInfluence", SqlDbType.Int);
            param[16].Value = geoInfluence;
            param[17] = new SqlParameter("@experience", SqlDbType.Int);
            param[17].Value = experience;
            param[18] = new SqlParameter("@proLevel", SqlDbType.Int);
            param[18].Value = proLevel;
            param[19] = new SqlParameter("@education", SqlDbType.Int);
            param[19].Value = education;
            param[20] = new SqlParameter("@catExp", SqlDbType.Int);
            param[20].Value = catExp;
            param[21] = new SqlParameter("@userId", SqlDbType.Int);
            param[21].Value = this.userId; 
            param[22] = new SqlParameter("@expiryDate", SqlDbType.DateTime);
            param[22].Value = dtExpiryDate;
            param[23] = new SqlParameter("@isExpired", SqlDbType.VarChar);
            param[23].Value = isExpired;
            param[24] = new SqlParameter("@flag", SqlDbType.Int);
            param[24].Value = 2;
            int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUpdateProfileAdmin", param));


            string[] strField = new string[]
                                        {
                                            "Id"
                                        };
            XmlRpcStruct[] resultFound = isdnAPI.findByEmail(txtEditEmailAddress.Text.Trim(), strField);
            int userId;
            XmlRpcStruct Contact = new XmlRpcStruct();
            if (resultFound.Length > 0)
            {
                userId = System.Convert.ToInt32(resultFound[0]["Id"].ToString());
                Contact.Add("FirstName", fname);
                Contact.Add("LastName", lname);
                Contact.Add("Email", txtEditEmailAddress.Text.Trim () );
                Contact.Add("Country", country);
                Contact.Add("_Jobrolebestdescribedas", SGACommon.GetJobRole(System.Convert.ToInt32(jobRole)));

                Contact.Add("ContactType", "Customer");
                isdnAPI.dsUpdate("Contact", userId, Contact);
            }
        }

        public void MarkExpireProfile(bool isExpired)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@isExpired", SqlDbType.VarChar);
            param[0].Value = isExpired;
            param[1] = new SqlParameter("@flag", SqlDbType.VarChar);
            param[1].Value = 1;
            param[2] = new SqlParameter("@userId", SqlDbType.Int);
            param[2].Value = this.userId;
            int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUpdateProfileAdmin", param));
            DataTable dt = this.GetUserDetailByUserId(this.userId);
            if (dt.Rows.Count > 0)
            {
                string subject = "";
                string body = "";
                SGACommon.GetEmailTemplate(9, ref subject, ref body);
                body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v1", dt.Rows[0]["lastName"].ToString()).Replace("@v2", dt.Rows[0]["company"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString());
                MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");
            }
        }

        protected void btnEditSaveProfile_Click(object sender, ImageClickEventArgs e)
        {
            string strIndirect = (base.Request["indirect"] == null) ? "" : base.Request["indirect"].ToString();
            string strDirect = (base.Request["direct"] == null) ? "" : base.Request["direct"].ToString();
            this.UpdateProfile(this.txtEditFname.Text, this.txtEditLname.Text, this.txtEditPassword.Text, System.Convert.ToInt32(this.ddlEditJobRole.SelectedValue), this.ddlMembeship.SelectedValue, this.ddlEditCountry.SelectedValue, System.Convert.ToInt32(this.ddlEditModel.SelectedValue), System.Convert.ToInt32(this.ddlEditReportingLine.SelectedValue), System.Convert.ToInt32(this.ddlEditSpendUnder.SelectedValue), System.Convert.ToInt32(this.ddlEditEmployeeCompany.SelectedValue), System.Convert.ToInt32(this.ddEditSector.SelectedValue), System.Convert.ToInt32(this.ddlEditExpertise.SelectedValue), System.Convert.ToInt32(this.ddlEditSpentUnder.SelectedValue), System.Convert.ToInt32(this.ddlEditGeographical.SelectedValue), System.Convert.ToInt32(this.ddlEditProcurementYear.SelectedValue), System.Convert.ToInt32(this.ddlEditProLevel.SelectedValue), System.Convert.ToInt32(this.cboEditQualifications.SelectedValue), System.Convert.ToInt32(this.ddlEditCatExp.SelectedValue), System.Convert.ToDateTime(this.txtEditExiryDate.Text), false);
            this.LoadProfile();
        }

        protected void btnEditProfileExpire_Click(object sender, ImageClickEventArgs e)
        {
            this.MarkExpireProfile(true);
            this.LoadProfile();
        }

        protected void ibtnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            foreach (DataGridItem item in this.dtgPermission.Items)
            {
                HtmlInputCheckBox chkSga = (HtmlInputCheckBox)item.FindControl("chkSga");
               

                HtmlInputCheckBox chkSgatest = (HtmlInputCheckBox)item.FindControl("chkSgatest");
             

                if (chkSga != null && chkSgatest != null )
                {
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spUpdateResultPermission", new SqlParameter[]
                     {
                      new SqlParameter("@userId", chkSga.Value),
                      new SqlParameter("@sgaResult", chkSga.Checked),
                   
                      new SqlParameter("@tnaTest", chkSgatest.Checked)
                   
                                        //chkCMK
                                    });
                }
            }
            this.BindPermission();
        }

        public DataTable GetUserDetailByUserId(int userId)
        {
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetProfileDetails", new SqlParameter[]
			{
				new SqlParameter("@userId", userId)
			}).Tables[0];
        }

        private void BindCMCTest()
        {
            string strOrderBy = " testId desc  ";
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManageCMCTest", new SqlParameter[]
			{
				new SqlParameter("@firstname", ""),
				new SqlParameter("@lastname", ""),
				new SqlParameter("@company", ""),
				new SqlParameter("@userIds", this.userId),
				new SqlParameter("@dateFrom", ""),
				new SqlParameter("@dateTo", ""),
				new SqlParameter("@orderBy", strOrderBy)
			});
            this.grdCMC.DataSource = ds;
            this.grdCMC.DataBind();
        }

        protected void grdCMC_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblDuration = (Label)e.Item.FindControl("lblDuration");
                Label lblAssesmentDate = (Label)e.Item.FindControl("lblAssesmentDate");
                //int complete = System.Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "complete"));
                string timeDiff = DataBinder.Eval(e.Item.DataItem, "diff").ToString();
                //HyperLink hylLink = (HyperLink)e.Item.FindControl("hylLink");
                //if (hylLink != null) {
                //    hylLink.NavigateUrl = ConfigurationManager.AppSettings["domain"].ToString() + "/Category_Management_Challenge_Report.aspx?Id="+DataBinder.Eval(e.Item.DataItem, "sessionId");
                //    hylLink.Text = "Report Download";
                //    hylLink.Target = "_blank";
                //}
                if (lblDuration != null)
                {
                    string[] strArr = timeDiff.Split(new char[]
					{
						':'
					});
                    lblDuration.Text = strArr[1] + " min " + strArr[2] + " sec ";
                }
                if (lblAssesmentDate != null)
                {
                    lblAssesmentDate.Text = SGACommon.ToAusTimeZone(System.Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "testDate"))).ToString("dd MMM yyyy HH:mm tt");
                }
                bool complete = System.Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "isTimeout").ToString());
                int isComplete = System.Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "complete"));
                if (complete || isComplete <= 0)
                {
                    e.Item.BackColor = Color.FromArgb(255, 156, 255);
                }
            }
        }

        protected void grdCMC_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spDeleteCMCTest", new SqlParameter[]
				{
					new SqlParameter("@testId", e.CommandArgument)
				});
                this.BindCMCTest();
            }
            else if (e.CommandName == "Graph")
            {
                base.Response.Redirect("TestChart.aspx?id=" + e.CommandArgument, false);
            }
            else if (e.CommandName == "drilldown")
            {
                base.Response.Redirect("/CMCChart/" + e.CommandArgument, false);
            }
            else if (e.CommandName == "Edit")
            {
                base.Response.Redirect("EditCMStest.aspx?id=" + e.CommandArgument, false);
            }
        }

      
    }
}
