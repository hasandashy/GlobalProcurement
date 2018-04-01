using DataTier;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class ProfileDetails : System.Web.UI.Page
    {
        public static int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (id != 0)
            {
                multiView.ActiveViewIndex = Convert.ToInt32(id) - 1;
            }
            else
            {
                Response.Redirect("MyProfile.aspx");
            }

        }

        [WebMethod]
        public static void SaveProfileData(int val)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@userId", SGACommon.LoginUserInfo.userId);
            param[1] = new SqlParameter("@valtype", id);
            param[2] = new SqlParameter("@val", val);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spSaveUserInfoData", param);
        }
    }
}