using DataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA.webadmin
{
    
    public partial class EditPillars : System.Web.UI.Page
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (base.Request.QueryString["id"] != null)
            {
                this.id = System.Convert.ToInt32(base.Request.QueryString["id"].ToString());
            }
            if (this.id <= 0)
            {
                base.Response.Redirect("ManageAssessmentPillars.aspx", false);
            }
            if (!base.IsPostBack)
            {
                this.GetTemplateData();
            }

        }

        private void GetTemplateData()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spPillarThoughtsMaster", new SqlParameter[]
            {
                new SqlParameter("@action", "getById"),
                new SqlParameter("@pillarId", this.id)
            });
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.txtTitle.Text = ds.Tables[0].Rows[0]["pillarQuotes"].ToString();
                    this.imgQuotes.ImageUrl = "~/Images/pillarThoughts/" + ds.Tables[0].Rows[0]["imagePath"].ToString();
                    this.imgExg.Value = ds.Tables[0].Rows[0]["imagePath"].ToString();
                }
                else
                {
                    base.Response.Redirect("ManageAssessmentPillars.aspx", false);
                }
            }
            else
            {
                base.Response.Redirect("ManageAssessmentPillars.aspx", false);
            }
        }

        protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Page.IsValid)
            {
                string fileName = imgExg.Value;
                if (txtImage.HasFile)
                {
                    fileName = Guid.NewGuid() + ".jpg"; 
                    txtImage.PostedFile.SaveAs(Server.MapPath("~/Images/pillarThoughts/") + fileName);
                }
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spPillarThoughtsMaster", new SqlParameter[]
                {
                    new SqlParameter("@action", "update"),
                    new SqlParameter("@pillarId", this.id),
                    new SqlParameter("@pillarQuotes", this.txtTitle.Text.Trim()),
                    new SqlParameter("@imagePath", fileName)
                });
                base.Response.Redirect("ManageAssessmentPillars.aspx", false);
            }
        }
    }
}