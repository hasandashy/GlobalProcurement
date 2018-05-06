using DataTier;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Linq;


namespace SGA.App_Code
{
    public static class SGACommon
    {
        public static User LoginUserInfo
        {
            get
            {
                User cu = null;
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    cu = new User();
                    string[] args = HttpContext.Current.User.Identity.Name.Split(new char[]
                    {
                        ':'
                    });
                    if (args.Length > 0)
                    {
                        cu.userId = System.Convert.ToInt32(args[1]);
                        cu.name = args[0];
                    }
                }
                return cu;
            }
        }

        public static string CreateToken(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

                var sb = new System.Text.StringBuilder();
                for (var i = 0; i <= hashmessage.Length - 1; i++)
                {
                    sb.Append(hashmessage[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string UppercaseFirst(string s)
        {
            string result;
            if (string.IsNullOrEmpty(s))
            {
                result = string.Empty;
            }
            else
            {
                result = char.ToUpper(s[0]) + s.Substring(1).ToLower();
            }
            return result;
        }

        public static void AddPageTitle(Page page, string title, string description)
        {
            page.Title = SGACommon.Left(title, 65);
            HtmlMeta keywords = new HtmlMeta();
            keywords.Name = "description";
            keywords.Content = SGACommon.Left(description, 156);
            page.Header.Controls.Add(keywords);
        }

        public static void SaveBrowserDetails(int userId, string browserName, string userAgent, string sessionId)
        {
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spProcessSessionDetails", new SqlParameter[]
            {
                new SqlParameter("@userId", userId),
                new SqlParameter("@browserName", browserName),
                new SqlParameter("@userAgent", userAgent),
                new SqlParameter("@sessionId", sessionId)
            });
        }

        public static string CmcRatingByPercentage(double percentage)
        {
            string strValue = "";
            if (percentage > 0.0 && percentage < 37.0)
            {
                strValue = "Novice";
            }
            else if (percentage > 37.01 && percentage < 46.5)
            {
                strValue = "Novice to Beginner";
            }
            else if (percentage > 46.51 && percentage < 56.0)
            {
                strValue = "Beginner";
            }
            else if (percentage > 56.01 && percentage < 65.5)
            {
                strValue = "Beginner to Intermediate";
            }
            else if (percentage > 65.51 && percentage < 75.0)
            {
                strValue = "Intermediate";
            }
            else if (percentage > 75.01 && percentage < 84.5)
            {
                strValue = "Specialist ";
            }
            else if (percentage > 84.51 && percentage < 94.0)
            {
                strValue = "Specialist to Mastery";
            }
            else if (percentage > 94.0)
            {
                strValue = "Mastery";
            }
            return strValue;
        }

        public static void IsViewResult(string colName)
        {
            bool isView = true;
            DataSet dsPermission = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPremission", new SqlParameter[]
            {
                new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
            });
            if (dsPermission != null)
            {
                isView = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0][colName].ToString());
            }
            if (!isView)
            {
                HttpContext.Current.Response.Redirect("ResultDenied.aspx");
            }
        }

