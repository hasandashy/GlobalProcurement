using DataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.webadmin
{
    public partial class ManageAssessmentPillars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.BindPillars();
            }
        }
        private void BindPillars()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spPillarThoughtsMaster", new SqlParameter[]
            {
                new SqlParameter("@action", "getAll")
            });
            this.rptPillars.DataSource = ds;
            this.rptPillars.DataBind();
        }



    }
}