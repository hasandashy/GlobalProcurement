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
    public partial class ResultDenied : System.Web.UI.Page
    {
        protected bool isSgaResult = false;

        protected bool isTnaResult = false;

        protected bool isPmpResult = false;

        protected bool isDmpResult = false;

        protected bool isNpResult = false;

        protected bool isCMAResult = false;

        protected bool isCMASGAResult = false;

        protected bool isLeadershipResult = false;

        protected bool isDNAResult = false;

        protected bool isCMKResult = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                
            }

        }
    }
}