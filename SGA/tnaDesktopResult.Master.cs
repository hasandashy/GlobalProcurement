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

namespace SGA
{
    public partial class tnaDesktopResult : System.Web.UI.MasterPage
    {
        protected string _email = "";
        protected string _company = "";
        protected string _jobRole = "";
        protected string _jobTitle = "";
        protected string _phone = "";
        protected string _state = "";
        protected string _fullName = "";
        protected string _intercomUserHash = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (!IsPostBack)
            {
                _intercomUserHash = SGACommon.CreateToken(SGACommon.LoginUserInfo.name, "Oecyqng3kirkc0RLSl5R7qh1vLjnreCMMICouvrd");
                _email = SGACommon.LoginUserInfo.name;

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@userId", SqlDbType.Int)
                };
                param[0].Value = SGACommon.LoginUserInfo.userId;
                System.Data.DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetProfileDetails", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        _company = ((ds.Tables[0].Rows[0]["company"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["company"].ToString() : "");
                        _phone = ((ds.Tables[0].Rows[0]["Phone"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["Phone"].ToString() : "");
                        _state = ((ds.Tables[0].Rows[0]["State"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["State"].ToString() : "");
                        _jobTitle = ((ds.Tables[0].Rows[0]["jobtitle"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["jobtitle"].ToString() : "");
                        _jobRole = Profile.GetJobRole(Convert.ToInt32(ds.Tables[0].Rows[0]["jobRole"].ToString()));
                        _fullName = ds.Tables[0].Rows[0]["firstname"].ToString() + " " + ds.Tables[0].Rows[0]["lastname"].ToString();


                    }
                }
            }

        }
    }
}