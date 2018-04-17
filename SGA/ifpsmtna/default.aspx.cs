using DataTier;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
                base.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
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
        
    }
}