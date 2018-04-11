using DataTier;
using SGA.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGA.tna
{
    public partial class Leaderboard : System.Web.UI.Page
    {
        protected string africaUsers = "0 user";
        protected string asiaUsers = "0 user";
        protected string europeUsers = "0 user";
        protected string americaUsers = "0 user";

        protected int TotalUsers = 0;


        protected string widthAfrica = "0%";
        protected string widthAsia = "0%";
        protected string widthAmerica = "0%";
        protected string widthEurope = "0%";

        protected string countries = "";
        protected string countryUsers = "";

        protected string association = "";
        protected string associationUsers = "";



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isProfileComplete())
            {
                Response.Redirect("MyProfile.aspx", false);
            }
            if (!IsPostBack)
            {
                TotalUsers = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(1) as nouser from tblusers where id != 4"));
                BindUsers();
            }
        }

        public void BindUsers()
        {
            DataSet dsUsers = SqlHelper.ExecuteDataset(CommandType.Text, "select countryRegion,count(1) as nouser from UserInfo where countryRegion is not null group by countryRegion order by nouser desc");
            if (dsUsers != null)
            {
                if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                {
                    lstRegion.DataSource = dsUsers.Tables[0];
                    lstRegion.DataBind();
                    //int asiaUsersCount = 0;
                    //int europeUsersCount = 0;
                    //int americaUsersCount = 0;
                    //int africaUsersCount = 0;
                    //DataRow[] drAsia = dsUsers.Tables[0].Select("countryRegion = 'Apac'");
                    //DataRow[] drAmerica = dsUsers.Tables[0].Select("countryRegion = 'America'");
                    //DataRow[] drAfrica = dsUsers.Tables[0].Select("countryRegion = 'Africa'");
                    //DataRow[] drEurope = dsUsers.Tables[0].Select("countryRegion = 'Europe'");

                    //if (drAmerica.Count() > 0)
                    //{
                    //    americaUsersCount = Convert.ToInt32(drAmerica[0][1]);
                    //    americaUsers = americaUsersCount.ToString() + " users";
                    //}
                    //if (drAsia.Count() > 0)
                    //{
                    //    asiaUsersCount = Convert.ToInt32(drAsia[0][1]);
                    //    asiaUsers = asiaUsersCount.ToString() + " users";
                    //}
                    //if (drAfrica.Count() > 0)
                    //{
                    //    africaUsersCount = Convert.ToInt32(drAfrica[0][1]);
                    //    africaUsers = africaUsersCount.ToString() + " users";
                    //}
                    //if (drEurope.Count() > 0)
                    //{
                    //    europeUsersCount = Convert.ToInt32(drEurope[0][1]);
                    //    europeUsers = europeUsersCount.ToString() + " users";
                    //}
                    //int totalUsers = asiaUsersCount + africaUsersCount + americaUsersCount + europeUsersCount;
                    //widthAfrica = (Convert.ToDecimal(africaUsersCount) / Convert.ToDecimal(totalUsers)) * 100 + "%";
                    //widthAmerica = (Convert.ToDecimal(americaUsersCount) / Convert.ToDecimal(totalUsers)) * 100 + "%";
                    //widthAsia = (Convert.ToDecimal(asiaUsersCount) / Convert.ToDecimal(totalUsers)) * 100 + "%";
                    //widthEurope = (Convert.ToDecimal(europeUsersCount) / Convert.ToDecimal(totalUsers)) * 100 + "%";

                    //asiaBar.Style.Add("width", widthAsia);
                    //americaBar.Style.Add("width", widthAmerica);
                    //europeBar.Style.Add("width", widthEurope);
                    //africaBar.Style.Add("width", widthAfrica);
                }
            }

            dsUsers = SqlHelper.ExecuteDataset(CommandType.Text, "select top 10 country,count(1) as nouser from UserInfo where country is not null group by country order by nouser desc");

            if (dsUsers != null)
            {
                if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                {
                    lstRegionUsers.DataSource = dsUsers.Tables[0];
                    lstRegionUsers.DataBind();
                }
            }

            dsUsers = SqlHelper.ExecuteDataset(CommandType.Text, "select top 3 membershipAssociation ,count(1) as nouser from tblUsers where membershipAssociation is not null group by membershipAssociation order by nouser desc");

            if (dsUsers != null)
            {
                if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                {
                    StringBuilder memName = new StringBuilder();
                    string logo1 = string.Empty;
                    string logo2 = string.Empty;
                    string logo3 = string.Empty;
                    for (int i = 0; i < dsUsers.Tables[0].Rows.Count; i++)
                    {
                        memName.Append("<p>" + (i + 1).ToString() + ". " + SGACommon.GetMembershipNameByMembership(dsUsers.Tables[0].Rows[i]["membershipAssociation"].ToString()) + "</p>");
                        if(i == 0)
                        {
                            logo1 = SGACommon.GetLogoNameByMembership(dsUsers.Tables[0].Rows[i]["membershipAssociation"].ToString());
                        } else if( i == 1)
                        {
                            logo2 = SGACommon.GetLogoNameByMembership(dsUsers.Tables[0].Rows[i]["membershipAssociation"].ToString());
                        } else if(i == 2)
                        {
                            logo3 = SGACommon.GetLogoNameByMembership(dsUsers.Tables[0].Rows[i]["membershipAssociation"].ToString());
                        }
                    }


                    membershipName.InnerHtml = memName.ToString();
                    if(logo1 != string.Empty)
                    {
                        logo1div.Visible = true;
                        imglogo1.Src = "~/images/" + logo1;
                    }
                    if (logo2 != string.Empty)
                    {
                        logo2div.Visible = true;
                        imglogo2.Src = "~/images/" + logo2;
                    }
                    if (logo3 != string.Empty)
                    {
                        logo3div.Visible = true;
                        imglogo3.Src = "~/images/" + logo3;
                    }
                }
            }
        }

        protected void lstRegionUsers_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem || e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                int userCount = System.Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "nouser"));
                string width = (Convert.ToDecimal(userCount) / Convert.ToDecimal(TotalUsers)) * 100 + "%";
                HtmlGenericControl div = e.Item.FindControl("progressBar") as HtmlGenericControl;

                div.Style.Add("width", width);

            }
        }

        protected void lstRegion_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem || e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                string strImagePath = string.Empty;
                string region = string.Empty;
                int userCount = System.Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "nouser"));
                string data = DataBinder.Eval(e.Item.DataItem, "countryRegion").ToString();
                string width = (Convert.ToDecimal(userCount) / Convert.ToDecimal(TotalUsers)) * 100 + "%";
                HtmlGenericControl div = e.Item.FindControl("progressBar") as HtmlGenericControl;
                HtmlImage img = e.Item.FindControl("regionImage") as HtmlImage;


                if (data.Trim().ToLower() == "apac")
                {
                    strImagePath = "~/Images/asia-map.png";
                    region = "Asia";
                }
                else if (data.Trim().ToLower() == "africa")
                {
                    strImagePath = "~/Images/africa-map.png";
                    region = "Africa";
                }
                else if (data.Trim().ToLower() == "america")
                {
                    strImagePath = "~/Images/america-map.png";
                    region = "America";
                }
                else if (data.Trim().ToLower() == "europe")
                {
                    strImagePath = "~/Images/europe-map.png";
                    region = "Europe";
                }
                img.Src = strImagePath;
                div.Style.Add("width", width);

            }
        }

        private bool isProfileComplete()
        {
            bool isComplete = false;
            int num = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(sector) from UserInfo where userid =" + SGACommon.LoginUserInfo.userId + " "));
            if (num == 1)
            {
                isComplete = true;
            }
            return isComplete;
        }
    }
}