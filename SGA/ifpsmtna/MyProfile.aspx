<%@ Page Language="C#" MasterPageFile="~/tnaDesktop.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="SGA.ifpsmtna.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Custom Form -->
    <script type="text/javascript" src="../js/custom-form-elements.js"></script>

    <!-- Accordion Menu -->
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <!-- Popup -->
    <script type="text/javascript" src="../Scripts/jquery.colorbox.js"></script>
    <script type="text/javascript" src="../js/custom.js"></script>
    <script type="text/javascript" language="javascript">


        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        var alertHtml = '';
        var lastpage = 'n';
        var redirect = 'y';
        function gup(name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
        function FinalSubmit() {
            var snd = <%= this._deirectsend%>;
            if(snd === 1)
            {
                window.location.href = '/ifpsmtna/pk-evaluation-instructions.aspx';
            }
            else{
                window.location.href = '/ifpsmtna/default.aspx';
            }
        }

        function sentBack() {

            //window.location.href = '/tna/default.aspx';
        }

        function setPassword(parameters) {
            $('#<%=password.ClientID %>').val(parameters);
            $('#<%=passwordplain.ClientID %>').val(parameters);

        }

        $(document).ready(function () {
            $('#edit').click(function () {
                $('#<%=password.ClientID %>').removeAttr("disabled");
                $('#<%=password.ClientID %>').hide();
                $('#<%=passwordplain.ClientID %>').show();
            })

            var backUrl = gup("id");
            $('#submitbutton,#submitbuttonnext').colorbox({
                href: "../Popup.aspx",
                width: "392px",
                height: "450px",
                onComplete: function () {
                    if (lastpage == 'y') {
                        if (($("#<%=fname.ClientID %>").val() == '') || $("#<%=lname.ClientID %>").val() == '' || $("#<%=passwordplain.ClientID %>").val() == '' || $("#<%=ddlJobRole.ClientID %>").val() == 0 || $("#<%=ddEditSector.ClientID %>").val() == 0) {
                            redirect = "y";
                            $('#title').text("Confirmation");
                            $('#colorbox').css({ "display": "block" });
                            $('#alertMessage').html("It seems you have not completed all mandatory fields - please complete all fields that are marked with a red asterisk. Thank you.");
                            //$('#btnCancel').css("display", "block");
                            //$('#btnOk').removeClass("btn-yes");
                            //$('#btnOk').addClass("btn-back");

                            //$('#btnCancel').removeClass("btn-back");
                            //$('#btnCancel').addClass("btn-proceed");
                        } else {
                            $('#colorbox').css({ "display": "none" });
                            var snd = <%= this._deirectsend%>;
                            if(snd === 1)
                            {
                                window.location.href = '/ifpsmtna/pk-evaluation-instructions.aspx';
                            }
                            else{
                                window.location.href = '/ifpsmtna/default.aspx';
                            }
                        }
                    }
                    else {
                        redirect = "n";
                        $('#colorbox').css({ "display": "block" });
                        $('#alertMessage').html(alertHtml);
                    }

                }
            });
            $('#submitbutton,#submitbuttonnext').click(function () {
                var error = 0;
                var emptyFields = new Array();
                var password = $('#<%=passwordplain.ClientID %>').val();
                var name = $('#<%=fname.ClientID %>').val();
                var surname = $('#<%=lname.ClientID %>').val();

          <%--   
            if (name == '' || name == 'First name') {
                error = 1;
                emptyFields.push('First name');
            }
           
            if (surname == '' || surname == 'Last name') {
                error = 1;
                emptyFields.push('Last name');
            }

           var agency = $("#<%=ddlAgency.ClientID %>").val();
            if (agency == 0) {
                error = 1;
                emptyFields.push('Your Organisation');
            }

            if (password == '') {
                error = 1;
                emptyFields.push('Password');
            }--%>

                if (($("#<%=fname.ClientID %>").val() == '') && $("#<%=lname.ClientID %>").val() == '' && $("#<%=passwordplain.ClientID %>").val() == '' && $("#<%=ddlJobRole.ClientID %>").val() == 0 && $("#<%=ddEditSector.ClientID %>").val() == 0) {
                    error = 1;
                }



                if (error) {
                    $('#colorbox').css({ "display": "block" });
                    alertHtml = 'It seems you have not completed all mandatory fields - please complete all fields that are marked with a red asterisk. Thank you.';
                }
                else {
                    alertHtml = 's';
                    lastpage = 'y';
                    var emailpass = 0;



                    var json =
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "MyProfile.aspx/UpdateProfile",
                            data: JSON.stringify({ 'fname': name, 'lname': surname, 'password': password, "jobRole": $("#<%=ddlJobRole.ClientID %>").val(), "pmodel": $("#<%=ddlEditModel.ClientID %>").val(), "reportingLine": $("#<%=ddlEditReportingLine.ClientID %>").val(), "spendUnder": $("#<%=ddlEditSpendUnder.ClientID %>").val(), "noemployee": $("#<%=ddlEditEmployeeCompany.ClientID %>").val(), "sector": $("#<%=ddEditSector.ClientID %>").val(), "category": $("#<%=ddlEditExpertise.ClientID %>").val(), "spentUnder": $("#<%=ddlEditSpentUnder.ClientID %>").val(), "geoInfluence": $("#<%=ddlEditGeographical.ClientID %>").val(), "experience": $("#<%=ddlEditProcurementYear.ClientID %>").val(), "proLevel": $("#<%=ddlEditProLevel.ClientID %>").val(), "education": $("#<%=cboEditQualifications.ClientID %>").val(), "catExp": $("#<%=ddlEditCatExp.ClientID %>").val(), 'email': $("#<%=email.ClientID %>").val(), }),
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.d == 's') {
                                    alertHtml = 's';
                                    lastpage = 'y';
                                }

                            },
                            error:function(XMLHttpRequest, textStatus, errorThrown) {
                                lastpage = 'n';
                                alert(XMLHttpRequest.responseText);
                            }
                        });

                    }
            });
        });
    </script>
    <article id="container">
        <section class="welcome-inner">
            <p class="title40-orange">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </p>
            <p class="title40">Here is your profile</p>
        </section>
        <section class="color-box">
            <article class="info-box-shdw-inner">
                <div class="my-pofile-form">
                    <p class="txt28 orange">We need a little more information before you begin!</p>
                    <p>&nbsp;</p>
                    <p>Providing this information helps us to support your learning. If you are unsure how to answer, then please choose the answer you think is the 'closest fit' for you.</p>
                    <p>&nbsp;</p>
                    <p>Since returning participants will have some information that has changed over time please complete this page once again. </p>
                    <p>&nbsp;</p>
                    <p class="txt18-bold">REGISTRATION DETAILS</p>
                    <span class="error">*</span>&nbsp;&nbsp;<b>First Name</b><br />
                    <span class="error"></span>&nbsp;<input type="text" id="fname" name="fname" maxlength="100" runat="server" class="text-box-2" />
                    <p>&nbsp;</p>
                    <span class="error">*</span>&nbsp;&nbsp;<b>Last Name</b><br />
                    <span class="error"></span>&nbsp;<input type="text" id="lname" name="lname" maxlength="100" runat="server" class="text-box-2" />
                    <p>&nbsp;</p>
                    <span class="error">*</span>&nbsp;&nbsp;<b>Your Job Role</b>
                    <div class="form-box1">
                        <asp:DropDownList ID="ddlJobRole" class="styled" runat="server">
                            <asp:ListItem Value="0">Job role best described as ...</asp:ListItem>
                            <asp:ListItem Value="1">Procurement Analyst</asp:ListItem>
                            <asp:ListItem Value="2">Procurement Support</asp:ListItem>
                            <asp:ListItem Value="3">Strategic Sourcing</asp:ListItem>
                            <asp:ListItem Value="4">Vendor Manager/ Supplier Relationship Manager</asp:ListItem>
                            <asp:ListItem Value="5">Category Manager</asp:ListItem>
                            <asp:ListItem Value="6">Procurement Leader</asp:ListItem>
                            <asp:ListItem Value="7">Supply Chain Manager</asp:ListItem>
                            <asp:ListItem Value="8">Non-Procurement: CXO</asp:ListItem>
                            <asp:ListItem Value="9">Non-Procurement: Director</asp:ListItem>
                            <asp:ListItem Value="10">Non-Procurement: Manager</asp:ListItem>
                            <asp:ListItem Value="11">Non-Procurement: Professional</asp:ListItem>
                            <asp:ListItem Value="12">Non-Procurement: Trainee</asp:ListItem>
                            <asp:ListItem Value="14">Head of Supply Chain</asp:ListItem>
                            <asp:ListItem Value="15">Supply Chain Analyst</asp:ListItem>
                            <asp:ListItem Value="16">Operator</asp:ListItem>
                            <asp:ListItem Value="17">Operations Coordinator</asp:ListItem>
                            <asp:ListItem Value="18">Operations Manager</asp:ListItem>
                            <asp:ListItem Value="19">Master Scheduling Manager</asp:ListItem>
                            <asp:ListItem Value="20">Materials Manager</asp:ListItem>
                            <asp:ListItem Value="21">Supply Chain Executive</asp:ListItem>
                            <asp:ListItem Value="22">Planner</asp:ListItem>
                            <asp:ListItem Value="23">Contract Manager</asp:ListItem>
                            <asp:ListItem Value="24">Head of Procurement</asp:ListItem>
                            <asp:ListItem Value="25">Operational Buyer</asp:ListItem>
                            <asp:ListItem Value="26">Senior Buyer</asp:ListItem>
                            <asp:ListItem Value="27">Support Manager</asp:ListItem>
                            <asp:ListItem Value="13">Other</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <p>&nbsp;</p>
                    <p class="txt18-bold">LOGIN DETAILS</p>

                    <span class="error">*</span>&nbsp;&nbsp;<b>Your Email</b><br />
                    <span class="error"></span>&nbsp;<input type="text" id="email" name="email" disabled="disabled" readonly="readonly" maxlength="250" runat="server" class="text-box-2" />
                    <p>&nbsp;</p>
                    <span class="error">*</span>&nbsp;&nbsp;<a href="javascript:void('0')" id="edit">Edit Password</a>
                    <br />
                    <span class="error"></span>&nbsp;<input type="text" id="passwordplain" name="passwordplain" maxlength="20" runat="server" style="display: none" class="text-box-2" /><input type="password" id="password" name="password" disabled="disabled" maxlength="20" runat="server" class="text-box-2" />


                    <p>&nbsp;</p>
                    <p class="txt18-bold">MY DETAILS</p>

                    <span class="error"></span>&nbsp;&nbsp;<b>What is your Procurement Organisational Model? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;<asp:DropDownList ID="ddlEditModel" CssClass="styled" runat="server">
                            <asp:ListItem Value="0" Selected="True">Procurement model</asp:ListItem>
                            <asp:ListItem Value="1">Centralised Procurement Function</asp:ListItem>
                            <asp:ListItem Value="2">Decentralised Procurement Function</asp:ListItem>
                            <asp:ListItem Value="3">Centre-Led Procurement Function</asp:ListItem>
                            <asp:ListItem Value="4">Procurement strategy is centralised, but execution is de-centralised</asp:ListItem>

                        </asp:DropDownList>

                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>To whom does procurement report in your organisation? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
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
                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>Spend Under Influence? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
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
                    </div>
                    <p>&nbsp;</p>
                    <span class="error">*</span>&nbsp;&nbsp;<b>Sector? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
                         <asp:DropDownList ID="ddEditSector" runat="server" CssClass="styled">
                             <asp:ListItem Value="0" Selected="True">Sector you belong to</asp:ListItem>
                             <asp:ListItem Value="1">Public</asp:ListItem>
                             <asp:ListItem Value="2">Private</asp:ListItem>
                             <asp:ListItem Value="3">Not for Profit</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>How many people work in the procurement & contracting department? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
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
                    </div>

                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>Which of the below best describes your category domain expertise: </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
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
                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>Spent under your influence : </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
                        <asp:DropDownList ID="ddlEditSpentUnder" runat="server" CssClass="styled">
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
                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>Geographical influence? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
                         <asp:DropDownList ID="ddlEditGeographical" runat="server" CssClass="styled">
                             <asp:ListItem Value="0" Selected="True">Geographical influence</asp:ListItem>
                             <asp:ListItem Value="1">Local</asp:ListItem>
                             <asp:ListItem Value="2">Regional</asp:ListItem>
                             <asp:ListItem Value="3">Global</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>How many years have you worked in procurement and supply chain? (Round up to the nearest whole year)? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
                         <asp:DropDownList ID="ddlEditProcurementYear" runat="server" CssClass="styled">
                             <asp:ListItem Value="0" Selected="True">Years of procurement experience</asp:ListItem>
                             <asp:ListItem Value="1">Less than 1 year</asp:ListItem>
                             <asp:ListItem Value="2">1 - 3 years</asp:ListItem>
                             <asp:ListItem Value="3">3 - 5 years</asp:ListItem>
                             <asp:ListItem Value="4">5 - 10 years</asp:ListItem>
                             <asp:ListItem Value="5">10 or more years</asp:ListItem>
                             <asp:ListItem Value="6">Not applicable</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>What is your Procurement qualification? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
                         <asp:DropDownList ID="ddlEditProLevel" CssClass="styled" runat="server">
                             <%-- <asp:ListItem Value="0" Selected="True">Procurement qualifications</asp:ListItem>
                             <asp:ListItem Value="1">Undergraduate degree in procurement / supply chain </asp:ListItem>
                             <asp:ListItem Value="2">Postgraduate degree in procurement / supply chain </asp:ListItem>
                             <asp:ListItem Value="3">CIPS: Member (MCIPS)</asp:ListItem>
                             <asp:ListItem Value="4">CIPS: Fellow (FCIPS)</asp:ListItem>
                             <asp:ListItem Value="5">AAPCM: Member </asp:ListItem>
                             <asp:ListItem Value="6">AAPCM: Fellow </asp:ListItem>
                             <asp:ListItem Value="7">Other </asp:ListItem>
                             <asp:ListItem Value="8">Not applicable</asp:ListItem>--%>
                             <asp:ListItem Selected="True" Value="0">Procurement & Supply Qualification</asp:ListItem>
                             <asp:ListItem Value="1">Certificate Procurement and Contracting</asp:ListItem>
                             <asp:ListItem Value="2">Certificate Purchasing</asp:ListItem>
                             <asp:ListItem Value="3">Certified Professional in Supply Management (CPSM)</asp:ListItem>
                             <asp:ListItem Value="4">Certificate in Production and Inventory Management (CPIM)</asp:ListItem>
                             <asp:ListItem Value="5">Diploma of Procurement and Contracting</asp:ListItem>
                             <asp:ListItem Value="6">Diploma of Purchasing</asp:ListItem>
                             <asp:ListItem Value="7">Diploma of Contract Management</asp:ListItem>
                             <asp:ListItem Value="8">Advanced Diploma of Procurement and Contracting</asp:ListItem>
                             <asp:ListItem Value="9">Graduate Certificate in Logistics and Supply Chain Management</asp:ListItem>
                             <asp:ListItem Value="10">Undergraduate degree procurement / supply chain</asp:ListItem>
                             <asp:ListItem Value="11">Postgraduate degree procurement/ supply chain</asp:ListItem>
                             <asp:ListItem Value="12">Certified Supply Chain Professional (CSCP)</asp:ListItem>
                             <asp:ListItem Value="13">Certified International Procurement Professional (CIPP)</asp:ListItem>
                             <asp:ListItem Value="14">Certified International Advanced Procurement Professional (CIAPP)</asp:ListItem>
                             <asp:ListItem Value="15">Member Chartered Institute Procurement Supply (MCIPS)</asp:ListItem>
                             <asp:ListItem Value="16">Fellow Chartered Institute Procurement Supply (FCIPS)</asp:ListItem>
                             <asp:ListItem Value="17">AAPCM Member</asp:ListItem>
                             <asp:ListItem Value="18">AAPCM Fellow</asp:ListItem>
                             <asp:ListItem Value="19">Other</asp:ListItem>
                             <asp:ListItem Value="20">Not applicable</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>What is your highest level of education? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
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
                    </div>
                    <p>&nbsp;</p>
                    <span class="error"></span>&nbsp;&nbsp;<b>What is your previous category Experience? </b>
                    <br />
                    <div class="form-box1">
                        <span class="error"></span>&nbsp;
                         <asp:DropDownList ID="ddlEditCatExp" CssClass="styled" runat="server">
                             <asp:ListItem Value="0" Selected="True">Category Experience</asp:ListItem>
                             <asp:ListItem Value="1">Indirect- General</asp:ListItem>
                             <asp:ListItem Value="2">Directs - General</asp:ListItem>
                             <asp:ListItem Value="3">IT&T Services: Software, Hardware, Telco etc.</asp:ListItem>
                             <asp:ListItem Value="4">Packaging: PET, Glass, Print, Labels, etc.</asp:ListItem>
                             <asp:ListItem Value="5">Marketing Services: ABT, BTL, Print, etc.</asp:ListItem>
                             <asp:ListItem Value="6">Ingredients</asp:ListItem>
                             <asp:ListItem Value="7">HR Services: Labour hire, Recruitment, Training, etc.</asp:ListItem>
                             <asp:ListItem Value="8">Chemicals</asp:ListItem>
                             <asp:ListItem Value="9">Professional Services: Legal, Audit & Accounting, Security, etc.</asp:ListItem>
                             <asp:ListItem Value="10">Industry specific production material</asp:ListItem>
                             <asp:ListItem Value="11">Facilities and Corporate Real Estate (FM/CRE</asp:ListItem>
                             <asp:ListItem Value="12">Utilities: Gas, Electricity, Water</asp:ListItem>
                             <asp:ListItem Value="13">Capex: Heavy machinery and equipment</asp:ListItem>
                             <asp:ListItem Value="14">MRO Maintenance, Repairs, Operations and Consumables</asp:ListItem>
                             <asp:ListItem Value="15">Office: Stationery, post</asp:ListItem>
                             <asp:ListItem Value="16">Travel</asp:ListItem>
                             <asp:ListItem Value="17">Fleet</asp:ListItem>
                             <asp:ListItem Value="18">Logistics</asp:ListItem>
                             <asp:ListItem Value="19">Other</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <p>&nbsp;</p>

                    <div class="clear"></div>
                    <p>&nbsp;</p>
                    <p class="txtRgt">
                        <input type="submit" id="submitbutton" value="BACK" class="btn-save" />
                        <input type="submit" id="submitbuttonnext" value="NEXT" class="btn-next" />
                    </p>
                    <p>&nbsp;</p>
                </div>
            </article>
        </section>
        <div class="dot-line">&nbsp;</div>
    </article>
</asp:Content>
