using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SGA.webadmin
{
    public partial class ManageSubdomains : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                lblSubdomainUrl.Text = ConfigurationManager.AppSettings["domain"].ToString() + "/";
                BindGrid();
            }
        }

        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        {
            if (this.fleCatalogImage.HasFile)
            {
                this.hdimageUrl.Value = "";
                string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + System.IO.Path.GetFileName(this.fleCatalogImage.FileName);
                this.fleCatalogImage.SaveAs(base.Server.MapPath("~/subdomainlogo/") + filename);
                this.hdimageUrl.Value = "/subdomainlogo/" + filename;
            }

            int result = DataTier.SqlHelper.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "spManageRegisterTemplate", new SqlParameter[] {
                    new SqlParameter("@logoName",this.hdimageUrl.Value),
                    new SqlParameter("@paragraphText",txtParagraph.Text.Trim()),
                    new SqlParameter("@urlSuffix",txtSubdomainUrl.Text.Trim().Replace("?","").Replace(" ","_")),
                    new SqlParameter("@hexCode",txtHexcode.Value.Trim()),
                    new SqlParameter("@ISCode",txtISCode.Text.Trim()),
                    new SqlParameter("@flag",imgSave.CommandName == "update"?"1":"0"),
                    new SqlParameter("@id",imgSave.CommandArgument)
                });
            lblError.Text = result == 0 ? "The url already exists! Please change that and try again." : "The details are saved.";
            

            
            this.hdimageUrl.Value = "";
            txtSubdomainUrl.Text = "";
            txtParagraph.Text = "";
            txtHexcode.Value = "";
            imgProduct.Visible = false;
            imgProduct.ImageUrl = "";
            txtISCode.Text = "";
            imgSave.CommandArgument = "0"; 
            BindGrid();
            selected_tab.Value = "0";
        }

        private void BindGrid()
        {
            DataSet ds = DataTier.SqlHelper.ExecuteDataset(System.Data.CommandType.StoredProcedure, "spManageRegisterTemplate",new System.Data.SqlClient.SqlParameter []{
                new SqlParameter("@flag","4")
            });
            this.grdUsers.DataSource = ds;
            this.grdUsers.DataBind();
        }

        protected void grdUsers_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.grdUsers.CurrentPageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void grdUsers_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
               System.Web.UI.HtmlControls.HtmlImage imgLogo = (System.Web.UI.HtmlControls.HtmlImage)e.Item.FindControl("imgLogo");
               
                if (imgLogo != null) {
                    imgLogo.Src = Page.ResolveUrl("~"+DataBinder.Eval(e.Item.DataItem, "logoName"));
                }
                Label lblSubdomainUrl = (Label)e.Item.FindControl("lblSubdomainUrl");
                if (lblSubdomainUrl != null) {
                    lblSubdomainUrl.Text = ConfigurationManager.AppSettings["domain"].ToString() + "/";
                }
                
            }
        }

        protected void grdUsers_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                DataTier.SqlHelper.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "spManageRegisterTemplate", new System.Data.SqlClient.SqlParameter[]{
                    new SqlParameter("@Id",e.CommandArgument.ToString()),
                    new SqlParameter("@flag","5")
                });
                this.grdUsers.CurrentPageIndex = 0;
                this.BindGrid();
            }
            else if (e.CommandName == "edit") {
                DataSet ds =DataTier.SqlHelper.ExecuteDataset(System.Data.CommandType.StoredProcedure, "spManageRegisterTemplate", new System.Data.SqlClient.SqlParameter[]{
                    new SqlParameter("@Id",e.CommandArgument.ToString()),
                    new SqlParameter("@flag","2")
                });
                if (ds != null) {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                        lblError.Text = "";
                        this.hdimageUrl.Value = ds.Tables[0].Rows[0]["logoName"].ToString();
                        txtParagraph.Text = ds.Tables[0].Rows[0]["paragraphText"].ToString();
                        txtHexcode.Value = ds.Tables[0].Rows[0]["hexCode"].ToString();
                        txtSubdomainUrl.Text = ds.Tables[0].Rows[0]["urlSuffix"].ToString();
                        txtISCode.Text = ds.Tables[0].Rows[0]["ISCode"].ToString();
                        imgSave.CommandName = "update";
                        imgSave.CommandArgument = e.CommandArgument.ToString();
                        imgProduct.Visible = true;
                        imgProduct.ImageUrl = Page.ResolveUrl("~" + ds.Tables[0].Rows[0]["logoName"].ToString());
                        rfvLogo.Enabled = false;
                        selected_tab.Value = "1";
                    }
                }
            }
        }
    }
}