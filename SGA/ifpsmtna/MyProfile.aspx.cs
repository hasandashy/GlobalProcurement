using CookComputing.XmlRpc;
using DataTier;
using InfusionSoftDotNet;
using SGA.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.ifpsmtna
{
    public partial class MyProfile : Page
    {
        protected string _deirectsend = "0";

        protected void Page_Load(object sender, System.EventArgs e)
        {
           
            SGACommon.AddPageTitle(this.Page, "The individuals profile page", "");
            if(Request.QueryString["_directsend"] != null)
            {
                _deirectsend = Request.QueryString["_directsend"].ToString();
            }
          
            if (!base.IsPostBack)
            {
                MasterPage mp = this.Page.Master;
                if (mp != null)
                {
                    UserControl uc = (UserControl)mp.FindControl("header1");
                    if (uc != null)
                    {
                        Panel pnlTopMenu = (Panel)uc.FindControl("pnlTopMenu");
                        if (pnlTopMenu != null)
                        {
                            pnlTopMenu.Visible = false;
                        }
                    }
                }
                this.lblName.Text = "Hi " + SGACommon.GetName() + "!";
                this.LoadProfile();
            }
        }

        private void LoadProfile()
        {
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@userId", SqlDbType.Int)
			};
            param[0].Value = SGACommon.LoginUserInfo.userId;
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetProfileDetails", param);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.fname.Value = ds.Tables[0].Rows[0]["firstname"].ToString();
                    this.lname.Value = ds.Tables[0].Rows[0]["lastname"].ToString();
                    this.email.Value = ds.Tables[0].Rows[0]["email"].ToString();
                    SGACommon.SelectListItem(this.ddlEditCatExp, ds.Tables[0].Rows[0]["prevCatExp"].ToString());
                    SGACommon.SelectListItem(this.ddEditSector, ds.Tables[0].Rows[0]["sector"].ToString());
                    SGACommon.SelectListItem(this.ddlEditModel, ds.Tables[0].Rows[0]["pmodel"].ToString());
                    SGACommon.SelectListItem(this.ddlEditEmployeeCompany, ds.Tables[0].Rows[0]["noemployee"].ToString());
                    SGACommon.SelectListItem(this.ddlEditSpentUnder, ds.Tables[0].Rows[0]["spentunder"].ToString());
                    SGACommon.SelectListItem(this.ddlEditProcurementYear, ds.Tables[0].Rows[0]["experience"].ToString());
                    SGACommon.SelectListItem(this.cboEditQualifications, ds.Tables[0].Rows[0]["education"].ToString());
                    SGACommon.SelectListItem(this.ddlEditExpertise, ds.Tables[0].Rows[0]["categoryId"].ToString());
                    SGACommon.SelectListItem(this.ddlEditReportingLine, ds.Tables[0].Rows[0]["reportline"].ToString());
                    SGACommon.SelectListItem(this.ddlEditSpendUnder, ds.Tables[0].Rows[0]["spendUnder"].ToString());
                    SGACommon.SelectListItem(this.ddlJobRole, ds.Tables[0].Rows[0]["jobRole"].ToString());
                    SGACommon.SelectListItem(this.ddlEditProLevel, ds.Tables[0].Rows[0]["proLevel"].ToString());
                    SGACommon.SelectListItem(this.ddlEditGeographical, ds.Tables[0].Rows[0]["geoInfluence"].ToString());

                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "statusup", "setPassword('" + ds.Tables[0].Rows[0]["plainpassword"].ToString() + "');", true);
                }
            }
        }

        [WebMethod]
        public static void UpdateProfile(string fname, string lname, string password, int jobRole, int pmodel, int reportingLine, int spendUnder, int noemployee, int sector, int category, int spentUnder, int geoInfluence, int experience, int proLevel, int education, int catExp, string email)
        {
            string passwordSalt = SGACommon.CreateSalt(5);
            string passwordHash = SGACommon.CreatePasswordHash(password, passwordSalt);
           
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@fname", SqlDbType.VarChar);
            param[1].Value = fname;
            param[2] = new SqlParameter("@lname", SqlDbType.VarChar);
            param[2].Value = lname;
            param[3] = new SqlParameter("@passwordSalt", SqlDbType.VarChar);
            param[3].Value = passwordSalt;
            param[4] = new SqlParameter("@passwordHash", SqlDbType.VarChar);
            param[4].Value = passwordHash;
            param[5] = new SqlParameter("@plainpassword", SqlDbType.VarChar);
            param[5].Value = password;
            param[6] = new SqlParameter("@jobRole", SqlDbType.Int);
            param[6].Value = jobRole;
            param[7] = new SqlParameter("@pmodel", SqlDbType.Int);
            param[7].Value = pmodel;
            param[8] = new SqlParameter("@reportline", SqlDbType.Int);
            param[8].Value = reportingLine;
            param[9] = new SqlParameter("@spendunder", SqlDbType.Int);
            param[9].Value = spendUnder;
            param[10] = new SqlParameter("@noemployee", SqlDbType.Int);
            param[10].Value = noemployee;
            param[11] = new SqlParameter("@sector", SqlDbType.Int);
            param[11].Value = sector;
            param[12] = new SqlParameter("@categoryId", SqlDbType.Int);
            param[12].Value = category;
            param[13] = new SqlParameter("@spentUnder", SqlDbType.Int);
            param[13].Value = spentUnder;
            param[14] = new SqlParameter("@geoInfluence", SqlDbType.Int);
            param[14].Value = geoInfluence;
            param[15] = new SqlParameter("@experience", SqlDbType.Int);
            param[15].Value = experience;
            param[16] = new SqlParameter("@proLevel", SqlDbType.Int);
            param[16].Value = proLevel;
            param[17] = new SqlParameter("@education", SqlDbType.Int);
            param[17].Value = education;
            param[18] = new SqlParameter("@catExp", SqlDbType.Int);
            param[18].Value = catExp;
            param[19] = new SqlParameter("@userId", SqlDbType.Int);
            param[19].Value = SGACommon.LoginUserInfo.userId;           
           
            int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUpdateProfile", param));


            string[] strField = new string[]
                                        {
                                            "Id"
                                        };
            XmlRpcStruct[] resultFound = isdnAPI.findByEmail(email.Trim(), strField);
            int userId;
            XmlRpcStruct Contact = new XmlRpcStruct();
            if (resultFound.Length > 0)
            {
                userId = System.Convert.ToInt32(resultFound[0]["Id"].ToString());
                Contact.Add("FirstName", fname);
                Contact.Add("LastName", lname);
                Contact.Add("Email", email.Trim());
                Contact.Add("_Jobrolebestdescribedas", SGACommon.GetJobRole(System.Convert.ToInt32(jobRole)));

                Contact.Add("ContactType", "Customer");
                isdnAPI.dsUpdate("Contact", userId, Contact);
            }
        }
    }
}
