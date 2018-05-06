using CookComputing.XmlRpc;
using InfusionSoftDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGA
{
    public partial class MembershipTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataSet ds = DataTier.SqlHelper.ExecuteDataset(new SqlConnection("Data Source=168.128.36.32;Database=ifpsm;User ID=sa;Password=Procuresourcing$#@!;"), CommandType.Text, "select id,email from tblusers where id  in(select userid from userinfo where country is null) and id <> 4");
                    string[] strField = new string[]
                            {
                            "Id",
                            "_Country1"
                            };

                    int userId;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        XmlRpcStruct Contact = new XmlRpcStruct();
                        XmlRpcStruct[] resultFound = isdnAPI.findByEmail("andrzej.zawistowski@psml.pl", strField);
                        if (resultFound.Length > 0)
                        {
                            string _mem = "";
                            userId = System.Convert.ToInt32(resultFound[0]["Id"].ToString());
                            if (resultFound[0]["_Country1"] != null)
                            {
                                _mem = resultFound[0]["_Country1"].ToString();
                            }
                            //Contact.Add("_SGApassword", ds.Tables[0].Rows[i]["plainpassword"].ToString());
                            //Contact.Add("ContactType", "Customer");
                            //isdnAPI.dsUpdate("Contact", userId, Contact);
                            if (_mem != string.Empty)
                            {
                                int ds1 = DataTier.SqlHelper.ExecuteNonQuery(new SqlConnection("Data Source=168.128.36.32;Database=ifpsm;User ID=sa;Password=Procuresourcing$#@!;"), CommandType.Text, "update userinfo set country = '" + _mem + "' where userid = '" + ds.Tables[0].Rows[i]["id"].ToString() + "'");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }


        }
    }
}