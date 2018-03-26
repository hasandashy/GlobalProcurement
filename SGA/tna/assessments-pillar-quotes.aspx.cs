using DataTier;
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
    public partial class assessments_pillar_quotes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string v = Request.QueryString["pillerId"];
                if (v != null)
                {
                    BindPillarQuotes(Convert.ToInt32(v));
                }
            }
        }
        public void BindPillarQuotes(int pillarId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spPillarThoughtsMaster", new SqlParameter[]
                {
                    new SqlParameter("@action", "getById"),
                new SqlParameter("@pillarId", pillarId)});
            this.parentRepeater.DataSource = ds;
            this.parentRepeater.DataBind();
            string pillarName = SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spPillarThoughtsMaster", new SqlParameter[]
                {
                    new SqlParameter("@action", "getPillarNameById"),
                new SqlParameter("@pillarId", pillarId)}).ToString();
            heading.InnerHtml = pillarName;
        }
        protected void hyl_Click(object sender, EventArgs e)
        {
            string v = Request.QueryString["pillerId"];
            if (v != null)
            {
                Response.Redirect("procurement-benchmark-assessment-test.aspx?pillerId=" + v);
            }
        }
    }
}