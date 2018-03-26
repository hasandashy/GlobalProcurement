using DataTier;
using SGA.App_Code;
using SGA.controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class my_results_bar_graph : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, System.EventArgs e)
        {
            //SGACommon.IsViewResult("viewSGAResult");
            Session["sgaTestId"] = "76";

            if (!base.IsPostBack)
            {
                base.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                if (this.Session["sgaTestId"] != null)
                {
                    //this.graph1.testId = System.Convert.ToInt32(this.Session["sgaTestId"].ToString());
                }
               
            }
        }

       
    }
}