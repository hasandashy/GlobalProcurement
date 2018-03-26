using Facebook;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGA.App_Code;
using Hammock.Authentication.OAuth;
using Hammock;

namespace SGA
{
    public partial class register : System.Web.UI.Page
    {

        public string redirectUrl = ConfigurationManager.AppSettings["LinkedIn-CallbackUrl"].ToString();

        public String apiKey = ConfigurationManager.AppSettings["LinkedIn-ClientID"].ToString();

        public String apiSecret = ConfigurationManager.AppSettings["LinkedIn-ClientSecret"].ToString();

        static string token_secret = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) return;

        }



        protected void btnLoginWithLinkedIn_Click1(object sender, EventArgs e)
        {
            var credentials = new OAuthCredentials
            {
                //CallbackUrl = "http://localhost/home/callback",
                CallbackUrl = redirectUrl,
                ConsumerKey = ConfigurationManager.AppSettings["LinkedIn-ClientID"],
                ConsumerSecret = ConfigurationManager.AppSettings["LinkedIn-ClientSecret"],
                Verifier = "123456",
                Type = OAuthType.RequestToken
            };

            var client = new RestClient { Authority = "https://api.linkedin.com/uas/oauth", Credentials = credentials };
            var request = new RestRequest { Path = "requestToken?scope=r_basicprofile%20r_emailaddress" };
            //request.AddParameter("scope", "r_fullprofile");
            RestResponse response = client.Request(request);
            string token = "";
            string verifier = "";
            token = response.Content.Split('&').Where(s => s.StartsWith("oauth_token=")).Single().Split('=')[1];
            token_secret = response.Content.Split('&').Where(s => s.StartsWith("oauth_token_secret=")).Single().Split('=')[1];
            Session["token"] = token_secret;
            Response.Redirect("https://api.linkedin.com/uas/oauth/authorize?oauth_token=" + token);


        }


        protected void btnLoginWithFb_Click(object sender, EventArgs e)
        {
            int pos = Request.Url.ToString().LastIndexOf('/');
            string url = Request.Url.ToString().Substring(0, (pos + 1));

            Response.Redirect(@"https://www.facebook.com/dialog/oauth?client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&redirect_uri=" + url + "CreateFBForm.aspx&scope=email,user_birthday");
            //oAuthFacebook oFB = new oAuthFacebook();
            //Response.Redirect(oFB.AuthorizationLinkGet());
            //Response.Redirect("https://www.facebook.com/v2.4/dialog/oauth/?client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/RegIster_Success.aspx&response_type=code&state=1");
        }

    }
}