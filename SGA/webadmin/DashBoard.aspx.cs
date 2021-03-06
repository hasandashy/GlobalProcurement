﻿using DataTier;
using SGA.App_Code;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.webadmin
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spDashBoardCount");
                HttpBrowserCapabilities browser = base.Request.Browser;
                SGACommon.SaveBrowserDetails(SGACommon.LoginUserInfo.userId, browser.Type, base.Request.UserAgent, this.Session.SessionID);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        this.lblRegistered.Text = ds.Tables[0].Rows[0]["totaluser"].ToString();
                        this.lblUnApproved.Text = ds.Tables[0].Rows[0]["totalUnApproved"].ToString();
                        this.lblDeactive.Text = ds.Tables[0].Rows[0]["totalExpired"].ToString();
                        //this.lblCompany.Text = ds.Tables[0].Rows[0]["totalCompany"].ToString();
                        this.lblCMC.Text = ds.Tables[0].Rows[0]["totalcmc"].ToString();
                       // this.lblSSA.Text = ds.Tables[0].Rows[0]["totalssa"].ToString();
                        //this.lblBA.Text = ds.Tables[0].Rows[0]["totalba"].ToString();
                        this.lblContact.Text = ds.Tables[0].Rows[0]["totalContact"].ToString();
                        this.lblEmailTemplate.Text = ds.Tables[0].Rows[0]["totalemail"].ToString();
                        this.lblFromFront.Text = ds.Tables[0].Rows[0]["frontusers"].ToString();
                        this.lblTotalUserByAdmin.Text = ds.Tables[0].Rows[0]["adminusers"].ToString();
                        this.lblLoggedin.Text = ds.Tables[0].Rows[0]["totalLoggedIn"].ToString();
                        this.lblNotLoggenin.Text = ds.Tables[0].Rows[0]["totalNotLoggedIn"].ToString();
                        //this.lblMP.Text = ds.Tables[0].Rows[0]["totalmp"].ToString();
                        //this.lblNP.Text = ds.Tables[0].Rows[0]["totalnp"].ToString();
                        //this.lblCMA.Text = ds.Tables[0].Rows[0]["totalcma"].ToString();
                        //this.lblCMASGA.Text = ds.Tables[0].Rows[0]["totalcmasga"].ToString();
                        //this.lblLeadership.Text = ds.Tables[0].Rows[0]["totalleadership"].ToString();
                        //this.lblSCKE.Text = ds.Tables[0].Rows[0]["totalSCKE"].ToString();
                        //this.lblSCSA.Text = ds.Tables[0].Rows[0]["totalSCSA"].ToString();
                        //this.lblCMKE.Text = ds.Tables[0].Rows[0]["totalCMKE"].ToString();

                    }
                }
            }
        }
    }
}