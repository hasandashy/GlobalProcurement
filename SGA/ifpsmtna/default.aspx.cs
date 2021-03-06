﻿using CookComputing.XmlRpc;
using DataTier;
using InfusionSoftDotNet;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.ifpsmtna
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            SGACommon.AddPageTitle(this.Page, "Multiple Assessment Landing page", "");
            if (!base.IsPostBack)
            {
                HttpBrowserCapabilities browser = base.Request.Browser;
                SGACommon.SaveBrowserDetails(SGACommon.LoginUserInfo.userId, browser.Type, base.Request.UserAgent, this.Session.SessionID);
                //base.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                lblName.Text = "Hi " + SGACommon.GetName() + "!";
                DataSet dsPermission = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPremission", new SqlParameter[]
                {
                    new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
                });
                bool isSgaTest = false;


                if (dsPermission != null)
                {
                    if (dsPermission.Tables.Count > 0 && dsPermission.Tables[0].Rows.Count > 0)
                    {
                        isSgaTest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeSga"].ToString());

                    }
                }
                /*  */
                hylSga.CssClass = (isSgaTest ? "btn-go" : "locked");
                hylSga.ToolTip = (isSgaTest ? "Go" : "Locked");
                hylSga.Text = (isSgaTest ? "GO" : "<span>Your access to this assessment is now locked.</span>");
                hylSga.NavigateUrl = (isSgaTest ? "~\\ifpsmtna\\pk-evaluation-instructions.aspx" : "#");

            }











        }

        [WebMethod]
        public static void SendEmail(string PKE, string PTSA, string PBSA, string CMKA, string CMSA, string LSA, string NP, string DMP, string SCKE, string SCSA)
        {
            string assessments = PKE + (PKE != string.Empty ? ", " : "") + PTSA + (PTSA != string.Empty ? ", " : "") + PBSA + (PBSA != string.Empty ? ", " : "") + CMKA + (CMKA != string.Empty ? ", " : "") + CMSA + (CMSA != string.Empty ? ", " : "") + LSA + (LSA != string.Empty ? ", " : "") + NP + (NP != string.Empty ? ", " : "") + DMP + (DMP != string.Empty ? ", " : "") + SCKE + (SCKE != string.Empty ? ", " : "") + SCSA + (SCSA != string.Empty ? ", " : "");
            string subject = "";
            string body = "";

            SqlParameter[] param = new SqlParameter[]
           {
                new SqlParameter("@userId", SqlDbType.Int)
           };
            param[0].Value = SGACommon.LoginUserInfo.userId;
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetByUserId", param);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                   string firstName = ds.Tables[0].Rows[0]["firstname"].ToString();
                    string lastName =  ds.Tables[0].Rows[0]["lastname"].ToString();
                    string email =  ds.Tables[0].Rows[0]["email"].ToString();
                    SGACommon.GetEmailTemplate(15, ref subject, ref body);
                    body = body.Replace("@v0", email).Replace("@v1", assessments).Replace("@v3", email).Replace("@v5", firstName).Replace("@v6", lastName);
                    MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), "sales@comprara.com.au", subject, body, "");


                    string[] strField = new string[]
                            {
                            "Id"
                            };
                    XmlRpcStruct[] resultFound = isdnAPI.findByEmail(email, strField);
                    if (resultFound.Length > 0)
                    {
                        isdnAPI.addToGroup(System.Convert.ToInt32(resultFound[0]["Id"].ToString()), 4077);                        
                    }
                }
            }

        }

    }
}