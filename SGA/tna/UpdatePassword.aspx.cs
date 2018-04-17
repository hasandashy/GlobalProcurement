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

namespace SGA.tna
{
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadProfile();
        }

        private void LoadProfile()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@userId", SqlDbType.Int)
            };
            param[0].Value = SGACommon.LoginUserInfo.userId;
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetProfileDetails", param);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (System.Convert.ToBoolean(ds.Tables[0].Rows[0]["passwordUpdated"].ToString()))
                    {
                        base.Response.Redirect("~/tna/mainmenu.aspx", false);
                    }
                }
            }
        }

    }
}