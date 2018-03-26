using DataTier;
using FredCK.FCKeditorV2;
using SGA.controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGA.App_Code;

namespace SGA.webadmin
{
    public partial class PlanAndElearningMapping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(0, this.grdSSASuggestions, 1);
                this.BindGrid(0, this.grdCMASuggestions, 2);
                this.BindGrid(0, this.grdCMCSuggestions, 3);

                this.BindPlans(0, this.ddlSSANegPlan, 1);
                this.BindPlans(0, this.ddlSSASRMPlan, 1);
                this.BindPlans(0, this.ddlSSAOAPlan, 1);
                this.BindPlans(0, this.ddlSSASDPlan, 1);
                this.BindPlans(0, this.ddlSSASRPlan, 1);
                this.BindPlans(0, this.ddlSSAMAPlan, 1);
                this.BindPlans(0, this.ddlSSAMEPlan, 1);
                this.BindPlans(0, this.ddlSSACIPlan, 1);


                this.BindPlans(0, this.ddlCMASIPlan, 2);
                this.BindPlans(0, this.ddlCMAMRPlan, 2);
                this.BindPlans(0, this.ddlCMAPGPlan, 2);
                this.BindPlans(0, this.ddlCMABRPlan, 2);
                this.BindPlans(0, this.ddlCMACAPlan, 2);
                this.BindPlans(0, this.ddlCMAMPPlan, 2);
                this.BindPlans(0, this.ddlCMARPPlan, 2);
                this.BindPlans(0, this.ddlCMAACPlan, 2);

