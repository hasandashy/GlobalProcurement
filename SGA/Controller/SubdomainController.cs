using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using SGA.App_Code;
using System.Web.Security;

namespace SGA.Controller
{
    public class SubdomainController : System.Web.Mvc.Controller
    {
        public ActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                DataSet ds = DataTier.SqlHelper.ExecuteDataset(System.Data.CommandType.StoredProcedure, "spManageRegisterTemplate", new System.Data.SqlClient.SqlParameter[]{
                    new SqlParameter("@urlSuffix",id.Trim().ToString()),
                    new SqlParameter("@flag","3")
                });
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ViewBag.Text = ds.Tables[0].Rows[0]["paragraphText"].ToString();
                        ViewBag.color = ds.Tables[0].Rows[0]["hexCode"].ToString();
                        ViewBag.LogoPath = Url.Content("~" + ds.Tables[0].Rows[0]["logoName"].ToString());
                        ViewBag.isCode = ds.Tables[0].Rows[0]["ISCode"].ToString();
                        //btnSend.Style.Add("background", "#" + ds.Tables[0].Rows[0]["hexCode"].ToString() + " none repeat scroll 0 0");
                        //imgLogo.Src = Page.ResolveUrl("~" + ds.Tables[0].Rows[0]["logoName"].ToString());
                    }
                    else
                    {
                        return Redirect("~/index.aspx");
                    }
                }
                else
                {
                    return Redirect("~/index.aspx");
                }
                return View();
            }
            else {
                return Redirect("~/index.aspx");
            }
            
        }
    }
}