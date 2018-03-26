<%@ Page Language="C#" MasterPageFile="~/tnaMaster.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="SGA.tna.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="../js/custom-form-elements.js"></script>
		
		<!-- Accordion Menu -->
		<script type="text/javascript" src="../js/jquery.min.js"></script>
		<!-- Popup -->
		<script type="text/javascript" src="../Scripts/jquery.colorbox.js"></script>
		<script type="text/javascript" src="../js/custom.js"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        var alertHtml = '';
        $('#share').colorbox({
            href: "../Popup.aspx",
            width: "392px",
            height: "200px",
            onComplete: function () {
                $('#alertMessage').text(alertHtml);
            }
        });

        $("#description").focus(function () {
            var value = $("#description").val();
            
            if (value == 'Description ...') {
                $("#description").val("");
            }
        });

        $('#share').click(function () {
            var error = 0;
            var emptyFields = new Array();
            var subject = $('#subject').val();
            if (subject == '' || subject == 'Subject ...') {
                error = 1;
                emptyFields.push('Subject');
            }
            var desc = $('#description').val();

            if (desc == '' || desc == 'Description ...') {
                error = 1;
                emptyFields.push('Description');
            }
            var help = $('#<%= ddlHelp.ClientID %>').val();
            if (help <= 0) {
                error = 1;
                emptyFields.push('Help type');
            }


            if (error) {
                $('#colorbox').css({ "display": "block" });

                alertHtml = 'Please enter/select ' + emptyFields.join(', ');
            }

            else {
                var json =
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "Help.aspx/SaveHelpInfo",
                            data: JSON.stringify({ 'subject': subject, 'description': desc, 'helpType': help }),
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.d == 's') {
                                    $('#colorbox').css({ "display": "block" });
                                    alertHtml = 'Thanks for your query, we will get back to you ASAP.';
                                    $('#subject').val('');
                                    $('#description').val('');

                                }
                            }
                        });
            }
        })
    });
</script>
<!-- Content Area start -->
				<article id="container">
					
					<div class="dot-line">&nbsp;</div>
					<section class="color-box">
						<article class="test-info-box">
							<p class="title orange">Help Section</p>
							<p>&nbsp;</p>
							<p><span class="dark">INSTRUCTIONS:</span> Fill in the form below and click 'submit'.  We will get back to you.</p>
						</article>
                        <article class="info-box-shdw-inner help">
							<div class="my-pofile-form">
								<p class="txt28 orange">Help is on its way!</p>
								<p>&nbsp;</p>
								<div class="form-box1">
									<input type="text" autocomplete="off" id="subject" name="subject" value="Subject ..." title="Subject ..." maxlength="500" class="text-box-2" />
								</div>
                                <div class="form-box1">
									<textarea cols="1" rows="10" id="description" name="description" class="text-box-2">Description ...</textarea>
								</div>
								<div class="form-box1">
									<asp:DropDownList ID="ddlHelp" runat="server" class="styled">
                                            <asp:ListItem Value="0" Selected="True">Nature of enquiry</asp:ListItem>
                                            <asp:ListItem Value="1"  >Technical support</asp:ListItem>
                                            <asp:ListItem Value="2">My results</asp:ListItem>
                                            <asp:ListItem Value="3">Assessment questions</asp:ListItem>
                                            <asp:ListItem Value="4">Other</asp:ListItem>
                                        </asp:DropDownList>
								</div>
                                <p class="txtRgt">
                                        <input id="share" class="btn-share cboxElement" type="submit" value="SUBMIT">
                                </p>
                            </div>
                            </article>
                            
					</section>
                </article>
<!-- Content Area end // -->
</asp:Content>