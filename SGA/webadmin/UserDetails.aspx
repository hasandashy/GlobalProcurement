<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="SGA.webadmin.UserDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Details</title>
    <link href="css/esourcing.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scrMgr" runat="server"></asp:ScriptManager>
        <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
            <tr>
                <td colspan="6"><b>User Details</b></td>
            </tr>
            <tr>
                <td class="txtrht">First Name
                </td>
                <td>
                    <asp:TextBox name="txtEditFname" ID="txtEditFname" runat="server" MaxLength="100" />
                </td>
                <td class="txtrht">Last Name
                </td>
                <td>
                    <asp:TextBox name="txtEditLname" ID="txtEditLname" runat="server" MaxLength="100" />
                </td>
                <td class="txtrht">Company
                </td>
                <td>
                    <asp:TextBox name="txtEditCompany" ID="txtEditCompany" runat="server" MaxLength="100" />
                </td>
            </tr>
            <tr>
                <td class="txtrht">Email
                </td>
                <td>
                    <asp:TextBox name="txtEditEmailAddress" ID="txtEditEmailAddress" ReadOnly="true"
                        runat="server" MaxLength="250" />
                </td>
                <td class="txtrht">Job Role
                </td>
                <td>
                    <asp:DropDownList ID="ddlEditJobRole" CssClass="styled" runat="server">
                        <asp:ListItem Value="0">Job role best described as ...</asp:ListItem>
                        <asp:ListItem Value="1">Analyst</asp:ListItem>
                        <asp:ListItem Value="2">Procurement Support</asp:ListItem>
                        <asp:ListItem Value="3">Strategic Sourcing</asp:ListItem>
                        <asp:ListItem Value="4">Vendor Manager/ Supplier Relationship Manager</asp:ListItem>
                        <asp:ListItem Value="5">Category Manager</asp:ListItem>
                        <asp:ListItem Value="6">Procurement Leader</asp:ListItem>
                        <asp:ListItem Value="7">Supply Chain</asp:ListItem>
                        <asp:ListItem Value="8">Non-Procurement: CXO</asp:ListItem>
                        <asp:ListItem Value="9">Non-Procurement: Director</asp:ListItem>
                        <asp:ListItem Value="10">Non-Procurement: Manager</asp:ListItem>
                        <asp:ListItem Value="11">Non-Procurement: Professional</asp:ListItem>
                        <asp:ListItem Value="12">Non-Procurement: Trainee</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="txtrht">Password
                </td>
                <td>
                    <asp:TextBox name="txtEditPassword" ID="txtEditPassword" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td class="txtrht">Job Title
                </td>
                <td>
                    <asp:TextBox name="txtEditJobTitle" ID="txtEditJobTitle" runat="server" MaxLength="100" />
                </td>
                <td class="txtrht">Phone
                </td>
                <td>
                    <asp:TextBox name="txtEditPhone" ID="txtEditPhone" runat="server" MaxLength="100" />
                </td>
                <td>State
                </td>
                <td>
                    <asp:TextBox ID="txtEditstate" name="txtEditstate" MaxLength="50" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Postal Code
                </td>
                <td colspan="5" class="ssec">
                    <asp:TextBox ID="txtEditpostcode" name="txtEditpostcode" MaxLength="20" runat="server" />
                </td>
            </tr>
            <tr id="trLinkedIn" runat="server">
                <td colspan="6">Linkedin Profile Url :
                    <asp:Label ID="lblLinkedIn" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="trFacebook" visible="false" runat="server">
                <td colspan="6">FaceBook Profile Url :
                    <asp:Label ID="lblFacebook" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">Which best describes the main industry in which your organization operates? Please
                select one of the following
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditIndustry" runat="server" class="styled">
                        <asp:ListItem Value="0" Selected="True">Industry</asp:ListItem>
                        <asp:ListItem Value="1">Advertising, Media &amp; Communications</asp:ListItem>
                        <asp:ListItem Value="2">Agribusiness</asp:ListItem>
                        <asp:ListItem Value="3">Associations</asp:ListItem>
                        <asp:ListItem Value="4">Automotive</asp:ListItem>
                        <asp:ListItem Value="5">Business Services</asp:ListItem>
                        <asp:ListItem Value="6">Consulting &amp; Business Strategy</asp:ListItem>
                        <asp:ListItem Value="7">Defence</asp:ListItem>
                        <asp:ListItem Value="8">Diversified</asp:ListItem>
                        <asp:ListItem Value="9">Education &amp; Training</asp:ListItem>
                        <asp:ListItem Value="10">Energy</asp:ListItem>
                        <asp:ListItem Value="11">Environment</asp:ListItem>
                        <asp:ListItem Value="12">Financial Services</asp:ListItem>
                        <asp:ListItem Value="13">FMCG</asp:ListItem>
                        <asp:ListItem Value="14">Government</asp:ListItem>
                        <asp:ListItem Value="15">Healthcare &amp; Medical</asp:ListItem>
                        <asp:ListItem Value="16">Hospitality, Tourism &amp; Entertainment</asp:ListItem>
                        <asp:ListItem Value="17">HR &amp; Recruitment</asp:ListItem>
                        <asp:ListItem Value="18">Information Technology</asp:ListItem>
                        <asp:ListItem Value="19">Infrastructure</asp:ListItem>
                        <asp:ListItem Value="20">Legal</asp:ListItem>
                        <asp:ListItem Value="21">Manufacturing</asp:ListItem>
                        <asp:ListItem Value="22">Mining, Oil, Gas &amp; Resources</asp:ListItem>
                        <asp:ListItem Value="23">Not for Profit</asp:ListItem>
                        <asp:ListItem Value="24">Pharmaceuticals</asp:ListItem>
                        <asp:ListItem Value="25">Property, Construction &amp; Engineering</asp:ListItem>
                        <asp:ListItem Value="26">Retail</asp:ListItem>
                        <asp:ListItem Value="27">Sports &amp; Community</asp:ListItem>
                        <asp:ListItem Value="28">Supply Chain, Logistics &amp; Transport</asp:ListItem>
                        <asp:ListItem Value="29">Telecommunications</asp:ListItem>
                        <asp:ListItem Value="30">Trade &amp; Services
                        </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">What is your company's approximate gross annual revenue ?
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditCompanyRevenue" runat="server" CssClass="styled">
                        <asp:ListItem Value="0" Selected="True">Annualised revenues</asp:ListItem>
                        <asp:ListItem Value="1">$1 billion or more</asp:ListItem>
                        <asp:ListItem Value="2">$500 million to $999.9 million</asp:ListItem>
                        <asp:ListItem Value="3">$100 million to $499.9 million</asp:ListItem>
                        <asp:ListItem Value="4">$50 million to $99.9 million</asp:ListItem>
                        <asp:ListItem Value="5">$20 million to $49.9 million</asp:ListItem>
                        <asp:ListItem Value="6">$10 million to $19.9 million</asp:ListItem>
                        <asp:ListItem Value="7">$5 million to $9.9 million</asp:ListItem>
                        <asp:ListItem Value="8">$2.5 million to $4.9 million</asp:ListItem>
                        <asp:ListItem Value="9">$1 million to $2.49 million</asp:ListItem>
                        <asp:ListItem Value="10">$500,000 to $999,999</asp:ListItem>
                        <asp:ListItem Value="11">Less than $500,000</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            </tr>

            <tr>
                <td colspan="6">Country
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditCountry" runat="server" class="styled">
                        <asp:ListItem>Australia</asp:ListItem>
                        <asp:ListItem>Afghanistan</asp:ListItem>
                        <asp:ListItem>Aland Islands</asp:ListItem>
                        <asp:ListItem>Albania</asp:ListItem>
                        <asp:ListItem>American Samoa</asp:ListItem>
                        <asp:ListItem>Andorra</asp:ListItem>
                        <asp:ListItem>Angola</asp:ListItem>
                        <asp:ListItem>Anguilla</asp:ListItem>
                        <asp:ListItem>Antarctica</asp:ListItem>
                        <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                        <asp:ListItem>Argentina</asp:ListItem>
                        <asp:ListItem>Armenia</asp:ListItem>
                        <asp:ListItem>Aruba</asp:ListItem>
                        <asp:ListItem>Austria</asp:ListItem>
                        <asp:ListItem>Azerbaijan</asp:ListItem>
                        <asp:ListItem>Bahamas</asp:ListItem>
                        <asp:ListItem>Bahrain</asp:ListItem>
                        <asp:ListItem>Bangladesh</asp:ListItem>
                        <asp:ListItem>Barbados</asp:ListItem>
                        <asp:ListItem>Belarus</asp:ListItem>
                        <asp:ListItem>Belgium</asp:ListItem>
                        <asp:ListItem>Belize</asp:ListItem>
                        <asp:ListItem>Benin</asp:ListItem>
                        <asp:ListItem>Bermuda</asp:ListItem>
                        <asp:ListItem>Bhutan</asp:ListItem>
                        <asp:ListItem>Bolivia</asp:ListItem>
                        <asp:ListItem>Bosnia and Herzegovina</asp:ListItem>
                        <asp:ListItem>Botswana</asp:ListItem>
                        <asp:ListItem>Bouvet Island</asp:ListItem>
                        <asp:ListItem>Brazil</asp:ListItem>
                        <asp:ListItem>British Indian Ocean Territory</asp:ListItem>
                        <asp:ListItem>British Virgin Islands</asp:ListItem>
                        <asp:ListItem>Brunei</asp:ListItem>
                        <asp:ListItem>Bulgaria</asp:ListItem>
                        <asp:ListItem>Burkina Faso</asp:ListItem>
                        <asp:ListItem>Burundi</asp:ListItem>
                        <asp:ListItem>Cambodia</asp:ListItem>
                        <asp:ListItem>Cameroon</asp:ListItem>
                        <asp:ListItem>Canada</asp:ListItem>
                        <asp:ListItem>Cape Verde</asp:ListItem>
                        <asp:ListItem>Cayman Islands</asp:ListItem>
                        <asp:ListItem>Central African Republic</asp:ListItem>
                        <asp:ListItem>Chad</asp:ListItem>
                        <asp:ListItem>Chile</asp:ListItem>
                        <asp:ListItem>China</asp:ListItem>
                        <asp:ListItem>Christmas Island</asp:ListItem>
                        <asp:ListItem>Cocos (Keeling) Islands</asp:ListItem>
                        <asp:ListItem>Colombia</asp:ListItem>
                        <asp:ListItem>Congo</asp:ListItem>
                        <asp:ListItem>Cook Islands</asp:ListItem>
                        <asp:ListItem>Costa Rica</asp:ListItem>
                        <asp:ListItem>Croatia</asp:ListItem>
                        <asp:ListItem>Cuba</asp:ListItem>
                        <asp:ListItem>Cyprus</asp:ListItem>
                        <asp:ListItem>Czech Republic</asp:ListItem>
                        <asp:ListItem>Democratic Republic of Congo</asp:ListItem>
                        <asp:ListItem>Denmark</asp:ListItem>
                        <asp:ListItem>Disputed Territory</asp:ListItem>
                        <asp:ListItem>Djibouti</asp:ListItem>
                        <asp:ListItem>Dominica</asp:ListItem>
                        <asp:ListItem>Dominican Republic</asp:ListItem>
                        <asp:ListItem>East Timor</asp:ListItem>
                        <asp:ListItem>Ecuador</asp:ListItem>
                        <asp:ListItem>Egypt</asp:ListItem>
                        <asp:ListItem>El Salvador</asp:ListItem>
                        <asp:ListItem>Equatorial Guinea</asp:ListItem>
                        <asp:ListItem>Eritrea</asp:ListItem>
                        <asp:ListItem>Estonia</asp:ListItem>
                        <asp:ListItem>Ethiopia</asp:ListItem>
                        <asp:ListItem>Falkland Islands</asp:ListItem>
                        <asp:ListItem>Faroe Islands</asp:ListItem>
                        <asp:ListItem>Federated States of Micronesia</asp:ListItem>
                        <asp:ListItem>Fiji</asp:ListItem>
                        <asp:ListItem>Finland</asp:ListItem>
                        <asp:ListItem>France</asp:ListItem>
                        <asp:ListItem>French Guyana</asp:ListItem>
                        <asp:ListItem>French Polynesia</asp:ListItem>
                        <asp:ListItem>French Southern Territories</asp:ListItem>
                        <asp:ListItem>Gabon</asp:ListItem>
                        <asp:ListItem>Gambia</asp:ListItem>
                        <asp:ListItem>Georgia</asp:ListItem>
                        <asp:ListItem>Germany</asp:ListItem>
                        <asp:ListItem>Ghana</asp:ListItem>
                        <asp:ListItem>Gibraltar</asp:ListItem>
                        <asp:ListItem>Greece</asp:ListItem>
                        <asp:ListItem>Greenland</asp:ListItem>
                        <asp:ListItem>Grenada</asp:ListItem>
                        <asp:ListItem>Guadeloupe</asp:ListItem>
                        <asp:ListItem>Guam</asp:ListItem>
                        <asp:ListItem>Guatemala</asp:ListItem>
                        <asp:ListItem>Guinea</asp:ListItem>
                        <asp:ListItem>Guinea-Bissau</asp:ListItem>
                        <asp:ListItem>Guyana</asp:ListItem>
                        <asp:ListItem>Haiti</asp:ListItem>
                        <asp:ListItem>Heard Island and McDonald Islands</asp:ListItem>
                        <asp:ListItem>Honduras</asp:ListItem>
                        <asp:ListItem>Hong Kong</asp:ListItem>
                        <asp:ListItem>Hungary</asp:ListItem>
                        <asp:ListItem>Iceland</asp:ListItem>
                        <asp:ListItem>India</asp:ListItem>
                        <asp:ListItem>Indonesia</asp:ListItem>
                        <asp:ListItem>Iran</asp:ListItem>
                        <asp:ListItem>Iraq</asp:ListItem>
                        <asp:ListItem>Iraq-Saudi Arabia Neutral Zone</asp:ListItem>
                        <asp:ListItem>Ireland</asp:ListItem>
                        <asp:ListItem>Israel</asp:ListItem>
                        <asp:ListItem>Italy</asp:ListItem>
                        <asp:ListItem>Ivory Coast</asp:ListItem>
                        <asp:ListItem>Jamaica</asp:ListItem>
                        <asp:ListItem>Japan</asp:ListItem>
                        <asp:ListItem>Jordan</asp:ListItem>
                        <asp:ListItem>Kazakhstan</asp:ListItem>
                        <asp:ListItem>Kenya</asp:ListItem>
                        <asp:ListItem>Kiribati</asp:ListItem>
                        <asp:ListItem>Kuwait</asp:ListItem>
                        <asp:ListItem>Kyrgyz Republic</asp:ListItem>
                        <asp:ListItem>Laos</asp:ListItem>
                        <asp:ListItem>Latvia</asp:ListItem>
                        <asp:ListItem>Lebanon</asp:ListItem>
                        <asp:ListItem>Lesotho</asp:ListItem>
                        <asp:ListItem>Liberia</asp:ListItem>
                        <asp:ListItem>Libya</asp:ListItem>
                        <asp:ListItem>Liechtenstein</asp:ListItem>
                        <asp:ListItem>Lithuania</asp:ListItem>
                        <asp:ListItem>Luxembourg</asp:ListItem>
                        <asp:ListItem>Macau</asp:ListItem>
                        <asp:ListItem>Macedonia</asp:ListItem>
                        <asp:ListItem>Madagascar</asp:ListItem>
                        <asp:ListItem>Malawi</asp:ListItem>
                        <asp:ListItem>Malaysia</asp:ListItem>
                        <asp:ListItem>Maldives</asp:ListItem>
                        <asp:ListItem>Mali</asp:ListItem>
                        <asp:ListItem>Malta</asp:ListItem>
                        <asp:ListItem>Marshall Islands</asp:ListItem>
                        <asp:ListItem>Martinique</asp:ListItem>
                        <asp:ListItem>Mauritania</asp:ListItem>
                        <asp:ListItem>Mauritius</asp:ListItem>
                        <asp:ListItem>Mayotte</asp:ListItem>
                        <asp:ListItem>Mexico</asp:ListItem>
                        <asp:ListItem>Moldova</asp:ListItem>
                        <asp:ListItem>Monaco</asp:ListItem>
                        <asp:ListItem>Mongolia</asp:ListItem>
                        <asp:ListItem>Montenegro</asp:ListItem>
                        <asp:ListItem>Montserrat</asp:ListItem>
                        <asp:ListItem>Morocco</asp:ListItem>
                        <asp:ListItem>Mozambique</asp:ListItem>
                        <asp:ListItem>Myanmar</asp:ListItem>
                        <asp:ListItem>Namibia</asp:ListItem>
                        <asp:ListItem>Nauru</asp:ListItem>
                        <asp:ListItem>Nepal</asp:ListItem>
                        <asp:ListItem>Netherlands Antilles</asp:ListItem>
                        <asp:ListItem>Netherlands</asp:ListItem>
                        <asp:ListItem>New Caledonia</asp:ListItem>
                        <asp:ListItem>New Zealand</asp:ListItem>
                        <asp:ListItem>Nicaragua</asp:ListItem>
                        <asp:ListItem>Niger</asp:ListItem>
                        <asp:ListItem>Nigeria</asp:ListItem>
                        <asp:ListItem>Niue</asp:ListItem>
                        <asp:ListItem>Norfolk Island</asp:ListItem>
                        <asp:ListItem>North Korea</asp:ListItem>
                        <asp:ListItem>Northern Mariana Islands</asp:ListItem>
                        <asp:ListItem>Norway</asp:ListItem>
                        <asp:ListItem>Oman</asp:ListItem>
                        <asp:ListItem>Pakistan</asp:ListItem>
                        <asp:ListItem>Palau</asp:ListItem>
                        <asp:ListItem>Palestinian Territories</asp:ListItem>
                        <asp:ListItem>Panama</asp:ListItem>
                        <asp:ListItem>Papua New Guinea</asp:ListItem>
                        <asp:ListItem>Paraguay</asp:ListItem>
                        <asp:ListItem>Peru</asp:ListItem>
                        <asp:ListItem>Philippines</asp:ListItem>
                        <asp:ListItem>Pitcairn Islands</asp:ListItem>
                        <asp:ListItem>Poland</asp:ListItem>
                        <asp:ListItem>Portugal</asp:ListItem>
                        <asp:ListItem>Puerto Rico</asp:ListItem>
                        <asp:ListItem>Qatar</asp:ListItem>
                        <asp:ListItem>Reunion</asp:ListItem>
                        <asp:ListItem>Romania</asp:ListItem>
                        <asp:ListItem>Russia</asp:ListItem>
                        <asp:ListItem>Rwanda</asp:ListItem>
                        <asp:ListItem>Saint Helena and Dependencies</asp:ListItem>
                        <asp:ListItem>Saint Kitts &amp; Nevis</asp:ListItem>
                        <asp:ListItem>Saint Lucia</asp:ListItem>
                        <asp:ListItem>Saint Pierre and Miquelon</asp:ListItem>
                        <asp:ListItem>Samoa</asp:ListItem>
                        <asp:ListItem>San Marino</asp:ListItem>
                        <asp:ListItem>Sao Tome and Principe</asp:ListItem>
                        <asp:ListItem>Saudi Arabia</asp:ListItem>
                        <asp:ListItem>Senegal</asp:ListItem>
                        <asp:ListItem>Serbia</asp:ListItem>
                        <asp:ListItem>Seychelles</asp:ListItem>
                        <asp:ListItem>Sierra Leone</asp:ListItem>
                        <asp:ListItem>Singapore</asp:ListItem>
                        <asp:ListItem>Slovakia</asp:ListItem>
                        <asp:ListItem>Slovenia</asp:ListItem>
                        <asp:ListItem>Solomon Islands</asp:ListItem>
                        <asp:ListItem>Somalia</asp:ListItem>
                        <asp:ListItem>South Africa</asp:ListItem>
                        <asp:ListItem>South Georgia and the South Sandwich Islands</asp:ListItem>
                        <asp:ListItem>South Korea</asp:ListItem>
                        <asp:ListItem>Spain</asp:ListItem>
                        <asp:ListItem>Spratly Islands</asp:ListItem>
                        <asp:ListItem>Sri Lanka</asp:ListItem>
                        <asp:ListItem>Sudan</asp:ListItem>
                        <asp:ListItem>Suriname</asp:ListItem>
                        <asp:ListItem>Svalbard and Jan Mayen Islands</asp:ListItem>
                        <asp:ListItem>Swaziland</asp:ListItem>
                        <asp:ListItem>Sweden</asp:ListItem>
                        <asp:ListItem>Switzerland</asp:ListItem>
                        <asp:ListItem>Syria</asp:ListItem>
                        <asp:ListItem>Taiwan</asp:ListItem>
                        <asp:ListItem>Tajikistan</asp:ListItem>
                        <asp:ListItem>Tanzania</asp:ListItem>
                        <asp:ListItem>Thailand</asp:ListItem>
                        <asp:ListItem>Togo</asp:ListItem>
                        <asp:ListItem>Tokelau</asp:ListItem>
                        <asp:ListItem>Tonga</asp:ListItem>
                        <asp:ListItem>Trinidad and Tobago</asp:ListItem>
                        <asp:ListItem>Tunisia</asp:ListItem>
                        <asp:ListItem>Turkey</asp:ListItem>
                        <asp:ListItem>Turkmenistan</asp:ListItem>
                        <asp:ListItem>Turks and Caicos Islands</asp:ListItem>
                        <asp:ListItem>Tuvalu</asp:ListItem>
                        <asp:ListItem>US Virgin Islands</asp:ListItem>
                        <asp:ListItem>Uganda</asp:ListItem>
                        <asp:ListItem>Ukraine</asp:ListItem>
                        <asp:ListItem>Union of the Comoros</asp:ListItem>
                        <asp:ListItem>United Arab Emirates</asp:ListItem>
                        <asp:ListItem>United Kingdom</asp:ListItem>
                        <asp:ListItem>United States Minor Outlying Islands</asp:ListItem>
                        <asp:ListItem>United States</asp:ListItem>
                        <asp:ListItem>Uruguay</asp:ListItem>
                        <asp:ListItem>Uzbekistan</asp:ListItem>
                        <asp:ListItem>Vanuatu</asp:ListItem>
                        <asp:ListItem>Vatican City</asp:ListItem>
                        <asp:ListItem>Venezuela</asp:ListItem>
                        <asp:ListItem>Vietnam</asp:ListItem>
                        <asp:ListItem>Wallis and Futuna Islands</asp:ListItem>
                        <asp:ListItem>Western Sahara</asp:ListItem>
                        <asp:ListItem>Yemen</asp:ListItem>
                        <asp:ListItem>Zambia</asp:ListItem>
                        <asp:ListItem>Zimbabwe</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">What is your Procurement Organisational Model?
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditModel" CssClass="styled" runat="server">
                        <asp:ListItem Value="0" Selected="True">Procurement model</asp:ListItem>
                        <asp:ListItem Value="1">Centralised Procurement Function</asp:ListItem>
                        <asp:ListItem Value="2">Decentralised Procurement Function</asp:ListItem>
                        <asp:ListItem Value="3">Centre-Led Procurement Function</asp:ListItem>
                        <asp:ListItem Value="4">Procurement strategy is centralised, but execution is de-centralised</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">To whom does procurement report in your organisation?
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditReportingLine" CssClass="styled" runat="server">
                        <asp:ListItem Value="0" Selected="True">Procurement function reports to…</asp:ListItem>
                        <asp:ListItem Value="1">CEO</asp:ListItem>
                        <asp:ListItem Value="2">CFO</asp:ListItem>
                        <asp:ListItem Value="3">COO</asp:ListItem>
                        <asp:ListItem Value="4">CIO</asp:ListItem>
                        <asp:ListItem Value="5">Legal Council</asp:ListItem>
                        <asp:ListItem Value="6">Head of Supply Chain</asp:ListItem>
                        <asp:ListItem Value="7">Division or Business Unit Head</asp:ListItem>
                        <asp:ListItem Value="8">Regional or Global Procurement</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">What is the approximate amount of expenditure you are responsible for or manage?
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditSpendUnder" runat="server" CssClass="styled">
                        <asp:ListItem Value="0" Selected="True">Spend under influence</asp:ListItem>
                        <asp:ListItem Value="1">$1 billion or more</asp:ListItem>
                        <asp:ListItem Value="2">$500 million to $999.9 million</asp:ListItem>
                        <asp:ListItem Value="3">$100 million to $499.9 million</asp:ListItem>
                        <asp:ListItem Value="4">$50 million to $99.9 million</asp:ListItem>
                        <asp:ListItem Value="5">$20 million to $49.9 million</asp:ListItem>
                        <asp:ListItem Value="6">$10 million to $19.9 million</asp:ListItem>
                        <asp:ListItem Value="7">$5 million to $9.9 million</asp:ListItem>
                        <asp:ListItem Value="8">$2.5 million to $4.9 million</asp:ListItem>
                        <asp:ListItem Value="9">$1 million to $2.49 million</asp:ListItem>
                        <asp:ListItem Value="10">$500,000 to $999,999</asp:ListItem>
                        <asp:ListItem Value="11">Less than $500,000</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">How many people work in the procurement & contracting department?
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditEmployeeCompany" runat="server" CssClass="styled">
                        <asp:ListItem Value="0" Selected="True">Number of employees</asp:ListItem>
                        <asp:ListItem Value="1">100+</asp:ListItem>
                        <asp:ListItem Value="2">75 to 99</asp:ListItem>
                        <asp:ListItem Value="3">50 to 74</asp:ListItem>
                        <asp:ListItem Value="4">30 to 49</asp:ListItem>
                        <asp:ListItem Value="5">15 to 29</asp:ListItem>
                        <asp:ListItem Value="6">10 to 14</asp:ListItem>
                        <asp:ListItem Value="7">9</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">7</asp:ListItem>
                        <asp:ListItem Value="10">6</asp:ListItem>
                        <asp:ListItem Value="11">5</asp:ListItem>
                        <asp:ListItem Value="12">4</asp:ListItem>
                        <asp:ListItem Value="13">3</asp:ListItem>
                        <asp:ListItem Value="14">2</asp:ListItem>
                        <asp:ListItem Value="15">1</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">Which of the below best describes your category domain expertise:
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditExpertise" CssClass="styled" runat="server">
                        <asp:ListItem Value="0" Selected="True">Category you manage currently</asp:ListItem>
                        <asp:ListItem Value="1">Generalist Direct & Indirects</asp:ListItem>
                        <asp:ListItem Value="2">Generalist Directs</asp:ListItem>
                        <asp:ListItem Value="3">Generalist Indirects</asp:ListItem>
                        <asp:ListItem Value="4">Chemicals</asp:ListItem>
                        <asp:ListItem Value="5">Energy</asp:ListItem>
                        <asp:ListItem Value="6">Facilities</asp:ListItem>
                        <asp:ListItem Value="7">Fleet</asp:ListItem>
                        <asp:ListItem Value="8">Heavy Machinery and Equipment</asp:ListItem>
                        <asp:ListItem Value="9">HR Services</asp:ListItem>
                        <asp:ListItem Value="10">ICT</asp:ListItem>
                        <asp:ListItem Value="11">Ingredients</asp:ListItem>
                        <asp:ListItem Value="12">Marketing</asp:ListItem>
                        <asp:ListItem Value="13">Mining Equipment</asp:ListItem>
                        <asp:ListItem Value="14">MRO and Capex</asp:ListItem>
                        <asp:ListItem Value="15">Packaging</asp:ListItem>
                        <asp:ListItem Value="16">Professional Services</asp:ListItem>
                        <asp:ListItem Value="17">Raw Materials</asp:ListItem>
                        <asp:ListItem Value="18">Travel</asp:ListItem>
                        <asp:ListItem Value="19">Wardrobe & Workwear</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">Procurement Annual revenue :
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditAnnualRevenue" runat="server" CssClass="styled">
                        <asp:ListItem Value="0" Selected="True">Spend under your influence </asp:ListItem>
                        <asp:ListItem Value="1">$1 billion or more</asp:ListItem>
                        <asp:ListItem Value="2">$500 million to $999.9 million</asp:ListItem>
                        <asp:ListItem Value="3">$100 million to $499.9 million</asp:ListItem>
                        <asp:ListItem Value="4">$50 million to $99.9 million</asp:ListItem>
                        <asp:ListItem Value="5">$20 million to $49.9 million</asp:ListItem>
                        <asp:ListItem Value="6">$10 million to $19.9 million</asp:ListItem>
                        <asp:ListItem Value="7">$5 million to $9.9 million</asp:ListItem>
                        <asp:ListItem Value="8">$2.5 million to $4.9 million</asp:ListItem>
                        <asp:ListItem Value="9">$1 million to $2.49 million</asp:ListItem>
                        <asp:ListItem Value="10">$500,000 to $999,999</asp:ListItem>
                        <asp:ListItem Value="11">Less than $500,000</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">Geographical influence
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditGeographical" runat="server" CssClass="styled">
                        <asp:ListItem Value="0" Selected="True">Geographical influence</asp:ListItem>
                        <asp:ListItem Value="1">Local</asp:ListItem>
                        <asp:ListItem Value="2">Regional</asp:ListItem>
                        <asp:ListItem Value="3">Global</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">How many years have you worked in procurement and supply chain? (Round up to the
                nearest whole year)?
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditProcurementYear" runat="server" CssClass="styled">
                        <asp:ListItem Value="0" Selected="True">Years of procurement experience</asp:ListItem>
                        <asp:ListItem Value="1">Less than 1 year</asp:ListItem>
                        <asp:ListItem Value="3">1 - 3 years</asp:ListItem>
                        <asp:ListItem Value="5">3 - 5 years</asp:ListItem>
                        <asp:ListItem Value="10">5 - 10 years</asp:ListItem>
                        <asp:ListItem Value="11">10 or more years</asp:ListItem>
                        <asp:ListItem Value="12">Not applicable</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">What is your Procurement qualification?
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="ddlEditProLevel" CssClass="styled" runat="server">
                        <asp:ListItem Value="0" Selected="True">Procurement qualifications</asp:ListItem>
                        <asp:ListItem Value="1">Undergraduate degree in procurement / supply chain </asp:ListItem>
                        <asp:ListItem Value="2">Postgraduate degree in procurement / supply chain </asp:ListItem>
                        <asp:ListItem Value="3">CIPS: Member (MCIPS)</asp:ListItem>
                        <asp:ListItem Value="4">CIPS: Fellow (FCIPS)</asp:ListItem>
                        <asp:ListItem Value="5">AAPCM: Member </asp:ListItem>
                        <asp:ListItem Value="6">AAPCM: Fellow </asp:ListItem>
                        <asp:ListItem Value="7">Other </asp:ListItem>
                        <asp:ListItem Value="8">Not applicable</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">What is your highest level of education?
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="5" class="ssec">
                    <asp:DropDownList ID="cboEditQualifications" CssClass="styled" runat="server">
                        <asp:ListItem Value="0" Selected="True">Level of education</asp:ListItem>
                        <asp:ListItem Value="1">Secondary school</asp:ListItem>
                        <asp:ListItem Value="2">Certificate</asp:ListItem>
                        <asp:ListItem Value="3">Diploma</asp:ListItem>
                        <asp:ListItem Value="4">Advanced Diploma</asp:ListItem>
                        <asp:ListItem Value="5">Undergraduate</asp:ListItem>
                        <asp:ListItem Value="6">Postgraduate</asp:ListItem>
                        <asp:ListItem Value="7">Masters</asp:ListItem>
                        <asp:ListItem Value="8">Doctorate</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Expiry Date
                </td>
                <td colspan="2" class="ssec">
                    <asp:TextBox ID="txtEditExiryDate" runat="server" />
                    <asp:ImageButton ID="ImageButton12" runat="server" Height="16px" ImageUrl="~/Images/cal.gif"
                        Width="16px" ImageAlign="Bottom" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" PopupButtonID="ImageButton7"
                        TargetControlID="txtEditExiryDate" Format="dd-MM-yyyy">
                    </ajaxToolkit:CalendarExtender>
                </td>
                <td colspan="3">Status:&nbsp;
                <asp:Label ID="lblEditStatus" runat="server"></asp:Label><br>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <b>Your previous category experience</b>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="3">
                    <input type="checkbox" name="indirect" value="15" class="styled" />
                    <b>Indirect</b> - General
                <div>
                    <input type="checkbox" name="indirect" value="1" class="styled" />
                    <b>IT&amp;T Services:</b> Software, Hardware, Telco, etc.
                </div>
                    <div>
                        <input type="checkbox" name="indirect" value="2" class="styled" />
                        <b>Marketing Services:</b> ABT, BTL, Print, etc.
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="3" class="styled" />
                        <b>HR Services:</b> Labour hire, Recruitment, Training, etc.
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="4" class="styled" />
                        <b>Professional Services:</b> Legal, Audit & Accounting, Security, etc.
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="5" class="styled" />
                        <b>Facilities</b> and Corporate Real Estate (FM/CRE)
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="6" class="styled" />
                        <b>Utilities:</b> Gas, Electricity, Water
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="7" class="styled" />
                        <b>Capex:</b> Heavy machinery and equipment
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="8" class="styled" />
                        <b>MRO</b> Maintenance, Repairs, Operations and Consumables
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="9" class="styled" />
                        <b>Office:</b> Stationery, post,
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="10" class="styled" />
                        <b>Travel</b>
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="11" class="styled" />
                        <b>Fleet</b>
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="13" class="styled" />
                        <b>Logistics</b>
                    </div>
                    <div>
                        <input type="checkbox" name="indirect" value="14" class="styled" />
                        <b>Other</b>
                    </div>
                </td>
                <td valign="top" colspan="3">
                    <input type="checkbox" name="direct" value="6" class="styled" />
                    <b>Directs</b> - General
                <br />
                <div>
                    <input type="checkbox" name="direct" value="1" class="styled" />
                    <b>Packaging:</b> PET, Glass, Print, Labels, etc.
                </div>
                <div>
                    <input type="checkbox" name="direct" value="2" class="styled" />
                    <b>Ingredients</b>
                </div>
                <div>
                    <input type="checkbox" name="direct" value="3" class="styled" />
                    <b>Chemicals</b>
                </div>
                <div>
                    <input type="checkbox" name="direct" value="4" class="styled" />
                    <b>Industry specific</b> production material
                </div>
                <div>
                    <input type="checkbox" name="direct" value="5" class="styled" />
                    <b>Other</b>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:ImageButton runat="server" ID="btnEditSaveProfile" OnClick="btnEditSaveProfile_Click"
                    ImageUrl="images/save.png" Width="96" Height="37" />
                <asp:ImageButton runat="server" ID="btnEditProfileClose" ImageUrl="images/close.png"
                    Width="96" Height="37" />
                <asp:ImageButton runat="server" ID="btnEditProfileExpire" OnClick="btnEditProfileExpire_Click"
                    ImageUrl="images/expired.png" Width="192" Height="37" />
            </td>
        </tr>
    </table>
    <br /><br />
    <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
        <tr>
            <td colspan="6"><b>Test Permission</b></td>
        </tr>
       <tr>
            <td style="height:10px" colspan="6"></td>
        </tr>
        <tr>
            <td colspan="6"><asp:DataGrid ID="dtgPermission" runat="server" AllowPaging="false" AllowSorting="false"
                AutoGenerateColumns="False" CssClass="grdMain" 
                Width="100%" GridLines="None" PageSize="20">
                <HeaderStyle CssClass="gridHeader" />
                <PagerStyle Mode="NumericPages"  CssClass="pager" HorizontalAlign="Center"  />
                <ItemStyle CssClass="gridItem"  />
                <Columns>
                    <asp:BoundColumn DataField="fullName" ItemStyle-Width="12%" HeaderText="Name" HeaderStyle-Width="12%" SortExpression="fullName"></asp:BoundColumn>

                                                                <asp:BoundColumn DataField="email" HeaderText="Email" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" HeaderStyle-Width="20%" SortExpression="email"></asp:BoundColumn>
                                                                <%--<asp:BoundColumn DataField="company" HeaderText="Company" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%" HeaderStyle-Width="10%" SortExpression="company">
                                                    </asp:BoundColumn>--%>
                                                                <asp:TemplateColumn HeaderText="PKE Result" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                                                                    <ItemTemplate>
                                                                        <input type="checkbox" id="chkSga" runat="server" value='<%#Eval("Id") %>' checked='<%#Eval("sgaResult") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                               
                                                                <asp:TemplateColumn HeaderText="PKE Test" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                                                                    <ItemTemplate>
                                                                        <input type="checkbox" id="chkSgatest" runat="server" value='<%#Eval("Id") %>' checked='<%#Eval("takeTNA") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                               
                </Columns>
            </asp:DataGrid></td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:ImageButton runat="server" ID="ibtnUpdate" OnClick="ibtnUpdate_Click"
                    ImageUrl="images/save.png" Width="96" Height="37" />
            </td>
        </tr> 
        <tr>
            <td style="height:10px" colspan="6"></td>
        </tr>
    </table>
    <br />
    <table width="100%" border="0" cellspacing="1" cellpadding="1" class="tform">
        <tr>
            <td colspan="6"><b> Procurement Benchmark Assessment</b></td>
        </tr>
        <tr>
            <td style="height:10px" colspan="6"></td>
        </tr>
        <tr>
            <td colspan="6"><asp:DataGrid ID="grdCMC" runat="server" AllowPaging="false" AllowSorting="false"
                                                AutoGenerateColumns="False" CssClass="grdMain" 
                                                OnItemDataBound="grdCMC_ItemDataBound" OnItemCommand="grdCMC_ItemCommand" 
                                                Width="100%" GridLines="None" PageSize="20">
                                                <HeaderStyle CssClass="gridHeader" />
                                                <PagerStyle Mode="NumericPages"  CssClass="pager" HorizontalAlign="Center"  />
                                                <ItemStyle CssClass="gridItem"  />
                                                <Columns>
                                                    <asp:BoundColumn DataField="name" ItemStyle-Width="16%" HeaderText="Name" HeaderStyle-Width="16%" SortExpression="name">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="company" HeaderText="Company" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="14%" HeaderStyle-Width="15%" SortExpression="company">
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn ItemStyle-Width="8%" HeaderStyle-Width="10%" SortExpression="marks" HeaderText="Marks">
                                                        <ItemTemplate>
                                                           <%#Eval("marks")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn ItemStyle-Width="12%" HeaderStyle-Width="12%" SortExpression="minDiff" HeaderText="Duration">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblDuration" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn ItemStyle-Width="12%" HeaderStyle-Width="12%" SortExpression="testDate" HeaderText="Assesment Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssesmentDate" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                 <%--   <asp:TemplateColumn ItemStyle-Width="11%" HeaderStyle-Width="11%"  HeaderText="Report Link">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hylLink" runat="server"></asp:HyperLink>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>--%>
                                                    <asp:TemplateColumn ItemStyle-Width="15%" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="iBtnDelete" runat="server" CausesValidation="false" AlternateText="Delete" style="height:25px;width:25px;" OnClientClick="return confirm('Are you sure you want to delete this record?');" CommandArgument='<%#Eval("testId") %>' CommandName="Delete" ToolTip="Delete" ImageUrl="~/webadmin/images/disapprove_icon.png" />
                                                            <%--&nbsp;
                                                            <a target="_blank" href="ShowCMCPdf.aspx?id=<%#Eval("testId") %>&userId=<%#Eval("userId") %>">
                                            <img src="../innerimages/icon-pdf.gif" style="height:25px;width:25px;" alt="" /></a>--%>
                                                            &nbsp;
                                                            <asp:ImageButton ID="iBtnGraph" runat="server" CausesValidation="false" AlternateText="Graph" Style="height: 25px; width: 25px;" CommandArgument='<%#Eval("testId") %>' CommandName="Graph" ToolTip="Graph" ImageUrl="~/webadmin/images/img-graph-icon.gif" />
                                    &nbsp;
                                                            <asp:ImageButton ID="iBtnEdit" runat="server" CausesValidation="false" AlternateText="Edit" Style="height: 25px; width: 25px;" CommandArgument='<%#Eval("testId") %>' CommandName="Edit" ToolTip="Edit" ImageUrl="~/webadmin/images/edit.png" />
                                    &nbsp;
                                                            <asp:ImageButton ID="iBtnDrill" runat="server" CausesValidation="false" AlternateText="Graph" Style="height: 30px; width: 30px;" CommandArgument='<%#Eval("testId") %>' CommandName="drilldown" ToolTip="drilldown" ImageUrl="~/webadmin/images/drilldown.png" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid></td>
            </tr>
            <tr>
                <td style="height: 10px" colspan="6"></td>
            </tr>
        </table>
        <br />
       
    </form>
</body>
</html>



