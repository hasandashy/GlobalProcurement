using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataTier;
using SGA.App_Code;

namespace SGA.controls
{
    public partial class ctrlUserLeftMenu : System.Web.UI.UserControl
    {
        protected bool isSgaResult = false;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dsPermission = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPremission", new SqlParameter[]
                {
                    new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
                });
                if (dsPermission != null)
                {
                    if (dsPermission.Tables.Count > 0 && dsPermission.Tables[0].Rows.Count > 0)
                    {
                        this.isSgaResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewSga"].ToString());

                    }
                }
                this.spCategory.Attributes["class"] = (this.isSgaResult ? "" : "lock");


            }
        }
    }
}