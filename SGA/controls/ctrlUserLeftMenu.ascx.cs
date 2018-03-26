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

        protected bool isTnaResult = false;

        protected bool isPmpResult = false;

        protected bool isDmpResult = false;

        protected bool isNpResult = false;

        protected bool isCMAResult = false;

        protected bool isCMASGAResult = false;

        protected bool isLeadershipResult = false;

        protected bool isDNAResult = false;

        protected bool isCMKResult = false;

        protected bool isSCKEResult = false;

        protected bool isSCSAResult = false;

        private string _strLinkType = "";

        public string strLinkType {
            get { return _strLinkType; }
            set { _strLinkType = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DataSet dsPermission = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPremission", new SqlParameter[]
                {
                    new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
                });
                if (dsPermission != null)
                {
                    if (dsPermission.Tables.Count > 0 && dsPermission.Tables[0].Rows.Count > 0)
                    {
                        this.isSgaResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewSgaResult"].ToString());
                        this.isTnaResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewTnaResult"].ToString());
                        this.isPmpResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewPMPResult"].ToString());
                        this.isDmpResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewDMPResult"].ToString());
                        this.isNpResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewNPResult"].ToString());
                        this.isCMAResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewCMAResult"].ToString());
                        this.isCMASGAResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewCMASGAResult"].ToString());
                        this.isLeadershipResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewLeadershipResult"].ToString());
                        this.isDNAResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewDna"].ToString());
                        this.isCMKResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewCMK"].ToString());
                        this.isSCKEResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewSCKEResult"].ToString());
                        this.isSCSAResult = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["viewSCSAResult"].ToString());
                    }
                }
                this.spCategory.Attributes["class"] = (this.isSgaResult ? "" : "lock");
                this.spSkills.Attributes["class"] = (this.isTnaResult ? "" : "lock");
                this.spBehaviour.Attributes["class"] = (this.isPmpResult ? "" : "lock");
                this.spMaturity.Attributes["class"] = (this.isDmpResult ? "" : "lock");
                this.spNegotiation.Attributes["class"] = (this.isNpResult ? "" : "lock");
                this.spCMA.Attributes["class"] = (this.isCMAResult ? "" : "lock");
                this.spCMASGA.Attributes["class"] = (this.isCMASGAResult ? "" : "lock");
                this.spLeadership.Attributes["class"] = (this.isLeadershipResult ? "" : "lock");
                this.spDNA.Attributes["class"] = (this.isDNAResult ? "" : "lock");
                this.spCMK.Attributes["class"] = (this.isCMKResult ? "" : "lock");
                this.spSCKE.Attributes["class"] = (this.isSCKEResult ? "" : "lock");
                this.spSCSA.Attributes["class"] = (this.isSCSAResult ? "" : "lock");
                switch (strLinkType) {
                    case "hylPKEGraph":
                        hylPKEGraph.Attributes.Add("class","active"); 
                        break;
                    case "hylPKE":
                        hylPKE.Attributes.Add("class", "active");
                        break;
                    case "hylSSAGraph":
                        hylSSAGraph.Attributes.Add("class", "active");
                        break;
                    case "hylSSA":
                        hylSSA.Attributes.Add("class", "active");
                        break;
                    case "hylBAGraph":
                        hylBAGraph.Attributes.Add("class", "active");
                        break;
                    case "hylBA":
                        hylBA.Attributes.Add("class", "active");
                        break;
                    case "hylCMKGraph":
                        hylCMKGraph.Attributes.Add("class", "active");
                        break;
                    case "hylCMK":
                        hylCMK.Attributes.Add("class", "active");
                        break;
                    case "hylCMASGAGraph":
                        hylCMASGAGraph.Attributes.Add("class", "active");
                        break;
                    case "hylCMASGA":
                        hylCMASGA.Attributes.Add("class", "active");
                        break;
                    case "hylLeadershipGraph":
                        hylLeadershipGraph.Attributes.Add("class", "active");
                        break;
                    case "hylLeadership":
                        hylLeadership.Attributes.Add("class", "active");
                        break;
                    case "hylNPGraph":
                        hylNPGraph.Attributes.Add("class", "active");
                        break;
                    case "hylNP":
                        hylNP.Attributes.Add("class", "active");
                        break;
                    case "hylDMPGraph":
                        hylDMPGraph.Attributes.Add("class", "active");
                        break;
                    case "hylDMP":
                        hylDMP.Attributes.Add("class", "active");
                        break;
                    case "hylCMAGraph":
                        hylCMAGraph.Attributes.Add("class", "active");
                        break;
                    case "hylCMA":
                        hylCMA.Attributes.Add("class", "active");
                        break;
                    case "hylDNAGraph":
                        hylDNAGraph.Attributes.Add("class", "active");
                        break;
                    case "hylDNA":
                        hylDNA.Attributes.Add("class", "active");
                        break;
                    case "hylSCKEGraph":
                        hylSCKEGraph.Attributes.Add("class", "active");
                        break;
                    case "hylSCKE":
                        hylSCKE.Attributes.Add("class", "active");
                        break;
                    case "hylSCSAGraph":
                        hylSCSAGraph.Attributes.Add("class", "active");
                        break;
                    case "hylSCSA":
                        hylSCSA.Attributes.Add("class", "active");
                        break;
                }
            }
        }
    }
}