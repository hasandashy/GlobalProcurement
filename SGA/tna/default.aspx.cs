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

namespace SGA.tna
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
                bool isTnaTest = false;
                bool isPmpTest = false;
                bool isDmpTest = false;
                bool isNpTest = false;
                bool isCMAtest = false;
                bool istakeCMASGAtest = false; 
                bool isLeadershiptest = false;
                bool isDNAtest = false;
                bool isCMKtest = false;
                bool isSCKEtest = false;
                bool isSCSAtest = false;

                if (dsPermission != null)
                {
                    if (dsPermission.Tables.Count > 0 && dsPermission.Tables[0].Rows.Count > 0)
                    {
                        isSgaTest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewSgaTest"].ToString());
                        isTnaTest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewTnaTest"].ToString());
                        isPmpTest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewPmpTest"].ToString());
                        isDmpTest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewDmpTest"].ToString());
                        isNpTest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewNpTest"].ToString());
                        isCMAtest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeCMATest"].ToString());
                        istakeCMASGAtest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeCMASGATest"].ToString());
                        isLeadershiptest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeLeadershipTest"].ToString());
                        isDNAtest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeDNA"].ToString());
                        isCMKtest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeCMK"].ToString());
                        isSCKEtest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeSCKE"].ToString());
                        isSCSAtest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeSCSA"].ToString());
                    }
                }
                /*  */
              


             
             

           


                
                
                

               


            }
        }
    }
}