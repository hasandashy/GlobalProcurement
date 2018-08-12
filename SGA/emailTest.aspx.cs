using CookComputing.XmlRpc;
using DataTier;
using InfusionSoftDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA
{
    public partial class emailTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imb_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder _sb = new StringBuilder();

            DataSet dsUsers = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetCompletedSGA");
            if (dsUsers != null)
            {
                if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsUsers.Tables[0].Rows.Count; i++)
                    {
                        string[] strField = new string[]
                {
                            "Id"
                };
                        XmlRpcStruct[] resultFound = isdnAPI.findByEmail(dsUsers.Tables[0].Rows[i]["email"].ToString(), strField);
                        int userId;
                        XmlRpcStruct Contact = new XmlRpcStruct();
                        if (resultFound.Length > 0)
                        {
                            userId = System.Convert.ToInt32(resultFound[0]["Id"].ToString());


                            if (resultFound[0]["Id"] != null && resultFound[0]["Id"].ToString() != String.Empty)
                            {
                                isdnAPI.addToGroup(userId, 4229);
                                isdnAPI.dsUpdate("Contact", userId, Contact);

                            }

                        }
                    }
                }


            }

            lblUserId.Text = "completed";
        }
    }
}