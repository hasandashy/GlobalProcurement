using DataTier;
using CookComputing.XmlRpc;
using InfusionSoftDotNet;
using SGA.App_Code;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Web.Script.Services;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace SGA
{
    /// <summary>
    /// Summary description for skillsservice
    /// </summary>
    [WebService(Namespace = "http://skillsgapanalysis.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class skillsservice : System.Web.Services.WebService
    {
        [WebMethod]
        public void RegisterUserFromGlobalProcurement(string firstName, string lastName, string emailAddress, string country, string jobRole, string membershipAssociation, string ifpsmComments, string ifpsmJobRole, string callback)
        {
            int status = 0;
            string[] strField = new string[]
                            {
                            "Id"
                            };
            string result2 = "d";
            if (ifpsmJobRole != "0")
            {
                // From Register page
                XmlRpcStruct[] resultFound = isdnAPI.findByEmail(emailAddress, strField);

                int userId;

                if (status > 0)
                {
                    XmlRpcStruct Contact = new XmlRpcStruct();

                    Contact.Add("ContactType", "Customer");
                    Contact.Add("FirstName", firstName);
                    Contact.Add("LastName", lastName);
                    Contact.Add("_Country1", country);
                    Contact.Add("_MembershipAssociation0", membershipAssociation);

                    Contact.Add("_IFPSMComments", ifpsmComments);
                    //Contact.Add("_Jobrolebestdescribedas", SGACommon.GetJobRole(Convert.ToInt32(jobRole)));

                    Contact.Add("_IFPSMPageJobRole", ifpsmJobRole);

                    isdnAPI.dsUpdate("Contact", System.Convert.ToInt32(resultFound[0]["Id"].ToString()), Contact);
                    isdnAPI.optIn(emailAddress, "Make them marketable");
                    isdnAPI.addToGroup(System.Convert.ToInt32(resultFound[0]["Id"].ToString()), 3472);
                    //retVal = System.Convert.ToInt32(resultFound[0]["Id"].ToString());

                }
                else
                {
                    userId = isdnAPI.add(new XmlRpcStruct
                            {
                                {
                                    "FirstName",
                                    firstName
                                },
                                {
                                    "LastName",
                                    lastName
                                },
                                {
                                    "JobTitle",
                                    ""
                                },
                                {
                                    "Email",
                                    emailAddress
                                },
                                {
                                    "Company",
                                    ""
                                },
                                {
                                    "_Yourlevel",
                                    ""
                                },
                                /*{
                                    "_Jobrolebestdescribedas",
                                    SGACommon.GetJobRole(Convert.ToInt32(jobRole))
                                },*/
                                {
                                    "LeadSourceId",
                                    "22"
                                },
                                {
                                    "OwnerID",
                                    "6"
                                },{
                                    "_MembershipAssociation0",
                                    membershipAssociation
                            },{
                                    "_Country1",
                                    country
                            },
                            { "_IFPSMComments", ifpsmComments },
                                { "_IFPSMPageJobRole",ifpsmJobRole},
                            {
                                    "ContactType",
                                    "Customer"
                                }
                            });
                    if (userId > 0)
                    {
                        isdnAPI.addToGroup(userId, 3472);
                        isdnAPI.optIn(emailAddress, "Make them marketable");
                    }
                }
            }
            else
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@email", SqlDbType.VarChar)
                };
                param[0].Value = emailAddress;
                status = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spCheckUniqueEmail", param));

                if (status > 0)
                {
                    // email exists and only update value in IS
                    UpdateValueinIS(emailAddress, firstName, lastName, country, membershipAssociation, ifpsmComments, jobRole, "");
                }
                else
                {
                    // Register user
                    string plainpassword = SGACommon.generatePassword(8);
                    string passwordSalt = SGACommon.CreateSalt(5);
                    string passwordHash = SGACommon.CreatePasswordHash(plainpassword, passwordSalt);

                    param = new SqlParameter[13];
                    param[0] = new SqlParameter("@action", SqlDbType.VarChar);
                    param[0].Value = "Insert";
                    param[1] = new SqlParameter("@password", SqlDbType.VarChar);
                    param[1].Value = plainpassword;
                    param[2] = new SqlParameter("@company", SqlDbType.VarChar);
                    param[2].Value = "";
                    param[3] = new SqlParameter("@firstName", SqlDbType.VarChar);
                    param[3].Value = firstName;
                    param[4] = new SqlParameter("@lastName", SqlDbType.VarChar);
                    param[4].Value = lastName;
                    param[5] = new SqlParameter("@email", SqlDbType.VarChar);
                    param[5].Value = emailAddress;
                    param[6] = new SqlParameter("@isApproved", SqlDbType.Bit);
                    param[6].Value = 1;
                    param[7] = new SqlParameter("@passwordHash", SqlDbType.VarChar);
                    param[7].Value = passwordHash;
                    param[8] = new SqlParameter("@passwordSalt", SqlDbType.VarChar);
                    param[8].Value = passwordSalt;
                    param[9] = new SqlParameter("@jobRole", SqlDbType.Int);
                    //param[9].Value = "1";
                    param[9].Value = jobRole;
                    param[10] = new SqlParameter("@isAdminAdded", SqlDbType.Bit);
                    param[10].Value = false;
                    param[11] = new SqlParameter("@country", SqlDbType.VarChar);
                    param[11].Value = country;
                    param[12] = new SqlParameter("@membershipAssociation", SqlDbType.VarChar);
                    param[12].Value = membershipAssociation;
                    int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUserMasterGlobalProcurement", param));
                    if (result > 0)
                    {
                        UpdateValueinIS(emailAddress, firstName, lastName, country, membershipAssociation, ifpsmComments, jobRole, plainpassword);
                        string subject = "New Contact has registered in IFPSM";
                        System.IO.StreamReader objStreamReader = System.IO.File.OpenText(HttpContext.Current.Server.MapPath("~/css/ifpsm.htm"));
                        string content = objStreamReader.ReadToEnd();
                        objStreamReader.Close();
                        objStreamReader.Dispose();
                        content = content.Replace("@fullname", firstName + " " + lastName).Replace("@email", emailAddress);
                        MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), emailAddress, ConfigurationManager.AppSettings["UserName"].ToString(), subject, content, "");

                        subject = "";
                        string body = "";

                        SGACommon.GetEmailTemplate(8, ref subject, ref body);
                        body = body.Replace("@v0", firstName).Replace("@v1", lastName).Replace("@v2", "").Replace("@v3", emailAddress).Replace("@v5", plainpassword);
                        MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), emailAddress, subject, body, "");


                    }
                }
            }




            // Method 1: use built-in serializer:
            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            sb.Append(callback + "(");
            sb.Append(js.Serialize(result2));
            sb.Append(");");
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
            //return result2;

        }

        public void UpdateValueinIS(string emailAddress, string firstName, string lastName, string country, string membershipAssociation, string ifpsmComments, string ifpsmJobRole, string plainPassword)
        {
            string[] strField = new string[]
                            {
                            "Id"
                            };
            XmlRpcStruct[] resultFound = isdnAPI.findByEmail(emailAddress, strField);
            if (resultFound.Length > 0)
            {
                XmlRpcStruct Contact = new XmlRpcStruct();

                Contact.Add("ContactType", "Customer");
                Contact.Add("FirstName", firstName);
                Contact.Add("LastName", lastName);
                Contact.Add("_Country1", country);
                Contact.Add("_MembershipAssociation0", membershipAssociation);
                Contact.Add("_IFPSMComments", ifpsmComments);
                Contact.Add("_Jobrolebestdescribedas", SGACommon.GetJobRole(Convert.ToInt32("1")));
                Contact.Add("_IFPSMPageJobRole", ifpsmJobRole);
                isdnAPI.dsUpdate("Contact", System.Convert.ToInt32(resultFound[0]["Id"].ToString()), Contact);
                isdnAPI.addToGroup(System.Convert.ToInt32(resultFound[0]["Id"].ToString()), 3448);
                isdnAPI.optIn(emailAddress, "Make them marketable");
            }
            else
            {
                int userId = isdnAPI.add(new XmlRpcStruct
                            {
                                {
                                    "FirstName",
                                    firstName
                                },
                                {
                                    "LastName",
                                    lastName
                                },
                                {
                                    "JobTitle",
                                    ""
                                },
                                {
                                    "Email",
                                    emailAddress
                                },
                                {
                                    "Company",
                                    ""
                                },
                                {
                                    "_Yourlevel",
                                    ""
                                },
                                {
                                    "_Jobrolebestdescribedas",
                                    SGACommon.GetJobRole(1)
                                },
                                {
                                    "LeadSourceId",
                                    "22"
                                },
                                {
                                    "OwnerID",
                                    "6"
                                },{
                                    "_MembershipAssociation0",
                                    membershipAssociation
                                },{
                                        "_Country1",
                                        country
                                },
                                { "_IFPSMComments", ifpsmComments },

                                {
                                    "ContactType",
                                    "Customer"
                                }
                            });
                if (userId > 0)
                {
                    if (plainPassword.Length > 0)
                    {
                        XmlRpcStruct Contact = new XmlRpcStruct();

                        Contact.Add("ContactType", "Customer");
                        Contact.Add("_SGApassword", plainPassword);
                        Contact.Add("_IFPSMPageJobRole", ifpsmJobRole);
                        isdnAPI.dsUpdate("Contact", userId, Contact);
                    }
                    else
                    {
                        XmlRpcStruct Contact = new XmlRpcStruct();

                        Contact.Add("ContactType", "Customer");
                        Contact.Add("_IFPSMPageJobRole", ifpsmJobRole);
                        isdnAPI.dsUpdate("Contact", userId, Contact);
                    }
                    isdnAPI.addToGroup(userId, 3448);
                    isdnAPI.optIn(emailAddress, "Make them marketable");
                }
            }
        }

        [WebMethod]
        public int RegisterUser(string firstName, string lastName, string emailAddress)
        {
            string[] strField = new string[]
                        {
                            "Id"
                        };
            XmlRpcStruct[] resultFound = isdnAPI.findByEmail(emailAddress, strField);
            int userId;
            int retVal = 0;
            if (resultFound.Length > 0)
            {
                //isdnAPI.addToGroup(System.Convert.ToInt32(resultFound[0]["Id"].ToString()), 3204);
                XmlRpcStruct Contact = new XmlRpcStruct();

                Contact.Add("ContactType", "Customer");
                Contact.Add("FirstName", firstName);
                Contact.Add("LastName", lastName);
                Contact.Add("_OrganisationPageURL", "http://academyofprocurement.com/about-your-organization/?customerId=" + System.Convert.ToInt32(resultFound[0]["Id"].ToString()));
                Contact.Add("_CapabilityPageURL", "http://academyofprocurement.com/capabilityaudit/?customerId=" + System.Convert.ToInt32(resultFound[0]["Id"].ToString()));
                isdnAPI.dsUpdate("Contact", System.Convert.ToInt32(resultFound[0]["Id"].ToString()), Contact);
                retVal = System.Convert.ToInt32(resultFound[0]["Id"].ToString());
                isdnAPI.addToGroup(retVal, 3206);
                isdnAPI.optIn(emailAddress, "Sending emails is allowed");
            }
            else
            {
                userId = isdnAPI.add(new XmlRpcStruct
                            {
                                {
                                    "FirstName",
                                    firstName
                                },
                                {
                                    "LastName",
                                    lastName
                                },{
                                    "Email",
                                    emailAddress
                                }});
                if (userId > 0)
                {
                    isdnAPI.addToGroup(userId, 3206);
                    isdnAPI.optIn(emailAddress, "Sending emails is allowed");

                    XmlRpcStruct Contact = new XmlRpcStruct();
                    Contact.Add("ContactType", "Customer");
                    Contact.Add("_OrganisationPageURL", "http://academyofprocurement.com/about-your-organization/?customerId=" + userId);
                    Contact.Add("_CapabilityPageURL", "http://academyofprocurement.com/capabilityaudit/?customerId=" + userId);
                    isdnAPI.dsUpdate("Contact", userId, Contact);

                }
                retVal = userId;
            }

            /* For sending email */
            string subject = "New Contact has registered for Procurement Capability Audit";
            System.IO.StreamReader objStreamReader = System.IO.File.OpenText(HttpContext.Current.Server.MapPath("~/css/aopemail.htm"));
            string content = objStreamReader.ReadToEnd();
            objStreamReader.Close();
            objStreamReader.Dispose();
            content = content.Replace("@fullname", firstName + " " + lastName).Replace("@email", emailAddress);
            MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), emailAddress, "support@comprara.com.au", subject, content, "");

            return retVal;
        }

        [WebMethod]
        public int CheckValidCustomer(string customerId)
        {
            string[] strField = new string[]
                        {
                            "Id"
                        };
            XmlRpcStruct cid = new XmlRpcStruct();
            cid.Add("Id", customerId);

            XmlRpcStruct[] resultFound = isdnAPI.dsQuery("Contact", 1, 0, cid, strField);
            return resultFound.Length > 0 ? System.Convert.ToInt32(resultFound[0]["Id"].ToString()) : 0;
        }

        [WebMethod]
        public string GetFirstName(string customerId)
        {
            string[] strField = new string[]
                        {
                            "Id","FirstName"
                        };
            XmlRpcStruct cid = new XmlRpcStruct();
            cid.Add("Id", customerId);

            XmlRpcStruct[] resultFound = isdnAPI.dsQuery("Contact", 1, 0, cid, strField);
            return resultFound.Length > 0 ? resultFound[0]["FirstName"].ToString() : "";
        }

        [WebMethod]
        public int SaveAboutYourOrganisation(int customerId, string company, string jobTitle, string mobile, string Isassessingorbuildingcapabilityforyourself, string Howlonghaveyoufacedchallengeswithregardcapabilityorcap, string Whendoyouwanttoimplementandidealsolution, string Iminterestedinimprovingourapproachtocapability)
        {
            string[] strField = new string[]
                        {
                            "Id"
                        };
            XmlRpcStruct cid = new XmlRpcStruct();
            cid.Add("Id", customerId);

            XmlRpcStruct[] resultFound = isdnAPI.dsQuery("Contact", 1, 0, cid, strField);
            if (resultFound.Length > 0)
            {
                XmlRpcStruct Contact = new XmlRpcStruct();
                Contact.Add("ContactType", "Customer");
                Contact.Add("Company", company);
                Contact.Add("JobTitle", jobTitle);
                Contact.Add("_Mobile", mobile);
                Contact.Add("_Isassessingorbuildingcapabilityforyourself", Isassessingorbuildingcapabilityforyourself);


                Contact.Add("_Howlonghaveyoufacedchallengeswithregardcapabilityorcap0", Howlonghaveyoufacedchallengeswithregardcapabilityorcap);
                Contact.Add("_Whendoyouwanttoimplementanidealsolution", Whendoyouwanttoimplementandidealsolution);
                Contact.Add("_Iminterestedinimprovingourapproachtocapability", Iminterestedinimprovingourapproachtocapability);// value Yes or No
                //Contact.Add("_Howmanypeopleorrolesexistinyourprocurementteam0", noofpeople);
                isdnAPI.dsUpdate("Contact", customerId, Contact);

                isdnAPI.addToGroup(customerId, 3426);

                return 1;
            }
            else
            {
                return 0;
            }

        }

        [WebMethod]
        public int AssessmentForm(int customerId, string answer1, string answer2, string answer3, string answer4, string answer5, string answer6, string answer7, string answer8, string answer9, string answer10)
        {
            string[] strField = new string[]
                         {
                            "Id"
                         };
            XmlRpcStruct cid = new XmlRpcStruct();
            cid.Add("Id", customerId);

            XmlRpcStruct[] resultFound = isdnAPI.dsQuery("Contact", 1, 0, cid, strField);
            if (resultFound.Length > 0)
            {
                XmlRpcStruct Contact = new XmlRpcStruct();
                Contact.Add("ContactType", "Customer");
                Contact.Add("_CapabilityFramework10", answer1);
                Contact.Add("_SkillsGAP10", answer2);
                Contact.Add("_SkillsGAP20", answer3);
                Contact.Add("_Academy10", answer4);
                Contact.Add("_Training10", answer5);
                Contact.Add("_Training20", answer6);
                Contact.Add("_Leadership10", answer7);
                Contact.Add("_Mentoring10", answer8);
                Contact.Add("_ELearning10", answer9);
                Contact.Add("_Certification1", answer10);
                isdnAPI.dsUpdate("Contact", customerId, Contact);
                //isdnAPI.addToGroup(customerId, 3208);
                isdnAPI.addToGroup(customerId, 3330);

                return 1;
            }
            else
            {
                return 0;
            }
        }

        [WebMethod]
        public void Login(string username, string password, string callback)
        {
            string success = "s";
            SqlParameter[] sql = new SqlParameter[]
           {
                new SqlParameter("@email", username)
           };
            int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spCheckLoginEmail", sql));

            if (result <= 0)
            {
                result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spCheckUserExpired", sql));
                if (result <= 0)
                {
                    success = "n";
                }
                else
                {
                    success = "n";
                }
            }
            else
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPassword", sql);
                string passwordHash = SGACommon.CreatePasswordHash(password, ds.Tables[0].Rows[0]["passwordSalt"].ToString());
                bool passMatch = ds.Tables[0].Rows[0]["passwordHash"].ToString().Equals(passwordHash);
                if (passMatch)
                {
                    result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetIdByEmail", sql));
                    sql[0] = new SqlParameter("@userId", result);
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "addLoginUserHistory", sql);
                    FormsAuthentication.SetAuthCookie(username + ":" + result, false);
                    success = "s";

                }
                else
                {
                    success = "i";
                }
            }


            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            sb.Append(callback + "(");
            sb.Append(js.Serialize(success));
            sb.Append(");");
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
        }


        [WebMethod]
        public void ForgotPassword(string email, string callback)
        {
            string retVal = "f";
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spForgotPassword", new SqlParameter[]
            {
                new SqlParameter("@email", email)
            });
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string subject = "";
                    string body = "";
                    SGACommon.GetEmailTemplate(3, ref subject, ref body);
                    body = body.Replace("@v0", ds.Tables[0].Rows[0]["firstName"].ToString()).Replace("@v1", ds.Tables[0].Rows[0]["lastName"].ToString()).Replace("@v3", ds.Tables[0].Rows[0]["email"].ToString()).Replace("@v5", ds.Tables[0].Rows[0]["plainpassword"].ToString());
                    MailSending.SendMail(ConfigurationManager.AppSettings["nameDisplay"].ToString(), ConfigurationManager.AppSettings["UserName"].ToString(), email, subject, body, "");
                    retVal = "s";
                }
            }
            // Method 1: use built-in serializer:
            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            sb.Append(callback + "(");
            sb.Append(js.Serialize(retVal));
            sb.Append(");");
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
            //return result2;
        }


        [WebMethod]
        public void UpdateNewPassword(string password, string callback)
        {
            string retVal = "f";
            string passwordSalt = SGACommon.CreateSalt(5);
            string passwordHash = SGACommon.CreatePasswordHash(password, passwordSalt);
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@password", SqlDbType.VarChar);
            param[0].Value = password;
            param[1] = new SqlParameter("@passwordHash", SqlDbType.VarChar);
            param[1].Value = passwordHash;
            param[2] = new SqlParameter("@passwordSalt", SqlDbType.VarChar);
            param[2].Value = passwordSalt;
            param[3] = new SqlParameter("@userId", SqlDbType.Int);
            param[3].Value = SGACommon.LoginUserInfo.userId;
            string[] strField = new string[]
            {
                "Id"
            };
            //        XmlRpcStruct[] resultFound = isdnAPI.findByEmail(SGACommon.LoginUserInfo.name, strField);
            //        if (resultFound.Length > 0)
            //        {
            //            int Id = System.Convert.ToInt32(resultFound[0]["Id"]);
            //            isdnAPI.dsUpdate("Contact", Id, new XmlRpcStruct
            //{
            //	{
            //		"_CSBPassword",
            //		password
            //	}
            //});
            //        }
            int result = System.Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spUpdatePassword", param));

            if (result == 0)
            {
                retVal = "s";
            }

            // Method 1: use built-in serializer:
            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            sb.Append(callback + "(");
            sb.Append(js.Serialize(retVal));
            sb.Append(");");
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(sb.ToString());
            Context.Response.End();
            //return result2;
        }
    }
}