                this.BindPlans(0, this.ddlCMCNegPlan, 3);
                this.BindPlans(0, this.ddlCMCSRMPlan, 3);
                this.BindPlans(0, this.ddlCMCOAPlan, 3);
                this.BindPlans(0, this.ddlCMCSDPlan, 3);
                this.BindPlans(0, this.ddlCMCSRPlan, 3);
                this.BindPlans(0, this.ddlCMCMAPlan, 3);
                this.BindPlans(0, this.ddlCMCMEPlan, 3);
                this.BindPlans(0, this.ddlCMCCIPlan, 3);
            }
        }

        private void BindGrid(int flag, DataGrid grd, int testType)
        {
            grd.DataSource = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManagePlansMapping", new SqlParameter[]
            {
                new SqlParameter("@flag", flag),
                new SqlParameter("@tableType", testType)
            });
            grd.DataBind();
        }

        private void BindPlans(int flag, DropDownList ddl, int testType)
        {
            ddl.DataSource = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManagePlans", new SqlParameter[]
            {
                new SqlParameter("@flag", flag),
                new SqlParameter("@planType", testType)
            });
            ddl.DataTextField = "PlanName";
            ddl.DataValueField = "PlanId";
            ddl.DataBind();
        }

        protected void grdSSASuggestions_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.pnlSSAEdit.Visible = true;
                this.pnlSSAList.Visible = false;
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManagePlansMapping", new SqlParameter[]
                {
                    new SqlParameter("@Id", e.CommandArgument),
                    new SqlParameter("@flag", "2")
                });
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblSSAScore.Text = ds.Tables[0].Rows[0]["minPercentage"].ToString() + "% - " + ds.Tables[0].Rows[0]["maxPercentage"].ToString() + "%";
                        SGACommon.SelectListItem(ddlSSANegPlan, ds.Tables[0].Rows[0]["negotiateTopicPlanId"].ToString());

                        SGACommon.SelectListItem(ddlSSASRMPlan, ds.Tables[0].Rows[0]["SrmTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlSSAOAPlan, ds.Tables[0].Rows[0]["opportunityAnalysisTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlSSASDPlan, ds.Tables[0].Rows[0]["sdTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlSSASRPlan, ds.Tables[0].Rows[0]["rsTopicPlanId"].ToString());

                        SGACommon.SelectListItem(ddlSSAMAPlan, ds.Tables[0].Rows[0]["maTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlSSAMEPlan, ds.Tables[0].Rows[0]["meTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlSSACIPlan, ds.Tables[0].Rows[0]["ciTopicPlanId"].ToString());
                        this.imgSSAEdit.CommandArgument = ds.Tables[0].Rows[0]["Id"].ToString();
                    }
                }
            }
        }

        protected void imgSSAEdit_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlSSAEdit.Visible = false;
            this.pnlSSAList.Visible = true;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spManagePlansMapping", new SqlParameter[]
            {
                new SqlParameter("@Id", this.imgSSAEdit.CommandArgument),
                new SqlParameter("@flag", "1"),
                new SqlParameter("@maTopicPlanId", Convert.ToInt32(ddlSSAMAPlan.SelectedValue)),
                new SqlParameter("@ciTopicPlanId", Convert.ToInt32(ddlSSACIPlan.SelectedValue)),
                new SqlParameter("@meTopicPlanId", Convert.ToInt32(ddlSSAMEPlan.SelectedValue)),
                new SqlParameter("@negotiateTopicPlanId", Convert.ToInt32(ddlSSANegPlan.SelectedValue)),
                new SqlParameter("@SrmTopicPlanId", Convert.ToInt32(ddlSSASRMPlan.SelectedValue)),
                new SqlParameter("@opportunityAnalysisTopicPlanId", Convert.ToInt32(ddlSSAOAPlan.SelectedValue)),
                new SqlParameter("@sdTopicPlanId", Convert.ToInt32(ddlSSASDPlan.SelectedValue)),
                new SqlParameter("@rsTopicPlanId", Convert.ToInt32(ddlSSASRPlan.SelectedValue))
            });
            this.BindGrid(0, this.grdSSASuggestions, 1);
        }

        protected void imgSSACancel_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlSSAEdit.Visible = false;
            this.pnlSSAList.Visible = true;
        }

        protected void grdCMCSuggestions_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.pnlCMCEdit.Visible = true;
                this.pnlCMCList.Visible = false;
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManagePlansMapping", new SqlParameter[]
                {
                    new SqlParameter("@Id", e.CommandArgument),
                    new SqlParameter("@flag", "2")
                });
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblCMCScore.Text = ds.Tables[0].Rows[0]["minPercentage"].ToString() + "% - " + ds.Tables[0].Rows[0]["maxPercentage"].ToString() + "%";
                        SGACommon.SelectListItem(ddlCMCNegPlan, ds.Tables[0].Rows[0]["negotiateTopicPlanId"].ToString());

                        SGACommon.SelectListItem(ddlCMCSRMPlan, ds.Tables[0].Rows[0]["SrmTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMCOAPlan, ds.Tables[0].Rows[0]["opportunityAnalysisTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMCSDPlan, ds.Tables[0].Rows[0]["sdTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMCSRPlan, ds.Tables[0].Rows[0]["rsTopicPlanId"].ToString());

                        SGACommon.SelectListItem(ddlCMCMAPlan, ds.Tables[0].Rows[0]["maTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMCMEPlan, ds.Tables[0].Rows[0]["meTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMCCIPlan, ds.Tables[0].Rows[0]["ciTopicPlanId"].ToString());
                        this.imgCMCEdit.CommandArgument = ds.Tables[0].Rows[0]["Id"].ToString();
                    }
                }
            }
        }

        protected void imgCMCEdit_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlCMCEdit.Visible = false;
            this.pnlCMCList.Visible = true;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spManagePlansMapping", new SqlParameter[]
            {
                new SqlParameter("@Id", this.imgCMCEdit.CommandArgument),
                new SqlParameter("@flag", "1"),
                new SqlParameter("@maTopicPlanId", Convert.ToInt32(ddlCMCMAPlan.SelectedValue)),
                new SqlParameter("@ciTopicPlanId", Convert.ToInt32(ddlCMCCIPlan.SelectedValue)),
                new SqlParameter("@meTopicPlanId", Convert.ToInt32(ddlCMCMEPlan.SelectedValue)),
                new SqlParameter("@negotiateTopicPlanId", Convert.ToInt32(ddlCMCNegPlan.SelectedValue)),
                new SqlParameter("@SrmTopicPlanId", Convert.ToInt32(ddlCMCSRMPlan.SelectedValue)),
                new SqlParameter("@opportunityAnalysisTopicPlanId", Convert.ToInt32(ddlCMCOAPlan.SelectedValue)),
                new SqlParameter("@sdTopicPlanId", Convert.ToInt32(ddlCMCSDPlan.SelectedValue)),
                new SqlParameter("@rsTopicPlanId", Convert.ToInt32(ddlCMCSRPlan.SelectedValue))
            });
            this.BindGrid(0, this.grdCMCSuggestions, 3);
        }

        protected void imgCMCCancel_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlCMCEdit.Visible = false;
            this.pnlCMCList.Visible = true;
        }

        protected void grdCMASuggestions_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.pnlCMAEdit.Visible = true;
                this.pnlCMAList.Visible = false;
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManagePlansMapping", new SqlParameter[]
                {
                    new SqlParameter("@Id", e.CommandArgument),
                    new SqlParameter("@flag", "2")
                });
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblCMAScore.Text = ds.Tables[0].Rows[0]["minPercentage"].ToString() + "% - " + ds.Tables[0].Rows[0]["maxPercentage"].ToString() + "%";
                        SGACommon.SelectListItem(ddlCMASIPlan, ds.Tables[0].Rows[0]["negotiateTopicPlanId"].ToString());

                        SGACommon.SelectListItem(ddlCMAMRPlan, ds.Tables[0].Rows[0]["SrmTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMAPGPlan, ds.Tables[0].Rows[0]["opportunityAnalysisTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMABRPlan, ds.Tables[0].Rows[0]["sdTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMACAPlan, ds.Tables[0].Rows[0]["rsTopicPlanId"].ToString());

                        SGACommon.SelectListItem(ddlCMAMPPlan, ds.Tables[0].Rows[0]["maTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMARPPlan, ds.Tables[0].Rows[0]["meTopicPlanId"].ToString());
                        SGACommon.SelectListItem(ddlCMAACPlan, ds.Tables[0].Rows[0]["ciTopicPlanId"].ToString());
                        this.imgCMAEdit.CommandArgument = ds.Tables[0].Rows[0]["Id"].ToString();
                    }
                }
            }
        }

        protected void imgCMAEdit_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlCMAEdit.Visible = false;
            this.pnlCMAList.Visible = true;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spManagePlansMapping", new SqlParameter[]
            {
                new SqlParameter("@Id", this.imgCMAEdit.CommandArgument),
                new SqlParameter("@flag", "1"),
                new SqlParameter("@maTopicPlanId", Convert.ToInt32(ddlCMAMPPlan.SelectedValue)),
                new SqlParameter("@ciTopicPlanId", Convert.ToInt32(ddlCMAACPlan.SelectedValue)),
                new SqlParameter("@meTopicPlanId", Convert.ToInt32(ddlCMARPPlan.SelectedValue)),
                new SqlParameter("@negotiateTopicPlanId", Convert.ToInt32(ddlCMASIPlan.SelectedValue)),
                new SqlParameter("@SrmTopicPlanId", Convert.ToInt32(ddlCMAMRPlan.SelectedValue)),
                new SqlParameter("@opportunityAnalysisTopicPlanId", Convert.ToInt32(ddlCMAPGPlan.SelectedValue)),
                new SqlParameter("@sdTopicPlanId", Convert.ToInt32(ddlCMABRPlan.SelectedValue)),
                new SqlParameter("@rsTopicPlanId", Convert.ToInt32(ddlCMACAPlan.SelectedValue))
            });
            this.BindGrid(0, this.grdCMASuggestions, 2);
        }

        protected void imgCMACancel_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlCMAEdit.Visible = false;
            this.pnlCMAList.Visible = true;
        }
    }
}