        public static void IsTakeTest(string colName)
        {
            bool isView = true;
            DataSet dsPermission = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spGetPremission", new SqlParameter[]
            {
                new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
            });
            if (dsPermission != null)
            {
                isView = System.Convert.ToBoolean(dsPermission.Tables[0].Rows[0][colName].ToString());
            }
            if (!isView)
            {
                HttpContext.Current.Response.Redirect("TestDenied.aspx");
            }
        }

        public static void DisplayErrorBox(string strMsg, Page myPage)
        {
            string script = "alert('" + strMsg + "');";
            ScriptManager.RegisterStartupScript(myPage, myPage.GetType(), "UserSecurity", script, true);
        }

        public static void GetEmailTemplate(int id, ref string subject, ref string body)
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "spManageTemplate", new SqlParameter[]
            {
                new SqlParameter("@flag", "0"),
                new SqlParameter("@id", id)
            });
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    body = HttpContext.Current.Server.HtmlDecode(ds.Tables[0].Rows[0]["emailBody"].ToString());
                    subject = ds.Tables[0].Rows[0]["subject"].ToString();
                }
            }
        }

        public static System.DateTimeOffset ToAusTimeZone(System.DateTime sourceDt)
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            System.DateTimeOffset utcOffset = new System.DateTimeOffset(sourceDt, System.TimeSpan.Zero);
            return utcOffset.ToOffset(tz.GetUtcOffset(utcOffset));
        }

        public static string GetJobRole(int roleId)
        {
            string strValue = "";
            switch (roleId)
            {
                case 1:
                    strValue = "Analyst";
                    break;
                case 2:
                    strValue = "Procurement Support";
                    break;
                case 3:
                    strValue = "Strategic Sourcing";
                    break;
                case 4:
                    strValue = "Vendor Manager/ Supplier Relationship Manager";
                    break;
                case 5:
                    strValue = "Category Manager";
                    break;
                case 6:
                    strValue = "Procurement Leader";
                    break;
                case 7:
                    strValue = "Supply Chain";
                    break;
                case 8:
                    strValue = "Non-Procurement: CXO";
                    break;
                case 9:
                    strValue = "Non-Procurement: Director";
                    break;
                case 10:
                    strValue = "Non-Procurement: Manager";
                    break;
                case 11:
                    strValue = "Non-Procurement: Professional";
                    break;
                case 12:
                    strValue = "Non-Procurement: Trainee";
                    break;
                case 13:
                    strValue = "Other";
                    break;

            }
            return strValue;
        }

        public static string ToTitleCase(string text)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        public static void Redirect(string url, string target, string windowFeatures)
        {
            HttpContext context = HttpContext.Current;
            if ((string.IsNullOrEmpty(target) || target.Equals("_self", System.StringComparison.OrdinalIgnoreCase)) && string.IsNullOrEmpty(windowFeatures))
            {
                context.Response.Redirect(url);
            }
            else
            {
                Page page = (Page)context.Handler;
                if (page == null)
                {
                    throw new System.InvalidOperationException("Cannot redirect to new window outside Page context.");
                }
                url = page.ResolveClientUrl(url);
                string script;
                if (!string.IsNullOrEmpty(windowFeatures))
                {
                    script = "window.open(\"{0}\", \"{1}\", \"{2}\");";
                }
                else
                {
                    script = "window.open(\"{0}\", \"{1}\");";
                }
                script = string.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true);
            }
        }

        public static SqlConnection dbConnect()
        {
            string sqlString = ConfigurationSettings.AppSettings["Conn"].ToString();
            SqlConnection cnQuestionaire = new SqlConnection(sqlString);
            cnQuestionaire.Open();
            return cnQuestionaire;
        }

        public static void SelectListItem(DropDownList list, object value)
        {
            if (list.Items.Count != 0)
            {
                ListItem selectedItem = list.SelectedItem;
                if (selectedItem != null)
                {
                    selectedItem.Selected = false;
                }
                if (value != null)
                {
                    selectedItem = list.Items.FindByValue(value.ToString());
                    if (selectedItem != null)
                    {
                        selectedItem.Selected = true;
                    }
                }
            }
        }

        public static void SelectListItemForListBox(ListBox list, object value)
        {
            if (list.Items.Count != 0)
            {
                ListItem selectedItem = list.SelectedItem;
                if (selectedItem != null)
                {
                    selectedItem.Selected = false;
                }
                if (value != null)
                {
                    selectedItem = list.Items.FindByValue(value.ToString());
                    if (selectedItem != null)
                    {
                        selectedItem.Selected = true;
                    }
                }
            }
        }

        public static void ShowMessageBox(string message, Page page)
        {
            if (message.Length > 0)
            {
                string strReturnValue = "jQuery(document).ready(function($) {\r\n";
                strReturnValue = strReturnValue + "jQuery.facebox(\"<b>" + message + "</b>\");\r\n";
                strReturnValue += "});";
                page.ClientScript.RegisterStartupScript(page.GetType(), "face", strReturnValue, true);
            }
        }

        public static void CloseWindow()
        {
            HttpContext.Current.Response.Write("<script>window.close();</script>");
        }

        public static string ContenType(string extention)
        {
            string strVal = "";
            switch (extention)
            {
                case "xls":
                    strVal = "application/vnd.ms-excel";
                    break;
                case "xlsx":
                    strVal = "application/vnd.ms-excel";
                    break;
                case "doc":
                    strVal = "application/msword";
                    break;
                case "docx":
                    strVal = "application/msword";
                    break;
                case "ppt":
                    strVal = "application/vnd.ms-powerpoint";
                    break;
                case "pptx":
                    strVal = "application/vnd.ms-powerpoint";
                    break;
                case "pdf":
                    strVal = "application/pdf";
                    break;
                case "jpg":
                    strVal = "image/jpeg";
                    break;
                case "jepg":
                    strVal = "image/jpeg";
                    break;
                case "gif":
                    strVal = "image/gif";
                    break;
                case "png":
                    strVal = "image/png";
                    break;
                case "bmp":
                    strVal = "image/bmp";
                    break;
                case "ico":
                    strVal = "image/vnd.microsoft.icon";
                    break;
                case "zip":
                    strVal = "application/zip";
                    break;
                case "txt":
                    strVal = "text/plain";
                    break;
                case "css":
                    strVal = "text/plain";
                    break;
                case "js":
                    strVal = "text/plain";
                    break;
                case "html":
                    strVal = "text/html";
                    break;
                case "rtf":
                    strVal = "text/richtext";
                    break;
            }
            return strVal;
        }

        public static bool ConfigGetBooleanValue(NameValueCollection config, string valueName, bool defaultValue)
        {
            string str = config[valueName];
            bool result2;
            if (str == null)
            {
                result2 = defaultValue;
            }
            else
            {
                bool result;
                if (!bool.TryParse(str, out result))
                {
                    throw new System.Exception(string.Format("Value must be boolean {0}", valueName));
                }
                result2 = result;
            }
            return result2;
        }

        public static int ConfigGetIntValue(NameValueCollection config, string valueName, int defaultValue, bool zeroAllowed, int maxValueAllowed)
        {
            string str = config[valueName];
            int result2;
            int result;
            if (str == null)
            {
                result2 = defaultValue;
            }
            else if (!int.TryParse(str, out result))
            {
                if (zeroAllowed)
                {
                    throw new System.Exception(string.Format("Value must be non negative integer {0}", valueName));
                }
                throw new System.Exception(string.Format("Value must be positive integer {0}", valueName));
            }
            else
            {
                if (zeroAllowed && result < 0)
                {
                    throw new System.Exception(string.Format("Value must be non negative integer {0}", valueName));
                }
                if (!zeroAllowed && result <= 0)
                {
                    throw new System.Exception(string.Format("Value must be positive integer {0}", valueName));
                }
                if (maxValueAllowed > 0 && result > maxValueAllowed)
                {
                    throw new System.Exception(string.Format("Value too big {0}", valueName));
                }
                result2 = result;
            }
            return result2;
        }

        public static string GetName()
        {
            string name = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                name = SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetName", new SqlParameter[]
                {
                    new SqlParameter("@Id", SGACommon.LoginUserInfo.userId)
                }).ToString();
            }
            return SGACommon.ToTitleCase(name);
        }

        public static string GetName(int userId)
        {
            string name = SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetName", new SqlParameter[]
            {
                new SqlParameter("@Id", userId)
            }).ToString();
            return SGACommon.ToTitleCase(name);
        }

        public static string GetFullName()
        {
            string name = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                name = SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetFullName", new SqlParameter[]
                {
                    new SqlParameter("@Id", SGACommon.LoginUserInfo.userId)
                }).ToString();
            }
            return SGACommon.ToTitleCase(name);
        }

        public static string GetCompanyName()
        {
            string name = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                name = SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "spGetCompanyByUser", new SqlParameter[]
                {
                    new SqlParameter("@userId", SGACommon.LoginUserInfo.userId)
                }).ToString();
            }
            return SGACommon.ToTitleCase(name);
        }

        public static string ShowMessageBoxWithJqeryInstance(string message, Page page)
        {
            string strReturnValue = "";
            if (message.Length > 0)
            {
                strReturnValue = "$(document).ready(function($) {\r\n";
                strReturnValue = strReturnValue + "$.facebox(\"<b>" + message + "</b>\");\r\n";
                strReturnValue += "});";
            }
            return strReturnValue;
        }

        public static string RemoveLastCharacter(string strInput)
        {
            if (strInput.Length > 0)
            {
                strInput = strInput.Remove(strInput.Length - 1, 1);
            }
            return strInput;
        }

        public static string GenerateFakeId(string prefix, int startNumber)
        {
            string strRetval;
            if (startNumber > 9)
            {
                strRetval = prefix + "00" + startNumber;
            }
            else
            {
                strRetval = prefix + "000" + startNumber;
            }
            return strRetval;
        }

        public static string Left(string text, int length)
        {
            string result;
            if (length <= 0 || text.Length == 0)
            {
                result = "";
            }
            else if (text.Length <= length)
            {
                result = text;
            }
            else
            {
                result = text.Substring(0, length);
            }
            return result;
        }

        public static bool isDecimal(string strInput)
        {
            bool retval;
            try
            {
                Regex numRange = new Regex("^\\d+(\\.\\d{1,2})?$");
                Match match = numRange.Match(strInput);
                retval = match.Success;
            }
            catch (System.Exception ex)
            {
                retval = false;
            }
            return retval;
        }

        public static void FillQuestionsPoints(DropDownList ddl)
        {
            for (int i = 0; i < 11; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        public static string FormatMultilineText(string strInput)
        {
            if (strInput.Length > 0)
            {
                strInput = strInput.Replace("\r\n", "<br />");
            }
            return strInput;
        }

        internal static bool isCorrectDateformat(string p)
        {
            throw new System.NotImplementedException();
        }

        public static string YesNoConversion(object obj)
        {
            string strValue = "";
            try
            {
                if (obj is bool)
                {
                    strValue = (System.Convert.ToBoolean(obj) ? "Yes" : "No");
                }
            }
            catch (System.Exception ex)
            {
                strValue = "";
            }
            return strValue;
        }

        public static string YesNoConversionInt(object obj)
        {
            string strValue = "";
            try
            {
                if (obj is int)
                {
                    strValue = ((System.Convert.ToInt32(obj) == 0) ? "No" : "Yes");
                }
            }
            catch (System.Exception ex)
            {
                strValue = ex.ToString();
            }
            return strValue;
        }

        public static void InsertDefaultItem(DropDownList source, string defaultText, string defaultValue)
        {
            source.Items.Insert(0, new ListItem(defaultText, defaultValue));
        }

        public static bool isNumeric(string strInput)
        {
            bool retval;
            try
            {
                System.Convert.ToInt32(strInput.ToString());
                retval = true;
            }
            catch (System.Exception ex)
            {
                retval = false;
            }
            return retval;
        }

        public static string generatePassword(int length)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", string.Empty);
            if (length <= 0 || length > guidResult.Length)
            {
                throw new System.ArgumentException("Length must be between 1 and " + guidResult.Length);
            }
            return guidResult.Substring(0, length);
        }

        public static string CreatePasswordHash(string password, string salt)
        {
            string passwordFormat = "SHA1";
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, passwordFormat);
        }

        public static string CreateSalt(int size)
        {
            System.Security.Cryptography.RNGCryptoServiceProvider provider = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            provider.GetBytes(data);
            return System.Convert.ToBase64String(data);
        }

        public static string GetLogoNameByMembership(string membership)
        {
            string strValue = string.Empty;
            switch (membership)
            {
                case "AACAM": strValue = "aacam.png"; break;
                case "ABCAL": strValue = "logo1.png"; break;
                case "ADACI": strValue = "adaci.png"; break;
                case "AERCE": strValue = "logo2.png"; break;
                case "APCADEC": strValue = "logo3.png"; break;
                case "APPI": strValue = "dpnappi.png"; break;
                case "APROCAL": strValue = "aprocal.png"; break;
                case "BME": strValue = "logo4.png"; break;
                case "BMOE": strValue = "bmo.png"; break;
                case "CAP": strValue = "hund.png"; break;
                case "CAPP": strValue = "cpi.png"; break;
                case "CBEC": strValue = "logo5.png"; break;
                case "CFLP": strValue = "logo6.png"; break;
                case "CIPSMN": strValue = "logo7.png"; break;
                case "DILF": strValue = "logo8.png"; break;
                case "Forum Einkauf": strValue = "logo9.png"; break;
                case "FZUP": strValue = "logo10.png"; break;
                case "HALPIM": strValue = "logo11.png"; break;
                case "HPI": strValue = "logo12.png"; break;
                case "IAPI": strValue = "logo13.png"; break;
                case "IFPSM": strValue = "ifpsm.png"; break;
                case "IIMM": strValue = "logo14.png"; break;
                case "IIPMM": strValue = "logo15.png"; break;
                case "IPLMA": strValue = "logo16.png"; break;
                case "IPPU": strValue = "ppu.png"; break;
                case "IPSHK": strValue = "logo17.png"; break;
                case "ISMM": strValue = "logo18.png"; break;
                case "JMMA": strValue = "logo19.png"; break;
                case "KISM": strValue = "logo20.png"; break;
                case "LOGY": strValue = "logo22.png"; break;
                case "MIPMM": strValue = "logo23.png"; break;
                case "MIPS": strValue = "aips.png"; break;
                case "NEVI": strValue = "logo24.png"; break;
                case "NIMA": strValue = "logo25.png"; break;
                case "PASIA": strValue = "logo26.png"; break;
                case "PISM ": strValue = "logo27.png"; break;
                case "PROCURE": strValue = "logo28.png"; break;
                case "PROLOG": strValue = "logo29.png"; break;
                case "PSCMT": strValue = "logo30.png"; break;
                case "PSML": strValue = "logo31.png"; break;
                case "SAPPP": strValue = "logo32.png"; break;
                case "SCMA": strValue = "logo33.png"; break;
                case "SILF ": strValue = "logo34.png"; break;
                case "SIMM": strValue = "logo35.png"; break;
                case "SMIT": strValue = "logo36.png"; break;
                case "SSCPA": strValue = "spa.png"; break;
                case "TUSAYDER": strValue = "logo37.png"; break;
                case "ZNS": strValue = "logo38.png"; break;
                case "Other - CIPS": strValue = "CIPS.png"; break;
                case "Other - ISM": strValue = "ISM.png"; break;
                default: strValue = string.Empty; break;
            }
            return strValue;
        }
        public static string GetMembershipNameByMembership(string membership)
        {
            string strValue = string.Empty;
            switch (membership)
            {
                case "AACAM": strValue = "Asociación Argentina de Compras Administracion de Materiales y Logistica"; break;
                case "ABCAL": strValue = "Association Belge des Cardes d’Achat et de Logistique"; break;
                case "ADACI": strValue = "Associazione Italiana Acquiste E Supply Management"; break;
                case "AERCE": strValue = "Associación Espanola de Professionales de Compras, Contractión y Aprovisionamientos"; break;
                case "APCADEC": strValue = "Portuguese association for Purchasing and Supply Management"; break;
                case "APPI": strValue = "Asosiasi Pengacara Pengadaan Indonesia"; break;
                case "APROCAL": strValue = "Asociación de Profesionales en Compras, Abastecimiento y Logística, A.C."; break;
                case "BME": strValue = "Bundesverband Materialwirtschaft, Einkauf und Logistik"; break;
                case "BMOE": strValue = "Bundesverband Materialwirtschaft, Einkauf und Logistik in Osterreich"; break;
                case "CAP": strValue = "Croatian Association of Purchasing"; break;
                case "CAPP": strValue = "Caribbean Association of Procurement Professionals"; break;
                case "CBEC": strValue = "Brazilian Council of Purchasing Executives"; break;
                case "CFLP": strValue = "China Federation of Logistics and Purchasing"; break;
                case "CIPSMN": strValue = "Chartered Institute of Purchasing & Supply Management of Nigeria"; break;
                case "DILF": strValue = "Danish Purchasing and Logistics Forum"; break;
                case "Forum Einkauf": strValue = "Forum Einkauf"; break;
                case "FZUP": strValue = "Federation of Purchases and Supply Management of Russia"; break;
                case "HALPIM": strValue = "Hungarian Association of Logistics, Purchasing and Inventory Management"; break;
                case "HPI": strValue = "Hellenic Purchasing Institute"; break;
                case "IAPI": strValue = "Ikatan Ahli Pengadaan Indonesia"; break;
                case "IFPSM": strValue = "International Federation of Purchasing & Supply Management"; break;
                case "IIMM": strValue = "Indian Institute of Materials Management"; break;
                case "IIPMM": strValue = "Irish Institute of Purchasing and Materials Management"; break;
                case "IPLMA": strValue = "Israeli Purchasing & Logistics Managers Association"; break;
                case "IPPU": strValue = "Institute of Procurement Professionals of Uganda"; break;
                case "IPSHK": strValue = "The Institute of Purchasing and Supply of Hong Kong"; break;
                case "ISMM": strValue = "Institute of Supply and Materials Management"; break;
                case "JMMA": strValue = "Japan Materials Management Association"; break;
                case "KISM": strValue = "Kenya Institute of Supplies Management"; break;
                case "LOGY": strValue = "Finnish Association of Purchasing and Logistics"; break;
                case "MIPMM": strValue = "Malaysian Institute of Purchasing & Materials Management"; break;
                case "MIPS": strValue = "Malawi Institute of Procurement and Supply"; break;
                case "NEVI": strValue = "Nederlandse Vereniging voor Inkoop Management"; break;
                case "NIMA": strValue = "Norsk Forbund for Innkjøp og Logistikk (The Norwegian Association of Purchasing and Logistics)"; break;
                case "PASIA": strValue = "Procurement and Supply Institute of Asia"; break;
                case "PISM": strValue = "Philippine Institute for Supply Management"; break;
                case "PROCURE": strValue = "procure.ch Swiss Association for Purchasing and Supply Management"; break;
                case "PROLOG": strValue = "Estonian Purchasing and Supply Chain Management Association"; break;
                case "PSCMT": strValue = "Purchasing and Supply Chain Management Association of Thailand"; break;
                case "PSML": strValue = "Polish Supply Management Leaders"; break;
                case "SAPPP": strValue = "Serbian Association of Professionals in Public Procurement"; break;
                case "SCMA": strValue = "Supply Chain Management Association"; break;
                case "SILF": strValue = "Swedish Purchasing and Logistic Association"; break;
                case "SIMM": strValue = "Singapore Institute of Materials Management"; break;
                case "SMIT": strValue = "Supply Management Institute, Taiwan"; break;
                case "SSCPA": strValue = "Serbian Supply Chain Professionals Association"; break;
                case "TUSAYDER": strValue = "TUSAYDER"; break;
                case "ZNS": strValue = "Zdruzenje nabavnikov Slovenije (Slovenian Purchasing Association)"; break;
                case "Other - CIPS": strValue = "Other: CIPS – Chartered Institute of Purchasing & Supply"; break;
                case "Other - ISM": strValue = "Other:ISM – Institute of Supply Management"; break;
                default: strValue = string.Empty; break;
            }
            return strValue;
        }
    }

    public class User
    {
        private int _userId;

        private string _name;

        public int userId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }

        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
    }

    public class Topic
    {
        private int _topicId;

        private string _topicTitle;

        public int topicId
        {
            get
            {
                return this._topicId;
            }
            set
            {
                this._topicId = value;
            }
        }

        public string topicTitle
        {
            get
            {
                return this._topicTitle;
            }
            set
            {
                this._topicTitle = value;
            }
        }



    }

    public static class Profile
    {
        public static string GetIndustry(int industryId)
        {
            string strValue;
            switch (industryId)
            {
                case 1:
                    strValue = "Advertising, Media & Communications";
                    break;
                case 2:
                    strValue = "Agribusiness";
                    break;
                case 3:
                    strValue = "Associations";
                    break;
                case 4:
                    strValue = "Automotive";
                    break;
                case 5:
                    strValue = "Business Services";
                    break;
                case 6:
                    strValue = "Consulting & Business Strategy";
                    break;
                case 7:
                    strValue = "Defence";
                    break;
                case 8:
                    strValue = "Diversified";
                    break;
                case 9:
                    strValue = "Education & Training";
                    break;
                case 10:
                    strValue = "Energy";
                    break;
                case 11:
                    strValue = "Environment";
                    break;
                case 12:
                    strValue = "Financial Services";
                    break;
                case 13:
                    strValue = "FMCG";
                    break;
                case 14:
                    strValue = "Government";
                    break;
                case 15:
                    strValue = "Healthcare & Medical";
                    break;
                case 16:
                    strValue = "Hospitality, Tourism & Entertainment";
                    break;
                case 17:
                    strValue = "HR & Recruitment";
                    break;
                case 18:
                    strValue = "Information Technology";
                    break;
                case 19:
                    strValue = "Infrastructure";
                    break;
                case 20:
                    strValue = "Legal";
                    break;
                case 21:
                    strValue = "Manufacturing";
                    break;
                case 22:
                    strValue = "Mining, Oil, Gas & Resources";
                    break;
                case 23:
                    strValue = "Not for Profit";
                    break;
                case 24:
                    strValue = "Pharmaceuticals";
                    break;
                case 25:
                    strValue = "Property, Construction & Engineering";
                    break;
                case 26:
                    strValue = "Retail";
                    break;
                case 27:
                    strValue = "Sports & Community";
                    break;
                case 28:
                    strValue = "Supply Chain, Logistics & Transport";
                    break;
                case 29:
                    strValue = "Telecommunications";
                    break;
                case 30:
                    strValue = "Trade & Services";
                    break;
                default:
                    strValue = "No response entered";
                    break;
            }
            return strValue;
        }

        public static string GetAnnualRevenue(int revenueId)
        {
            string strValue;
            switch (revenueId)
            {
                case 1:
                    strValue = "$1 billion or more";
                    break;
                case 2:
                    strValue = "$500 million to $999.9 million";
                    break;
                case 3:
                    strValue = "$100 million to $499.9 million";
                    break;
                case 4:
                    strValue = "$50 million to $99.9 million";
                    break;
                case 5:
                    strValue = "$20 million to $49.9 million";
                    break;
                case 6:
                    strValue = "$10 million to $19.9 million";
                    break;
                case 7:
                    strValue = "$5 million to $9.9 million";
                    break;
                case 8:
                    strValue = "$2.5 million to $4.9 million";
                    break;
                case 9:
                    strValue = "$1 million to $2.49 million";
                    break;
                case 10:
                    strValue = "$500,000 to $999,999";
                    break;
                case 11:
                    strValue = "Less than $500,000";
                    break;
                default:
                    strValue = "No response entered";
                    break;
            }
            return strValue;
        }

        public static string GetProcurementModel(int modelId)
        {
            string strValue;
            switch (modelId)
            {
                case 1:
                    strValue = "Centralised Procurement Function";
                    break;
                case 2:
                    strValue = "Decentralised Procurement Function";
                    break;
                case 3:
                    strValue = "Centre-Led Procurement Function";
                    break;
                case 4:
                    strValue = "Procurement strategy is centralised, but execution is de-centralised";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetReportLineTo(int reportingId)
        {
            string strValue;
            switch (reportingId)
            {
                case 1:
                    strValue = "CEO";
                    break;
                case 2:
                    strValue = "CFO";
                    break;
                case 3:
                    strValue = "COO";
                    break;
                case 4:
                    strValue = "CIO";
                    break;
                case 5:
                    strValue = "Legal Council";
                    break;
                case 6:
                    strValue = "Head of Supply Chain";
                    break;
                case 7:
                    strValue = "Division or Business Unit Head";
                    break;
                case 8:
                    strValue = "Regional or Global Procurement";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetSpendUnderInfluence(int spendId)
        {
            string strValue;
            switch (spendId)
            {
                case 1:
                    strValue = "$1 billion or more";
                    break;
                case 2:
                    strValue = "$500 million to $999.9 million";
                    break;
                case 3:
                    strValue = "$100 million to $499.9 million";
                    break;
                case 4:
                    strValue = "$50 million to $99.9 million";
                    break;
                case 5:
                    strValue = "$20 million to $49.9 million";
                    break;
                case 6:
                    strValue = "$10 million to $19.9 million";
                    break;
                case 7:
                    strValue = "$5 million to $9.9 million";
                    break;
                case 8:
                    strValue = "$2.5 million to $4.9 million";
                    break;
                case 9:
                    strValue = "$1 million to $2.49 million";
                    break;
                case 10:
                    strValue = "$500,000 to $999,999";
                    break;
                case 11:
                    strValue = "Less than $500,000";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetSector(int sectorId)
        {
            string strValue;
            switch (sectorId)
            {
                case 1:
                    strValue = "Public";
                    break;
                case 2:
                    strValue = "Private";
                    break;
                case 3:
                    strValue = "Non Profit";
                    break;

                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }


        public static string GetSpentUnderYourInfluence(int spendId)
        {
            string strValue;
            switch (spendId)
            {
                case 1:
                    strValue = "$1 billion or more";
                    break;
                case 2:
                    strValue = "$500 million to $999.9 million";
                    break;
                case 3:
                    strValue = "$100 million to $499.9 million";
                    break;
                case 4:
                    strValue = "$50 million to $99.9 million";
                    break;
                case 5:
                    strValue = "$20 million to $49.9 million";
                    break;
                case 6:
                    strValue = "$10 million to $19.9 million";
                    break;
                case 7:
                    strValue = "$5 million to $9.9 million";
                    break;
                case 8:
                    strValue = "$2.5 million to $4.9 million";
                    break;
                case 9:
                    strValue = "$1 million to $2.49 million";
                    break;
                case 10:
                    strValue = "$500,000 to $999,999";
                    break;
                case 11:
                    strValue = "Less than $500,000";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetNoOfEmployee(int noofEmployeeId)
        {
            string strValue;
            switch (noofEmployeeId)
            {
                case 1:
                    strValue = "100+";
                    break;
                case 2:
                    strValue = "75 to 99";
                    break;
                case 3:
                    strValue = "50 to 74";
                    break;
                case 4:
                    strValue = "30 to 49";
                    break;
                case 5:
                    strValue = "15 to 29";
                    break;
                case 6:
                    strValue = "10 to 14";
                    break;
                case 7:
                    strValue = "9";
                    break;
                case 8:
                    strValue = "8";
                    break;
                case 9:
                    strValue = "7";
                    break;
                case 10:
                    strValue = "6";
                    break;
                case 11:
                    strValue = "5";
                    break;
                case 12:
                    strValue = "4";
                    break;
                case 13:
                    strValue = "3";
                    break;
                case 14:
                    strValue = "2";
                    break;
                case 15:
                    strValue = "1";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetGeoInfluence(int influenceId)
        {
            string strValue;
            switch (influenceId)
            {
                case 1:
                    strValue = "Local";
                    break;
                case 2:
                    strValue = "Regional";
                    break;
                case 3:
                    strValue = "Global";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetJobRole(int roleId)
        {
            string strValue;
            switch (roleId)
            {
                case 1:
                    strValue = "Analyst";
                    break;
                case 2:
                    strValue = "Procurement Support";
                    break;
                case 3:
                    strValue = "Strategic Sourcing";
                    break;
                case 4:
                    strValue = "Vendor Manager/ Supplier Relationship Manager";
                    break;
                case 5:
                    strValue = "Category Manager";
                    break;
                case 6:
                    strValue = "Procurement Leader";
                    break;
                case 7:
                    strValue = "Supply Chain";
                    break;
                case 8:
                    strValue = "Non-Procurement: CXO";
                    break;
                case 9:
                    strValue = "Non-Procurement: Director";
                    break;
                case 10:
                    strValue = "Non-Procurement: Manager";
                    break;
                case 11:
                    strValue = "Non-Procurement: Professional";
                    break;
                case 12:
                    strValue = "Non-Procurement: Trainee";
                    break;

                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetCategory(int categoryId)
        {
            string strValue;
            switch (categoryId)
            {
                case 1:
                    strValue = "Generalist Direct & Indirects";
                    break;
                case 2:
                    strValue = "Generalist Directs";
                    break;
                case 3:
                    strValue = "Generalist Indirects";
                    break;
                case 4:
                    strValue = "Chemicals";
                    break;
                case 5:
                    strValue = "Energy";
                    break;
                case 6:
                    strValue = "Facilities";
                    break;
                case 7:
                    strValue = "Fleet";
                    break;
                case 8:
                    strValue = "Heavy Machinery and Equipment";
                    break;
                case 9:
                    strValue = "HR Services";
                    break;
                case 10:
                    strValue = "ICT";
                    break;
                case 11:
                    strValue = "Ingredients";
                    break;
                case 12:
                    strValue = "Marketing";
                    break;
                case 13:
                    strValue = "Mining Equipment";
                    break;
                case 14:
                    strValue = "MRO and Capex";
                    break;
                case 15:
                    strValue = "Packaging";
                    break;
                case 16:
                    strValue = "Professional Services";
                    break;
                case 17:
                    strValue = "Raw Materials";
                    break;
                case 18:
                    strValue = "Travel";
                    break;
                case 19:
                    strValue = "Wardrobe & Workwear";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetProcurementLevel(int proLevelId)
        {
            string strValue;
            switch (proLevelId)
            {
                case 1:
                    strValue = "Certificate Procurement and Contracting";
                    break;
                case 2:
                    strValue = "Certificate Purchasing";
                    break;
                case 3:
                    strValue = "Certified Professional in Supply Management (CPSM)";
                    break;
                case 4:
                    strValue = "Certificate in Production and Inventory Management (CPIM)";
                    break;
                case 5:
                    strValue = "Diploma of Procurement and Contracting";
                    break;
                case 6:
                    strValue = "Diploma of Purchasing";
                    break;
                case 7:
                    strValue = "Diploma of Contract Management";
                    break;
                case 8:
                    strValue = "Advanced Diploma of Procurement and Contracting";
                    break;
                case 9:
                    strValue = "Graduate Certificate in Logistics and Supply Chain Management";
                    break;
                case 10:
                    strValue = "Undergraduate degree procurement / supply chain";
                    break;
                case 11:
                    strValue = "Postgraduate degree procurement/ supply chain";
                    break;
                case 12:
                    strValue = "Certified Supply Chain Professional (CSCP)";
                    break;
                case 13:
                    strValue = "Certified International Procurement Professional (CIPP)";
                    break;
                case 14:
                    strValue = "Certified International Advanced Procurement Professional (CIAPP)";
                    break;
                case 15:
                    strValue = "Member Chartered Institute Procurement Supply (MCIPS)";
                    break;
                case 16:
                    strValue = "Fellow Chartered Institute Procurement Supply (FCIPS)";
                    break;
                case 17:
                    strValue = "AAPCM Member";
                    break;
                case 18:
                    strValue = "AAPCM Fellow";
                    break;
                case 19:
                    strValue = "Other";
                    break;
                case 20:
                    strValue = "Not applicable";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetEducation(int educationId)
        {
            string strValue;
            switch (educationId)
            {
                case 1:
                    strValue = "Secondary school";
                    break;
                case 2:
                    strValue = "Certificate";
                    break;
                case 3:
                    strValue = "Diploma";
                    break;
                case 4:
                    strValue = "Advanced Diploma";
                    break;
                case 5:
                    strValue = "Undergraduate";
                    break;
                case 6:
                    strValue = "Postgraduate";
                    break;
                case 7:
                    strValue = "Masters";
                    break;
                case 8:
                    strValue = "Doctorate";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetExp(int expId)
        {
            string strValue;
            switch (expId)
            {
                case 1:
                    strValue = "Less than 1 year";
                    break;
                case 2:
                    strValue = "1 - 3 years";
                    break;
                case 3:
                    strValue = "3 - 5 years";
                    break;
                case 4:
                    strValue = "5 - 10 years";
                    break;
                case 5:
                    strValue = "10 or more years";
                    break;
                case 6:
                    strValue = "Not Applicable";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }

        public static string GetPrevCatExp(int expId)
        {
            string strValue;
            switch (expId)
            {
                case 1:
                    strValue = "Indirect- General";
                    break;
                case 2:
                    strValue = "Directs - General";
                    break;
                case 3:
                    strValue = "IT&T Services: Software, Hardware, Telco etc.";
                    break;
                case 4:
                    strValue = "Packaging: PET, Glass, Print, Labels, etc.";
                    break;
                case 5:
                    strValue = "Marketing Services: ABT, BTL, Print, etc.";
                    break;
                case 6:
                    strValue = "Ingredients";
                    break;
                case 7:
                    strValue = "HR Services: Labour hire, Recruitment, Training, etc.";
                    break;
                case 8:
                    strValue = "Chemicals";
                    break;
                case 9:
                    strValue = "Professional Services: Legal, Audit & Accounting, Security, etc.";
                    break;
                case 10:
                    strValue = "Industry specific production material";
                    break;
                case 11:
                    strValue = "Facilities and Corporate Real Estate (FM/CRE)";
                    break;
                case 12:
                    strValue = "Utilities: Gas, Electricity, Water";
                    break;
                case 13:
                    strValue = "Capex: Heavy machinery and equipment";
                    break;
                case 14:
                    strValue = "MRO Maintenance, Repairs, Operations and Consumables";
                    break;
                case 15:
                    strValue = "Office: Stationery, post";
                    break;
                case 16:
                    strValue = "Travel";
                    break;
                case 17:
                    strValue = "Fleet";
                    break;
                case 18:
                    strValue = "Logistics";
                    break;
                case 19:
                    strValue = "Other";
                    break;
                default:
                    strValue = "--select item--";
                    break;
            }
            return strValue;
        }
    }

    public static class Quartiles
    {
        public static double FirstQuartile(IEnumerable<double> list)
        {
            return GetQuartileExcel(list, 0.25);
        }

        public static double ThirdQuartile(IEnumerable<double> list)
        {
            return GetQuartileExcel(list, 0.75);
        }

        public static double MiddleQuartile(IEnumerable<double> list)
        {
            return GetQuartileExcel(list, 0.50);
        }

        /*
         * Let n be the number of observations in a data set (here n=4), and x(1), … x(n) the ordered values of a
           data set. Let p be the p-th percentile we want to calculate (ex: p=0.25, 0.5, or .75).
           For each of these methods, we’ll need to calculate the product (n-1)*p (or a similar one).
           The product n(n-1)*p can be split up between j and g, where j is the integer part of n*p and g is the decimal
           part of n*p.
           Ex: for p=0.5 (50th percentile), n=8,
           n*p= 8*0.5= 4 = 4 + 0 , hence j=4 and g=0.
           Ex: for p=0.75 (75th percentile), n=10,
           n*p= 10*.75= 7.5 = 7 + 0.5, hence j=7 and g=.5 .
           Let y be the percentile associated to p (so that, in fact, y= q(p)). We then have approximately p % of the
           data set values lying below y. In the following paragraphs, the p-th percentile will always be referred to as
           y.*/
        //y= (1-g)*x(j+1) +g*x(j+2), where (n-1)*p= j + g
        private static double GetQuartileExcel(IEnumerable<double> list, double quartile)
        {
            //p
            double result;

            //n
            int count = list.Count();
            //j
            int integerPart;
            //g
            double decimalPart;

            double index = (count - 1) * quartile;
            decimalPart = index % 1;

            integerPart = (int)index;
            //Formula For Excel Quartile only

            result = ((1 - decimalPart) * list.ElementAt(integerPart)) + (decimalPart * list.ElementAt(integerPart + 1));

            return Math.Round(result, 2);
        }
    }
}