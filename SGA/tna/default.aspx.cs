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
        protected bool isSgaTest = false;
        protected bool takeSgaTest = false;
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
             
              

                if (dsPermission != null)
                {
                    if (dsPermission.Tables.Count > 0 && dsPermission.Tables[0].Rows.Count > 0)
                    {
                        isSgaTest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewSga"].ToString());
                        takeSgaTest = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["takeSga"].ToString());
                      
                    }
                   
                }
                /*  */


                if (takeSgaTest)
                {
                    assesactive.Visible = true;
                    asseslocked.Visible = false;
                }
                else
                {
                    assesactive.Visible = false;
                    asseslocked.Visible = true;
                }
             
             

           


                
                
                

               


            }
        }
    }
}