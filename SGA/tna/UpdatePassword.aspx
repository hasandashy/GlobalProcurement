<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="SGA.tna.UpdatePassword" %>
<%@ Register TagName="header" TagPrefix="sga" Src="~/controls/ctrlHeader.ascx"   %>
<%@ Register TagName="footer" TagPrefix="sga" Src="~/controls/ctrlFooter.ascx"   %>
<!DOCTYPE HTML>
<html>
<head>
    <title>Update Password</title>
    <link href="../css/font-awesome.min.css" rel="stylesheet">
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/responsive.css" rel="stylesheet">
    <link href="../css/jquery.fancybox.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="../js/jquery-validate.js"></script>
</head>
<body>
    <div class="comman-page">
				<sga:header id="header1" runat="server"></sga:header>
				<!-- Header end // -->
    <form class="infusion-form-change" id="infusion-form-change">
        <span class="dotline top1 bdrt1"></span>

        <div class="container ">
            <div class="heading two-line  marT50 marB50">
                <h2><span>Update Password</span></h2>
                <span>Please choose your own password.</span>
            </div>
        </div>
        <!-- Content Area start // -->
        <div>

            <div class="faq-page">

                <div class="clear"></div>
                <div class="dot-line">&nbsp;</div>


                <!-- Banner end // -->
                <!-- Content Area start -->
                <div class="block1 greybg padtop-none full-graybg ">
                    <div class="container ">


                        <div class="info-block exchange1 ">
                            <div class="audit-form">

                                <div class="dis_block clearfix">
                                    <div class="form-group" style="text-align: center;">
                                        <asp:Label ID="lblErrorUpdate" ClientIDMode="Static" runat="server" ForeColor="Red"></asp:Label>
                                    </div>                                   
                                    <div class="form-group">
                                        <input required class="form-control" id="inf_field_NewPassword1" maxlength="250" name="inf_field_NewPassword1" type="password" placeholder="New Password *" />
                                    </div>
                                    <div class="form-group">
                                        <input class="form-control" id="inf_field_NewPassword2" maxlength="250" name="inf_field_NewPassword2" type="password" placeholder="Confirm Password *" />
                                    </div>



                                    <div class="form-group register-btn">
                                        <input type="submit" id="updatepassword" class="btn custom-btn" value="Go" />
                                    </div>
                                </div>
                            </div>



                        </div>


                    </div>



                </div>
                <!-- Content Area end // -->

                <div class="clear"></div>
                <div class="dot-line">&nbsp;</div>


            </div>
        </div>

    </form>
        <!-- Content Area end // -->
				<sga:footer id="footer" runat="server"></sga:footer>
			</div>
		<div id="outer-btm">&nbsp;</div>
    <script>
        
        jQuery(document).ready(function () {
            jQuery(document).on('click', '#updatepassword', function (e) {
                jQuery("#infusion-form-change").validate({
                    debug: true,
                    rules: {
                        inf_field_NewPassword1: "required",
                        inf_field_NewPassword2: { equalTo: "#inf_field_NewPassword1" }
                    },
                    messages: {
                        inf_field_NewPassword1: "Please enter your Password",
                        inf_field_NewPassword2: "Passwords do not match.",

                    },
                    submitHandler: function (form) {

                        //e.preventDefault();

                        jQuery.ajax({
                            crossDomain: true,
                            contentType: "application/json; charset=utf-8",
                            url: '../skillsservice.asmx/UpdateNewPassword',
                            dataType: "jsonp",
                            data: { 'password': $("#inf_field_NewPassword1").val() },
                            success: function (data) {
                                if (data == "s") {
                                    e.preventDefault();
                                    window.location.href = 'default.aspx';
                                }
                                else if (data == "f") {
                                    $('#lblErrorUpdate').text("Error While Updating Password.");
                                }
                            },

                            error: function (jqXHR, exception) {
                                var msg = '';
                                if (jqXHR.status === 0) {
                                    msg = 'Not connect.\n Verify Network.';
                                } else if (jqXHR.status == 404) {
                                    msg = 'Requested page not found. [404]';
                                } else if (jqXHR.status == 500) {
                                    msg = 'Internal Server Error [500].';
                                } else if (exception === 'parsererror') {
                                    msg = 'Requested JSON parse failed.';
                                } else if (exception === 'timeout') {
                                    msg = 'Time out error.';
                                } else if (exception === 'abort') {
                                    msg = 'Ajax request aborted.';
                                } else {
                                    msg = 'Uncaught Error.\n' + jqXHR.responseText;
                                }
                                alert(msg);
                            }
                        });
                    }

                });
            });
        });

    </script>
</body>
</html>
