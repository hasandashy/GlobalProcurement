using SGA.controls;
using DataTier;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.webadmin
{
    public partial class PeerReviewRequests : System.Web.UI.Page
    {
        public string SortExpression
        {
            get
            {
                return (this.ViewState["SortExpression"] == null) ? "" : this.ViewState["SortExpression"].ToString();
            }
            set
            {
                this.ViewState["SortExpression"] = value;
            }
        }

        public bool SortOrder
        {
            get
            {
                return this.ViewState["SortOrder"] != null && System.Convert.ToBoolean(this.ViewState["SortOrder"].ToString());
            }
            set
            {
                this.ViewState["SortOrder"] = value;
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string strOrderBy = " company asc ";
            if (this.SortExpression.Length > 0)
            {
                strOrderBy = (this.SortOrder ? (this.SortExpression + " Asc") : (this.SortExpression + " Desc"));
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@orderBy", strOrderBy)
            };
            this.dtgList.DataSource = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPeerRequests", param);
            this.dtgList.DataBind();
        }

        protected void dtgList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                base.Response.Redirect("EditReviewtest.aspx?id=" + e.CommandArgument, false);
            }
            if (e.CommandName == "Delete")
            {
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spDeleteReviewRequest", new SqlParameter[]
                {
                    new SqlParameter("@emailLink",e.CommandArgument)
                });
            }
            BindGrid();
        }

        protected void dtgList_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (e.SortExpression.ToString() == this.SortExpression)
            {
                this.SortOrder = !this.SortOrder;
            }
            else
            {
                this.SortOrder = true;
            }
            this.SortExpression = e.SortExpression;
            int i = 0;
            string strOrder = this.SortOrder ? "ASC" : "DESC";
            foreach (DataGridColumn col in this.dtgList.Columns)
            {
                if (col.SortExpression == e.SortExpression)
                {
                    this.dtgList.Columns[i].HeaderStyle.CssClass = "gridHeaderSort" + strOrder;
                }
                else
                {
                    this.dtgList.Columns[i].HeaderStyle.CssClass = "gridHeader";
                }
                i++;
            }
            this.BindGrid();
        }



    }
}