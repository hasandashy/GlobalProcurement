<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SGA.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="clearfix"></div>

    <span class="dotline top1 bdrt1"></span>

    <div class="container ">
        <div class="heading two-line  marT50 marB50">
            <h2>Your invitation to participate in the inaugural <span>Global Procurement Capability Benchmark.</span></h2>
            <p>
                Do you know what skills and knowledge you will need
                <br>
                in order to deliver tomorrow – and into the future?
            </p>
        </div>
    </div>


    <span class="dotline"></span>




    <div class="block1 greybg padtop-none full-graybg ">
        <div class="container ">


            <div class="info-block exchange1 ">
                <div class="audit-form">
                    <form class="infusion-form" id="infusion-form">

                        <div class="dis_block clearfix">
                              <div class="form-group" style="text-align:center;">
                                           <asp:Label ID="lblErrorRegister" ClientIDMode="Static" runat="server" ForeColor="Red"></asp:Label>
                               </div>
                            <div class="form-group">

                                <input required class="form-control" id="inf_field_FirstName" maxlength="250" name="inf_field_FirstName" type="text" placeholder="First Name *" />
                            </div>
                            <div class="form-group">

                                <input required id="inf_field_LastName" name="inf_field_LastName" maxlength="250" type="text" class="form-control" placeholder="Last Name *" />
                            </div>




                            <div class="form-group">

                                <select id="jobRole" name="jobRole" class="form-control">
                                    <option value="1">Analyst</option>
                                    <option value="2">Procurement Support</option>
                                    <option value="3">Strategic Sourcing</option>
                                    <option value="4">Vendor Manager/ Supplier Relationship Manager</option>
                                    <option value="5">Category Manager</option>
                                    <option value="6">Procurement Leader</option>
                                    <option value="7">Supply Chain</option>
                                    <option value="8">Non-Procurement: CXO</option>
                                    <option value="9">Non-Procurement: Director</option>
                                    <option value="10">Non-Procurement: Manager</option>
                                    <option value="11">Non-Procurement: Professional</option>
                                    <option value="12">Non-Procurement: Trainee</option>
                                    <option value="13">Other</option>

                                    <!--<option value="1">Analyst</option>
		<option value="2">Procurement Support</option>
		<option value="3">Strategic Sourcing</option>
		<option value="4">Vendor Manager/ Supplier Relationship Manager</option>
		<option value="5">Category Manager</option>
		<option value="6">Procurement Leader</option>
		<option value="7">Supply Chain</option>
		<option value="8">Non-Procurement: CXO</option>
		<option value="9">Non-Procurement: Director</option>
		<option value="10">Non-Procurement: Manager</option>
		<option value="11">Non-Procurement: Professional</option>
		<option value="12">Non-Procurement: Trainee</option>-->
                                </select>
                            </div>
                            <div class="form-group">
                                <input required id="inf_field_Email" name="inf_field_Email" type="email" maxlength="250" class="form-control" placeholder="Email Address *" />
                            </div>

                            <div class="form-group">
                                <select id="membershipAssociation" name="membershipAssociation" class="form-control">
                                    <option selected value="0">Membership Association *</option>
                                    <option value="AACAM">AACAM - Asociación Argentina de Compras Administracion de Materiales y Logistica</option>
                                    <option value="ABCAL">ABCAL - Association Belge des Cardes d’Achat et de Logistique</option>
                                    <option value="ADACI">ADACI - Associazione Italiana Acquiste E Supply Management</option>
                                    <option value="AERCE">AERCE - Associación Espanola de Professionales de Compras, Contractión y Aprovisionamientos</option>
                                    <option value="APCADEC">APCADEC - Portuguese association for Purchasing and Supply Management</option>
                                    <option value="APPI">APPI - Asosiasi Pengacara Pengadaan Indonesia</option>
                                    <option value="APROCAL">APROCAL - Asociación de Profesionales en Compras, Abastecimiento y Logística, A.C.</option>
                                    <option value="BME">BME - Bundesverband Materialwirtschaft, Einkauf und Logistik</option>
                                    <option value="BMOE">BMOE - Bundesverband Materialwirtschaft, Einkauf und Logistik in Osterreich</option>
                                    <option value="CAP">CAP - Croatian Association of Purchasing</option>
                                    <option value="CAPP">CAPP - Caribbean Association of Procurement Professionals</option>
                                    <option value="CBEC">CBEC - Brazilian Council of Purchasing Executives</option>
                                    <option value="CFLP">CFLP - China Federation of Logistics and Purchasing</option>
                                    <option value="CIPSMN">CIPSMN - Chartered Institute of Purchasing & Supply Management of Nigeria</option>
                                    <option value="DILF">DILF - Danish Purchasing and Logistics Forum</option>
                                    <option value="Forum Einkauf">Forum Einkauf - Forum Einkauf</option>
                                    <option value="FZUP">FZUP - Federation of Purchases and Supply Management of Russia</option>
                                    <option value="HALPIM">HALPIM - Hungarian Association of Logistics, Purchasing and Inventory Management</option>
                                    <option value="HPI">HPI - Hellenic Purchasing Institute</option>
                                    <option value="IAPI">IAPI - Ikatan Ahli Pengadaan Indonesia</option>
                                    <option value="IFPSM">IFPSM - International Federation of Purchasing & Supply Management</option>
                                    <option value="IIMM">IIMM - Indian Institute of Materials Management</option>
                                    <option value="IIPMM">IIPMM - Irish Institute of Purchasing and Materials Management</option>
                                    <option value="IPLMA">IPLMA - Israeli Purchasing & Logistics Managers Association</option>
                                    <option value="IPPU">IPPU - Institute of Procurement Professionals of Uganda</option>
                                    <option value="IPSHK">IPSHK - The Institute of Purchasing and Supply of Hong Kong</option>
                                    <option value="ISMM">ISMM - Institute of Supply and Materials Management</option>
                                    <option value="JMMA">JMMA - Japan Materials Management Association</option>
                                    <option value="KISM">KISM - Kenya Institute of Supplies Management</option>
                                    <option value="LOGY">LOGY - Finnish Association of Purchasing and Logistics</option>
                                    <option value="MIPMM">MIPMM - Malaysian Institute of Purchasing & Materials Management</option>
                                    <option value="MIPS">MIPS - Malawi Institute of Procurement and Supply</option>
                                    <option value="NEVI">NEVI - Nederlandse Vereniging voor Inkoop Management</option>
                                    <option value="NIMA">NIMA - Norsk Forbund for Innkjøp og Logistikk (The Norwegian Association of Purchasing and Logistics)</option>
                                    <option value="PASIA">PASIA - Procurement and Supply Institute of Asia</option>
                                    <option value="PISM">PISM - Philippine Institute for Supply Management</option>
                                    <option value="PROCURE">PROCURE - procure.ch Swiss Association for Purchasing and Supply Management</option>
                                    <option value="PROLOG">PROLOG - Estonian Purchasing and Supply Chain Management Association</option>
                                    <option value="PSCMT">PSCMT - Purchasing and Supply Chain Management Association of Thailand</option>
                                    <option value="PSML">PSML - Polish Supply Management Leaders</option>
                                    <option value="SAPPP">SAPPP - Serbian Association of Professionals in Public Procurement</option>
                                    <option value="SCMA">SCMA - Supply Chain Management Association</option>
                                    <option value="SILF">SILF - Swedish Purchasing and Logistic Association</option>
                                    <option value="SIMM">SIMM - Singapore Institute of Materials Management</option>
                                    <option value="SMIT">SMIT - Supply Management Institute, Taiwan</option>
                                    <option value="SSCPA">SSCPA - Serbian Supply Chain Professionals Association</option>
                                    <option value="TUSAYDER">TUSAYDER - TUSAYDER</option>
                                    <option value="ZNS">ZNS - Zdruzenje nabavnikov Slovenije (Slovenian Purchasing Association)</option>
                                    <option value="Other - CIPS">Other: CIPS – Chartered Institute of Purchasing & Supply</option>
                                    <option value="Other - ISM">Other: ISM – Institute of Supply Management</option>
                                </select>
                            </div>

                            <div class="form-group">

                                <select id="country" name="country" class="form-control">
                                    <option selected value="0">Select Country *</option>
                                    <option>Australia</option>
                                    <option>Afghanistan</option>
                                    <option>Aland Islands</option>
                                    <option>Albania</option>
                                    <option>American Samoa</option>
                                    <option>Andorra</option>
                                    <option>Angola</option>
                                    <option>Anguilla</option>
                                    <option>Antarctica</option>
                                    <option>Antigua and Barbuda</option>
                                    <option>Argentina</option>
                                    <option>Armenia</option>
                                    <option>Aruba</option>
                                    <option>Austria</option>
                                    <option>Azerbaijan</option>
                                    <option>Bahamas</option>
                                    <option>Bahrain</option>
                                    <option>Bangladesh</option>
                                    <option>Barbados</option>
                                    <option>Belarus</option>
                                    <option>Belgium</option>
                                    <option>Belize</option>
                                    <option>Benin</option>
                                    <option>Bermuda</option>
                                    <option>Bhutan</option>
                                    <option>Bolivia</option>
                                    <option>Bosnia and Herzegovina</option>
                                    <option>Botswana</option>
                                    <option>Bouvet Island</option>
                                    <option>Brazil</option>
                                    <option>British Indian Ocean Territory</option>
                                    <option>British Virgin Islands</option>
                                    <option>Brunei</option>
                                    <option>Bulgaria</option>
                                    <option>Burkina Faso</option>
                                    <option>Burundi</option>
                                    <option>Cambodia</option>
                                    <option>Cameroon</option>
                                    <option>Canada</option>
                                    <option>Cape Verde</option>
                                    <option>Cayman Islands</option>
                                    <option>Central African Republic</option>
                                    <option>Chad</option>
                                    <option>Chile</option>
                                    <option>China</option>
                                    <option>Christmas Island</option>
                                    <option>Cocos (Keeling) Islands</option>
                                    <option>Colombia</option>
                                    <option>Congo</option>
                                    <option>Cook Islands</option>
                                    <option>Costa Rica</option>
                                    <option>Croatia</option>
                                    <option>Cuba</option>
                                    <option>Cyprus</option>
                                    <option>Czech Republic</option>
                                    <option>Democratic Republic of Congo</option>
                                    <option>Denmark</option>
                                    <option>Disputed Territory</option>
                                    <option>Djibouti</option>
                                    <option>Dominica</option>
                                    <option>Dominican Republic</option>
                                    <option>East Timor</option>
                                    <option>Ecuador</option>
                                    <option>Egypt</option>
                                    <option>El Salvador</option>
                                    <option>Equatorial Guinea</option>
                                    <option>Eritrea</option>
                                    <option>Estonia</option>
                                    <option>Ethiopia</option>
                                    <option>Falkland Islands</option>
                                    <option>Faroe Islands</option>
                                    <option>Federated States of Micronesia</option>
                                    <option>Fiji</option>
                                    <option>Finland</option>
                                    <option>France</option>
                                    <option>French Guyana</option>
                                    <option>French Polynesia</option>
                                    <option>French Southern Territories</option>
                                    <option>Gabon</option>
                                    <option>Gambia</option>
                                    <option>Georgia</option>
                                    <option>Germany</option>
                                    <option>Ghana</option>
                                    <option>Gibraltar</option>
                                    <option>Greece</option>
                                    <option>Greenland</option>
                                    <option>Grenada</option>
                                    <option>Guadeloupe</option>
                                    <option>Guam</option>
                                    <option>Guatemala</option>
                                    <option>Guinea</option>
                                    <option>Guinea-Bissau</option>
                                    <option>Guyana</option>
                                    <option>Haiti</option>
                                    <option>Heard Island and McDonald Islands</option>
                                    <option>Honduras</option>
                                    <option>Hong Kong</option>
                                    <option>Hungary</option>
                                    <option>Iceland</option>
                                    <option>India</option>
                                    <option>Indonesia</option>
                                    <option>Iran</option>
                                    <option>Iraq</option>
                                    <option>Iraq-Saudi Arabia Neutral Zone</option>
                                    <option>Ireland</option>
                                    <option>Israel</option>
                                    <option>Italy</option>
                                    <option>Ivory Coast</option>
                                    <option>Jamaica</option>
                                    <option>Japan</option>
                                    <option>Jordan</option>
                                    <option>Kazakhstan</option>
                                    <option>Kenya</option>
                                    <option>Kiribati</option>
                                    <option>Kuwait</option>
                                    <option>Kyrgyz Republic</option>
                                    <option>Laos</option>
                                    <option>Latvia</option>
                                    <option>Lebanon</option>
                                    <option>Lesotho</option>
                                    <option>Liberia</option>
                                    <option>Libya</option>
                                    <option>Liechtenstein</option>
                                    <option>Lithuania</option>
                                    <option>Luxembourg</option>
                                    <option>Macau</option>
                                    <option>Macedonia</option>
                                    <option>Madagascar</option>
                                    <option>Malawi</option>
                                    <option>Malaysia</option>
                                    <option>Maldives</option>
                                    <option>Mali</option>
                                    <option>Malta</option>
                                    <option>Marshall Islands</option>
                                    <option>Martinique</option>
                                    <option>Mauritania</option>
                                    <option>Mauritius</option>
                                    <option>Mayotte</option>
                                    <option>Mexico</option>
                                    <option>Moldova</option>
                                    <option>Monaco</option>
                                    <option>Mongolia</option>
                                    <option>Montenegro</option>
                                    <option>Montserrat</option>
                                    <option>Morocco</option>
                                    <option>Mozambique</option>
                                    <option>Myanmar</option>
                                    <option>Namibia</option>
                                    <option>Nauru</option>
                                    <option>Nepal</option>
                                    <option>Netherlands Antilles</option>
                                    <option>Netherlands</option>
                                    <option>New Caledonia</option>
                                    <option>New Zealand</option>
                                    <option>Nicaragua</option>
                                    <option>Niger</option>
                                    <option>Nigeria</option>
                                    <option>Niue</option>
                                    <option>Norfolk Island</option>
                                    <option>North Korea</option>
                                    <option>Northern Mariana Islands</option>
                                    <option>Norway</option>
                                    <option>Oman</option>
                                    <option>Pakistan</option>
                                    <option>Palau</option>
                                    <option>Palestinian Territories</option>
                                    <option>Panama</option>
                                    <option>Papua New Guinea</option>
                                    <option>Paraguay</option>
                                    <option>Peru</option>
                                    <option>Philippines</option>
                                    <option>Pitcairn Islands</option>
                                    <option>Poland</option>
                                    <option>Portugal</option>
                                    <option>Puerto Rico</option>
                                    <option>Qatar</option>
                                    <option>Reunion</option>
                                    <option>Romania</option>
                                    <option>Russia</option>
                                    <option>Rwanda</option>
                                    <option>Saint Helena and Dependencies</option>
                                    <option>Saint Kitts &amp; Nevis</option>
                                    <option>Saint Lucia</option>
                                    <option>Saint Pierre and Miquelon</option>
                                    <option>Samoa</option>
                                    <option>San Marino</option>
                                    <option>Sao Tome and Principe</option>
                                    <option>Saudi Arabia</option>
                                    <option>Senegal</option>
                                    <option>Serbia</option>
                                    <option>Seychelles</option>
                                    <option>Sierra Leone</option>
                                    <option>Singapore</option>
                                    <option>Slovakia</option>
                                    <option>Slovenia</option>
                                    <option>Solomon Islands</option>
                                    <option>Somalia</option>
                                    <option>South Africa</option>
                                    <option>South Georgia and the South Sandwich Islands</option>
                                    <option>South Korea</option>
                                    <option>Spain</option>
                                    <option>Spratly Islands</option>
                                    <option>Sri Lanka</option>
                                    <option>Sudan</option>
                                    <option>Suriname</option>
                                    <option>Svalbard and Jan Mayen Islands</option>
                                    <option>Swaziland</option>
                                    <option>Sweden</option>
                                    <option>Switzerland</option>
                                    <option>Syria</option>
                                    <option>Taiwan</option>
                                    <option>Tajikistan</option>
                                    <option>Tanzania</option>
                                    <option>Thailand</option>
                                    <option>Togo</option>
                                    <option>Tokelau</option>
                                    <option>Tonga</option>
                                    <option>Trinidad and Tobago</option>
                                    <option>Tunisia</option>
                                    <option>Turkey</option>
                                    <option>Turkmenistan</option>
                                    <option>Turks and Caicos Islands</option>
                                    <option>Tuvalu</option>
                                    <option>US Virgin Islands</option>
                                    <option>Uganda</option>
                                    <option>Ukraine</option>
                                    <option>Union of the Comoros</option>
                                    <option>United Arab Emirates</option>
                                    <option>United Kingdom</option>
                                    <option>United States Minor Outlying Islands</option>
                                    <option>United States</option>
                                    <option>Uruguay</option>
                                    <option>Uzbekistan</option>
                                    <option>Vanuatu</option>
                                    <option>Vatican City</option>
                                    <option>Venezuela</option>
                                    <option>Vietnam</option>
                                    <option>Wallis and Futuna Islands</option>
                                    <option>Western Sahara</option>
                                    <option>Yemen</option>
                                    <option>Zambia</option>
                                    <option>Zimbabwe</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <input type="checkbox" id="chkTerms"/>
                                <span>By ticking this box, I agree to the <a href="Terms.aspx" target="_blank">terms and conditions</a> of this website and acknowledge how this service will protect my personal information while aggregating and analysing the data received. Your details will be handled with care and in accordance with GDPR.</span>
                            </div>
                            <div class="form-group register-btn">
                                <input type="submit" id="frm_basic_info" class="btn custom-btn" value="Go" />

                            </div>
                        </div>
                    </form>
                </div>



            </div>


        </div>
</asp:Content>
