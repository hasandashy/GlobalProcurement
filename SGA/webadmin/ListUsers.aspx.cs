using AjaxControlToolkit;
using CookComputing.XmlRpc;
using DataTier;
using InfusionSoftDotNet;
using OfficeOpenXml;
using SGA.App_Code;
using SGA.controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.webadmin
{
    public partial class ListUsers : Page
    {
        protected string _direct = "";

        protected string _indirect = "";



        public string SortExpression
        {
            get
            {
                return (this.ViewState["SortExpression"] == null) ? "" : this.ViewState["SortExpression"].ToString();
            }
            set
            {
                this.ViewState["SortExpression"] = value;
            }
        }

        public bool SortOrder
        {
            get
            {
                return this.ViewState["SortOrder"] != null && System.Convert.ToBoolean(this.ViewState["SortOrder"].ToString());
            }
            set
            {
                this.ViewState["SortOrder"] = value;
            }
        }

        public string SortExpressionCMC
        {
            get
            {
                return (this.ViewState["SortExpressionCMC"] == null) ? "" : this.ViewState["SortExpressionCMC"].ToString();
            }
            set
            {
                this.ViewState["SortExpressionCMC"] = value;
            }
        }

        public bool SortOrderCMC
        {
            get
            {
                return this.ViewState["SortOrderCMC"] != null && System.Convert.ToBoolean(this.ViewState["SortOrderCMC"].ToString());
            }
            set
            {
                this.ViewState["SortOrderCMC"] = value;
            }
        }

      
        public int PageNumber
        {
            get
            {
                int result;
                if (this.ViewState["PageNumber"] != null)
                {
                    result = System.Convert.ToInt32(this.ViewState["PageNumber"]);
                }
                else
                {
                    result = 0;
                }
                return result;
            }
            set
            {
                this.ViewState["PageNumber"] = value;
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.selected_tab.Value = base.Request.Form[this.selected_tab.UniqueID];
            this.txtFrom.Attributes.Add("readonly", "readonly");
            this.txtTo.Attributes.Add("readonly", "readonly");
            this.txtCMCFrom.Attributes.Add("readonly", "readonly");
            this.txtCMCTo.Attributes.Add("readonly", "readonly");
          


            this.txtEditExiryDate.Attributes.Add("readonly", "readonly");

            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    SGACommon.SelectListItem(this.ddlOrder, base.Request.QueryString["id"].ToString());
                }
                if (base.Request.QueryString["tabId"] != null)
                {
                    this.selected_tab.Value = base.Request.QueryString["tabId"].ToString();
                }
                this.BindGrid();
                this.BindPermission();
                this.BindUserTestInfo();
                this.BindCMCTest();
             
            }
        }

        private void BindUserTestInfo()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spUserTestInformation", new SqlParameter[]
            {
                new SqlParameter("@userIds", this.hdSelectIds.Value)
            });
            this.grdUserTest.DataSource = ds;
            this.grdUserTest.DataBind();
        }

        private void BindPermission()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetUserResult", new SqlParameter[]
            {
                new SqlParameter("@userIds", this.hdSelectIds.Value)
            });
            this.dtgList.DataSource = ds;
            this.dtgList.DataBind();
        }

        private void BindGrid()
        {
            string strOrderBy = " u.isApproved asc, id desc  ";
            if (this.SortExpression.Length > 0)
            {
                strOrderBy = (this.SortOrder ? (this.SortExpression + " Asc") : (this.SortExpression + " Desc"));
            }
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManageUsers", new SqlParameter[]
            {
                new SqlParameter("@firstname", this.txtFname.Value.Trim()),
                new SqlParameter("@lastname", this.txtLname.Value.Trim()),
                new SqlParameter("@email", this.txtEmail.Value.Trim()),
                new SqlParameter("@company", this.txtCompany.Value.Trim()),
                new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
                new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
                new SqlParameter("@userCondition", this.ddlOrder.SelectedValue),
                new SqlParameter("@orderBy", strOrderBy),
                new SqlParameter("@roleId", 2)
            });
            this.grdUsers.DataSource = ds;
            this.grdUsers.DataBind();
        }

        protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
        {
            this.hdSelectIds.Value = "";
            foreach (DataGridItem item in this.grdUsers.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    if (chkSelect.Checked)
                    {
                        this.hdSelectIds.Value = this.hdSelectIds.Value + chkSelect.Value + ",";
                    }
                }
            }
            this.BindGrid();
            this.dtgList.CurrentPageIndex = 0;
            this.BindPermission();
            this.grdUserTest.CurrentPageIndex = 0;
            this.BindUserTestInfo();
            this.grdCMC.CurrentPageIndex = 0;
            this.BindCMCTest();
           
            this.LoadProfile();
        }

        protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            foreach (DataGridItem item in this.grdUsers.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    if (chkSelect.Checked)
                    {
                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spDeleteUser", new SqlParameter[]
                        {
                            new SqlParameter("@userId", chkSelect.Value)
                        });
                    }
                }
            }
            this.BindGrid();
            this.BindPermission();
            this.BindUserTestInfo();
            this.BindCMCTest();
        
        }

        protected void iBtnDisApproveAll_Click(object sender, ImageClickEventArgs e)
        {
            foreach (DataGridItem item in this.grdUsers.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    if (chkSelect.Checked)
                    {
                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spUserStatus", new SqlParameter[]
                        {
                            new SqlParameter("@userId", chkSelect.Value)
                        });
                        DataTable dt = this.GetUserDetailByUserId(chkSelect.Value);
                        if (dt.Rows.Count > 0)
                        {
                            string subject = "";
                            string body = "";
                            SGACommon.GetEmailTemplate(9, ref subject, ref body);
                            body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v1", dt.Rows[0]["lastName"].ToString()).Replace("@v2", dt.Rows[0]["company"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString());
                            MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");
                        }
                    }
                }
            }
            this.BindGrid();
            this.BindPermission();
            this.BindUserTestInfo();
            this.BindCMCTest();
         
        }

        protected void iBtnApproveAll_Click(object sender, ImageClickEventArgs e)
        {
            foreach (DataGridItem item in this.grdUsers.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    if (chkSelect.Checked)
                    {
                        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spUserStatus", new SqlParameter[]
                        {
                            new SqlParameter("@userId", chkSelect.Value)
                        });
                        DataTable dt = this.GetUserDetailByUserId(chkSelect.Value);
                        if (dt.Rows.Count > 0)
                        {
                            string subject = "";
                            string body = "";
                            SGACommon.GetEmailTemplate(7, ref subject, ref body);
                            body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v1", dt.Rows[0]["lastName"].ToString()).Replace("@v2", dt.Rows[0]["company"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString()).Replace("@v4", SGACommon.GetJobRole(System.Convert.ToInt32(dt.Rows[0]["jobRole"].ToString())));
                            MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");
                        }
                    }
                }
            }
            this.BindGrid();
            this.BindPermission();
            this.BindUserTestInfo();
            this.BindCMCTest();
          

        }

        protected void iBtnLoginReminder_Click(object sender, ImageClickEventArgs e)
        {
            foreach (DataGridItem item in this.grdUsers.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    if (chkSelect.Checked)
                    {
                        DataTable dt = this.GetUserDetailByUserId(chkSelect.Value);
                        if (dt.Rows.Count > 0)
                        {
                            string subject = "";
                            string body = "";
                            SGACommon.GetEmailTemplate(14, ref subject, ref body);
                            body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString());
                            subject = subject.Replace("@v0", dt.Rows[0]["firstName"].ToString());
                            MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");

                            string[] strField = new string[]
                            {
                                "Id"
                            };
                            XmlRpcStruct[] resultFound = isdnAPI.findByEmail(dt.Rows[0]["email"].ToString(), strField);
                            int userId;
                            if (resultFound.Length > 0)
                            {
                                userId = System.Convert.ToInt32(resultFound[0]["Id"].ToString());
                                isdnAPI.addToGroup(userId, 1478);
                            }
                        }
                    }
                }
            }
        }

        protected void iBtnResendEmail_Click(object sender, ImageClickEventArgs e)
        {
            foreach (DataGridItem item in this.grdUsers.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    if (chkSelect.Checked)
                    {
                        DataTable dt = this.GetUserDetailByUserId(chkSelect.Value);
                        if (dt.Rows.Count > 0)
                        {
                            string subject = "";
                            string body = "";
                            SGACommon.GetEmailTemplate(7, ref subject, ref body);
                            body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v1", dt.Rows[0]["lastName"].ToString()).Replace("@v2", dt.Rows[0]["company"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString());
                            MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");
                        }
                    }
                }
            }
        }

        protected void dtgList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                bool isSga = System.Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "viewSGA"));
               

                bool isTakeSga = System.Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "takeSGA"));
             
                if (isSga && isTakeSga)
                {
                    e.Item.BackColor = Color.FromArgb(133, 195, 233);
                }
            }
        }

        protected void dtgList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dtgList.CurrentPageIndex = e.NewPageIndex;
            this.BindPermission();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridItem item in this.dtgList.Items)
            {
                HtmlInputCheckBox chkSga = (HtmlInputCheckBox)item.FindControl("chkSga");
              

                HtmlInputCheckBox chkSgatest = (HtmlInputCheckBox)item.FindControl("chkSgatest");
              

                if (chkSga != null && chkSgatest != null)
                {
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spUpdateResultPermission", new SqlParameter[]
                     {
                      new SqlParameter("@userId", chkSga.Value),
                      new SqlParameter("@sgaResult", chkSga.Checked),

                      new SqlParameter("@tnaTest", chkSgatest.Checked)

                                    });
                }
            }
            this.BindPermission();
        }

        public DataTable GetUserDetailByUserId(string userId)
        {
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetProfileDetails", new SqlParameter[]
            {
                new SqlParameter("@userId", userId)
            }).Tables[0];
        }

        protected void lnkSearch_Click(object sender, System.EventArgs e)
        {
            this.grdUsers.CurrentPageIndex = 0;
            this.BindGrid();
        }

        private void BindCMCTest()
        {
            string strOrderBy = " testId desc  ";
            if (this.SortExpressionCMC.Length > 0)
            {
                strOrderBy = (this.SortOrderCMC ? (this.SortExpressionCMC + " Asc") : (this.SortExpressionCMC + " Desc"));
            }
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManageCMCTest", new SqlParameter[]
            {
                new SqlParameter("@firstname", this.txtCMCFname.Value.Trim()),
                new SqlParameter("@lastname", this.txtCMCLname.Value.Trim()),
                new SqlParameter("@company", this.txtCMCCompany.Value.Trim()),
                new SqlParameter("@userIds", this.hdSelectIds.Value),
                new SqlParameter("@dateFrom", this.txtCMCFrom.Text.Trim()),
                new SqlParameter("@dateTo", this.txtCMCTo.Text.Trim()),
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
                
                string timeDiff = DataBinder.Eval(e.Item.DataItem, "diff").ToString();
                if (lblDuration != null)
                {
                    string[] strArr = timeDiff.Split(new char[]
                    {
                        ':'
                    });
                    lblDuration.Text = string.Concat(new string[]
                    {
                        strArr[0],
                        " hour ",
                        strArr[1],
                        " min ",
                        strArr[2],
                        " sec "
                    });
                }
                if (lblAssesmentDate != null)
                {
                    lblAssesmentDate.Text = SGACommon.ToAusTimeZone(System.Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "testDate"))).ToString("dd MMM yyyy HH:mm tt");
                }
                bool complete = System.Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "isTimeout"));
                int isComplete = System.Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "complete"));
                if (complete || isComplete <= 0)
                {
                    e.Item.BackColor = Color.FromArgb(255, 156, 255);
                }
            }
        }

        protected void grdCMC_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.grdCMC.CurrentPageIndex = e.NewPageIndex;
            this.BindCMCTest();
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

        protected void lnkCMCSearch_Click(object sender, System.EventArgs e)
        {
            this.grdCMC.CurrentPageIndex = 0;
            this.BindCMCTest();
        }

       

        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@email", SqlDbType.VarChar)
            };
            param[0].Value = this.txtEmailAddress.Value.Trim();
            int status = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spCheckUniqueEmail", param));
            if (status > 0)
            {
                this.lblError.Text = "The email address already exists!";
            }
            else
            {
                try
                {
                    // Register user
                    string plainpassword = SGACommon.generatePassword(8);
                    string passwordSalt = SGACommon.CreateSalt(5);
                    string passwordHash = SGACommon.CreatePasswordHash(plainpassword, passwordSalt);

                    param = new SqlParameter[13];
                    param[0] = new SqlParameter("@action", SqlDbType.VarChar);
                    param[0].Value = "Insert";
                    param[1] = new SqlParameter("@password", SqlDbType.VarChar);
                    param[1].Value = plainpassword;
                    param[2] = new SqlParameter("@company", SqlDbType.VarChar);
                    param[2].Value = "";
                    param[3] = new SqlParameter("@firstName", SqlDbType.VarChar);
                    param[3].Value = this.txtFirstname.Value;
                    param[4] = new SqlParameter("@lastName", SqlDbType.VarChar);
                    param[4].Value = this.txtLastname.Value;
                    param[5] = new SqlParameter("@email", SqlDbType.VarChar);
                    param[5].Value = this.txtEmailAddress.Value;
                    param[6] = new SqlParameter("@isApproved", SqlDbType.Bit);
                    param[6].Value = 1;
                    param[7] = new SqlParameter("@passwordHash", SqlDbType.VarChar);
                    param[7].Value = passwordHash;
                    param[8] = new SqlParameter("@passwordSalt", SqlDbType.VarChar);
                    param[8].Value = passwordSalt;
                    param[9] = new SqlParameter("@jobRole", SqlDbType.Int);
                    param[9].Value = this.ddlJobRole.SelectedValue;
                    param[10] = new SqlParameter("@isAdminAdded", SqlDbType.Bit);
                    param[10].Value = true;
                    param[11] = new SqlParameter("@country", SqlDbType.VarChar);
                    param[11].Value = this.ddlCountry.SelectedValue;
                    param[12] = new SqlParameter("@membershipAssociation", SqlDbType.VarChar);
                    param[12].Value = this.ddlMembership.SelectedValue;
                    int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUserMasterGlobalProcurement", param));

                    
                    if (result == 0)
                    {
                        this.lblError.Text = "There was some error with user saving, try again.";
                    }
                    else
                    {
                        UpdateValueinIS(this.txtEmailAddress.Value, this.txtFirstname.Value, this.txtLastname.Value, this.ddlCountry.SelectedValue, this.ddlMembership.SelectedValue, "", "", plainpassword, Convert.ToInt32(this.ddlJobRole.SelectedValue));
                        //string subject = "";
                        //string body = "";
                        //SGACommon.GetEmailTemplate(8, ref subject, ref body);
                        //body = body.Replace("@v0", this.txtFirstname.Value.Trim()).Replace("@v1", this.txtLastname.Value.Trim()).Replace("@v2", "".Trim()).Replace("@v3", this.txtEmailAddress.Value.Trim()).Replace("@v5", this.txtPassword.Value.Trim()).Replace("@v4", SGACommon.GetJobRole(System.Convert.ToInt32(this.ddlJobRole.SelectedValue)));
                        //MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), this.txtEmailAddress.Value.Trim(), subject, body, "");

                        //XmlRpcStruct MailContent = new XmlRpcStruct();
                        //MailContent = isdnAPI.getEmailTemplate(3396);
                        //subject = MailContent["subject"].ToString();
                        //string fromAddress = MailContent["fromAddress"].ToString();
                        //string htmlBody = MailContent["htmlBody"].ToString();

                        //subject = "New user registration email";
                        //System.IO.StreamReader objStreamReader = System.IO.File.OpenText(HttpContext.Current.Server.MapPath("~/css/register.htm"));
                        //string content = objStreamReader.ReadToEnd();
                        //objStreamReader.Close();
                        //objStreamReader.Dispose();
                        //content = content.Replace("@firstname", this.txtFirstname.Value.Trim()).Replace("@lastname", this.txtLastname.Value.Trim()).Replace("@email", this.txtEmailAddress.Value.Trim()).Replace("@company", "".Trim()).Replace("@jobrole", SGACommon.GetJobRole(System.Convert.ToInt32(this.ddlJobRole.SelectedValue))).Replace("@ip", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                        //MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), fromAddress, ConfigurationManager.AppSettings["infusionTo"].ToString(), subject, content, ConfigurationManager.AppSettings["infusionCC"].ToString());
                        this.lblError.Text = "User added successfully and email sent to him.";
                        this.txtFirstname.Value = "";
                        this.txtLastname.Value = "";
                        
                        this.txtEmailAddress.Value = "";
                        this.ddlMembership.SelectedIndex = -1;
                        this.ddlJobRole.SelectedIndex = -1;
                        this.BindGrid();
                    }
                }
                catch (System.Exception ex_81E)
                {
                    this.lblError.Text = "There was some error with user saving, try again.";
                }
            }
        }

        public void UpdateValueinIS(string emailAddress, string firstName, string lastName, string country, string membershipAssociation, string ifpsmComments, string ifpsmJobRole, string plainPassword, int jobRole)
        {
            string[] strField = new string[]
                            {
                            "Id"
                            };
            XmlRpcStruct[] resultFound = isdnAPI.findByEmail(emailAddress, strField);
            if (resultFound.Length > 0)
            {
                XmlRpcStruct Contact = new XmlRpcStruct();

                Contact.Add("ContactType", "Customer");
                Contact.Add("FirstName", firstName);
                Contact.Add("LastName", lastName);
                Contact.Add("_Country1", country);
                Contact.Add("_MembershipAssociation0", membershipAssociation);
                Contact.Add("_IFPSMComments", ifpsmComments);
                Contact.Add("_Jobrolebestdescribedas", SGACommon.GetJobRole(jobRole));
                Contact.Add("_IFPSMPageJobRole", ifpsmJobRole);
                isdnAPI.dsUpdate("Contact", System.Convert.ToInt32(resultFound[0]["Id"].ToString()), Contact);
                isdnAPI.addToGroup(System.Convert.ToInt32(resultFound[0]["Id"].ToString()), 3448);
                isdnAPI.optIn(emailAddress, "Make them marketable");
            }
            else
            {
                int userId = isdnAPI.add(new XmlRpcStruct
                            {
                                {
                                    "FirstName",
                                    firstName
                                },
                                {
                                    "LastName",
                                    lastName
                                },
                                {
                                    "JobTitle",
                                    ""
                                },
                                {
                                    "Email",
                                    emailAddress
                                },
                                {
                                    "Company",
                                    ""
                                },
                                {
                                    "_Yourlevel",
                                    ""
                                },
                                {
                                    "_Jobrolebestdescribedas",
                                    SGACommon.GetJobRole(jobRole)
                                },
                                {
                                    "LeadSourceId",
                                    "22"
                                },
                                {
                                    "OwnerID",
                                    "6"
                                },{
                                    "_MembershipAssociation0",
                                    membershipAssociation
                                },{
                                        "_Country1",
                                        country
                                },
                                { "_IFPSMComments", ifpsmComments },

                                {
                                    "ContactType",
                                    "Customer"
                                }
                            });
                if (userId > 0)
                {
                    if (plainPassword.Length > 0)
                    {
                        XmlRpcStruct Contact = new XmlRpcStruct();

                        Contact.Add("ContactType", "Customer");
                        Contact.Add("_SGApassword", plainPassword);
                        Contact.Add("_IFPSMPageJobRole", ifpsmJobRole);
                        isdnAPI.dsUpdate("Contact", userId, Contact);
                    }
                    else
                    {
                        XmlRpcStruct Contact = new XmlRpcStruct();

                        Contact.Add("ContactType", "Customer");
                        Contact.Add("_IFPSMPageJobRole", ifpsmJobRole);
                        isdnAPI.dsUpdate("Contact", userId, Contact);
                    }
                    isdnAPI.addToGroup(userId, 3448);
                    isdnAPI.optIn(emailAddress, "Make them marketable");
                }
            }
        }

        protected void imgUpload_Click(object sender, ImageClickEventArgs e)
        {
            this.lblEmailErrors.Text = "";
            System.Text.StringBuilder strmail = new System.Text.StringBuilder();
            strmail.Append("The following emails already exists in the system and have not been updated : <br />");
            HttpPostedFile file = this.FileInput.PostedFile;
            if (file != null && file.ContentLength > 0)
            {
                byte[] fileBytes = new byte[file.ContentLength];
                file.InputStream.Read(fileBytes, 0, file.ContentLength);
                string fileName = string.Format("SgaUsers_{0}_{1}.xlsx", System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), SGACommon.generatePassword(4));
                string filePath = System.IO.Path.Combine(base.Request.PhysicalApplicationPath + "//webadmin/docs/", fileName);
                System.IO.File.WriteAllBytes(filePath, fileBytes);
                try
                {
                    System.IO.FileInfo newFile = new System.IO.FileInfo(filePath);
                    string[] properties = new string[]
                    {
                        "Email address",
                        "First name",
                        "Last name",
                        "Country",
                        "Job Role ID",
                        "Membership Accociation"
                    };
                    int iRow = 2;
                    using (ExcelPackage xlPackage = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                        if (worksheet == null)
                        {
                            throw new System.Exception("No worksheet found");
                        }
                        bool isValidData = true;
                        while (true)
                        {
                            bool allColumnsAreEmpty = true;
                            for (int i = 1; i < properties.Length; i++)
                            {
                                if (worksheet.Cells[iRow, i].Value != null && !string.IsNullOrEmpty(worksheet.Cells[iRow, i].Value.ToString()))
                                {
                                    allColumnsAreEmpty = false;
                                    break;
                                }
                            }
                            if (allColumnsAreEmpty)
                            {
                                break;
                            }
                            string email = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Email address")].Value.ToString().Trim();
                            string fName = worksheet.Cells[iRow, this.GetColumnIndex(properties, "First name")].Value.ToString().Trim();
                            string lName = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Last name")].Value.ToString().Trim();
                            string Country = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Country")].Value.ToString().Trim();
                            string jobRoleId = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Job Role ID")].Value.ToString().Trim();
                            string membership = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Membership Accociation")].Value.ToString().Trim();
                            if (email.Trim().Length <= 0)
                            {
                                goto Block_12;
                            }
                            iRow++;
                        }
                        goto IL_6E8;
                    Block_12:
                        this.lblUploadError.Visible = true;
                        this.lblUploadError.Text = "Email address is required in the excel on row '" + iRow + "'.";
                        this.lblUploadError.ForeColor = Color.Red;
                        isValidData = false;
                    IL_6E8:
                        iRow = 2;
                        if (isValidData)
                        {
                            bool userInsert = false;
                            bool isEmailError = false;
                            while (true)
                            {
                                bool allColumnsAreEmpty = true;
                                for (int i = 1; i < properties.Length; i++)
                                {
                                    if (worksheet.Cells[iRow, i].Value != null && !string.IsNullOrEmpty(worksheet.Cells[iRow, i].Value.ToString()))
                                    {
                                        allColumnsAreEmpty = false;
                                        break;
                                    }
                                }
                                if (allColumnsAreEmpty)
                                {
                                    break;
                                }
                                string email = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Email address")].Value.ToString().Trim();
                                string fName = worksheet.Cells[iRow, this.GetColumnIndex(properties, "First name")].Value.ToString().Trim();
                                string lName = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Last name")].Value.ToString().Trim();
                                string Country = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Country")].Value.ToString().Trim();
                                string jobRoleId = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Job Role ID")].Value.ToString().Trim();
                                string membership = worksheet.Cells[iRow, this.GetColumnIndex(properties, "Membership Accociation")].Value.ToString().Trim();

                                SqlParameter[] param = new SqlParameter[]
                                {
                                    new SqlParameter("@email", SqlDbType.VarChar)
                                };
                                param[0].Value = email;
                                int status = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spCheckUniqueEmail", param));
                                if (status > 0)
                                {
                                    isEmailError = true;
                                    strmail.Append(email + "<br/>");
                                }
                                else
                                {
                                    // Register user
                                    string plainpassword = SGACommon.generatePassword(8);
                                    string passwordSalt = SGACommon.CreateSalt(5);
                                    string passwordHash = SGACommon.CreatePasswordHash(plainpassword, passwordSalt);

                                    param = new SqlParameter[13];
                                    param[0] = new SqlParameter("@action", SqlDbType.VarChar);
                                    param[0].Value = "Insert";
                                    param[1] = new SqlParameter("@password", SqlDbType.VarChar);
                                    param[1].Value = plainpassword;
                                    param[2] = new SqlParameter("@company", SqlDbType.VarChar);
                                    param[2].Value = "";
                                    param[3] = new SqlParameter("@firstName", SqlDbType.VarChar);
                                    param[3].Value = fName;
                                    param[4] = new SqlParameter("@lastName", SqlDbType.VarChar);
                                    param[4].Value = lName;
                                    param[5] = new SqlParameter("@email", SqlDbType.VarChar);
                                    param[5].Value = email;
                                    param[6] = new SqlParameter("@isApproved", SqlDbType.Bit);
                                    param[6].Value = 1;
                                    param[7] = new SqlParameter("@passwordHash", SqlDbType.VarChar);
                                    param[7].Value = passwordHash;
                                    param[8] = new SqlParameter("@passwordSalt", SqlDbType.VarChar);
                                    param[8].Value = passwordSalt;
                                    param[9] = new SqlParameter("@jobRole", SqlDbType.Int);
                                    //param[9].Value = "1";
                                    param[9].Value = jobRoleId;
                                    param[10] = new SqlParameter("@isAdminAdded", SqlDbType.Bit);
                                    param[10].Value = false;
                                    param[11] = new SqlParameter("@country", SqlDbType.VarChar);
                                    param[11].Value = Country;
                                    param[12] = new SqlParameter("@membershipAssociation", SqlDbType.VarChar);
                                    param[12].Value = membership;
                                    int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUserMasterGlobalProcurement", param));


                                    if (result > 0)
                                    {
                                        UpdateValueinIS(email, fName, lName, Country, membership, "", "", plainpassword, Convert.ToInt32(jobRoleId));
                                        //string subject = "";
                                        //string body = "";
                                        //SGACommon.GetEmailTemplate(8, ref subject, ref body);
                                        //body = body.Replace("@v0", fName).Replace("@v1", lName).Replace("@v2", CName).Replace("@v3", email).Replace("@v5", password);
                                        //MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), email, subject, body, "");

                                        //subject = "New user registration email";
                                        //System.IO.StreamReader objStreamReader = System.IO.File.OpenText(HttpContext.Current.Server.MapPath("~/css/register.htm"));
                                        //string content = objStreamReader.ReadToEnd();
                                        //objStreamReader.Close();
                                        //objStreamReader.Dispose();
                                        //content = content.Replace("@firstname", fName).Replace("@lastname", lName).Replace("@email", email).Replace("@company", CName).Replace("@jobrole", SGACommon.GetJobRole(System.Convert.ToInt32(jobRoleId))).Replace("@ip", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                                        //MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), fromAddress, ConfigurationManager.AppSettings["infusionTo"].ToString(), subject, content, ConfigurationManager.AppSettings["infusionCC"].ToString());
                                    }
                                    userInsert = true;
                                }
                                iRow++;
                            }
                            if (isEmailError)
                            {
                                this.lblEmailErrors.Visible = true;
                                this.lblEmailErrors.Text = strmail.ToString();
                                this.lblEmailErrors.ForeColor = Color.Red;
                            }
                            if (userInsert)
                            {
                                this.BindGrid();
                                this.BindPermission();
                                this.lblUploadError.Visible = true;
                                this.lblUploadError.Text = "Data inserted successfully.";
                                this.lblUploadError.ForeColor = Color.Green;
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    this.lblUploadError.Visible = true;
                    this.lblUploadError.Text = ex.ToString();
                    this.lblUploadError.ForeColor = Color.Red;
                }
                finally
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }

        protected virtual int GetColumnIndex(string[] properties, string columnName)
        {
            if (properties == null)
            {
                throw new System.ArgumentNullException("properties");
            }
            if (columnName == null)
            {
                throw new System.ArgumentNullException("columnName");
            }
            int result;
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Equals(columnName, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    result = i + 1;
                    return result;
                }
            }
            result = 0;
            return result;
        }

        private void LoadProfile()
        {
            if (this.hdSelectIds.Value.Length > 0)
            {
                string[] strArr = this.hdSelectIds.Value.Split(new char[]
                {
                    ','
                });
                if (strArr.Length == 2)
                {
                    this.viewUser2.Visible = false;
                    this.viewUser1.Visible = true;
                    int id = System.Convert.ToInt32(strArr[0]);
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@userId", SqlDbType.Int)
                    };
                    param[0].Value = id;
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
                else
                {
                    this.viewUser2.Visible = true;
                    this.viewUser1.Visible = false;
                }
            }
        }

        public void UpdateProfile(string fname, string lname, string password, int jobRole, string membership, string country, int pmodel, int reportingLine, int spendUnder, int noemployee, int sector, int category, int spentUnder, int geoInfluence, int experience, int proLevel, int education, int catExp, System.DateTime dtExpiryDate, bool isExpired)
        {
            string passwordSalt = SGACommon.CreateSalt(5);
            string passwordHash = SGACommon.CreatePasswordHash(password, passwordSalt);
            int id = System.Convert.ToInt32(this.hdSelectIds.Value.Split(new char[]
           {
                ','
           })[0]);
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
            param[21].Value = id;
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
                Contact.Add("Email", txtEditEmailAddress.Text.Trim());
                Contact.Add("Country", country);
                Contact.Add("_Jobrolebestdescribedas", SGACommon.GetJobRole(System.Convert.ToInt32(jobRole)));

                Contact.Add("ContactType", "Customer");
                isdnAPI.dsUpdate("Contact", userId, Contact);
            }
        }

        public void MarkExpireProfile(bool isExpired)
        {
            SqlParameter[] param = new SqlParameter[3];
            int id = System.Convert.ToInt32(this.hdSelectIds.Value.Split(new char[]
            {
                ','
            })[0]);
            param[0] = new SqlParameter("@isExpired", SqlDbType.VarChar);
            param[0].Value = isExpired;
            param[1] = new SqlParameter("@flag", SqlDbType.VarChar);
            param[1].Value = 1;
            param[2] = new SqlParameter("@userId", SqlDbType.Int);
            param[2].Value = id;
            int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUpdateProfileAdmin", param));
            DataTable dt = this.GetUserDetailByUserId(id.ToString());
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
            this.BindGrid();
        }

        protected void btnEditProfileExpire_Click(object sender, ImageClickEventArgs e)
        {
            this.MarkExpireProfile(true);
            this.LoadProfile();
        }

        protected void btnExport_Click(object sender, System.EventArgs e)
        {
            DataSet DS = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spExcelExportUsers", new SqlParameter[]
            {
                new SqlParameter("@firstname", this.txtFname.Value.Trim()),
                new SqlParameter("@lastname", this.txtLname.Value.Trim()),
                new SqlParameter("@email", this.txtEmail.Value.Trim()),
                new SqlParameter("@company", this.txtCompany.Value.Trim()),
                new SqlParameter("@dateFrom", this.txtFrom.Text.Trim()),
                new SqlParameter("@dateTo", this.txtTo.Text.Trim()),
                new SqlParameter("@userCondition", this.ddlOrder.SelectedValue),
                new SqlParameter("@orderBy", " id desc ")
            });
            string fileName = "userlist.xlsx";
            string excelTmpFilePath = ConfigurationManager.AppSettings["templatePath"];
            //string SGAfilePath = ConfigurationManager.AppSettings["SGAFilePath"];
            string fullTempFilePath = Server.MapPath(excelTmpFilePath + "users.xlsx");
            string fullSGAPath = Server.MapPath(excelTmpFilePath + fileName);
            System.IO.FileInfo existingFile = new System.IO.FileInfo(fullTempFilePath);
            System.IO.FileInfo fNewFile = new System.IO.FileInfo(fullSGAPath);

            using (ExcelPackage MyExcel = new ExcelPackage(existingFile))
            {
                ExcelWorksheet MyWorksheet = MyExcel.Workbook.Worksheets["Sheet1"];
                int startRow = 2;
                if (DS != null)
                {
                    if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                    {
                        int i = 0;
                        while (i < DS.Tables[0].Rows.Count)
                        {
                            MyWorksheet.Cells[startRow, 1].Value = DS.Tables[0].Rows[i]["Id"].ToString();
                            MyWorksheet.Cells[startRow, 2].Value = DS.Tables[0].Rows[i]["First name"].ToString();
                            MyWorksheet.Cells[startRow, 3].Value = DS.Tables[0].Rows[i]["Last name"].ToString();
                            MyWorksheet.Cells[startRow, 4].Value = DS.Tables[0].Rows[i]["Email"].ToString();
                            MyWorksheet.Cells[startRow, 5].Value = DS.Tables[0].Rows[i]["Company"].ToString();
                            MyWorksheet.Cells[startRow, 6].Value = DS.Tables[0].Rows[i]["ExpiryDate"].ToString();
                            MyWorksheet.Cells[startRow, 7].Value = DS.Tables[0].Rows[i]["Register date"].ToString();
                            MyWorksheet.Cells[startRow, 8].Value = DS.Tables[0].Rows[i]["Password"].ToString();
                            MyWorksheet.Cells[startRow, 9].Value = DS.Tables[0].Rows[i]["Job Role"].ToString();
                            MyWorksheet.Cells[startRow, 10].Value = DS.Tables[0].Rows[i]["Approved"].ToString();
                            MyWorksheet.Cells[startRow, 11].Value = DS.Tables[0].Rows[i]["Added By Admin"].ToString();
                            MyWorksheet.Cells[startRow, 12].Value = DS.Tables[0].Rows[i]["Industry"].ToString();
                            MyWorksheet.Cells[startRow, 13].Value = DS.Tables[0].Rows[i]["Annualised revenues"].ToString();
                            MyWorksheet.Cells[startRow, 14].Value = DS.Tables[0].Rows[i]["Spend under influence"].ToString();
                            MyWorksheet.Cells[startRow, 15].Value = DS.Tables[0].Rows[i]["Procurement model"].ToString();
                            MyWorksheet.Cells[startRow, 16].Value = DS.Tables[0].Rows[i]["Number of employees"].ToString();
                            MyWorksheet.Cells[startRow, 17].Value = DS.Tables[0].Rows[i]["Years of procurement experience"].ToString();
                            MyWorksheet.Cells[startRow, 18].Value = DS.Tables[0].Rows[i]["Level of education"].ToString();
                            MyWorksheet.Cells[startRow, 19].Value = DS.Tables[0].Rows[i]["Category you manage currently"].ToString();
                            MyWorksheet.Cells[startRow, 20].Value = DS.Tables[0].Rows[i]["Procurement function reports to"].ToString();
                            MyWorksheet.Cells[startRow, 21].Value = DS.Tables[0].Rows[i]["Procurement qualifications"].ToString();
                            MyWorksheet.Cells[startRow, 22].Value = DS.Tables[0].Rows[i]["Geographical influence"].ToString();
                            MyWorksheet.Cells[startRow, 23].Value = DS.Tables[0].Rows[i]["Phone No"].ToString();
                            MyWorksheet.Cells[startRow, 24].Value = DS.Tables[0].Rows[i]["In which state do you work?"].ToString();
                            MyWorksheet.Cells[startRow, 25].Value = DS.Tables[0].Rows[i]["Postcode"].ToString();
                            MyWorksheet.Cells[startRow, 26].Value = DS.Tables[0].Rows[i]["Country"].ToString();
                            MyWorksheet.Cells[startRow, 27].Value = DS.Tables[0].Rows[i]["JobTitle"].ToString();
                            MyWorksheet.Cells[startRow, 28].Value = DS.Tables[0].Rows[i]["Procurement Knowledge Evaluation - Assigned"].ToString();
                            MyWorksheet.Cells[startRow, 29].Value = DS.Tables[0].Rows[i]["Procurement Knowledge Evaluation - Started"].ToString();
                            MyWorksheet.Cells[startRow, 30].Value = DS.Tables[0].Rows[i]["Skills Self Assessment Given"].ToString();
                            MyWorksheet.Cells[startRow, 31].Value = DS.Tables[0].Rows[i]["Behavioural Assessment Given"].ToString();
                            MyWorksheet.Cells[startRow, 32].Value = DS.Tables[0].Rows[i]["Negotiation Profile Assessment Given"].ToString();
                            MyWorksheet.Cells[startRow, 33].Value = DS.Tables[0].Rows[i]["Maturity Profile Assessment Given"].ToString();
                            MyWorksheet.Cells[startRow, 34].Value = DS.Tables[0].Rows[i]["Negotiation Profile Assessment Given"].ToString();
                            MyWorksheet.Cells[startRow, 35].Value = DS.Tables[0].Rows[i]["Contract Management Assessmen Given"].ToString();
                            MyWorksheet.Cells[startRow, 36].Value = DS.Tables[0].Rows[i]["Procurement Knowledge Evaluation - Completed"].ToString();
                            MyWorksheet.Cells[startRow, 37].Value = DS.Tables[0].Rows[i]["Behavioural Assessment Completed"].ToString();
                            MyWorksheet.Cells[startRow, 38].Value = DS.Tables[0].Rows[i]["Skills Self Assessment Completed"].ToString();
                            MyWorksheet.Cells[startRow, 39].Value = DS.Tables[0].Rows[i]["Negotiation Profile Assessment Completed"].ToString();
                            MyWorksheet.Cells[startRow, 40].Value = DS.Tables[0].Rows[i]["Maturity Profile Assessment Completed"].ToString();
                            MyWorksheet.Cells[startRow, 41].Value = DS.Tables[0].Rows[i]["Contract Management Assessment Completed"].ToString();
                            MyWorksheet.Cells[startRow, 42].Value = DS.Tables[0].Rows[i]["Procurement Knowledge Evaluation Link"].ToString();
                            MyWorksheet.Cells[startRow, 43].Value = DS.Tables[0].Rows[i]["Behavioural Assessment Link"].ToString();
                            MyWorksheet.Cells[startRow, 44].Value = DS.Tables[0].Rows[i]["Skills Self Assessment Link"].ToString();
                            MyWorksheet.Cells[startRow, 45].Value = DS.Tables[0].Rows[i]["Negotiation Profile Assessment Link"].ToString();
                            MyWorksheet.Cells[startRow, 46].Value = DS.Tables[0].Rows[i]["Maturity Profile Assessment Link"].ToString();
                            MyWorksheet.Cells[startRow, 47].Value = DS.Tables[0].Rows[i]["Contract Management Assessment Link"].ToString();
                            startRow++;
                            i++;
                        }
                    }
                }

                MyExcel.SaveAs(fNewFile);
            }
            this.Download("UsersList.xlsx", fullSGAPath);

            //this.ExportDataSetToExcel(DS, "UsersList.xls");
        }

        public void Download(string fileName, string filePath)
        {
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            //string aaa = Server.MapPath("~/SavedFolder/" + filename);
            Response.TransmitFile(filePath);
            Response.End();
        }

        public void ExportDataSetToExcel(DataSet ds, string filename)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.Charset = "";
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    DataGrid dg = new DataGrid();
                    dg.DataSource = ds.Tables[0];
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString().Replace("`", "'"));
                    response.End();
                }
            }
        }

        protected void grdUsers_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.grdUsers.CurrentPageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void grdUsers_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                System.DateTime dtRegisterdate = System.Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "dtInsertDate"));
                string strLoginDt = DataBinder.Eval(e.Item.DataItem, "lastLoginDt").ToString();
                Label lblLastlogin = (Label)e.Item.FindControl("lblLastlogin");
                Label lblRegisterDate = (Label)e.Item.FindControl("lblRegisterDate");
                Label lblStatus = (Label)e.Item.FindControl("lblStatus");
                Label lblLinkedIn = (Label)e.Item.FindControl("lblLinkedIn");

                if (lblLinkedIn != null)
                {
                    lblLinkedIn.Text = SGACommon.YesNoConversion(DataBinder.Eval(e.Item.DataItem, "isLinkedinAssociated"));
                }

                if (lblLastlogin != null && strLoginDt.Length > 0)
                {
                    lblLastlogin.Text = SGACommon.ToAusTimeZone(System.Convert.ToDateTime(strLoginDt)).ToString("dd MMM yyyy HH:mm tt");
                }
                if (lblRegisterDate != null)
                {
                    lblRegisterDate.Text = SGACommon.ToAusTimeZone(dtRegisterdate).ToString("dd MMM yyyy");
                }
                ImageButton iBtnApprove = (ImageButton)e.Item.FindControl("iBtnApprove");
                ImageButton IbtnResend = (ImageButton)e.Item.FindControl("IbtnResend");
                ImageButton iBtnSelect = (ImageButton)e.Item.FindControl("iBtnSelect");
                if (System.Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "IsApproved")))
                {
                    if (System.Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "expired")))
                    {
                        iBtnApprove.Visible = false;
                        IbtnResend.Visible = false;
                        lblStatus.Text = "Expired";
                    }
                    else
                    {
                        iBtnApprove.CommandName = "disapprove";
                        iBtnApprove.ToolTip = "Disapprove user";
                        iBtnApprove.ImageUrl = this.Page.ResolveUrl("~/webadmin/images/disap.png");
                        lblStatus.Text = "Approved";
                    }
                }
                else
                {
                    e.Item.BackColor = Color.FromArgb(133, 195, 233);
                    iBtnApprove.CommandName = "approve";
                    iBtnApprove.ToolTip = "Approve user";
                    iBtnApprove.ImageUrl = this.Page.ResolveUrl("~/webadmin/images/approve.png");
                    lblStatus.Text = "Not Approved";
                }
                string[] strArr = this.hdSelectIds.Value.Split(new char[]
                {
                    ','
                });
                if (strArr.Length > 0)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (strArr[i].ToString() == DataBinder.Eval(e.Item.DataItem, "Id").ToString())
                        {
                            e.Item.BackColor = Color.FromArgb(252, 136, 113);
                            iBtnSelect.ImageUrl = this.Page.ResolveUrl("~/webadmin/images/unselect-icon.png");
                            iBtnSelect.CommandName = "deselect";
                        }
                    }
                }
            }
        }

        protected void grdUsers_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "delete")
            {
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spDeleteUser", new SqlParameter[]
                {
                    new SqlParameter("@userId", e.CommandArgument)
                });
                this.BindGrid();
            }
            if (e.CommandName.ToLower() == "reminder")
            {
                DataTable dt = this.GetUserDetailByUserId(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    string subject = "";
                    string body = "";
                    SGACommon.GetEmailTemplate(14, ref subject, ref body);
                    body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString());
                    subject = subject.Replace("@v0", dt.Rows[0]["firstName"].ToString());
                    MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");
                    string[] strField = new string[]
                        {
                            "Id"
                        };
                    XmlRpcStruct[] resultFound = isdnAPI.findByEmail(dt.Rows[0]["email"].ToString(), strField);
                    int userId;
                    if (resultFound.Length > 0)
                    {
                        userId = System.Convert.ToInt32(resultFound[0]["Id"].ToString());
                        isdnAPI.addToGroup(userId, 1478);
                    }
                }
            }
            else if (e.CommandName == "select")
            {
                HiddenField expr_1C8 = this.hdSelectIds;
                expr_1C8.Value = expr_1C8.Value + e.CommandArgument + ",";
                this.BindGrid();
                this.dtgList.CurrentPageIndex = 0;
                this.BindPermission();
                this.grdUserTest.CurrentPageIndex = 0;
                this.BindUserTestInfo();
                this.grdCMC.CurrentPageIndex = 0;
                this.BindCMCTest();
              
                this.LoadProfile();
            }
            else if (e.CommandName == "deselect")
            {
                System.Collections.Generic.List<string> Items = (from i in this.hdSelectIds.Value.Split(new char[]
                {
                    ','
                })
                                                                 select i.Trim() into i
                                                                 where i != string.Empty
                                                                 select i).ToList<string>();
                Items.Remove(e.CommandArgument.ToString());
                this.hdSelectIds.Value = string.Join(",", Items.ToArray());
                this.BindGrid();
                this.BindPermission();
                this.BindUserTestInfo();
                this.BindCMCTest();
               
            }
            else if (e.CommandName == "send")
            {
                DataTable dt = this.GetUserDetailByUserId(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    string subject = "";
                    string body = "";
                    SGACommon.GetEmailTemplate(7, ref subject, ref body);
                    body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v1", dt.Rows[0]["lastName"].ToString()).Replace("@v2", dt.Rows[0]["company"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString());
                    MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");
                }
            }
            else if (e.CommandName.ToLower() == "approve")
            {
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spUserStatus", new SqlParameter[]
                {
                    new SqlParameter("@userId", e.CommandArgument)
                });
                DataTable dt = this.GetUserDetailByUserId(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    string subject = "";
                    string body = "";
                    SGACommon.GetEmailTemplate(7, ref subject, ref body);
                    body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v1", dt.Rows[0]["lastName"].ToString()).Replace("@v2", dt.Rows[0]["company"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString()).Replace("@v4", SGACommon.GetJobRole(System.Convert.ToInt32(dt.Rows[0]["jobRole"].ToString())));
                    MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");
                }
                this.BindGrid();
            }
            else if (e.CommandName.ToLower() == "disapprove")
            {
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spUserStatus", new SqlParameter[]
                {
                    new SqlParameter("@userId", e.CommandArgument)
                });
                DataTable dt = this.GetUserDetailByUserId(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    string subject = "";
                    string body = "";
                    SGACommon.GetEmailTemplate(9, ref subject, ref body);
                    body = body.Replace("@v0", dt.Rows[0]["firstName"].ToString()).Replace("@v1", dt.Rows[0]["lastName"].ToString()).Replace("@v2", dt.Rows[0]["company"].ToString()).Replace("@v3", dt.Rows[0]["email"].ToString()).Replace("@v5", dt.Rows[0]["plainpassword"].ToString());
                    MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), dt.Rows[0]["email"].ToString(), subject, body, "");
                }
                this.BindGrid();
            }
        }

        protected void grdUsers_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (e.SortExpression.ToString() == this.SortExpression)
            {
                this.SortOrder = !this.SortOrder;
            }
            else
            {
                this.SortOrder = true;
            }
            this.SortExpression = e.SortExpression;
            int i = 0;
            string strOrder = this.SortOrder ? "ASC" : "DESC";
            foreach (DataGridColumn col in this.grdUsers.Columns)
            {
                if (col.SortExpression == e.SortExpression)
                {
                    this.grdUsers.Columns[i].HeaderStyle.CssClass = "gridHeaderSort" + strOrder;
                }
                else
                {
                    this.grdUsers.Columns[i].HeaderStyle.CssClass = "gridHeader";
                }
                i++;
            }
            this.BindGrid();
        }

        protected void grdCMC_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (e.SortExpression.ToString() == this.SortExpressionCMC)
            {
                this.SortOrderCMC = !this.SortOrderCMC;
            }
            else
            {
                this.SortOrderCMC = true;
            }
            this.SortExpressionCMC = e.SortExpression;
            int i = 0;
            string strOrder = this.SortOrderCMC ? "ASC" : "DESC";
            foreach (DataGridColumn col in this.grdCMC.Columns)
            {
                if (col.SortExpression == e.SortExpression)
                {
                    this.grdCMC.Columns[i].HeaderStyle.CssClass = "gridHeaderSort" + strOrder;
                }
                else
                {
                    this.grdCMC.Columns[i].HeaderStyle.CssClass = "gridHeader";
                }
                i++;
            }
            this.BindCMCTest();
        }

        protected void lnkCMCDownload_Click(object sender, System.EventArgs e)
        {
            base.Response.Redirect(string.Concat(new string[]
            {
                "DownloadReport.aspx?id=1&fname=",
                this.txtCMCFname.Value,
                "&lname=",
                this.txtCMCLname.Value,
                "&company=",
                this.txtCMCCompany.Value,
                "&dfrom=",
                this.txtCMCFrom.Text,
                "&dto=",
                this.txtCMCTo.Text,
                "&userIds=",
                this.hdSelectIds.Value
            }));
        }
    }
}
