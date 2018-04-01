using DataTier;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookComputing.XmlRpc;
using InfusionSoftDotNet;

namespace SGA.tna
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected string _direct = "";

        protected string _indirect = "";

        protected void Page_Load(object sender, System.EventArgs e)
        {
            SGACommon.AddPageTitle(this.Page, "The individuals profile page", "");
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
                //this.lblName.Text = "Hi " + SGACommon.GetName() + "!";
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
                    procModel.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["pmodel"].ToString()) ? "Procurement model" : Profile.GetProcurementModel(Convert.ToInt32( ds.Tables[0].Rows[0]["pmodel"]));
                    reportingLine.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["reportline"].ToString()) ? "Reporting line" : Profile.GetReportLineTo(Convert.ToInt32(ds.Tables[0].Rows[0]["reportline"]));
                    spenUnderInfluence.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["spendunder"].ToString()) ? "Spend under influence" : Profile.GetSpendUnderInfluence(Convert.ToInt32(ds.Tables[0].Rows[0]["spendunder"]));
                    sector.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["sector"].ToString()) ? "Sector" : Profile.GetSector(Convert.ToInt32(ds.Tables[0].Rows[0]["sector"]));
                    numberOfEmp.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["noemployee"].ToString()) ? "Number of employees" : Profile.GetNoOfEmployee(Convert.ToInt32(ds.Tables[0].Rows[0]["noemployee"]));

                    jobRole.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["jobRole"].ToString()) ? "Role best described as:" : Profile.GetJobRole(Convert.ToInt32(ds.Tables[0].Rows[0]["jobRole"]));
                    category.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["categoryId"].ToString()) ? "Category you manage currently:" : Profile.GetCategory(Convert.ToInt32(ds.Tables[0].Rows[0]["categoryId"]));
                    spendUnderYour.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["spentUnder"].ToString()) ? "Spend under your influence" : Profile.GetSpentUnderYourInfluence(Convert.ToInt32(ds.Tables[0].Rows[0]["spentUnder"]));
                    geoInfluence.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["geoInfluence"].ToString()) ? "Geographical influence" : Profile.GetGeoInfluence(Convert.ToInt32(ds.Tables[0].Rows[0]["geoInfluence"]));
                    exp.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["experience"].ToString()) ? "Years of procurement experience" : Profile.GetExp(Convert.ToInt32(ds.Tables[0].Rows[0]["experience"]));
                    edu.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["education"].ToString()) ? "Level of Education" : Profile.GetEducation(Convert.ToInt32(ds.Tables[0].Rows[0]["education"]));
                    procQual.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["proLevel"].ToString()) ? "Procurement qualifications" : Profile.GetProcurementLevel(Convert.ToInt32(ds.Tables[0].Rows[0]["proLevel"]));
                    prevExp.InnerHtml = String.IsNullOrEmpty(ds.Tables[0].Rows[0]["prevCatExp"].ToString()) ? "Your previous category experience" : Profile.GetPrevCatExp(Convert.ToInt32(ds.Tables[0].Rows[0]["prevCatExp"]));

                    //SGACommon.SelectListItem(this.ddlIndustry, ds.Tables[0].Rows[0]["industry"].ToString());
                    //SGACommon.SelectListItem(this.ddlAnnualRevenue, ds.Tables[0].Rows[0]["arevenue"].ToString());
                    //SGACommon.SelectListItem(this.ddlModel, ds.Tables[0].Rows[0]["pmodel"].ToString());
                    //SGACommon.SelectListItem(this.ddlEmployeeCompany, ds.Tables[0].Rows[0]["noemployee"].ToString());
                    //SGACommon.SelectListItem(this.ddlCompanyRevenue, ds.Tables[0].Rows[0]["spendunder"].ToString());
                    //SGACommon.SelectListItem(this.ddlProcurementYear, ds.Tables[0].Rows[0]["experience"].ToString());
                    //SGACommon.SelectListItem(this.cboQualifications, ds.Tables[0].Rows[0]["education"].ToString());
                    //SGACommon.SelectListItem(this.ddlExpertise, ds.Tables[0].Rows[0]["categoryId"].ToString());
                    //SGACommon.SelectListItem(this.ddlReportingLine, ds.Tables[0].Rows[0]["reportline"].ToString());
                    //SGACommon.SelectListItem(this.ddlSpendUnder, ds.Tables[0].Rows[0]["spentUnder"].ToString());
                    //SGACommon.SelectListItem(this.ddlJobRole, ds.Tables[0].Rows[0]["jobRole"].ToString());
                    //SGACommon.SelectListItem(this.ddlProLevel, ds.Tables[0].Rows[0]["proLevel"].ToString());
                    //SGACommon.SelectListItem(this.ddlGeographical, ds.Tables[0].Rows[0]["geoInfluence"].ToString());
                    //SGACommon.SelectListItem(this.ddlCountry, ds.Tables[0].Rows[0]["country"].ToString());
                    //this.fname.Value = ds.Tables[0].Rows[0]["firstname"].ToString();
                    //this.lname.Value = ds.Tables[0].Rows[0]["lastname"].ToString();
                    //this.company.Value = ((ds.Tables[0].Rows[0]["company"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["company"].ToString() : "Company");
                    //this.password.Value = ds.Tables[0].Rows[0]["plainpassword"].ToString();
                    //this.phone.Value = ((ds.Tables[0].Rows[0]["Phone"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["Phone"].ToString() : "Phone No");
                    //this.state.Value = ((ds.Tables[0].Rows[0]["State"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["State"].ToString() : "In which state do you work?");
                    //this.postcode.Value = ((ds.Tables[0].Rows[0]["postcode"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["postcode"].ToString() : "PostCode");
                    //this.jobtitle.Value = ((ds.Tables[0].Rows[0]["jobtitle"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["jobtitle"].ToString() : "JobTitle");
                    //this.email.Value = ds.Tables[0].Rows[0]["email"].ToString();
                    //this._direct = ds.Tables[0].Rows[0]["directgenneral"].ToString();
                    //this._indirect = ds.Tables[0].Rows[0]["specialist"].ToString();
                }
            }
        }

        [WebMethod]
        public static string UpdateProfile(int industry, int arevenue, int pmodel, int noemployee, int category, int spent, int experience, int education, string specialist, int reportingLine, int spentUnder, int jobRole, int proLevel, string directGeneral, string fname, string lname, string company, string phone, int geoInfluence, string password, string state, string postcode, string country, string jobtitle,string email)
        {
            string passwordSalt = SGACommon.CreateSalt(5);
            string passwordHash = SGACommon.CreatePasswordHash(password, passwordSalt);
            SqlParameter[] param = new SqlParameter[27];
            param[0] = new SqlParameter("@industry", SqlDbType.Int);
            param[0].Value = industry;
            param[1] = new SqlParameter("@arevenue", SqlDbType.Int);
            param[1].Value = arevenue;
            param[2] = new SqlParameter("@pmodel", SqlDbType.Int);
            param[2].Value = pmodel;
            param[3] = new SqlParameter("@noemployee", SqlDbType.Int);
            param[3].Value = noemployee;
            param[4] = new SqlParameter("@categoryId", SqlDbType.Int);
            param[4].Value = category;
            param[5] = new SqlParameter("@spendunder", SqlDbType.Int);
            param[5].Value = spent;
            param[6] = new SqlParameter("@experience", SqlDbType.Int);
            param[6].Value = experience;
            param[7] = new SqlParameter("@education", SqlDbType.Int);
            param[7].Value = education;
            param[8] = new SqlParameter("@specialist", SqlDbType.VarChar);
            param[8].Value = specialist;
            param[9] = new SqlParameter("@userId", SqlDbType.Int);
            param[9].Value = SGACommon.LoginUserInfo.userId;
            param[10] = new SqlParameter("@reportline", SqlDbType.Int);
            param[10].Value = reportingLine;
            param[11] = new SqlParameter("@spentUnder", SqlDbType.Int);
            param[11].Value = spentUnder;
            param[12] = new SqlParameter("@jobRole", SqlDbType.Int);
            param[12].Value = jobRole;
            param[13] = new SqlParameter("@proLevel", SqlDbType.Int);
            param[13].Value = proLevel;
            param[14] = new SqlParameter("@directGeneral", SqlDbType.VarChar);
            param[14].Value = directGeneral;
            param[15] = new SqlParameter("@fname", SqlDbType.VarChar);
            param[15].Value = fname;
            param[16] = new SqlParameter("@lname", SqlDbType.VarChar);
            param[16].Value = lname;
            param[17] = new SqlParameter("@company", SqlDbType.VarChar);
            param[17].Value = company;
            param[18] = new SqlParameter("@phone", SqlDbType.VarChar);
            param[18].Value = phone;
            param[19] = new SqlParameter("@geoInfluence", SqlDbType.Int);
            param[19].Value = geoInfluence;
            param[20] = new SqlParameter("@passwordSalt", SqlDbType.VarChar);
            param[20].Value = passwordSalt;
            param[21] = new SqlParameter("@passwordHash", SqlDbType.VarChar);
            param[21].Value = passwordHash;
            param[22] = new SqlParameter("@plainpassword", SqlDbType.VarChar);
            param[22].Value = password;
            param[23] = new SqlParameter("@state", SqlDbType.VarChar);
            param[23].Value = state;
            param[24] = new SqlParameter("@postcode", SqlDbType.VarChar);
            param[24].Value = postcode;
            param[25] = new SqlParameter("@country", SqlDbType.VarChar);
            param[25].Value = country;
            param[26] = new SqlParameter("@jobtitle", SqlDbType.VarChar);
            param[26].Value = jobtitle;
            int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUpdateProfile", param));

            string[] strField = new string[]
										{
											"Id"
										};
            XmlRpcStruct[] resultFound = isdnAPI.findByEmail(email, strField);
            int userId;
            XmlRpcStruct Contact = new XmlRpcStruct();
            if (resultFound.Length > 0)
            {
                userId = System.Convert.ToInt32(resultFound[0]["Id"].ToString());
                Contact.Add("FirstName", fname);
                Contact.Add("LastName", lname);
                Contact.Add("JobTitle", jobtitle);
                Contact.Add("Email", email);
                Contact.Add("Company", company);
                Contact.Add("State", state);
                Contact.Add("PostalCode", postcode);
                Contact.Add("Country", country);
                Contact.Add("Fax1", phone);
                Contact.Add("_Jobrolebestdescribedas", SGACommon.GetJobRole(System.Convert.ToInt32(jobRole)));
                
                Contact.Add("ContactType", "Customer");
                isdnAPI.dsUpdate("Contact", userId, Contact);
            }

            return "s";
        }
    }
}