﻿using DataTier;
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
    public partial class my_results_bar_graph_gap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionId = string.Empty;


            if (!base.IsPostBack)
            {
                base.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                sessionId = SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetTestIdByUserId", new SqlParameter[]
               {
                    new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)}).ToString();

                if (!String.IsNullOrEmpty(sessionId))
                {
                    this.graph1.testId = System.Convert.ToInt32(sessionId);
                }
                else
                {
                    Response.Redirect("default.aspx");
                }

            }

        }
    }
}