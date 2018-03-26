<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="SGA.tna.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Custom Form -->
		<script type="text/javascript" src="../js/custom-form-elements.js"></script>
		
		<!-- Accordion Menu -->
		<script type="text/javascript" src="../js/jquery.min.js"></script>
		<script type="text/javascript" src="../js/ddaccordion.js"></script>
		<script type="text/javascript" src="../js/ddaccordion-menu.js"></script>
		<!-- Popup -->
		<script type="text/javascript" src="../Scripts/jquery.colorbox.js"></script>
		<script type="text/javascript" src="../js/custom.js"></script>
<script type="text/javascript" language="javascript">
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
        var backUrl = gup("id");
        if (backUrl == "1") {
            window.location.href = '/tna/category-management-test.aspx';
        } else if (backUrl == "2") {
            window.location.href = '/tna/skills-self-test.aspx';
        } else if (backUrl == "3") {
            window.location.href = '/tna/behavioural-assessment-test.aspx';
        } else if (backUrl == "4") {
            window.location.href = '/tna/department-maturity-test.aspx';
        } else if (backUrl == "5") {
            window.location.href = '/tna/negotiation-profile-test.aspx';
        } else if (backUrl == "6") {
            window.location.href = '/tna/cmk-relationsip-context.aspx';
        } else if (backUrl == "7") {
            window.location.href = '/tna/contract-sga-management-assessment-test.aspx';
        } else if (backUrl == "8") {
            window.location.href = '/tna/leadership-assessment-test.aspx';
        } else if (backUrl == "9") {
            window.location.href = '/tna/diagnostic-skills-self-test.aspx';
        }
        else if (backUrl == "10") {
            window.location.href = '/tna/supply-chain-knowledge-evaluation-test.aspx';
        }
        else if (backUrl == "11") {
            window.location.href = '/tna/supply-chain-self-assessment-test.aspx';
        }
        else {
            window.location.href = '/tna/default.aspx';
        }
    }

    function sentBack() {
        window.location.href = '/tna/default.aspx';
    }

    $(document).ready(function () {
        var directSelected = "<%=_direct %>";
        var dirSel = directSelected.split(',');
        for (var i = 0; i < dirSel.length; i++) {
            $("input[name='direct']").each(function () {
                if ($(this).val() == dirSel[i]) {
                    $(this).attr("checked", "checked");
                }
            });
        }

        var indirectSelected = "<%=_indirect %>";
        dirSel = indirectSelected.split(',');
        for (var i = 0; i < dirSel.length; i++) {
            $("input[name='indirect']").each(function () {
                if ($(this).val() == dirSel[i]) {
                    $(this).attr("checked", "checked");
                }
            });
        }
        //alert(directSelected);

        $('#edit').click(function () {
            $('#<%=password.ClientID %>').removeAttr("disabled");
        })
        var backUrl = gup("id");
        $('#submitbutton,#submitbuttonnext').colorbox({
            href: "../Popup.aspx",
            width: "392px",
            height: "450px",
            onComplete: function () {
                if (lastpage == 'y') {
                    if (backUrl.length == 0) {
                        $('#cboxOverlay').remove();
                        $('#colorbox').remove();
                        //$('#colorbox').css({ "display": "none" });
                        window.location.href = '/tna/default.aspx';
                    }
                    else {
                        redirect = "y";
                        $('#title').text("Confirmation");
                        $('#colorbox').css({ "display": "block" });
                        if (backUrl == "1") {
                            $('#alertMessage').text("You are about to begin your Procurement Knowledge Evaluation. This is a timed event and must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "2") {
                            $('#alertMessage').text("You are about to begin the Category Management Self Assessment. This assessment must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "3") {
                            $('#alertMessage').text("You are about to begin the Category Management Behavioural Assessment. This assessment must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "4") {
                            $('#alertMessage').text("You are about to begin the Department Maturity Profile. This assessment must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "5") {
                            $('#alertMessage').text("You are about to begin the Negotiation Profile. This assessment must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "6") {
                            $('#alertMessage').text("You are about to begin the Contract Management Knowledge Evaluation. This is a timed event and must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "7") {
                            $('#alertMessage').text("You are about to begin the Contract Management Self Assessment. This assessment must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "8") {
                            $('#alertMessage').text("You are about to begin the Leadership Assessment. This assessment must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "10") {
                            $('#alertMessage').text("You are about to begin your Supply Chain Knowledge Evaluation. This is a timed event and must be taken in a single sitting. Are you ready to begin?");
                        } else if (backUrl == "11") {
                            $('#alertMessage').text("You are about to begin the Supply Chain Self Assessment. This assessment must be taken in a single sitting. Are you ready to begin?");
                        }

                        //$('#alertMessage').text("You are about to begin the Category Management Challenge. This is a timed event and must be taken in a single sitting. Are you ready to begin?");
                        $('#btnCancel').css("display", "block");
                        $('#btnOk').removeClass("btn-yes");
                        $('#btnOk').addClass("btn-back");
                        $('#btnCancel').removeClass("btn-back");
                        $('#btnCancel').addClass("btn-yes");
                    }

                }
                else {
                    redirect = "n";
                    $('#colorbox').css({ "display": "block" });
                    $('#alertMessage').html(alertHtml);
                }
                /*else {
                if (alertHtml == "s") {
                $('#colorbox').css({ "display": "none" });
                if (backUrl == "1") {
                window.location.href = '/tna/category-management-test.aspx';
                } else if (backUrl == "2") {
                window.location.href = '/tna/skills-self-test.aspx';
                } else if (backUrl == "3") {
                window.location.href = '/tna/behavioural-assessment-test.aspx';
                } else {
                window.location.href = '/tna/default.aspx';
                }

                } else {
                $('#colorbox').css({ "display": "block" });
                $('#alertMessage').html(alertHtml);
                }
                }*/

            }
        });
        $('#submitbutton,#submitbuttonnext').click(function () {
            var error = 0;
            var emptyFields = new Array();
            var industry = $('#<%=ddlIndustry.ClientID %>').val();
            var revenue = $('#<%=ddlCompanyRevenue.ClientID %>').val();
            var model = $('#<%=ddlModel.ClientID %>').val();
            var company = $('#<%=ddlEmployeeCompany.ClientID %>').val();
            var expertise = $('#<%=ddlExpertise.ClientID %>').val();
            var arevenue = $('#<%=ddlAnnualRevenue.ClientID %>').val();
            var pyear = $('#<%=ddlProcurementYear.ClientID %>').val();
            var geographical = $('#<%=ddlGeographical.ClientID %>').val();
            var qualification = $('#<%=cboQualifications.ClientID %>').val();
            var reportline = $('#<%=ddlReportingLine.ClientID %>').val();
            var spentUnder = $('#<%=ddlSpendUnder.ClientID %>').val();
            var proLevel = $('#<%=ddlProLevel.ClientID %>').val();
            var fname = $('#<%=fname.ClientID %>').val();
            var lname = $('#<%=lname.ClientID %>').val();
            var companyname = $('#<%=company.ClientID %>').val();
            var phone = $('#<%=phone.ClientID %>').val();
            var state = $('#<%=state.ClientID %>').val();
            var postCode = $('#<%=postcode.ClientID %>').val();
            var password = $('#<%=password.ClientID %>').val();
            var jobtitle = $('#<%=jobtitle.ClientID %>').val();

            var specification = "";

            $("input[name='indirect']:checked").each(function () {
                specification += $(this).val() + ",";
            });

            var directGeneral = "";

            $("input[name='direct']:checked").each(function () {
                directGeneral += $(this).val() + ",";
            });

            if (fname == '') {
                error = 1;
                emptyFields.push('First name');
            }
            if (lname == '') {
                error = 1;
                emptyFields.push('Last name');
            }
            if (companyname == '') {
                error = 1;
                emptyFields.push('Company name');
            }
            if (password == '') {
                error = 1;
                emptyFields.push('Password');
            }

            if (jobtitle == '' || jobtitle == 'JobTitle') {
                error = 1;
                emptyFields.push('JobTitle');
            }

            if (state == '' || state == 'In which state do you work?') {
                error = 1;
                emptyFields.push('State');
            }



            if (industry == 0) {
                error = 1;
                emptyFields.push('Industry');
            }

            if (phone == '' || phone == 'Phone No') {
                error = 1;
                emptyFields.push('Phone No');
            }

            /*Phone No
            
            if (revenue == 0) {
            error = 1;
            emptyFields.push('Analysed revenues');
            }

            if (model == 0) {
            error = 1;
            emptyFields.push('Procurement model');
            }*/


            /*if (geographical == 0) {
            error = 1;
            emptyFields.push('Geographical influence');
            }
            if (reportline == 0) {
            error = 1;
            emptyFields.push('Reporting line');
            }
            //reportline
            if (spentUnder == 0) {
            error = 1;
            emptyFields.push('Spend under influence');
            }


            if (company == 0) {
            error = 1;
            emptyFields.push('Number of employee');
            }*/

            if (expertise == 0) {
                error = 1;
                emptyFields.push('Category you manage');
            }

            /*if (arevenue == 0) {
            error = 1;
            emptyFields.push('Spend under your influence');
            }

            if (pyear == 0) {
            error = 1;
            emptyFields.push('Year of procurement experience');
            }

            if (qualification == 0) {
            error = 1;
            emptyFields.push('Level of education');
            }

            if (proLevel == 0) {
            error = 1;
            emptyFields.push('Procurement qualifications');
            }


            */
            var job = $("#<%=ddlJobRole.ClientID %>").val();
            if (job == 0) {
                error = 1;
                emptyFields.push('Job role');
            }
            if (error) {
                lastpage = 'n';
                $('#colorbox').css({ "display": "block" });
                alertHtml = 'The information listed below is used in the analysis of your results. Please complete the following fields:<br />' + emptyFields.join('<br /> ');
            }
            else {

                var json =
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "MyProfile.aspx/UpdateProfile",
                            data: JSON.stringify({ 'industry': industry, 'arevenue': arevenue, 'pmodel': model, 'noemployee': company, 'category': expertise, 'spent': revenue, 'experience': pyear, 'education': qualification, 'specialist': specification, 'reportingLine': reportline, 'spentUnder': spentUnder, 'jobRole': $("#<%=ddlJobRole.ClientID %>").val(), 'proLevel': proLevel, 'directGeneral': directGeneral, 'fname': fname, 'lname': lname, 'company': companyname, 'phone': phone, 'geoInfluence': geographical, 'password': password, 'state': state, 'postcode': postCode, 'country': $("#<%=ddlCountry.ClientID %>").val(), 'jobtitle': jobtitle, 'email': $("#<%=email.ClientID %>").val() }),
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.d == 's') {
                                    alertHtml = 's';
                                    lastpage = 'y';
                                }
                            }
                        });
            }
        });
    });
</script>
<article id="container">
					<section class="welcome-inner">
						<p class="title40-orange"><asp:Label ID="lblName" runat="server"></asp:Label></p>
						<p class="title40">Here is your profile</p>
					</section>
					<section class="color-box">
						<article class="info-box-shdw-inner">
							<div class="my-pofile-form">
								<p class="txt28 orange">We need a little more information before you begin!</p>
								<p>&nbsp;</p>
								<p class="txt18-bold">My Details.</p>
                                <b>&nbsp;&nbsp;First name</b><br>
                                <span class="error">*</span>&nbsp;<input type="text" autocomplete="off" id="fname" name="fname" maxlength="100"  runat="server" class="text-box-2" />
                                <p>&nbsp;</p>
                                <b>&nbsp;&nbsp;Last name</b><br>
                                <span class="error">*</span>&nbsp;<input type="text" autocomplete="off" id="lname" name="lname" maxlength="100" runat="server" class="text-box-2" />
                                <p>&nbsp;</p>
                                <b>&nbsp;&nbsp;Job title</b><br>
                                <span class="error">*</span>&nbsp;<input type="text" autocomplete="off" id="jobtitle" name="jobtitle" maxlength="100" runat="server" class="text-box-2" />
                                <p>&nbsp;</p>
                                <b>&nbsp;&nbsp;Company</b><br>
                                <span class="error">*</span>&nbsp;<input type="text" autocomplete="off" id="company" name="company" maxlength="100" runat="server" class="text-box-2"  />
                                <p>&nbsp;</p>
                                <b>&nbsp;&nbsp;Phone</b><br>
                                <span class="error">*</span>&nbsp;<input type="text" autocomplete="off" id="phone" name="phone" maxlength="20" runat="server" class="text-box-2" />
                                <p>&nbsp;</p>
                                <span class="error"></span>&nbsp;&nbsp;<a href="javascript:void('0')" id="edit">Edit Password</a>
                                <br /><span class="error">*</span>&nbsp;<input type="text" autocomplete="off" id="password" name="password" disabled="disabled" maxlength="20" runat="server" class="text-box-2" />
                                
                                <p>&nbsp;</p>
                                <b>&nbsp;&nbsp;Email</b><br>
                                <span class="error">*</span>&nbsp;<input type="text" autocomplete="off" id="email" name="email" disabled="disabled" readonly="readonly" maxlength="20" runat="server" class="text-box-2" />
                                
                                <p>&nbsp;</p>
								<p class="txt18-bold">About your organisation.</p>
                                <p>&nbsp;</p>
                                <b>&nbsp;&nbsp;Industry</b><br>
								<div class="form-box1">
									<span class="error">*</span>&nbsp;<asp:DropDownList ID="ddlIndustry" runat="server" class="styled">
                                            <asp:ListItem Value="0" Selected="True">Industry</asp:ListItem>
                                            <asp:ListItem Value="1"  >Advertising, Media &amp; Communications</asp:ListItem>
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
                                    
								</div>
                                <b>&nbsp;&nbsp;Annualised revenues</b><br>
								<div class="form-box1">
									<span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlCompanyRevenue" runat="server" cssclass="styled">
                                            <asp:ListItem Value="0" Selected="True">Annualised revenues</asp:ListItem>
                                            <asp:ListItem Value="1"  >$1 billion or more</asp:ListItem>
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
                                <b>&nbsp;&nbsp;State</b><br>
                                <span class="error">*</span>&nbsp;<input type="text" autocomplete="off" id="state" name="state"  maxlength="50" runat="server" class="text-box-2" />
                                <p>&nbsp;</p>
                                <b>&nbsp;&nbsp;Postcode</b><br>
                                <span class="error"></span>&nbsp;&nbsp;<input type="text" autocomplete="off" id="postcode" name="postcode"  maxlength="20" runat="server" class="text-box-2" />
                                <p>&nbsp;</p>
                                <b>&nbsp;&nbsp;Country</b><br>
                                <div class="form-box1">
                                <span class="error">*</span>&nbsp;<asp:DropDownList ID="ddlCountry" runat="server"  class="styled">
									<asp:Listitem>Australia</asp:Listitem>
	<asp:Listitem >Afghanistan</asp:Listitem>
	<asp:Listitem >Aland Islands</asp:Listitem>
	<asp:Listitem >Albania</asp:Listitem>
	<asp:Listitem >American Samoa</asp:Listitem>
	<asp:Listitem >Andorra</asp:Listitem>
	<asp:Listitem >Angola</asp:Listitem>
	<asp:Listitem >Anguilla</asp:Listitem>
	<asp:Listitem >Antarctica</asp:Listitem>
	<asp:Listitem >Antigua and Barbuda</asp:Listitem>
	<asp:Listitem >Argentina</asp:Listitem>
	<asp:Listitem >Armenia</asp:Listitem>
	<asp:Listitem >Aruba</asp:Listitem>
	<asp:Listitem >Austria</asp:Listitem>
	<asp:Listitem >Azerbaijan</asp:Listitem>
	<asp:Listitem >Bahamas</asp:Listitem>
	<asp:Listitem >Bahrain</asp:Listitem>
	<asp:Listitem >Bangladesh</asp:Listitem>
	<asp:Listitem >Barbados</asp:Listitem>
	<asp:Listitem >Belarus</asp:Listitem>
	<asp:Listitem >Belgium</asp:Listitem>
	<asp:Listitem >Belize</asp:Listitem>
	<asp:Listitem >Benin</asp:Listitem>
	<asp:Listitem >Bermuda</asp:Listitem>
	<asp:Listitem >Bhutan</asp:Listitem>
	<asp:Listitem >Bolivia</asp:Listitem>
	<asp:Listitem >Bosnia and Herzegovina</asp:Listitem>
	<asp:Listitem >Botswana</asp:Listitem>
	<asp:Listitem >Bouvet Island</asp:Listitem>
	<asp:Listitem >Brazil</asp:Listitem>
	<asp:Listitem >British Indian Ocean Territory</asp:Listitem>
	<asp:Listitem >British Virgin Islands</asp:Listitem>
	<asp:Listitem >Brunei</asp:Listitem>
	<asp:Listitem >Bulgaria</asp:Listitem>
	<asp:Listitem>Burkina Faso</asp:Listitem>
	<asp:Listitem >Burundi</asp:Listitem>
	<asp:Listitem >Cambodia</asp:Listitem>
	<asp:Listitem >Cameroon</asp:Listitem>
	<asp:Listitem >Canada</asp:Listitem>
	<asp:Listitem >Cape Verde</asp:Listitem>
	<asp:Listitem >Cayman Islands</asp:Listitem>
	<asp:Listitem >Central African Republic</asp:Listitem>
	<asp:Listitem >Chad</asp:Listitem>
	<asp:Listitem >Chile</asp:Listitem>
	<asp:Listitem >China</asp:Listitem>
	<asp:Listitem >Christmas Island</asp:Listitem>
	<asp:Listitem >Cocos (Keeling) Islands</asp:Listitem>
	<asp:Listitem>Colombia</asp:Listitem>
	<asp:Listitem >Congo</asp:Listitem>
	<asp:Listitem >Cook Islands</asp:Listitem>
	<asp:Listitem>Costa Rica</asp:Listitem>
	<asp:Listitem>Croatia</asp:Listitem>
	<asp:Listitem>Cuba</asp:Listitem>
	<asp:Listitem>Cyprus</asp:Listitem>
	<asp:Listitem >Czech Republic</asp:Listitem>
	<asp:Listitem >Democratic Republic of Congo</asp:Listitem>
	<asp:Listitem >Denmark</asp:Listitem>
	<asp:Listitem >Disputed Territory</asp:Listitem>
	<asp:Listitem >Djibouti</asp:Listitem>
	<asp:Listitem >Dominica</asp:Listitem>
	<asp:Listitem >Dominican Republic</asp:Listitem>
	<asp:Listitem >East Timor</asp:Listitem>
	<asp:Listitem >Ecuador</asp:Listitem>
	<asp:Listitem >Egypt</asp:Listitem>
	<asp:Listitem >El Salvador</asp:Listitem>
	<asp:Listitem >Equatorial Guinea</asp:Listitem>
	<asp:Listitem >Eritrea</asp:Listitem>
	<asp:Listitem >Estonia</asp:Listitem>
	<asp:Listitem >Ethiopia</asp:Listitem>
	<asp:Listitem >Falkland Islands</asp:Listitem>
	<asp:Listitem >Faroe Islands</asp:Listitem>
	<asp:Listitem >Federated States of Micronesia</asp:Listitem>
	<asp:Listitem >Fiji</asp:Listitem>
	<asp:Listitem >Finland</asp:Listitem>
	<asp:Listitem >France</asp:Listitem>
	<asp:Listitem >French Guyana</asp:Listitem>
	<asp:Listitem >French Polynesia</asp:Listitem>
	<asp:Listitem >French Southern Territories</asp:Listitem>
	<asp:Listitem >Gabon</asp:Listitem>
	<asp:Listitem >Gambia</asp:Listitem>
	<asp:Listitem >Georgia</asp:Listitem>
	<asp:Listitem >Germany</asp:Listitem>
	<asp:Listitem >Ghana</asp:Listitem>
	<asp:Listitem >Gibraltar</asp:Listitem>
	<asp:Listitem >Greece</asp:Listitem>
	<asp:Listitem >Greenland</asp:Listitem>
	<asp:Listitem >Grenada</asp:Listitem>
	<asp:Listitem >Guadeloupe</asp:Listitem>
	<asp:Listitem >Guam</asp:Listitem>
	<asp:Listitem >Guatemala</asp:Listitem>
	<asp:Listitem >Guinea</asp:Listitem>
	<asp:Listitem >Guinea-Bissau</asp:Listitem>
	<asp:Listitem >Guyana</asp:Listitem>
	<asp:Listitem >Haiti</asp:Listitem>
	<asp:Listitem >Heard Island and McDonald Islands</asp:Listitem>
	<asp:Listitem >Honduras</asp:Listitem>
	<asp:Listitem >Hong Kong</asp:Listitem>
	<asp:Listitem >Hungary</asp:Listitem>
	<asp:Listitem >Iceland</asp:Listitem>
	<asp:Listitem >India</asp:Listitem>
	<asp:Listitem >Indonesia</asp:Listitem>
	<asp:Listitem >Iran</asp:Listitem>
	<asp:Listitem >Iraq</asp:Listitem>
	<asp:Listitem >Iraq-Saudi Arabia Neutral Zone</asp:Listitem>
	<asp:Listitem >Ireland</asp:Listitem>
	<asp:Listitem >Israel</asp:Listitem>
	<asp:Listitem >Italy</asp:Listitem>
	<asp:Listitem >Ivory Coast</asp:Listitem>
	<asp:Listitem >Jamaica</asp:Listitem>
	<asp:Listitem >Japan</asp:Listitem>
	<asp:Listitem >Jordan</asp:Listitem>
	<asp:Listitem >Kazakhstan</asp:Listitem>
	<asp:Listitem >Kenya</asp:Listitem>
	<asp:Listitem >Kiribati</asp:Listitem>
	<asp:Listitem >Kuwait</asp:Listitem>
	<asp:Listitem >Kyrgyz Republic</asp:Listitem>
	<asp:Listitem >Laos</asp:Listitem>
	<asp:Listitem >Latvia</asp:Listitem>
	<asp:Listitem >Lebanon</asp:Listitem>
	<asp:Listitem >Lesotho</asp:Listitem>
	<asp:Listitem >Liberia</asp:Listitem>
	<asp:Listitem >Libya</asp:Listitem>
	<asp:Listitem >Liechtenstein</asp:Listitem>
	<asp:Listitem >Lithuania</asp:Listitem>
	<asp:Listitem >Luxembourg</asp:Listitem>
	<asp:Listitem >Macau</asp:Listitem>
	<asp:Listitem >Macedonia</asp:Listitem>
	<asp:Listitem >Madagascar</asp:Listitem>
	<asp:Listitem >Malawi</asp:Listitem>
	<asp:Listitem >Malaysia</asp:Listitem>
	<asp:Listitem >Maldives</asp:Listitem>
	<asp:Listitem >Mali</asp:Listitem>
	<asp:Listitem >Malta</asp:Listitem>
	<asp:Listitem >Marshall Islands</asp:Listitem>
	<asp:Listitem >Martinique</asp:Listitem>
	<asp:Listitem >Mauritania</asp:Listitem>
	<asp:Listitem >Mauritius</asp:Listitem>
	<asp:Listitem >Mayotte</asp:Listitem>
	<asp:Listitem >Mexico</asp:Listitem>
	<asp:Listitem >Moldova</asp:Listitem>
	<asp:Listitem >Monaco</asp:Listitem>
	<asp:Listitem >Mongolia</asp:Listitem>
	<asp:Listitem >Montenegro</asp:Listitem>
	<asp:Listitem >Montserrat</asp:Listitem>
	<asp:Listitem >Morocco</asp:Listitem>
	<asp:Listitem >Mozambique</asp:Listitem>
	<asp:Listitem >Myanmar</asp:Listitem>
	<asp:Listitem >Namibia</asp:Listitem>
	<asp:Listitem >Nauru</asp:Listitem>
	<asp:Listitem >Nepal</asp:Listitem>
	<asp:Listitem >Netherlands Antilles</asp:Listitem>
	<asp:Listitem >Netherlands</asp:Listitem>
	<asp:Listitem >New Caledonia</asp:Listitem>
	<asp:Listitem >New Zealand</asp:Listitem>
	<asp:Listitem >Nicaragua</asp:Listitem>
	<asp:Listitem >Niger</asp:Listitem>
	<asp:Listitem >Nigeria</asp:Listitem>
	<asp:Listitem >Niue</asp:Listitem>
	<asp:Listitem >Norfolk Island</asp:Listitem>
	<asp:Listitem >North Korea</asp:Listitem>
	<asp:Listitem >Northern Mariana Islands</asp:Listitem>
	<asp:Listitem >Norway</asp:Listitem>
	<asp:Listitem >Oman</asp:Listitem>
	<asp:Listitem >Pakistan</asp:Listitem>
	<asp:Listitem >Palau</asp:Listitem>
	<asp:Listitem >Palestinian Territories</asp:Listitem>
	<asp:Listitem >Panama</asp:Listitem>
	<asp:Listitem >Papua New Guinea</asp:Listitem>
	<asp:Listitem >Paraguay</asp:Listitem>
	<asp:Listitem >Peru</asp:Listitem>
	<asp:Listitem >Philippines</asp:Listitem>
	<asp:Listitem >Pitcairn Islands</asp:Listitem>
	<asp:Listitem >Poland</asp:Listitem>
	<asp:Listitem >Portugal</asp:Listitem>
	<asp:Listitem >Puerto Rico</asp:Listitem>
	<asp:Listitem >Qatar</asp:Listitem>
	<asp:Listitem >Reunion</asp:Listitem>
	<asp:Listitem >Romania</asp:Listitem>
	<asp:Listitem >Russia</asp:Listitem>
	<asp:Listitem >Rwanda</asp:Listitem>
	<asp:Listitem >Saint Helena and Dependencies</asp:Listitem>
	<asp:Listitem >Saint Kitts &amp; Nevis</asp:Listitem>
	<asp:Listitem >Saint Lucia</asp:Listitem>
	<asp:Listitem >Saint Pierre and Miquelon</asp:Listitem>
	<asp:Listitem >Samoa</asp:Listitem>
	<asp:Listitem >San Marino</asp:Listitem>
	<asp:Listitem >Sao Tome and Principe</asp:Listitem>
	<asp:Listitem >Saudi Arabia</asp:Listitem>
	<asp:Listitem >Senegal</asp:Listitem>
	<asp:Listitem >Serbia</asp:Listitem>
	<asp:Listitem >Seychelles</asp:Listitem>
	<asp:Listitem >Sierra Leone</asp:Listitem>
	<asp:Listitem >Singapore</asp:Listitem>
	<asp:Listitem >Slovakia</asp:Listitem>
	<asp:Listitem >Slovenia</asp:Listitem>
	<asp:Listitem >Solomon Islands</asp:Listitem>
	<asp:Listitem >Somalia</asp:Listitem>
	<asp:Listitem >South Africa</asp:Listitem>
	<asp:Listitem >South Georgia and the South Sandwich Islands</asp:Listitem>
	<asp:Listitem >South Korea</asp:Listitem>
	<asp:Listitem >Spain</asp:Listitem>
	<asp:Listitem >Spratly Islands</asp:Listitem>
	<asp:Listitem >Sri Lanka</asp:Listitem>
	<asp:Listitem >Sudan</asp:Listitem>
	<asp:Listitem >Suriname</asp:Listitem>
	<asp:Listitem >Svalbard and Jan Mayen Islands</asp:Listitem>
	<asp:Listitem >Swaziland</asp:Listitem>
	<asp:Listitem >Sweden</asp:Listitem>
	<asp:Listitem >Switzerland</asp:Listitem>
	<asp:Listitem >Syria</asp:Listitem>
	<asp:Listitem >Taiwan</asp:Listitem>
	<asp:Listitem >Tajikistan</asp:Listitem>
	<asp:Listitem >Tanzania</asp:Listitem>
	<asp:Listitem >Thailand</asp:Listitem>
	<asp:Listitem >Togo</asp:Listitem>
	<asp:Listitem >Tokelau</asp:Listitem>
	<asp:Listitem >Tonga</asp:Listitem>
	<asp:Listitem >Trinidad and Tobago</asp:Listitem>
	<asp:Listitem >Tunisia</asp:Listitem>
	<asp:Listitem >Turkey</asp:Listitem>
	<asp:Listitem >Turkmenistan</asp:Listitem>
	<asp:Listitem >Turks and Caicos Islands</asp:Listitem>
	<asp:Listitem >Tuvalu</asp:Listitem>
	<asp:Listitem >US Virgin Islands</asp:Listitem>
	<asp:Listitem >Uganda</asp:Listitem>
	<asp:Listitem >Ukraine</asp:Listitem>
	<asp:Listitem >Union of the Comoros</asp:Listitem>
	<asp:Listitem >United Arab Emirates</asp:Listitem>
	<asp:Listitem >United Kingdom</asp:Listitem>
	<asp:Listitem >United States Minor Outlying Islands</asp:Listitem>
	<asp:Listitem >United States</asp:Listitem>
	<asp:Listitem >Uruguay</asp:Listitem>
	<asp:Listitem >Uzbekistan</asp:Listitem>
	<asp:Listitem >Vanuatu</asp:Listitem>
	<asp:Listitem >Vatican City</asp:Listitem>
	<asp:Listitem >Venezuela</asp:Listitem>
	<asp:Listitem >Vietnam</asp:Listitem>
	<asp:Listitem >Wallis and Futuna Islands</asp:Listitem>
	<asp:Listitem >Western Sahara</asp:Listitem>
	<asp:Listitem >Yemen</asp:Listitem>
	<asp:Listitem >Zambia</asp:Listitem>
	<asp:Listitem >Zimbabwe</asp:Listitem>
								</asp:DropDownList>
                                </div>
								<p>&nbsp;</p>

								<p class="txt18-bold">About your procurement function.</p>
                                <b>&nbsp;&nbsp;Procurement model</b><br>
								<div class="form-box1">
									<span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlModel" CssClass="styled" runat="server"
                                           >
                                            <asp:ListItem Value="0" Selected="True">Procurement model</asp:ListItem>
                                            <asp:ListItem Value="1">Centralised Procurement Function</asp:ListItem>
                                            <asp:ListItem Value="2">Decentralised Procurement Function</asp:ListItem>
                                            <asp:ListItem Value="3">Centre-Led Procurement Function</asp:ListItem>
                                            <asp:ListItem Value="4" >Procurement strategy is centralised, but execution is de-centralised</asp:ListItem>
                                            
                                        </asp:DropDownList>
                                    
								</div>
                                <b>&nbsp;&nbsp;Procurement function reports to</b><br>
								<div class="form-box1">
									
                                    <span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlReportingLine" CssClass="styled" runat="server">
                                    <asp:ListItem Value="0" Selected="True">Procurement function reports to…</asp:ListItem>
                                    <asp:ListItem Value="1" >CEO</asp:ListItem>
                                    <asp:ListItem Value="2" >CFO</asp:ListItem>
                                    <asp:ListItem Value="3" >COO</asp:ListItem>
                                    <asp:ListItem Value="4" >CIO</asp:ListItem>
                                    <asp:ListItem Value="5" >Legal Council</asp:ListItem>
                                    <asp:ListItem Value="6" >Head of Supply Chain</asp:ListItem>
                                    <asp:ListItem Value="7" >Division or Business Unit Head</asp:ListItem>
                                    <asp:ListItem Value="8" >Regional or Global Procurement</asp:ListItem>
                                    
                                    </asp:DropDownList>
								</div>
                                <b>&nbsp;&nbsp;Spend under influence</b><br>
								<div class="form-box1">
									
                                    <span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlSpendUnder" runat="server" cssclass="styled">
                                            <asp:ListItem Value="0" Selected="True">Spend under influence</asp:ListItem>
                                            <asp:ListItem Value="1"  >$1 billion or more</asp:ListItem>
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
                                <b>&nbsp;&nbsp;Number of employees</b><br>
								<div class="form-box1">
									<span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlEmployeeCompany" runat="server" cssclass="styled">
                                            <asp:ListItem Value="0" Selected="True">Number of employees</asp:ListItem>
                                            <asp:ListItem Value="1"  >100+</asp:ListItem>
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
								<p class="txt18-bold">About you.</p>
								<b>&nbsp;&nbsp;Job role best described as</b><br>
                                <div class="form-box1">
									
                                    <span class="error">*</span>&nbsp;<asp:DropDownList ID="ddlJobRole" CssClass="styled" runat="server">
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
								</div>
                                <b>&nbsp;&nbsp;Category you manage currently</b><br>
								<div class="form-box1">
									<span class="error">*</span>&nbsp;<asp:DropDownList ID="ddlExpertise" CssClass="styled"  runat="server"
                                           >
                                            <asp:ListItem Value="0" Selected="True">Category you manage currently</asp:ListItem>
                                            <asp:ListItem Value="1">Generalist Direct & Indirects</asp:ListItem>
                                            <asp:ListItem Value="2">Generalist Directs</asp:ListItem>
                                            <asp:ListItem Value="3">Generalist Indirects</asp:ListItem>
                                            <asp:ListItem Value="4" >Chemicals</asp:ListItem>
                                            <asp:ListItem Value="5" >Energy</asp:ListItem>
                                            <asp:ListItem Value="6" >Facilities</asp:ListItem>
                                            <asp:ListItem Value="7" >Fleet</asp:ListItem>
                                            <asp:ListItem Value="8" >Heavy Machinery and Equipment</asp:ListItem>
                                            <asp:ListItem Value="9" >HR Services</asp:ListItem>
                                            <asp:ListItem Value="10" >ICT</asp:ListItem>
                                            <asp:ListItem Value="11" >Ingredients</asp:ListItem>
                                            <asp:ListItem Value="12" >Marketing</asp:ListItem>
                                            <asp:ListItem Value="13" >Mining Equipment</asp:ListItem>
                                            <asp:ListItem Value="14" >MRO and Capex</asp:ListItem>
                                            <asp:ListItem Value="15" >Packaging</asp:ListItem>
                                            <asp:ListItem Value="16" >Professional Services</asp:ListItem>
                                            <asp:ListItem Value="17" >Raw Materials</asp:ListItem>
                                            <asp:ListItem Value="18" >Travel</asp:ListItem>
                                            <asp:ListItem Value="19" >Wardrobe & Workwear</asp:ListItem>
                                        </asp:DropDownList>
                                   
								</div>
                                <b>&nbsp;&nbsp;Spend under your influence</b><br>
								<div class="form-box1">
									<span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlAnnualRevenue" runat="server" cssclass="styled">
                                            <asp:ListItem Value="0" Selected="True">Spend under your influence </asp:ListItem>
                                            <asp:ListItem Value="1"  >$1 billion or more</asp:ListItem>
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
                                <b>&nbsp;&nbsp;Geographical influence</b><br>
								<div class="form-box1">
                                    <span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlGeographical" runat="server" cssclass="styled">
                                        <asp:ListItem Value="0" Selected="True">Geographical influence</asp:ListItem>
                                            <asp:ListItem Value="1">Local</asp:ListItem>
                                            <asp:ListItem Value="2">Regional</asp:ListItem>
                                            <asp:ListItem Value="3">Global</asp:ListItem>
                                    </asp:DropDownList>
								</div>
                                <b>&nbsp;&nbsp;Years of procurement experience</b><br>
								<div class="form-box1">
									<span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlProcurementYear" runat="server" cssclass="styled">
                                            <asp:ListItem Value="0" Selected="True">Years of procurement experience</asp:ListItem>
                                            <asp:ListItem Value="1">Less than 1 year</asp:ListItem>
                                            <asp:ListItem Value="3">1 - 3 years</asp:ListItem>
                                            <asp:ListItem Value="5">3 - 5 years</asp:ListItem>
                                            <asp:ListItem Value="10">5 - 10 years</asp:ListItem>
                                            <asp:ListItem Value="11">10 or more years</asp:ListItem>
                                            <asp:ListItem Value="12">Not applicable</asp:ListItem>
                                        </asp:DropDownList>
                                    
								</div>
                                <b>&nbsp;&nbsp;Procurement qualifications</b><br>
								<div class="form-box1">
                                    <span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="ddlProLevel" CssClass="styled" runat="server"
                                           >
                                            <asp:ListItem Value="0" Selected="True">Procurement qualifications</asp:ListItem>
                                            <asp:ListItem Value="1" >Undergraduate degree in procurement / supply chain </asp:ListItem>
                                            <asp:ListItem Value="2" >Postgraduate degree in procurement / supply chain </asp:ListItem>
                                            <asp:ListItem Value="3" >CIPS: Member (MCIPS)</asp:ListItem>
                                            <asp:ListItem Value="4" >CIPS: Fellow (FCIPS)</asp:ListItem>
                                            <asp:ListItem Value="5">AAPCM: Member </asp:ListItem>
                                            <asp:ListItem Value="6">AAPCM: Fellow </asp:ListItem>
                                            <asp:ListItem Value="7">Other </asp:ListItem>
                                             <asp:ListItem Value="8">Not applicable</asp:ListItem>
                                    </asp:DropDownList>
								</div>
                                <b>&nbsp;&nbsp;Level of education</b><br>
								<div class="form-box1">
                                    <span class="error"></span>&nbsp;&nbsp;<asp:DropDownList ID="cboQualifications" CssClass="styled" runat="server"
                                           >
                                            <asp:ListItem Value="0" Selected="True">Level of education</asp:ListItem>
                                            <asp:ListItem Value="1">Secondary school</asp:ListItem>
                                            <asp:ListItem Value="2">Certificate</asp:ListItem>
                                            <asp:ListItem Value="3" >Diploma</asp:ListItem>
                                            <asp:ListItem Value="4">Advanced Diploma</asp:ListItem>
                                            
                                            
                                            <asp:ListItem Value="5">Undergraduate</asp:ListItem>
                                            <asp:ListItem Value="6">Postgraduate</asp:ListItem>
                                            <asp:ListItem Value="7">Masters</asp:ListItem>
                                            <asp:ListItem Value="8">Doctorate</asp:ListItem>
                                        </asp:DropDownList>
									
								</div>
								<p>&nbsp;</p>
								<p class="txt18-bold">Your previous category experience</p>
                                <div class="form-list-lft">
									<div>
										<input type="checkbox" name="indirect" value="15"  class="styled" /> <b>Indirect</b> - General 
									</div>
								</div>
								<div class="form-list-rgt">
									<div style="position:relative">
										<input type="checkbox" name="direct" value="6" class="styled" /> <b>Directs</b> - General 
									</div>
								</div>
								<div class="clear"></div>
								
								<div class="form-list-lft">
									<div>
										<input type="checkbox" name="indirect" value="1"  class="styled" /> <b>IT&amp;T Services:</b> Software, Hardware, Telco, etc.
									</div>
									<div>
										<input type="checkbox" name="indirect" value="2"  class="styled" /> <b>Marketing Services:</b> ABT, BTL, Print, etc.
									</div>
									<div>
										<input type="checkbox" name="indirect" value="3"  class="styled" /> <b>HR Services:</b> Labour hire, Recruitment, Training, etc.
									</div>
                                    <div>
										<input type="checkbox" name="indirect" value="4"  class="styled" /> <b>Professional Services:</b> Legal, Audit & Accounting, Security, etc.
									</div>
									<div>
										<input type="checkbox" name="indirect" value="5"  class="styled" /> <b>Facilities</b> and Corporate Real Estate (FM/CRE) 
									</div>
									<div>
										<input type="checkbox" name="indirect" value="6"  class="styled" /> <b>Utilities:</b> Gas, Electricity, Water
									</div>
									<div>
										<input type="checkbox" name="indirect" value="7"  class="styled" /> <b>Capex:</b> Heavy machinery and equipment
									</div>
									<div>
										<input type="checkbox" name="indirect" value="8"  class="styled" /> <b>MRO</b> Maintenance, Repairs, Operations and Consumables
									</div>
									<div>
										<input type="checkbox" name="indirect" value="9"  class="styled" /> <b>Office:</b> Stationery, post, 
									</div>
                                    <div>
										<input type="checkbox" name="indirect" value="10"  class="styled" /> <b>Travel</b>
									</div>
									<div>
										<input type="checkbox" name="indirect" value="11" class="styled" /> <b>Fleet</b>
									</div>
									<div>
										<input type="checkbox" name="indirect" value="13"  class="styled" /> <b>Logistics</b>
									</div>
									<div>
										<input type="checkbox" name="indirect" value="14"  class="styled" /> <b>Other</b>
									</div>
								</div>
								<div class="form-list-rgt">
									<div>
										<input type="checkbox" name="direct" value="1"  class="styled" /> <b>Packaging:</b> PET, Glass, Print, Labels, etc. 
									</div>
									<div>
										<input type="checkbox" name="direct" value="2"  class="styled" /> <b>Ingredients</b>
									</div>
									<div>
										<input type="checkbox" name="direct" value="3"  class="styled" /> <b>Chemicals</b>
									</div>
									
									<div>
										<input type="checkbox" name="direct" value="4" class="styled" /> <b>Industry specific</b> production material
									</div>
                                    <div>
										<input type="checkbox" name="direct" value="5" class="styled" /> <b>Other</b>
									</div>
									
								</div>
								<div class="clear"></div>
								<p>&nbsp;</p>
								<p class="txtRgt"><input type="submit" id="submitbutton" value="BACK" class="btn-save"   /> 
                                <input type="submit" id="submitbuttonnext" value="NEXT" class="btn-next" /></p>
								<p>&nbsp;</p>
							</div>
						</article>
					</section>
					<div class="dot-line">&nbsp;</div>
				</article>
</asp:Content>

